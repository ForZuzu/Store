using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

enum RowState
{
    Existed,
    New,
    Modified,
    ModifiedNew,
    Deleted
}
enum RowState1
{
    Existed,
    New,
    Modified,
    ModifiedNew,
    Deleted
}
namespace Cursova4
{
    public partial class Form1 : Form
    {
        DataBase dataBase = new DataBase();
        DataBase dataBase2 = new DataBase();


        int k = 0;
        int t = 0;
        int selectedRow;
        string Sort1 = "";
        string Sort4 = "";
        string Sort5 = "";

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns1()
        {
            dataGridView1.Columns.Add("1", "Код товара");
            dataGridView1.Columns.Add("2", "Бренд");
            dataGridView1.Columns.Add("3", "Цена");
            dataGridView1.Columns.Add("4", "Состав");
            dataGridView1.Columns.Add("5", "Тип одежды");
            dataGridView1.Columns.Add("6", "Код поставщика");
            dataGridView1.Columns.Add("7", "Наименование склада");
            dataGridView1.Columns.Add("IsNew", String.Empty);
            dataGridView1.Columns["IsNew"].Visible = false;
        }

        private void ReadSingleRow1(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetString(3), record.GetString(4), record.GetInt32(5), record.GetString(6), RowState.ModifiedNew);
        }

        private void RefreshDataGrid1(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"Select * From Одежда;";

            SqlCommand sqlCommand = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow1(dgw, reader);
            }

            reader.Close();
        }

        private void CreateColumns2()
        {
            dataGridView2.Columns.Add("1", "Код товара");
            dataGridView2.Columns.Add("2", "Размер");
            dataGridView2.Columns.Add("3", "Цвет");
            dataGridView2.Columns.Add("4", "Количество");
            dataGridView2.Columns.Add("IsNew", String.Empty);
            dataGridView2.Columns["IsNew"].Visible = false;
        }

        private void ReadSingleRow2(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2), record.GetInt32(3), RowState1.ModifiedNew);
        }

        private void RefreshDataGrid2(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"Select * From [Размер-Цвет];";

            SqlCommand sqlCommand = new SqlCommand(queryString, dataBase2.getConnection());

            dataBase2.openConnection();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow2(dgw, reader);
            }

            reader.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateColumns1();
            RefreshDataGrid1(dataGridView1);
            CreateColumns2();
            RefreshDataGrid2(dataGridView2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.BackColor = Color.Green;
            k++;
            Sort1 = "полиэстр";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (k == 1)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button10.Enabled = false;
                button15.Enabled = false;
                k = 0;
            }
            if (t == 1)
            {
                button12.Enabled = false;
                button11.Enabled = false;
                button9.Enabled = false;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gray;
            button2.BackColor = Color.Gray;
            button3.BackColor = Color.Gray;
            button6.BackColor = Color.Gray;
            button7.BackColor = Color.Gray;
            button8.BackColor = Color.Gray;
            button10.BackColor = Color.Gray;
            button15.BackColor = Color.Gray;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button10.Enabled = true;
            button14.Enabled = true;
            Sort1 = "";
            k = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button2.BackColor = Color.Green;
            k++;
            Sort1 = "деним";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button3.BackColor = Color.Green;
            k++;
            Sort1 = "жаккард";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button6.BackColor = Color.Green;
            k++;
            Sort1 = "кожа";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Enabled = false;
            button7.BackColor = Color.Green;
            k++;
            Sort1 = "хлопок";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            button8.BackColor = Color.Green;
            k++;
            Sort1 = "каучук";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button10.Enabled = false;
            button10.BackColor = Color.Green;
            k++;
            Sort1 = "вискоза";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            button15.Enabled = false;
            button15.BackColor = Color.Green;
            k++;
            Sort1 = "шерсть";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            t++;
            button12.Enabled = false;
            button12.BackColor = Color.Green;
            if (Sort4 == "")
            {
                Sort4 = "черный";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            t++;
            button11.Enabled = false;
            button11.BackColor = Color.Green;
            if (Sort4 == "")
            {
                Sort4 = "белый";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            t++;
            button9.Enabled = false;
            button9.BackColor = Color.Green;
            if (Sort4 == "")
            {
                Sort4 = "красный";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            button9.BackColor = Color.Gray;
            button12.BackColor = Color.Gray;
            button11.BackColor = Color.Gray;
            button9.Enabled = true;
            button12.Enabled = true;
            button11.Enabled = true;
            Sort4 = "";
            t = 0;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Sort5 = comboBox1.Text;
            if (Sort1 != "" && Sort4 != "" && Sort5 != "")
            {
                Sorting1(dataGridView1);
            }
            if (Sort1 != "" && Sort4 != "" && Sort5 == "")
            {
                Sorting2(dataGridView1);
            }
            if (Sort1 != "" && Sort4 == "" && Sort5 != "")
            {
                Sorting3(dataGridView1);
            }
            if (Sort1 != "" && Sort4 == "" && Sort5 == "")
            {
                Sorting4(dataGridView1);
            }
            if (Sort1 == "" && Sort4 != "" && Sort5 != "")
            {
                Sorting5(dataGridView1);
            }
            if (Sort1 == "" && Sort4 == "" && Sort5 != "")
            {
                Sorting6(dataGridView1);
            }
            if (Sort1 == "" && Sort4 != "" && Sort5 == "")
            {
                Sorting7(dataGridView1);
            }
        }

        private void Sorting1(DataGridView dgw)
        {
            dgw.Rows.Clear();
            MessageBox.Show(Sort1);
            string queryString = $"Select * From [Одежда] Where [Код товара] IN (Select [Код товара] From [Размер-Цвет] Where [Цвет] = '{Sort4}') And [Состав] = '{Sort1}' And [Тип одежды] = '{Sort5}';";
            string queryString2 = $"Select * From [Размер-Цвет] Where [Цвет] = '{Sort4}' And [Код товара] IN (Select [Код товара] From [Одежда] Where [Тип одежды] = '{Sort5}') And [Код товара] IN (Select [Код товара] From [Одежда] Where [Состав] = '{Sort1}');";


            SqlCommand sqlCommand = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow1(dgw, reader);
            }

            reader.Close();
            SqlCommand sqlCommand2 = new SqlCommand(queryString2, dataBase.getConnection());

            dataGridView2.Rows.Clear();

            SqlDataReader reader2 = sqlCommand2.ExecuteReader();

            while (reader2.Read())
            {
                ReadSingleRow2(dataGridView2, reader2);
            }

            reader2.Close();
        }

        private void Sorting2(DataGridView dgw)
        {
            dgw.Rows.Clear();
            MessageBox.Show(Sort1);
            string queryString = $"Select * From [Одежда] Where [Код товара] IN (Select [Код товара] From [Размер-Цвет] Where [Цвет] = '{Sort4}') And [Состав] = '{Sort1}';";
            string queryString2 = $"Select * From [Размер-Цвет] Where [Цвет] = '{Sort4}' And [Код товара] IN (Select [Код товара] From [Одежда] Where [Состав] = '{Sort1}');";


            SqlCommand sqlCommand = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow1(dgw, reader);
            }

            reader.Close();
            SqlCommand sqlCommand2 = new SqlCommand(queryString2, dataBase.getConnection());

            dataGridView2.Rows.Clear();

            SqlDataReader reader2 = sqlCommand2.ExecuteReader();

            while (reader2.Read())
            {
                ReadSingleRow2(dataGridView2, reader2);
            }

            reader2.Close();
        }

        private void Sorting3(DataGridView dgw)
        {
            dgw.Rows.Clear();
            MessageBox.Show(Sort1);
            string queryString = $"Select * From [Одежда] Where [Состав] = '{Sort1}' And [Тип одежды] = '{Sort5}';";
            string queryString2 = $"Select * From [Размер-Цвет] Where [Код товара] IN (Select [Код товара] From [Одежда] Where [Тип одежды] = '{Sort5}') And [Код товара] IN (Select [Код товара] From [Одежда] Where [Состав] = '{Sort1}');";

            SqlCommand sqlCommand = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow1(dgw, reader);
            }

            reader.Close();
            SqlCommand sqlCommand2 = new SqlCommand(queryString2, dataBase.getConnection());

            dataGridView2.Rows.Clear();

            SqlDataReader reader2 = sqlCommand2.ExecuteReader();

            while (reader2.Read())
            {
                ReadSingleRow2(dataGridView2, reader2);
            }

            reader2.Close();
        }

        private void Sorting4(DataGridView dgw)
        {
            dgw.Rows.Clear();
            MessageBox.Show(Sort1);
            string queryString = $"Select * From [Одежда] Where [Состав] = '{Sort1}';";
            string queryString2 = $"Select * From [Размер-Цвет] Where [Код товара] IN (Select [Код товара] From [Одежда] Where [Состав] = '{Sort1}');";

            SqlCommand sqlCommand = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow1(dgw, reader);
            }

            reader.Close();
            SqlCommand sqlCommand2 = new SqlCommand(queryString2, dataBase.getConnection());

            dataGridView2.Rows.Clear();

            SqlDataReader reader2 = sqlCommand2.ExecuteReader();

            while (reader2.Read())
            {
                ReadSingleRow2(dataGridView2, reader2);
            }

            reader2.Close();
        }

        private void Sorting5(DataGridView dgw)
        {
            dgw.Rows.Clear();
            MessageBox.Show(Sort1);
            string queryString = $"Select * From [Одежда] Where [Код товара] IN (Select [Код товара] From [Размер-Цвет] Where [Цвет] = '{Sort4}') And [Тип одежды] = '{Sort5}';";
            string queryString2 = $"Select * From [Размер-Цвет] Where [Цвет] = '{Sort4}' And [Код товара] IN (Select [Код товара] From [Одежда] Where [Тип одежды] = '{Sort5}');";


            SqlCommand sqlCommand = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow1(dgw, reader);
            }

            reader.Close();
            SqlCommand sqlCommand2 = new SqlCommand(queryString2, dataBase.getConnection());

            dataGridView2.Rows.Clear();

            SqlDataReader reader2 = sqlCommand2.ExecuteReader();

            while (reader2.Read())
            {
                ReadSingleRow2(dataGridView2, reader2);
            }

            reader2.Close();
        }

        private void Sorting6(DataGridView dgw)
        {
            dgw.Rows.Clear();
            MessageBox.Show(Sort1);
            string queryString = $"Select * From [Одежда] Where [Тип одежды] = '{Sort5}';";
            string queryString2 = $"Select * From [Размер-Цвет] Where [Код товара] IN (Select [Код товара] From [Одежда] Where [Тип одежды] = '{Sort5}');";


            SqlCommand sqlCommand = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow1(dgw, reader);
            }

            reader.Close();
            SqlCommand sqlCommand2 = new SqlCommand(queryString2, dataBase.getConnection());

            dataGridView2.Rows.Clear();

            SqlDataReader reader2 = sqlCommand2.ExecuteReader();

            while (reader2.Read())
            {
                ReadSingleRow2(dataGridView2, reader2);
            }

            reader2.Close();
        }

        private void Sorting7(DataGridView dgw)
        {
            dgw.Rows.Clear();
            MessageBox.Show(Sort1);
            string queryString = $"Select * From [Одежда] Where [Код товара] IN (Select [Код товара] From [Размер-Цвет] Where [Цвет] = '{Sort4}');";
            string queryString2 = $"Select * From [Размер-Цвет] Where [Цвет] = '{Sort4}';";


            SqlCommand sqlCommand = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow1(dgw, reader);
            }

            reader.Close();
            SqlCommand sqlCommand2 = new SqlCommand(queryString2, dataBase.getConnection());

            dataGridView2.Rows.Clear();

            SqlDataReader reader2 = sqlCommand2.ExecuteReader();

            while (reader2.Read())
            {
                ReadSingleRow2(dataGridView2, reader2);
            }

            reader2.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            RefreshDataGrid1(dataGridView1);
            RefreshDataGrid2(dataGridView2);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            var kol = textBox9.Text;
            var query = $"EXECUTE P1 '{kol}';";
            var command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConnection();
            command.ExecuteNonQuery();
            MessageBox.Show("Процедура выполнена!");
            dataBase.closeConnection();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            var kol = textBox9.Text;
            var query = $"EXECUTE P2 '{kol}';";
            var command = new SqlCommand(query, dataBase.getConnection());
            dataBase.openConnection();
            command.ExecuteNonQuery();
            MessageBox.Show("Процедура выполнена!");
            dataBase.closeConnection();
        }
    }
}
