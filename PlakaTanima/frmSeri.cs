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
    public partial class frmSeri : Form
    {
        public frmSeri()
        {
            InitializeComponent();
        }
        OtoparkDbContext db = new OtoparkDbContext();


        private void frmSeri_Load(object sender, EventArgs e)
        {
            Listele();
            var comboliste = db.TBLMarka.ToList();
            comboMarka.DataSource = comboliste;
            comboMarka.DisplayMember = "MarkaAdi";
            comboMarka.ValueMember = "ID";

            
        }
        void Temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboMarka.Text = "";
        }
        private void Listele()
        {
            listView1.Items.Clear();
            var liste = from x in db.TBLSeri
                        join y in db.TBLMarka on
                        x.MarkaID equals y.ID
                        select new
                        {
                            x.ID,
                            y.MarkaAdi,
                            x.seri
                        };

            foreach (var item in liste)
            {
                ListViewItem viewItem = new ListViewItem(item.ID.ToString());
                viewItem.SubItems.Add(item.MarkaAdi);
                viewItem.SubItems.Add(item.seri);
                listView1.Items.Add(viewItem);


            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int markaid = (int)comboMarka.SelectedValue;
            var ekle = new Seri();
            //ekle.ID = int.Parse(textBox1.Text);
            ekle.MarkaID = markaid;
            ekle.seri = textBox2.Text;
            db.TBLSeri.Add(ekle);
            db.SaveChanges();
            Temizle();
            Listele();
            MessageBox.Show("Araca yeni seri eklendi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ListViewItem SecilenID = listView1.SelectedItems[0];
            int secilenID = int.Parse(SecilenID.SubItems[0].Text);
            var sil = db.TBLSeri.FirstOrDefault(x => x.ID == secilenID);
            db.TBLSeri.Remove(sil);
            db.SaveChanges();
            MessageBox.Show("Araç serisi silindi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var guncelle = db.TBLSeri.FirstOrDefault(x => x.ID == id);
            guncelle.MarkaID = (int)comboMarka.SelectedValue;
            guncelle.seri = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Araç markası güncellendi.", "Kaydet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem secilen = listView1.SelectedItems[0];
            if (listView1.SelectedItems.Count > 0)
            {
                textBox1.Text = secilen.SubItems[0].Text;
                comboMarka.Text = secilen.SubItems[1].Text;
                textBox2.Text = secilen.SubItems[2].Text;
            }
        }

        private void comboMarka_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmAnaEkran f11 = new frmAnaEkran();
            f11.Show();
            this.Hide();
        }
    }
}
