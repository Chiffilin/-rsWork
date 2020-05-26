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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tb = (TextBox)sender;
            if (e.KeyChar.Equals('\b')) return;

            e.Handled = tb.SelectionStart == 0 || tb.Text[tb.SelectionStart - 1].Equals('-');
            if (!e.Handled)
            {
                return;
            }

            //Разрешаем только буквы
            e.Handled = !char.IsNumber(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tb = (TextBox)sender;
            if (e.KeyChar.Equals('\b')) return;

            e.Handled = tb.SelectionStart == 0 || tb.Text[tb.SelectionStart - 1].Equals('-');
            if (!e.Handled)
            {
                return;
            }

            //Разрешаем только буквы
            e.Handled = !char.IsNumber(e.KeyChar);
        }
    }
}
