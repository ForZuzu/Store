using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

enum RowState3
{
    A,
    Existed,
    New,
    Modified,
    ModifiedNew,
    Deleted
}

namespace Cursova4
{
    public partial class FormKorobki : Form
    {
        DataBase dataBase = new DataBase();
        int selectedRow;
        public FormKorobki()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns1()
        {
            dataGridView1.Columns.Add("1", "Код коробки");
            dataGridView1.Columns.Add("2", "Код товара");
            dataGridView1.Columns.Add("3", "Код поставки");
            dataGridView1.Columns.Add("4", "Код поставщика");
            dataGridView1.Columns.Add("5", "Название товара");
            dataGridView1.Columns.Add("6", "Количество");
            dataGridView1.Columns.Add("7", "Цена за единицу");
            dataGridView1.Columns.Add("IsNew", String.Empty);
            dataGridView1.Columns["IsNew"].Visible = false;
        }

        private void ReadSingleRow1(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), record.GetInt32(3), record.GetString(4), record.GetString(5), record.GetInt32(6), RowState3.ModifiedNew);
        }

        private void RefreshDataGrid1(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"Select * From Коробка;";

            SqlCommand sqlCommand = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow1(dgw, reader);
            }

            reader.Close();
        }

        private void FormKorobki_Load(object sender, EventArgs e)
        {
            CreateColumns1();
            RefreshDataGrid1(dataGridView1);
        }

        private void ClearFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox7.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
                textBox5.Text = row.Cells[6].Value.ToString();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RefreshDataGrid1(dataGridView1);
        }

        private void SearchBox(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string query = $"Select * from [Коробка] Where concat ([Код коробки], [Код товара], [Код поставки], [Код поставщика], [Наименование товара], Количество, [Цена за единицу]) like '%" + textBox9.Text + "%'";

            SqlCommand sqlCommand = new SqlCommand(query, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow1(dgw, reader);
            }

            reader.Close();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            SearchBox(dataGridView1);
        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[7].Value = RowState3.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[7].Value = RowState3.Deleted;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            deleteRow();
        }

        private void ChangeRow()
        {
            var SelectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id1 = textBox1.Text;
            var id2 = textBox2.Text;
            var id3 = textBox3.Text;
            var id4 = textBox4.Text;
            var id5 = textBox7.Text;
            var id6 = textBox6.Text;
            var id7 = textBox5.Text;


            if (dataGridView1.Rows[SelectedRowIndex].Cells[0].Value.ToString() != String.Empty)
            {
                dataGridView1.Rows[SelectedRowIndex].SetValues(id1, id2, id3, id4, id5, id6, id7);
                dataGridView1.Rows[SelectedRowIndex].Cells[7].Value = RowState3.Modified;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeRow();
        }

        private void updateRows()
        {

            dataBase.openConnection();
            for (int ind = 0; ind < dataGridView1.Rows.Count; ind++)
            {
                Debug.WriteLine(ind);
                var rowState = RowState3.A;

                try
                {
                    rowState = (RowState3)dataGridView1.Rows[ind].Cells[7].Value;
                }
                catch
                {

                }

                if (rowState == RowState3.Existed)
                {
                    MessageBox.Show("Ничего не происходит");
                    continue;
                }

                if (rowState == RowState3.Deleted)
                {
                    MessageBox.Show("Изменения сохранены!");
                    var id = Convert.ToInt32(dataGridView1.Rows[ind].Cells[0].Value);
                    var deleteQuery = $"Delete from [Коробка] Where [Код коробки] = '{id}';";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState3.Modified)
                {
                    MessageBox.Show("Изменения сохранены!");
                    var id1 = dataGridView1.Rows[ind].Cells[0].Value.ToString();
                    var id2 = dataGridView1.Rows[ind].Cells[1].Value.ToString();
                    var id3 = dataGridView1.Rows[ind].Cells[2].Value.ToString();
                    var id4 = dataGridView1.Rows[ind].Cells[3].Value.ToString();
                    var id5 = dataGridView1.Rows[ind].Cells[4].Value.ToString();
                    var id6 = dataGridView1.Rows[ind].Cells[5].Value.ToString();
                    var id7 = dataGridView1.Rows[ind].Cells[6].Value.ToString();

                    var changeQuery = $"Update [Коробка] Set [Код коробки] = '{id1}', [Код товара] = '{id2}', [Код поставки] = '{id3}', [Код поставщика] = '{id4}', [Наименование товара] = '{id5}', Количество = '{id6}', [Цена за единицу] = '{id7}' Where [Код коробки] = '{id1}'";

                    var command = new SqlCommand(changeQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateRows();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FormNewKorobki formNewKorobki = new FormNewKorobki();
            formNewKorobki.Show();
        }
    }
}
