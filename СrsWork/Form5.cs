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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кнопка отвечает за добавление инвестора в таблицу. ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кнопка отвечает за удаление выделенного инвестора в таблице. ");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кнопка отвечает за поиск по ФИО инвестора, введенного в поле слева от кнопки Поиск.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кнопка отвечает за поиск и удаление по ФИО инвестора, введенного в поле слева от кнопки Удалить.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кнопка отвечает за поиск по вкладу инвестора, введенного в поле слева от кнопки Поиск по вкладу.");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кнопка отвечает за поиск по сроку вклада инвестора, введенного в поле слева от кнопки Поиск по сроку.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кнопка отвечает за редактирование выделенного инвестора в таблице.");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
