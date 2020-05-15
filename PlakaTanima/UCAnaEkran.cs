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
    public partial class UCAnaEkran : UserControl
    {
        public UCAnaEkran()
        {
            InitializeComponent();
        }

        OtoparkDbContext db = new OtoparkDbContext();

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void UCAnaEkran_Load(object sender, EventArgs e)
        {
            /*  timer1.Enabled = true;
              label1.Text = DateTime.Now.ToString();*/

           
            label2.Text = "KAPASİTE: " + db.TBLAracParkYerleri.Count();
            label3.Text = "BOŞ: " + (120 - db.TBLAracParkBilgileri.Count()); // 4 panel, 30 kapasiteli
            label4.Text = "DOLU: " + db.TBLAracParkBilgileri.Count();



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            frmOtopark otopark = new frmOtopark();
            this.Hide();
            otopark.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmPlakaBul form1 = new frmPlakaBul();
            this.Hide();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmCikis cikis = new frmCikis();
            this.Hide();
            cikis.Show();
        }
    }
}
