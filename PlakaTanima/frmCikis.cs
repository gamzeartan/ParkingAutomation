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
    public partial class frmCikis : Form
    {
        public frmCikis()
        {
            InitializeComponent();
        }
        OtoparkDbContext db = new OtoparkDbContext();


        private void frmCikis_Load(object sender, EventArgs e)
        {
            comboUcret.SelectedIndex = 0;

           /* var plakagetir = db.TBLAracParkBilgileri.ToList();
            foreach (var item in plakagetir)
            {

                comboPlakaAra.Items.Add(item.Plaka);

            }*/
            Yenile();

            var markagetir = db.TBLMarka.ToList();
            comboMarka.DataSource = markagetir;
            comboMarka.DisplayMember = "MarkaAdi";
            comboMarka.ValueMember = "ID";

        }

        private void Yenile()
        {

            comboPlakaAra.Text = "";
            comboPlakaAra.Items.Clear();
            var plakagetir = db.TBLAracParkBilgileri.ToList();
            foreach (var item in plakagetir)
            {

                comboPlakaAra.Items.Add(item.Plaka);

            }





            var bosparkyerleri = db.TBLAracParkYerleri.Where(x => x.Durumu == "Boş").ToList();

            comboParkYeri.DataSource = bosparkyerleri;
            comboParkYeri.DisplayMember = "ParkYerleri";
            comboParkYeri.ValueMember = "ID";



            var doluparkyerleri = db.TBLAracParkYerleri.Where(x => x.Durumu == "Dolu").ToList();
            comboParkAra.DataSource = doluparkyerleri;
            comboParkAra.DisplayMember = "ParkYerleri";
            comboParkAra.ValueMember = "ID";
            comboParkAra.Text = "";
            comboParkYeri.Text = "";


            /*foreach (var item in doluparkyerleri)
            {

                comboParkAra.Items.Add(item.ParkYerleri);

            }*/
        }


        private void comboMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var serigetir = db.TBLSeri.Where(x => x.MarkaID == (int)comboMarka.SelectedValue).ToList();
                comboSeri.DataSource = serigetir;
                comboSeri.DisplayMember = "seri";
                comboSeri.ValueMember = "ID";

            }
            catch (Exception)
            {


            }
        }


        private void comboMarka_ValueMemberChanged(object sender, EventArgs e)
        {
            var serigetir = db.TBLSeri.Where(x => x.MarkaID == (int)comboMarka.SelectedValue).ToList();
            comboSeri.DataSource = serigetir;
            comboSeri.DisplayMember = "seri";
            comboSeri.ValueMember = "ID";
        }


        void UcretHesapla()
        {

            try
            {
                label19.Text = DateTime.Now.ToString();
                TimeSpan fark;
                fark = DateTime.Parse(label19.Text) - DateTime.Parse(label15.Text);
                decimal saatucreti = 0, sure = 0, tutar = 0;
                label21.Text = fark.TotalHours.ToString("0.00");
                saatucreti = decimal.Parse(comboUcret.Text);
                sure = decimal.Parse(label21.Text);
                tutar = sure * saatucreti;
                label23.Text = tutar.ToString("0.00");

                

            }
            catch (Exception)
            {

             
            }

        }



        private void textIDAra_TextChanged(object sender, EventArgs e)
        {
            if (textIDAra.Text == "")
            {
                foreach (Control item in panelBilgiler.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
            #region ID_Ara
            var IDAra = (from x in db.TBLAracParkBilgileri
                         join y in db.TBLMarka on
                         x.MarkaID equals y.ID
                         join z in db.TBLSeri on x.SeriID equals z.ID
                         join
                         w in db.TBLAracParkYerleri on x.ParkyeriID equals w.ID
                         select new
                         {
                             x.ID,
                             x.MusteriId,
                             x.AdiSoyadi,
                             x.Telefon,
                             x.Plaka,
                             x.Renk,
                             x.Aciklama,
                             x.GirisTarihi,
                             y.MarkaAdi,
                             z.seri,
                             w.ParkYerleri
                            
                         }).Where(ara => ara.ID.ToString() == textIDAra.Text).ToList();
            foreach (var item in IDAra)
            {
                textID.Text = item.ID.ToString();
                textMusteriID.Text = item.MusteriId.ToString();
                textAdSoyad.Text = item.AdiSoyadi;
                textTelefon.Text = item.Telefon;
                comboMarka.Text = item.MarkaAdi;
                comboSeri.Text = item.seri;
                textPlaka.Text = item.Plaka;
                textRenk.Text = item.Renk;
                comboParkYeri.Text = item.ParkYerleri;
                textAciklama.Text = item.Aciklama;//15 19 21 23
                label15.Text = item.GirisTarihi.ToString();
                UcretHesapla();

            } //13.46


            #endregion     

        }

        private void textMusteriIDAra_TextChanged(object sender, EventArgs e)
        {
            if (textMusteriIDAra.Text == "")
            {
                foreach (Control item in panelBilgiler.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }




            #region MusteriID_Ara
            var MusteriIDAra = (from x in db.TBLAracParkBilgileri
                                join y in db.TBLMarka on
                                x.MarkaID equals y.ID
                                join z in db.TBLSeri on x.SeriID equals z.ID
                                join
                                w in db.TBLAracParkYerleri on x.ParkyeriID equals w.ID
                                select new
                                {
                                    x.ID,
                                    x.MusteriId,
                                    x.AdiSoyadi,
                                    x.Telefon,
                                    x.Plaka,
                                    x.Renk,
                                    x.Aciklama,
                                    x.GirisTarihi,
                                    y.MarkaAdi,
                                    z.seri,
                                    w.ParkYerleri
                                }).Where(ara => ara.MusteriId.ToString() == textMusteriIDAra.Text).ToList();
            foreach (var item in MusteriIDAra)
            {
                textID.Text = item.ID.ToString();
                textMusteriID.Text = item.MusteriId.ToString();
                textAdSoyad.Text = item.AdiSoyadi;
                textTelefon.Text = item.Telefon;
                comboMarka.Text = item.MarkaAdi;
                comboSeri.Text = item.seri;
                textPlaka.Text = item.Plaka;
                textRenk.Text = item.Renk;
                comboParkYeri.Text = item.ParkYerleri;
                textAciklama.Text = item.Aciklama;//15 19 21 23
                label15.Text = item.GirisTarihi.ToString();
                UcretHesapla();

            } //13.46


            #endregion     
        }

        private void textAdSoyadAra_TextChanged(object sender, EventArgs e)
        {

            if (textAdSoyadAra.Text == "")
            {
                foreach (Control item in panelBilgiler.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }




            #region AdSoyad_Ara
            var AdSoyadAra = (from x in db.TBLAracParkBilgileri
                                join y in db.TBLMarka on
                                x.MarkaID equals y.ID
                                join z in db.TBLSeri on x.SeriID equals z.ID
                                join
                                w in db.TBLAracParkYerleri on x.ParkyeriID equals w.ID
                                select new
                                {
                                    x.ID,
                                    x.MusteriId,
                                    x.AdiSoyadi,
                                    x.Telefon,
                                    x.Plaka,
                                    x.Renk,
                                    x.Aciklama,
                                    x.GirisTarihi,
                                    y.MarkaAdi,
                                    z.seri,
                                    w.ParkYerleri
                                }).Where(ara => ara.AdiSoyadi.ToString() == textAdSoyadAra.Text).ToList();
            foreach (var item in AdSoyadAra)
            {
                textID.Text = item.ID.ToString();
                textMusteriID.Text = item.MusteriId.ToString();
                textAdSoyad.Text = item.AdiSoyadi;
                textTelefon.Text = item.Telefon;
                comboMarka.Text = item.MarkaAdi;
                comboSeri.Text = item.seri;
                textPlaka.Text = item.Plaka;
                textRenk.Text = item.Renk;
                comboParkYeri.Text = item.ParkYerleri;
                textAciklama.Text = item.Aciklama;//15 19 21 23
                label15.Text = item.GirisTarihi.ToString();
                UcretHesapla();

            } 


            #endregion     
        }

        private void comboPlakaAra_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            #region Plaka_Ara
            var PlakaAra = (from x in db.TBLAracParkBilgileri
                              join y in db.TBLMarka on
                              x.MarkaID equals y.ID
                              join z in db.TBLSeri on x.SeriID equals z.ID
                              join
                              w in db.TBLAracParkYerleri on x.ParkyeriID equals w.ID
                              select new
                              {
                                  x.ID,
                                  x.MusteriId,
                                  x.AdiSoyadi,
                                  x.Telefon,
                                  x.Plaka,
                                  x.Renk,
                                  x.Aciklama,
                                  x.GirisTarihi,
                                  y.MarkaAdi,
                                  z.seri,
                                  w.ParkYerleri
                              }).Where(ara => ara.Plaka.ToString() == comboPlakaAra.Text).ToList();
            foreach (var item in PlakaAra)
            {
                textID.Text = item.ID.ToString();
                textMusteriID.Text = item.MusteriId.ToString();
                textAdSoyad.Text = item.AdiSoyadi;
                textTelefon.Text = item.Telefon;
                comboMarka.Text = item.MarkaAdi;
                comboSeri.Text = item.seri;
                textPlaka.Text = item.Plaka;
                textRenk.Text = item.Renk;
                comboParkYeri.Text = item.ParkYerleri;
                textAciklama.Text = item.Aciklama;//15 19 21 23
                label15.Text = item.GirisTarihi.ToString();
                UcretHesapla();


            } //13.46


            #endregion     
        }

        private void comboParkAra_SelectedIndexChanged(object sender, EventArgs e)
        {



            #region ParkYeri_Ara
            var ParkYeriAra = (from x in db.TBLAracParkBilgileri
                              join y in db.TBLMarka on
                              x.MarkaID equals y.ID
                              join z in db.TBLSeri on x.SeriID equals z.ID
                              join
                              w in db.TBLAracParkYerleri on x.ParkyeriID equals w.ID
                              select new
                              {
                                  x.ID,
                                  x.MusteriId,
                                  x.AdiSoyadi,
                                  x.Telefon,
                                  x.Plaka,
                                  x.Renk,
                                  x.Aciklama,
                                  x.GirisTarihi,
                                  y.MarkaAdi,
                                  z.seri,
                                  w.ParkYerleri
                              }).Where(ara => ara.ParkYerleri.ToString() == comboParkAra.Text).ToList();
            foreach (var item in ParkYeriAra)
            {
                textID.Text = item.ID.ToString();
                textMusteriID.Text = item.MusteriId.ToString();
                textAdSoyad.Text = item.AdiSoyadi;
                textTelefon.Text = item.Telefon;
                comboMarka.Text = item.MarkaAdi;
                comboSeri.Text = item.seri;
                textPlaka.Text = item.Plaka;
                textRenk.Text = item.Renk;
                comboParkYeri.Text = item.ParkYerleri;
                textAciklama.Text = item.Aciklama;//15 19 21 23
                label15.Text = item.GirisTarihi.ToString();
              

            } //13.46


            #endregion     
        }

        private void comboPlakaAra_TextChanged(object sender, EventArgs e)
        {

            if (comboPlakaAra.Text == "")
            {
                foreach (Control item in panelBilgiler.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }

        }

        private void comboParkAra_TextChanged(object sender, EventArgs e)
        {
            if (comboParkAra.Text == "")
            {
                foreach (Control item in panelBilgiler.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            var guncelle = db.TBLAracParkBilgileri.FirstOrDefault(x => x.ID.ToString() == textID.Text);
            guncelle.MarkaID = (int)comboMarka.SelectedValue;
            guncelle.SeriID = (int)comboSeri.SelectedValue;
            guncelle.Plaka = textPlaka.Text;
            guncelle.Renk = textRenk.Text;
            guncelle.Aciklama = textAciklama.Text;
            db.SaveChanges();
            MessageBox.Show("Araç bilgileri guncellendi.", "Kayit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Yenile();
            btnTemizle.PerformClick();
            label21.Text = "0.00";
            label23.Text = "0.00";
            label15.Text = DateTime.Now.ToString();
            label19.Text = DateTime.Now.ToString();










        }

        private void btnParkGuncelle_Click(object sender, EventArgs e)
        {



            var doluparkyeridegistir = db.TBLAracParkYerleri.FirstOrDefault(x => x.ParkYerleri == comboParkAra.Text);
            doluparkyeridegistir.Durumu = "Boş";
            db.SaveChanges();


            var bosparkyeridegistir = db.TBLAracParkYerleri.FirstOrDefault(x => x.ParkYerleri == comboParkYeri.Text);
            bosparkyeridegistir.Durumu = "Dolu";
            db.SaveChanges();

            var aracparkyeridegistir = db.TBLAracParkBilgileri.FirstOrDefault(x => x.Plaka == textPlaka.Text);
            aracparkyeridegistir.ParkyeriID = (int)comboParkYeri.SelectedValue;
            db.SaveChanges();
            MessageBox.Show("Araç Park Yeri Güncellendi.", "Kayıt",MessageBoxButtons.OK,MessageBoxIcon.Information);

            
           // comboParkAra.Items.Clear();
            
            Yenile();
            btnTemizle.PerformClick();
            label21.Text = "0.00";
            label23.Text = "0.00";
            label15.Text = DateTime.Now.ToString();
            label19.Text = DateTime.Now.ToString();

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            foreach (Control item in panelArama.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";

                }
                if (item is ComboBox)
                {
                    item.Text = "";

                }
            }

                foreach (Control item in panelBilgiler.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";

                    }
                    if (item is ComboBox)
                    {
                    if (item!= comboUcret)
                    {
                        item.Text = "";
                    }

                    }


                }
            label21.Text = "0.00";
            label23.Text = "0.00";
            label15.Text = DateTime.Now.ToString();
            label19.Text = DateTime.Now.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            #region sil
            KayitSil();

            #endregion
            MessageBox.Show("Araç Park Yeri Silindi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);


            comboParkAra.Items.Clear();

            Yenile();
            btnTemizle.PerformClick();
            label21.Text = "0.00";
            label23.Text = "0.00";
            label15.Text = DateTime.Now.ToString();
            label19.Text = DateTime.Now.ToString();

        }

        private void KayitSil()
        {
            var sil = db.TBLAracParkBilgileri.FirstOrDefault(x => x.Plaka == textPlaka.Text);
            db.TBLAracParkBilgileri.Remove(sil);
            db.SaveChanges();

            var aracparkyeriboşalt = db.TBLAracParkYerleri.FirstOrDefault(x => x.ParkYerleri == comboParkYeri.Text);
            aracparkyeriboşalt.Durumu = "Boş";
            db.SaveChanges();
        }

        private void btnAracCikis_Click(object sender, EventArgs e)
        {

            #region AracCikis   
            if (comboParkAra.Text!="")
            {
                var ekle = new Satis();
                ekle.SatisID = int.Parse(textID.Text);
                ekle.MusteriId = int.Parse(textMusteriID.Text);
                ekle.AdiSoyadi = textAdSoyad.Text;
                ekle.Telefon = textTelefon.Text;
                ekle.MarkaID = (int)comboMarka.SelectedValue;
                ekle.SeriID = (int)comboSeri.SelectedValue;
                ekle.Plaka = textPlaka.Text;
                ekle.Yil = "Belirtilmedi";
                ekle.Renk = textRenk.Text;
                ekle.ParkyeriID = (int)comboParkAra.SelectedValue;
                ekle.saatUcreti = decimal.Parse(comboUcret.Text);
                ekle.Sure = decimal.Parse(label21.Text);
                ekle.Tutar = decimal.Parse(label23.Text);
                ekle.Aciklama = textAciklama.Text;
                
               ekle.GirisTarihi = DateTime.Parse(label15.Text);
                ekle.CikisTarihi = DateTime.Parse(label19.Text);
                db.TBLSatis.Add(ekle);
                db.SaveChanges();
                MessageBox.Show("Araç otopark çıkışı yapıldı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //  comboParkAra.Items.Clear();
                KayitSil();
                Yenile();
                btnTemizle.PerformClick();

            

                label21.Text = "0.00";
                label23.Text = "0.00";
                label15.Text = DateTime.Now.ToString();
                label19.Text = DateTime.Now.ToString();


            }
            else
            {
                MessageBox.Show("Dolu park yerinin seçilmesi gerekir. ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
    #endregion
           




        }

        private void comboUcret_SelectedIndexChanged(object sender, EventArgs e)
        {
            UcretHesapla();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAnaEkran f3 = new frmAnaEkran();
            f3.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void panelArama_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelIslemler_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panelBilgiler_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
