using System.Windows.Forms;

namespace PassDataBetweenForms4
{
    public partial class Form1 : Form
    {
        public delegate void PassDataDelegate(TextBox textBox);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var form2 = new Form2();

            var passDataDelegate = new PassDataDelegate(form2.GetTheTextBoxData);

            passDataDelegate(textBox1);

            form2.Show();
        }
    }
}
