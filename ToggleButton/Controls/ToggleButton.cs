using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace ToggleButtons
{
    public class ToggleButton : Control
    {
        #region Переменные

        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Фоновая основа компонента
        /// </summary>
        private Rectangle backRect;

        /// <summary>
        /// Внутренний переключатель
        /// </summary>
        private Rectangle togglerRect;

        /// <summary>
        /// Цвет обводки фона текущий
        /// </summary>
        private Color backBorderColor;

        /// <summary>
        /// Цвет переключателя текущий
        /// </summary>
        private Color togglerColor;

        /// <summary>
        /// Цвет обводки переключателя текущий
        /// </summary>
        private Color togglerBorderColor;


        private Color _backOffColor = Color.White;
        private Color _backOnColor = SystemColors.Highlight;
        private Color _backBorderOffColor = Color.Gray;
        private Color _backBorderOnColor = Color.Gray;
        private int _backBorderWidth = 1;

        private Color _togglerOffColor = Color.White;
        private Color _togglerOnColor = Color.White;
        private Color _togglerBorderOffColor = SystemColors.Highlight;
        private Color _togglerBorderOnColor = Color.White;
        private int _togglerBorderWidth = 2;

        private int _borderRadius = 10;
        private int _gap = 3;
        private bool _checked = true;

        #endregion


        #region Свойства

        [Browsable(false)]
        public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }


        [Category("Appearance")]
        [Description("Цвет фона в выключенном положении")]
        public Color BackOffColor
        {
            get => _backOffColor;
            set
            {
                _backOffColor = value;
                UpdateColors();
            }
        }

        [Category("Appearance")]
        [Description("Цвет фона во включенном положении")]
        public Color BackOnColor
        {
            get => _backOnColor;
            set
            {
                _backOnColor = value;
                UpdateColors();
            }
        }

        [Category("Appearance")]
        [Description("Цвет обводки фона в выключенном положении")]
        public Color BackBorderOffColor
        {
            get => _backBorderOffColor;
            set
            {
                _backBorderOffColor = value;
                UpdateColors();
            }
        }

        [Category("Appearance")]
        [Description("Цвет обводки фона во включенном положении")]
        public Color BackBorderOnColor
        {
            get => _backBorderOnColor;
            set
            {
                _backBorderOnColor = value;
                UpdateColors();
            }
        }

        [Category("Appearance")]
        [Description("Толщина обводки фона")]
        public int BackBorderWidth
        {
            get => _backBorderWidth;
            set
            {
                if (value > 0)
                {
                    _backBorderWidth = value;
                    Invalidate();
                }
            }
        }

        
        [Category("Appearance")]
        [Description("Цвет переключателя в выключенном положении")]
        public Color TogglerOffColor
        {
            get => _togglerOffColor;
            set
            {
                _togglerOffColor = value;
                UpdateColors();
            }
        }
        
        [Category("Appearance")]
        [Description("Цвет переключателя во включенном положении")]
        public Color TogglerOnColor
        {
            get => _togglerOnColor;
            set
            {
                _togglerOnColor = value;
                UpdateColors();
            }
        }
        
        [Category("Appearance")]
        [Description("Цвет обводки переключателя в выключенном положении")]
        public Color TogglerBorderOffColor
        {
            get => _togglerBorderOffColor;
            set
            {
                _togglerBorderOffColor = value;
                UpdateColors();
            }
        }

        [Category("Appearance")]
        [Description("Цвет обводки переключателя во включенном положении")]
        public Color TogglerBorderOnColor
        {
            get => _togglerBorderOnColor;
            set
            {
                _togglerBorderOnColor = value;
                UpdateColors();
            }
        }
        
        [Category("Appearance")]
        [Description("Толщина обводки переключателя")]
        public int TogglerBorderWidth
        {
            get => _togglerBorderWidth;
            set
            {
                if (value > 0)
                {
                    _togglerBorderWidth = value;
                    Invalidate();
                }
            }
        }


        [Category("Appearance")]
        [Description("Радиус скругления углов фона")]
        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                if (value > 0)
                {
                    _borderRadius = value;
                    Invalidate();
                }
            }
        }

        [Category("Appearance")]
        [Description("Отступ между переключателем и границами фона")]
        public int Gap
        {
            get => _gap;
            set
            {
                if (value >= 0)
                {
                    _gap = value;
                    CreateRectangles();
                    UpdateColors();
                }
            }
        }

        [Category("Appearance")]
        [Description("Находится ли переключатель во включенном положении")]
        public bool Checked
        {
            get => _checked;
            set
            {
                _checked = value;
                CreateRectangles();
                UpdateColors();
            }
        }

        #endregion

        public ToggleButton()
        {
            InitializeComponent();

            // Настройка оптимизации компонента
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Size = new Size(45, 25);

            Font = new Font("Verdana", 9f, FontStyle.Regular);

            Cursor = Cursors.Hand;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

            this.Click += new System.EventHandler(this.ToggleButton_Click);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            CreateRectangles();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            CreateRectangles();
            UpdateColors();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Настройка холста
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Parent.BackColor);

            // Скругленные прямоугольники
            GraphicsPath backRectGP = RoundedRectangle(backRect, BorderRadius);
            GraphicsPath togglerRectGP = RoundedRectangle(togglerRect, BorderRadius - Gap);

            // Кисти
            Pen backPen = new Pen(backBorderColor, BackBorderWidth);
            Pen togglerPen = new Pen(togglerBorderColor, TogglerBorderWidth);

            // Отрисовка
            g.DrawPath(backPen, backRectGP);
            g.FillPath(new SolidBrush(BackColor), backRectGP);
            g.DrawPath(togglerPen, togglerRectGP);
            g.FillPath(new SolidBrush(togglerColor), togglerRectGP);
        }

        /// <summary>
        /// Возвращает прямоугольник со скругленными углами
        /// </summary>
        /// <param name="rect">Прямоугольник</param>
        /// <param name="radius">Радиус скругления</param>
        /// <returns>Прямоугольник со скругленными углами</returns>
        private GraphicsPath RoundedRectangle(Rectangle rect, int radius)
        {
            if (radius < 1) radius = 1;

            GraphicsPath gp = new GraphicsPath();

            gp.AddArc(rect.X, rect.Y, radius, radius, 180, 90);                         // Левый верхний угол
            gp.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);   // Правый верхний угол
            gp.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);  // Правый нижний угол
            gp.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);   // Левый нижний угол

            gp.CloseFigure();

            return gp;
        }

        /// <summary>
        /// Создает прямоугольники в соответствии с текущими размерами
        /// </summary>
        private void CreateRectangles()
        {
            backRect = new Rectangle(BackBorderWidth, BackBorderWidth, Width - BackBorderWidth * 2, Height - BackBorderWidth * 2);

            int gap = Gap + BackBorderWidth;
            int togglerX = Checked ? Width - Height + gap : gap;

            togglerRect = new Rectangle(togglerX, gap, Height - gap * 2, Height - gap * 2);
        }

        /// <summary>
        /// Обновляет цвета компонента
        /// </summary>
        private void UpdateColors()
        {
            if (Checked)
            {
                BackColor = BackOnColor;
                backBorderColor = BackBorderOnColor;

                togglerColor = TogglerOnColor;
                togglerBorderColor = TogglerBorderOnColor;
            }
            else
            {
                BackColor = BackOffColor;
                backBorderColor = BackBorderOffColor;

                togglerColor = TogglerOffColor;
                togglerBorderColor = TogglerBorderOffColor;
            }

            Invalidate();
        }

        private void ToggleButton_Click(object sender, EventArgs e)
        {
            Checked = !Checked;
        }
    }
}
