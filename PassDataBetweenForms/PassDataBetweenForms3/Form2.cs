using System.Windows.Forms;

namespace PassDataBetweenForms3
{
    public partial class Form2 : Form
    {
        public string label1Text
        {
            set
            {
                label1.Text = value;
            }
        }

        public Form2()
        {
            InitializeComponent();
        }
    }
}
