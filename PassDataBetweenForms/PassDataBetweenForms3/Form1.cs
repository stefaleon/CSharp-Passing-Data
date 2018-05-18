using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassDataBetweenForms3
{
    public partial class Form1 : Form
    {
        public string textBox1Text
        {
            get
            {
                return textBox1.Text;
            }
               
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();

            frm2.label1Text = textBox1Text;

            frm2.Show();
        }
    }
}
