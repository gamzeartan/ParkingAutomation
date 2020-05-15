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
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
            removeBG(txtIcon, icon);
          //  removeBG(txtIcon2, icon2);
        }
        OtoparkDbContext db = new OtoparkDbContext();



        void removeBG (PictureBox pb, PictureBox pb2)
        {
            var pos = this.PointToScreen(pb2.Location);
            pos = pb.PointToClient(pos);
            pb2.Parent = pb;
            pb2.Location = pos;
            pb2.BackColor = Color.Transparent;

        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void frmGiris_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*   otopark_dbEntities dc = new otopark_dbEntities();

               /* if (kullanicitext.Text = "" && parolatext.Text = "")
                {
                    MessageBox.Show("Boş alan bırakmayınız!");
                }*/

            /* if (kullanicitext.Text != string.Empty && parolatext.Text != string.Empty)
             {
                 var kullanici = dc.tbl_kullanici.FirstOrDefault(a => a.kullanici_adi.Equals(kullanicitext.Text));
                 if (kullanici != null)
                 {
                     if (kullanici.kullanici_adi.Equals(kullanicitext.Text) && kullanici.kullanici_parola.Equals(parolatext.Text))
                         MessageBox.Show("Giriş başarılı!");
                     FrmAnaEkran FrmAnaEkran = new FrmAnaEkran();
                        FrmAnaEkran.Show();
                 }
                 //this.Hide();
                 else
                         MessageBox.Show("Hatalı giriş! Lütfen kontrol ediniz."); //sadece şifre hatalı ise uyarı veriyor!


             }
             else
                 MessageBox.Show("Boş alan bırakmayınız.");*/

            /*  if (kullanicitext.Text != String.Empty)
              {
                  if (kullanicitext.Text == "admin" && parolatext.Text=="admin")
                  {
                      MessageBox.Show("Giriş başarılı!");
                      frmAnaEkran anaekran = new frmAnaEkran();
                      anaekran.Show();
                      this.Hide();


                  }
                  else
                      MessageBox.Show("Giriş başarısız.");
              }
              else
                  MessageBox.Show("Boş alan bırakmayınız!");*/


            Kullanici k = db.TBLKullanici.Where(x => x.KullaniciAdi == kullanicitext.Text && x.Sifre == parolatext.Text).SingleOrDefault();
            if (k==null)
            {
                MessageBox.Show("Kullanıcı Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (k !=null)
            {
                frmAnaEkran fm = new frmAnaEkran();
                fm.Show();
                this.Hide();
            }


        }

        private void kullanicitext_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void kullanicitext_MouseClick(object sender, MouseEventArgs e)
        {
            kullanicitext.Text = "";
        }

        private void parolatext_MouseClick(object sender, MouseEventArgs e)
        {
            parolatext.Text = "";
        }

        private void label5_Click(object sender, EventArgs e)
        {
            frmAdminGiris frmAdminGiris = new frmAdminGiris();
            frmAdminGiris.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
