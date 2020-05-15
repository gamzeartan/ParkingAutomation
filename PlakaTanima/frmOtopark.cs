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
    public partial class frmOtopark : Form
    {
        public frmOtopark()
        {
            InitializeComponent();
        }

        OtoparkDbContext db = new OtoparkDbContext();

      /*  private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }*/

        private void frmOtopark_Load(object sender, EventArgs e)
        {
            int m = 1, y = 1, z = 1, t = 1, s = 31, c=1;

          foreach (Control item in panel1.Controls)
            {
                if (item is Label)
                {
                     item.Text = "A-" + c;
                     item.Name = m.ToString();
                    c++;
                    m++;
                    
                }

            }
            foreach (Control item in panel2.Controls)
            {
                if (item is Label)
                {
                    item.Text = "B-" + y;
                    item.Name = s.ToString();
                    y++;
                    s++;
                   
                }

            }


            foreach (Control item in panel3.Controls)
            {
                if (item is Label)
                {
                    item.Text = "C-" + z;
                    item.Name = s.ToString();
                    z++;
                    s++;

                }

            }


            foreach (Control item in panel4.Controls)
            {
                if (item is Label)
                {
                    item.Text = "D-" + t;
                    item.Name = s.ToString();
                    t++;
                    s++;
                }

            }

            var parkyerleri = from i in db.TBLAracParkYerleri

                              select new
                              {
                                  i.Durumu,
                                  i,
                                  i.ID,
                                  i.ParkYerleri

                              };


            foreach (var item in parkyerleri)
            {

                foreach(Control lbl in panel1.Controls) // A serisine park ait yerlerinin kontrolü
                {
                    if(item.Durumu=="Boş" && item.ParkYerleri == lbl.Text)
                    {
                        lbl.BackColor = Color.LimeGreen;
                    }
                    else if (item.Durumu == "Dolu" && item.ParkYerleri == lbl.Text)
                    {
                        lbl.BackColor = Color.Firebrick;
                    }
                }

                foreach (Control lbl in panel2.Controls) //B serisine ait park yerlerinin kontrolü
                {
                    if (item.Durumu == "Boş" && item.ParkYerleri == lbl.Text)
                    {
                        lbl.BackColor = Color.LimeGreen;
                    }
                    else if (item.Durumu == "Dolu" && item.ParkYerleri == lbl.Text)
                    {
                        lbl.BackColor = Color.Firebrick;
                    }
                }

                foreach (Control lbl in panel3.Controls) // C serisine ait park yerlerinin kontrolü
                {
                    if (item.Durumu == "Boş" && item.ParkYerleri == lbl.Text)
                    {
                        lbl.BackColor = Color.LimeGreen;
                    }
                    else if (item.Durumu == "Dolu" && item.ParkYerleri == lbl.Text)
                    {
                        lbl.BackColor = Color.Firebrick;
                    }
                }

                foreach (Control lbl in panel4.Controls) // D serisine ait park yerlerinin kontrolü
                {
                    if (item.Durumu == "Boş" && item.ParkYerleri == lbl.Text)
                    {
                        lbl.BackColor = Color.LimeGreen;
                    }
                    else if (item.Durumu == "Dolu" && item.ParkYerleri == lbl.Text)
                    {
                        lbl.BackColor = Color.Firebrick;
                    }
                }




            }

            var plakagoster = from x in db.TBLAracParkBilgileri
                              select new { x.Plaka, x.ParkyeriID };
            foreach (var item in plakagoster)
            {
                foreach (Control lbl in panel1.Controls)
                {
                    if (lbl.Name == item.ParkyeriID.ToString() && lbl.BackColor == Color.Firebrick)
                    {
                        lbl.Text = item.Plaka;

                    }
                }
            
                foreach (Control lbl in panel2.Controls)
                {
                    if (lbl.Name == item.ParkyeriID.ToString() && lbl.BackColor == Color.Firebrick)
                    {
                        lbl.Text = item.Plaka;

                    }
                }
                foreach (Control lbl in panel3.Controls)
                {
                    if (lbl.Name == item.ParkyeriID.ToString() && lbl.BackColor == Color.Firebrick)
                    {
                        lbl.Text = item.Plaka;

                    }
                }
                foreach (Control lbl in panel4.Controls)
                {
                    if (lbl.Name == item.ParkyeriID.ToString() && lbl.BackColor == Color.Firebrick)
                    {
                        lbl.Text = item.Plaka;

                    }
                }
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAnaEkran f9 = new frmAnaEkran();
            f9.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
