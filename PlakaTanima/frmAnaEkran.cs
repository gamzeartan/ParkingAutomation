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
    public partial class frmAnaEkran : Form
    {
        public frmAnaEkran()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmAnaEkran_Load(object sender, EventArgs e)
        {
            UCAnaEkran uo = new UCAnaEkran();
            uo.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uo);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMarka marka = new frmMarka();
            this.Hide();
            marka.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSeri seri = new frmSeri();
            this.Hide();
            seri.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmMusteri musteri = new frmMusteri();
            this.Hide();
            musteri.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmKayitlar kayitlar = new frmKayitlar();
            this.Hide();
            kayitlar.Show();
        }
    }
}
