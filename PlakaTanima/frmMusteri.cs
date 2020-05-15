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
    public partial class frmMusteri : Form
    {
        public frmMusteri()
        {
            InitializeComponent();
        }
        OtoparkDbContext db = new OtoparkDbContext();

        private void frmMusteri_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = db.TBLMusteri.ToList(); //datagridview listeleme

        }
        void temizle()
        {
            foreach(Control item in Controls) // formun kontrollerinin dolaş
            {
                if (item is TextBox ) //textbox ise temizle
                {
                    item.Text = "";
                }

            }
            dateTimePicker1.Value = DateTime.Now; // anlık tarihi alır

        }


        private void textID_TextChanged(object sender, EventArgs e)
        {
            var ara = from x in db.TBLMusteri
                      where x.ID.ToString() == textID.Text
                      select x;
            foreach (var item in ara)
            {
                textAdSoyad.Text = item.AdiSoyadi;
                textTelefon.Text = item.Telefon;
                textMail.Text = item.Email;
                dateTimePicker1.Value = item.Tarih;
            }

            if (textID.Text == "")
            {
                temizle();
            }



        }

        

      
        private void btnEkle_Click(object sender, EventArgs e)
        {
            var ekle = new Musteri();
            ekle.AdiSoyadi = textAdSoyad.Text;
            ekle.Telefon = textTelefon.Text;
            ekle.Email = textMail.Text;
            ekle.Tarih = dateTimePicker1.Value;

            db.TBLMusteri.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("Ekleme işlemi gerçekleştirildi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);

            temizle();
            dataGridView1.DataSource = db.TBLMusteri.ToList(); //datagridview listeleme



           

        }

        private void btnSil_Click(object sender, EventArgs e)
        {


            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var sil = db.TBLMusteri.FirstOrDefault(x=>x.ID==id);
            db.TBLMusteri.Remove(sil);
            db.SaveChanges();
            MessageBox.Show("Kayıt silindi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            temizle();
            dataGridView1.DataSource = db.TBLMusteri.ToList(); //datagridview listeleme




        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textID.Text);
            var guncelle = db.TBLMusteri.FirstOrDefault(x => x.ID == id);
            guncelle.AdiSoyadi = textAdSoyad.Text;
            guncelle.Telefon = textTelefon.Text;
            guncelle.Email = textMail.Text;
           guncelle.Tarih = dateTimePicker1.Value;

           
            db.SaveChanges();
            MessageBox.Show("Guncelleme işlemi gerçekleştirildi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);

            temizle();
            dataGridView1.DataSource = db.TBLMusteri.ToList(); //datagridview listeleme



        }

        private void button5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAnaEkran f7 = new frmAnaEkran();
            f7.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

          /*  string secilenTarih = dateTimePicker1.Value.ToString();

            frmAracKayit f21 = new frmAracKayit();
            f21.gelenTarih = DateTime.Parse(secilenTarih);
           // f21.Show();
           // this.Hide();

           // string secilenPlaka = dateTimePicker1

           

           /* frmAracKayit frmAracKayit = new frmAracKayit();

            frmAracKayit.gelen = secilen.Remove(7);
            frmAracKayit.Show();
            this.Hide();*/

        }
    }
}
