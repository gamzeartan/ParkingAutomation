using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlakaTanima
{
    public partial class frmAdminGiris : Form
    {
        public frmAdminGiris()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             if (admintext.Text != String.Empty)
             {
                 if (admintext.Text == "admin")
                 {
                     MessageBox.Show("Giriş başarılı!");
                     frmKullaniciEkle frmkullaniciEkle = new frmKullaniciEkle();
                     frmkullaniciEkle.Show();
                     this.Hide();


                 }
                 else
                     MessageBox.Show("Yönetici girişi başarısız.");
             }
             else
                 MessageBox.Show("Boş alan bırakmayınız!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void frmAdminGiris_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmGiris f1 = new frmGiris();
            f1.Show();
            this.Hide();
        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {



        }
    }
}
