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
    public partial class UCGuncelle : UserControl
    {
        public UCGuncelle()
        {
            InitializeComponent();
        }
        OtoparkDbContext db = new OtoparkDbContext();
        private void KListele()

        {
            listView1.Items.Clear();

            var kListesi = db.TBLKullanici.ToList();
            for (int i = 0; i < kListesi.Count; i++)
            {
                ListViewItem ekle = new ListViewItem(kListesi[i].KullaniciID.ToString());
             
                ekle.SubItems.Add(kListesi[i].Sifre);
                ekle.SubItems.Add(kListesi[i].KullaniciAdi);
                listView1.Items.Add(ekle);

            }
        }

        void temizle()
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var guncelle = db.TBLKullanici.FirstOrDefault(x => x.KullaniciID == id);
            guncelle.KullaniciAdi = textBox2.Text;
            guncelle.Sifre = textBox3.Text;
            db.SaveChanges();
            MessageBox.Show("Kullanıcı güncellendi.", "Kaydet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            KListele();
            temizle();
        }

        private void UCGuncelle_Load(object sender, EventArgs e)
        {
            KListele();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem secilen = listView1.SelectedItems[0];
            if (listView1.SelectedItems.Count > 0)
            {
                textBox1.Text = secilen.SubItems[0].Text;
                textBox2.Text = secilen.SubItems[1].Text;
                textBox3.Text = secilen.SubItems[2].Text;


            }
        }
    }
}
