using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cursova4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent(); 
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FormOdejda formOdejda = new FormOdejda();
            formOdejda.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormKorobki formKorobki = new FormKorobki();
            formKorobki.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRazmerCvet formRazmerCvet = new FormRazmerCvet();
            formRazmerCvet.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormPostav formPostav = new FormPostav();
            formPostav.Show();
        }
    }
}
