using System;
using System.Windows.Forms;

namespace PassDataBetweenForms2
{
    public partial class Form1 : Form
    {
        public TextBox textBox1;
        public Form1()
        {
            InitializeComponent();
        }               

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2
            {
                frm1 = this
            };

            frm2.Show();
        }
    }
}
