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
    public partial class frmKayitlar : Form
    {
        public frmKayitlar()
        {
            InitializeComponent();
        }

        OtoparkDbContext db = new OtoparkDbContext();

        private void frmKayitlar_Load(object sender, EventArgs e)
        {
            TumKayitlar();
        }

        private void TumKayitlar()
        {
            #region KayitGoster
            var liste = (from x in db.TBLSatis
                         join y in db.TBLMarka on
                         x.MarkaID equals y.ID
                         join z in db.TBLSeri on x.SeriID equals z.ID
                         join
                         w in db.TBLAracParkYerleri on x.ParkyeriID equals w.ID
                         select new
                         {
                             x.ID,
                            x.SatisID,
                             x.MusteriId,
                             x.AdiSoyadi,
                             x.Telefon,
                             y.MarkaAdi,
                             z.seri,
                             w.ParkYerleri,
                             x.Plaka,
                             x.Yil,
                             x.Renk,
                             x.Aciklama,
                             x.saatUcreti,
                             x.Sure,
                             x.Tutar,
                             x.GirisTarihi,
                             x.CikisTarihi,

                         }).ToList();

            dataGridView1.DataSource = liste;

           // String.Format("{0:0.00}", db.TBLSatis.Average(x => x.Tutar)); //virgülden sonra 2 basamak al

            labelTutar.Text = "Toplam Tutar: " + db.TBLSatis.Sum(x => x.Tutar);
            labelKayit.Text = "Toplam " + db.TBLSatis.Count() + " kayıt var.";
            labelOrtalama.Text = "Ortalama Tutar: " + String.Format("{0:0.00}",db.TBLSatis.Average(x => x.Tutar));
          


            labelMax.Text = "En Yüksek Ücret: " + db.TBLSatis.Max(x => x.Tutar);
            labelMin.Text = "En Düşük Ücret: " + db.TBLSatis.Min(x => x.Tutar);


            #endregion
        }

        private void textIDAra_TextChanged(object sender, EventArgs e)
        {
            #region IDAra
            var liste = (from x in db.TBLSatis
                         join y in db.TBLMarka on
                         x.MarkaID equals y.ID
                         join z in db.TBLSeri on x.SeriID equals z.ID
                         join
                         w in db.TBLAracParkYerleri on x.ParkyeriID equals w.ID
                         select new
                         {
                             x.ID,
                             x.SatisID,
                             x.MusteriId,
                             x.AdiSoyadi,
                             x.Telefon,
                             y.MarkaAdi,
                             z.seri,
                             w.ParkYerleri,
                             x.Plaka,
                             x.Yil,
                             x.Renk,
                             x.Aciklama,
                             x.saatUcreti,
                             x.Sure,
                             x.Tutar,
                             x.GirisTarihi,
                             x.CikisTarihi,

                         }).Where(x => x.ID.ToString() == textIDAra.Text).ToList();

            dataGridView1.DataSource = liste;
            if (textIDAra.Text=="")
            {
                TumKayitlar();
            }
              
           



            #endregion

        }

        private void textMusteriAra_TextChanged(object sender, EventArgs e)
        {
            #region MusteriAra
            var liste = (from x in db.TBLSatis
                         join y in db.TBLMarka on
                         x.MarkaID equals y.ID
                         join z in db.TBLSeri on x.SeriID equals z.ID
                         join
                         w in db.TBLAracParkYerleri on x.ParkyeriID equals w.ID
                         select new
                         {
                             x.ID,
                             x.SatisID,
                             x.MusteriId,
                             x.AdiSoyadi,
                             x.Telefon,
                             y.MarkaAdi,
                             z.seri,
                             w.ParkYerleri,
                             x.Plaka,
                             x.Yil,
                             x.Renk,
                             x.Aciklama,
                             x.saatUcreti,
                             x.Sure,
                             x.Tutar,
                             x.GirisTarihi,
                             x.CikisTarihi,

                         }).Where(x => x.MusteriId.ToString() == textMusteriAra.Text).ToList();

            dataGridView1.DataSource = liste;
            if (textMusteriAra.Text == "")
            {
                TumKayitlar();
            }





            #endregion

        }

        private void textAdAra_TextChanged(object sender, EventArgs e)
        {
            #region AdSoyadAra
            var liste = (from x in db.TBLSatis
                         join y in db.TBLMarka on
                         x.MarkaID equals y.ID
                         join z in db.TBLSeri on x.SeriID equals z.ID
                         join
                         w in db.TBLAracParkYerleri on x.ParkyeriID equals w.ID
                         select new
                         {
                             x.ID,
                             x.SatisID,
                             x.MusteriId,
                             x.AdiSoyadi,
                             x.Telefon,
                             y.MarkaAdi,
                             z.seri,
                             w.ParkYerleri,
                             x.Plaka,
                             x.Yil,
                             x.Renk,
                             x.Aciklama,
                             x.saatUcreti,
                             x.Sure,
                             x.Tutar,
                             x.GirisTarihi,
                             x.CikisTarihi,

                         }).Where(x => x.AdiSoyadi.Contains(textAdAra.Text)).ToList();

            dataGridView1.DataSource = liste;
            /* if (textAdAra.Text == "")
             {
                 TumKayitlar();
             }*/

            labelTutar.Text = "Toplam Tutar: " + db.TBLSatis.Sum(x => x.Tutar);
            labelKayit.Text = "Toplam " + db.TBLSatis.Count() + " kayıt var.";
            labelOrtalama.Text = "Ortalama Tutar: " + db.TBLSatis.Average(x => x.Tutar);
            labelMax.Text = "En Yüksek Ücret: " + db.TBLSatis.Max(x => x.Tutar);
            labelMin.Text = "En Düşük Ücret: " + db.TBLSatis.Min(x => x.Tutar);



            #endregion

        }

        private void textPlakaAra_TextChanged(object sender, EventArgs e)
        {
            #region PlakaAra
            var liste = (from x in db.TBLSatis
                         join y in db.TBLMarka on
                         x.MarkaID equals y.ID
                         join z in db.TBLSeri on x.SeriID equals z.ID
                         join
                         w in db.TBLAracParkYerleri on x.ParkyeriID equals w.ID
                         select new
                         {
                             x.ID,
                             x.SatisID,
                             x.MusteriId,
                             x.AdiSoyadi,
                             x.Telefon,
                             y.MarkaAdi,
                             z.seri,
                             w.ParkYerleri,
                             x.Plaka,
                             x.Yil,
                             x.Renk,
                             x.Aciklama,
                             x.saatUcreti,
                             x.Sure,
                             x.Tutar,
                             x.GirisTarihi,
                             x.CikisTarihi,

                         }).Where(x => x.Plaka.Contains(textPlakaAra.Text)).ToList();

            dataGridView1.DataSource = liste;
            /* if (textAdAra.Text == "")
             {
                 TumKayitlar();
             }
             */


            labelTutar.Text = "Toplam Tutar: " + db.TBLSatis.Sum(x => x.Tutar);
            labelKayit.Text = "Toplam " + db.TBLSatis.Count() + " kayıt var.";
            labelOrtalama.Text = "Ortalama Tutar: " + db.TBLSatis.Average(x => x.Tutar);
            labelMax.Text = "En Yüksek Ücret: " + db.TBLSatis.Max(x => x.Tutar);
            labelMin.Text = "En Düşük Ücret: " + db.TBLSatis.Min(x => x.Tutar);

            #endregion

        }

        private void textParkAra_TextChanged(object sender, EventArgs e)
        {
            #region ParkYeriAra
            var liste = (from x in db.TBLSatis
                         join y in db.TBLMarka on
                         x.MarkaID equals y.ID
                         join z in db.TBLSeri on x.SeriID equals z.ID
                         join
                         w in db.TBLAracParkYerleri on x.ParkyeriID equals w.ID
                         select new
                         {
                             x.ID,
                             x.SatisID,
                             x.MusteriId,
                             x.AdiSoyadi,
                             x.Telefon,
                             y.MarkaAdi,
                             z.seri,
                             w.ParkYerleri,
                             x.Plaka,
                             x.Yil,
                             x.Renk,
                             x.Aciklama,
                             x.saatUcreti,
                             x.Sure,
                             x.Tutar,
                             x.GirisTarihi,
                             x.CikisTarihi,

                         }).Where(x => x.ParkYerleri.Contains(textParkAra.Text)).ToList();

            dataGridView1.DataSource = liste;
            /* if (textAdAra.Text == "")
             {
                 TumKayitlar();
             }*/


            labelTutar.Text = "Toplam Tutar: " + db.TBLSatis.Sum(x => x.Tutar);
            labelKayit.Text = "Toplam " + db.TBLSatis.Count() + " kayıt var.";
            labelOrtalama.Text = "Ortalama Tutar: " + db.TBLSatis.Average(x => x.Tutar);
            labelMax.Text = "En Yüksek Ücret: " + db.TBLSatis.Max(x => x.Tutar);
            labelMin.Text = "En Düşük Ücret: " + db.TBLSatis.Min(x => x.Tutar);


            #endregion

        }

        private void textTarih_TextChanged(object sender, EventArgs e)
        {
            #region Tarih
            var liste = (from x in db.TBLSatis
                         join y in db.TBLMarka on
                         x.MarkaID equals y.ID
                         join z in db.TBLSeri on x.SeriID equals z.ID
                         join
                         w in db.TBLAracParkYerleri on x.ParkyeriID equals w.ID
                         select new
                         {
                             x.ID,
                             x.SatisID,
                             x.MusteriId,
                             x.AdiSoyadi
                          ,
                             x.Telefon,
                             y.MarkaAdi,
                             z.seri,
                             w.ParkYerleri,
                             x.Plaka,
                             x.Yil,
                             x.Renk,
                             x.Aciklama,
                             x.saatUcreti,
                             x.Sure,
                             x.Tutar,
                             x.GirisTarihi,
                             x.CikisTarihi,

                         }).Where(x => x.GirisTarihi.ToString().Substring(0,10).Contains(textTarih.Text)).ToList(); //nokta koyunca sıkıntı var.
         
            dataGridView1.DataSource = liste;
            /* if (textAdAra.Text == "")
             {
                 TumKayitlar();
             }*/

            labelTutar.Text = "Toplam Tutar: " + db.TBLSatis.Sum(x => x.Tutar);
            labelKayit.Text = "Toplam " + db.TBLSatis.Count() + " kayıt var.";
            labelOrtalama.Text = "Ortalama Tutar: " + db.TBLSatis.Average(x => x.Tutar);
            labelMax.Text = "En Yüksek Ücret: " + db.TBLSatis.Max(x => x.Tutar);
            labelMin.Text = "En Düşük Ücret: " + db.TBLSatis.Min(x => x.Tutar);



            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAnaEkran f4 = new frmAnaEkran();
            f4.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
