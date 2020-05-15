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
    public partial class UCKullaniciSil : UserControl
    {
        public UCKullaniciSil()
        {
            InitializeComponent();
        }
        OtoparkDbContext db = new OtoparkDbContext();

        private void UCKullaniciSil_Load(object sender, EventArgs e)
        {
            KullaniciListele();
        }

        private void KullaniciListele()

        {
            listView1.Items.Clear();

            var kullaniciListesi = db.TBLKullanici.ToList();
            for (int i = 0; i < kullaniciListesi.Count; i++)
            {
                ListViewItem ekle = new ListViewItem(kullaniciListesi[i].KullaniciID.ToString());
                
                ekle.SubItems.Add(kullaniciListesi[i].KullaniciAdi);
                ekle.SubItems.Add(kullaniciListesi[i].Sifre);
                listView1.Items.Add(ekle);

            }
        }
        void temizle()
        {

            textBox1.Text = "";
            textBox2.Text = "";


        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem secilen = listView1.SelectedItems[0];
            if (listView1.SelectedItems.Count > 0)
            {
                textBox1.Text = secilen.SubItems[0].Text;
                textBox2.Text = secilen.SubItems[1].Text;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem SecilenID = listView1.SelectedItems[0];
            int secilenID = int.Parse(SecilenID.SubItems[0].Text);
            var sil = db.TBLKullanici.FirstOrDefault(x => x.KullaniciID == secilenID);
            db.TBLKullanici.Remove(sil);
            db.SaveChanges();
            MessageBox.Show("Kullanıcı silindi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            KullaniciListele();
            temizle();
        }
    }
}
