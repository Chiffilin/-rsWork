using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СrsWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //создадим таблицу вывода инвесторами с колонками 
            //ФИО / Номер договора / Адрес / Сумма вклада / Срок договора

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "ФИО"; //текст в шапке
            column1.Width = 100; //ширина колонки
            column1.ReadOnly = true; //значение в этой колонке нельзя править
            column1.Name = "name"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column1.Frozen = true; //флаг, что данная колонка всегда отображается на своем месте
            column1.CellTemplate = new DataGridViewTextBoxCell(); //тип  колонки

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Номер договора";
            column2.Name = "number";
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Aдрес";
            column3.Name = "addres";
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Сумма вклада";
            column4.Name = "cash";
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Срок договора";
            column5.Name = "contract";
            column5.CellTemplate = new DataGridViewTextBoxCell();


            dataGridView1.Columns.Add(column1);     // Добавление колонки "ФИО"
            dataGridView1.Columns.Add(column2);     // Добавление колонки "Номер договора"
            dataGridView1.Columns.Add(column3);     // Добавление колонки "Адрес"
            dataGridView1.Columns.Add(column4);     // Добавление колонки "Сумма вклада"
            dataGridView1.Columns.Add(column5);     // Добавление колонки "Срок договора"

            dataGridView1.AllowUserToAddRows = false; //запрешаем пользователю самому добавлять строки
            dataGridView1.ReadOnly = true;

            
          
            //А теперь простой пройдемся циклом по всем ячейкам
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; ++j)
                {
                    //Значения ячеек хряняться в типе object
                    //это позволяет хранить любые данные в таблице
                    object o = dataGridView1[j, i].Value;
                }
            }
            dataGridView1.Rows.Clear();
            

        }

        private void button1_Click(object sender, EventArgs e) // Кнопка "Добавить"
        {
            Form2 f = new Form2();
            if (f.ShowDialog() == DialogResult.OK)
            {

                dataGridView1["name", dataGridView1.Rows.Count - 1].Value = f.textBox1.Text;// Занесение данных "ФИО" в строку (первый столбец)
                
                for (int j = 0; j < dataGridView1.Rows.Count; j++)// Цикл нумерации договора (второй столбец ) 
                {
                    dataGridView1.Rows[j].Cells[1].Value = j + 1;
                    
                }
                dataGridView1["addres", dataGridView1.Rows.Count - 1].Value = f.textBox3.Text;// Занесение данных "Адрес" в строку (третий столбец)
                dataGridView1["cash", dataGridView1.Rows.Count - 1].Value = f.textBox4.Text;// Занесение данных "Сумма вклада" в строку (четверный столбец)
                dataGridView1["contract", dataGridView1.Rows.Count - 1].Value = f.textBox5.Text;// Занесение данных "Срок договора" в строку (пятый столбец)
                dataGridView1.Rows.Add();//Добавление строки
            }
        }

        private void button2_Click(object sender, EventArgs e)// Кнопка "Удалить"(выбранную строку)    
        {
            int index, n;
            n = dataGridView1.Rows.Count;
            if (n == 1) return;
            Form3 f = new Form3();
            index = dataGridView1.CurrentRow.Index;
            Name = Convert.ToString(dataGridView1[0, index].Value);
            f.label2.Text = Name;
            if (f.ShowDialog() == DialogResult.OK) // Вывод формы, после нажатия кнопки "ОК" происходит удаление выделенной строки
            {
                dataGridView1.Rows.RemoveAt(index); // Удаление строки
            }
        }

        private void button3_Click(object sender, EventArgs e)//Кнопка "Редактировать"
        {
            int index, n;
            string Name, Number, Addres, Cash, Contract;
            n = dataGridView1.Rows.Count;// проверка, есть ли вообще записи в таблице 
            if (n == 1) return;
            Form4 f = new Form4();// заполнить форму данными перед открытием
            index = dataGridView1.CurrentRow.Index;
            Name = dataGridView1[0, index].Value.ToString();
            Number = dataGridView1[1, index].Value.ToString();
            Addres = dataGridView1[2, index].Value.ToString();
            Cash = dataGridView1[3, index].Value.ToString();
            Contract = dataGridView1[4, index].Value.ToString();

            f.textBox1.Text = Name;
            f.textBox3.Text = Addres;
            f.textBox4.Text = Cash;
            f.textBox5.Text = Contract;
            if (f.ShowDialog() == DialogResult.OK) // Вывод формы, после нажатия кнопки "ОК" происходит редактирование выделенной строки
            {
                Name = f.textBox1.Text; // Заполнение данных в "textBox1" переменной Name
                Addres = f.textBox3.Text;// Заполнение данных в "textBox3" переменной Addres
                Cash = f.textBox4.Text;// Заполнение данных в "textBox4" переменной Cash
                Contract = f.textBox5.Text;// Заполнение данных в "textBox5" переменной Contract

                dataGridView1.Rows.RemoveAt(index);
                dataGridView1["name", dataGridView1.Rows.Count - 1].Value = Name;// Занесение данных "ФИО" в строку (первый столбец)
                dataGridView1["number", dataGridView1.Rows.Count - 1].Value = Number;// Занесение данных "Номер контракта" в строку (второй столбец) 
                dataGridView1["addres", dataGridView1.Rows.Count - 1].Value = Addres;// Занесение данных "Адрес" в строку (третий столбец)
                dataGridView1["cash", dataGridView1.Rows.Count - 1].Value = Cash;// Занесение данных "Сумма вклада" в строку (четверный столбец)
                dataGridView1["contract", dataGridView1.Rows.Count - 1].Value = Contract;// Занесение данных "Срок договора" в строку (пятый столбец)
                dataGridView1.Rows.Add();//Добавление строки
            }
        }

        private void button4_Click(object sender, EventArgs e)// Кнопка "Удалить" 
        {
            if (textBox1.Text != "")// Проверка на заполнения поля "Text" в textBox1
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)//Цикл поиск по ФИО в первом столбце и выделение данных строк
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        if (dataGridView1.Rows[i].Cells[0].Value != null)
                            if (dataGridView1.Rows[i].Cells[0].Value.ToString().Contains(textBox1.Text))
                            {
                                dataGridView1.Rows[i].Selected = true;
                                int delet = dataGridView1.SelectedCells[0].RowIndex;
                                dataGridView1.Rows.RemoveAt(delet); // Удаление всех выделенных строк
                                break;
                            }
                }
            }
            


        }
        private void button5_Click(object sender, EventArgs e)
        {
           
            if (textBox2.Text != "")// Проверка на заполнения поля "Text" в textBox2
            {

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)// Цикл поиска данных  из "textBox2"  по первому столбцу
                {
                    dataGridView1.Rows[i].Visible = dataGridView1[0, i].Value.ToString() == textBox2.Text;
                }
                             
                
            }
            else // Если после "Text" пустое, то все ячейки таблицы снова видно
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Visible = true;
                }
            }
           
            
        }
        private void button6_Click(object sender, EventArgs e)// Кнопка "Поиск по вкладу"
        {
            if (textBox3.Text != "")// Проверка на заполнения поля "Text" в textBox3
            {

               for (int i = 0; i < dataGridView1.Rows.Count - 5; i++)// Цикл поиска данных  из "textBox3" по заданной сумме вклада
                {
                    dataGridView1.Rows[i].Visible = dataGridView1[3, i].Value.ToString() == textBox3.Text;
                }

            }
            else // Если после "Text" пустое, то все ячейки таблицы снова видно
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Visible = true;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)// Кнопка "Поиск по сроку"
        {
            if (textBox4.Text != "")// Проверка на заполнения поля "Text" в textBox4
            {

                for (int i = 0; i < dataGridView1.Rows.Count - 5; i++)// Цикл поиска данных  из "textBox4" по сроку вклада
                {
                    dataGridView1.Rows[i].Visible = dataGridView1[4, i].Value.ToString() == textBox4.Text;
                }

            }
            else // Если после "Text" пустое, то все ячейки таблицы снова видно
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Visible = true;
                }
            }
        }
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string file = "D:\\mygrid.bin";
            using (BinaryWriter bw = new BinaryWriter(File.Open(file, FileMode.Create)))
            {
                
                bw.Write(dataGridView1.Columns.Count);
                bw.Write(dataGridView1.Rows.Count);
                foreach (DataGridViewRow dgvR in dataGridView1.Rows)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; ++j)
                    {
                        object val = dgvR.Cells[j].Value;
                        if (val == null)
                        {
                            bw.Write(false);
                            bw.Write(false);
                        }
                        else
                        {
                            bw.Write(true);
                            bw.Write(val.ToString());
                        }
                    }
               
                }


             }
    }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string file = "D:\\mygrid.bin";
            using (BinaryReader bw = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                int n = bw.ReadInt32();
                int m = bw.ReadInt32();
                for (int i = 0; i < m; ++i)
                {
                    dataGridView1.Rows.Add();
                    for (int j = 0; j < n; ++j)
                    {
                        if (bw.ReadBoolean())
                        {
                            dataGridView1.Rows[i].Cells[j].Value = bw.ReadString();
                        }
                        else bw.ReadBoolean();
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tb = (TextBox)sender;
            if (e.KeyChar.Equals('\b')) return;

            e.Handled = tb.SelectionStart == 0 || tb.Text[tb.SelectionStart - 1].Equals('-');
            if (!e.Handled)
            {
                return;
            }

            //Разрешаем только цифры
            e.Handled = !char.IsNumber(e.KeyChar);
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

            //Разрешаем только цифры

            e.Handled = !char.IsNumber(e.KeyChar);
        }
    }   
}


