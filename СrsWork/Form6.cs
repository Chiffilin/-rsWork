using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СrsWork
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "12345")
            {
                this.DialogResult = DialogResult.OK;

            }
            else
            {
                MessageBox.Show("Неверный пароль");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
