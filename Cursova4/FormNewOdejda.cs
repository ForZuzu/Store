using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cursova4
{
    public partial class FormNewOdejda : Form
    {
        DataBase dataBase = new DataBase();
        public FormNewOdejda()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            var id1 = textBox1.Text;
            var id2 = textBox2.Text;
            var id3 = textBox3.Text;
            var id4 = textBox4.Text;
            var id5 = textBox7.Text;
            var id6 = textBox6.Text;
            var id7 = textBox5.Text;

            var addQuery = $"Insert into [Одежда] ([Код товара], Бренд, Цена, Состав, [Тип одежды], [Код поставщика], [Наименование склада]) values ('{id1}', '{id2}', '{id3}', '{id4}', '{id5}', '{id6}', '{id7}');";

            var command = new SqlCommand(addQuery, dataBase.getConnection());
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно создана!");
            }
            catch
            {
                MessageBox.Show("Ошибка! Возможно вы ввели что-то неправильно!");
            }
            dataBase.closeConnection();
        }
    }
}
