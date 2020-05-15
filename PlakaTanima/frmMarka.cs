using PlakaTanima.classlar;
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
    public partial class frmMarka : Form
    {
        public frmMarka()
        {
            InitializeComponent();
        }
        OtoparkDbContext db = new OtoparkDbContext();
        private void frmMarka_Load(object sender, EventArgs e)
        {
            MarkaListele();

        }

        private void MarkaListele()

        {
            listView1.Items.Clear();

            var markaListesi = db.TBLMarka.ToList();
            for (int i = 0; i < markaListesi.Count; i++)
            {
                ListViewItem ekle = new ListViewItem(markaListesi[i].ID.ToString());
                ekle.SubItems.Add(markaListesi[i].MarkaAdi);
                listView1.Items.Add(ekle);

            }
        }

        void temizle()
        {

            textBox1.Text = "";
            textBox2.Text = "";


        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            var tbl = new Marka();
            tbl.MarkaAdi = textBox2.Text;
            db.TBLMarka.Add(tbl);
            db.SaveChanges();
            MessageBox.Show("Araç markası eklendi.","Kayıt",MessageBoxButtons.OK,MessageBoxIcon.Information);
            MarkaListele();
            temizle();
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            ListViewItem SecilenID = listView1.SelectedItems[0];
            int secilenID = int.Parse(SecilenID.SubItems[0].Text);
            var sil = db.TBLMarka.FirstOrDefault(x => x.ID == secilenID);
            db.TBLMarka.Remove(sil);
            db.SaveChanges();
            MessageBox.Show("Araç markası silindi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MarkaListele();
            temizle();



        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var guncelle = db.TBLMarka.FirstOrDefault(x => x.ID == id);
            guncelle.MarkaAdi = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Araç markası güncellendi.", "Kaydet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MarkaListele();
            temizle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); // sadece pencere kapatan kod ile değistir
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmAnaEkran f6 = new frmAnaEkran();
            f6.Show();
            this.Hide();
        }
    }
}
