using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlakaTanima.classlar;

namespace PlakaTanima
{
    public partial class UCKullaniciEkle : UserControl
    {
        public UCKullaniciEkle()
        {
            InitializeComponent();
        }
        OtoparkDbContext db = new OtoparkDbContext();
        private void UCKullaniciEkle_Load(object sender, EventArgs e)
        {
            DListele();
        }
        private void DListele()

        {
            listView1.Items.Clear();

            var dlistesi = db.TBLKullanici.ToList();
            for (int i = 0; i < dlistesi.Count; i++)
            {
                ListViewItem ekle = new ListViewItem(dlistesi[i].KullaniciID.ToString());
                ekle.SubItems.Add(dlistesi[i].KullaniciAdi);
                ekle.SubItems.Add(dlistesi[i].Sifre);
                listView1.Items.Add(ekle);

            }
        }

        void temizle()
        {
            
            textBox2.Text = "";
            textBox3.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
         

            var tbl = new Kullanici();
            tbl.KullaniciAdi = textBox2.Text;
            tbl.Sifre = textBox3.Text;
            db.TBLKullanici.Add(tbl);
            db.SaveChanges();
            MessageBox.Show("Kullanıcı eklendi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DListele();
            temizle();

           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmGiris f5 = new frmGiris();
            f5.Show();
            this.Hide();
        }
    }
}
