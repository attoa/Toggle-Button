using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toggleButton1.Checked = checkBox1.Checked;
            toggleButton2.Checked = checkBox1.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            toggleButton1.Checked = checkBox1.Checked;
            toggleButton2.Checked = checkBox1.Checked;
        }

        private void toggleButton1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = toggleButton1.Checked;
        }

        private void toggleButton2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = toggleButton2.Checked;
        }
    }
}
