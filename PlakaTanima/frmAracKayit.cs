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
    public partial class frmAracKayit : Form
    {
        public frmAracKayit()
        {
            InitializeComponent();
        }

        OtoparkDbContext db = new OtoparkDbContext();

       // public DateTime gelenTarih;
        public string gelen;

        private void frmAracKayit_Load(object sender, EventArgs e)
        {
            textPlaka.Text = gelen; // tüm satırı aktarıyor. sadece plaka için düzeltilmesi lazım, düzeltildi

            var getir = db.TBLMarka.ToList();
            comboMarka.DataSource = getir;
            comboMarka.DisplayMember = "MarkaAdi";
            comboMarka.ValueMember = "ID";

            ParkGuncelle();

        }

        private void ParkGuncelle()
        {
            var parkyeri = db.TBLAracParkYerleri.Where(x => x.Durumu == "Boş").ToList();
            comboParkYeri.DataSource = parkyeri;
            comboParkYeri.DisplayMember = "ParkYerleri";
            comboParkYeri.ValueMember = "ID";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboMarka_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {

                var seri = db.TBLSeri.Where(x => x.MarkaID == (int)comboMarka.SelectedValue).ToList();
                comboSeri.DataSource = seri;
                comboSeri.DisplayMember = "Seri";
                comboSeri.ValueMember = "ID";
            }
             catch(Exception)
            {


            }



        }

        private void comboMarka_ValueMemberChanged(object sender, EventArgs e)
        {

        /*  var seri = db.TBLSeri.Where(x => x.MarkaID == (int)comboMarka.SelectedValue).ToList();
            comboSeri.DataSource = seri;
            comboSeri.DisplayMember = "Seri";
            comboSeri.ValueMember = "ID";*/
            //form load olduğunda seçili combo için
        }

        private void textMusteriID_TextChanged(object sender, EventArgs e)
        {
            
            try {
                var MusteriGetir = db.TBLMusteri.Where(x => x.ID.ToString() == textMusteriID.Text).ToList();

                foreach (var item in MusteriGetir)
                {
                    textAdi.Text = item.AdiSoyadi;
                    textTelefon.Text = item.Telefon;

                }
                if(textMusteriID.Text == "")
                {
                    textAdi.Text = "";
                    textTelefon.Text = "";
                }

             
            }
            catch (Exception)
            {



            }
            




        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close(); //form kapat
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            //formdaki textleri temizle
            foreach(Control item in panel2.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }

            }




        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            var ekle = new AracParkBilgileri();

            ekle.MusteriId = int.Parse(textMusteriID.Text);
            ekle.AdiSoyadi = textAdi.Text;
            ekle.Telefon = textTelefon.Text;
            ekle.MarkaID = (int)comboMarka.SelectedValue;
            ekle.SeriID = (int)comboSeri.SelectedValue;
            ekle.Plaka = textPlaka.Text; // değişkende hata veriyor
            ekle.Yil = textYil.Text;
            ekle.Renk = textRenk.Text;
            ekle.ParkyeriID = (int)comboParkYeri.SelectedValue;
            ekle.Aciklama = textAciklama.Text;
            ekle.GirisTarihi = dateTimePicker1.Value;
           // ekle.GirisTarihi = DateTime.Now;
           // db.SaveChanges();

            //BAKKKKK
            // ekle.GirisTarihi = tblmüsteri.tarih;




            db.TBLAracParkBilgileri.Add(ekle);
            db.SaveChanges();
            //seçilen park yerinin veritabanında dolu olarak değiştir
            var parkdoldur = db.TBLAracParkYerleri.FirstOrDefault(x => x.ID == (int)comboParkYeri.SelectedValue);
            parkdoldur.Durumu = "Dolu";
          
            
            db.SaveChanges();
            MessageBox.Show("Kayit gerçekleştirildi.", "Kayit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSil.PerformClick();
            ParkGuncelle();






        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAnaEkran f2 = new frmAnaEkran();
            f2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
