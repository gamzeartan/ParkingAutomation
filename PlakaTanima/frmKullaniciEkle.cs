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
    public partial class frmKullaniciEkle : Form
    {
        public frmKullaniciEkle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* UCKullaniciEkle uc = new UCKullaniciEkle();
             panel2.Controls.Add(uc);
           uc.Dock = DockStyle.Fill;
          panel2.Controls.Add(uc);*/
            UCKullaniciEkle uo2 = new UCKullaniciEkle();
            uo2.Dock = DockStyle.Fill;
           panel2.Controls.Add(uo2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*UCKullaniciSil ucs = new UCKullaniciSil();
            ucs.Dock = DockStyle.Fill;
            panel2.Controls.Add(ucs);*/
        
            UCKullaniciSil uo3 = new UCKullaniciSil();
            uo3.Dock = DockStyle.Fill;
           panelKullanici.Controls.Add(uo3);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmkullaniciEkle_Load(object sender, EventArgs e)
        {
;
          
            
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UCGuncelle uo4 = new UCGuncelle();
            uo4.Dock = DockStyle.Fill;
            panel3.Controls.Add(uo4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmGiris f5 = new frmGiris();
            f5.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
