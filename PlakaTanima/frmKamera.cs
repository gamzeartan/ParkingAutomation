using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;


namespace PlakaTanima
{
    public partial class Form2 : Form

    {
        private FilterInfoCollection webcam; //BU değişken bilgisayarda kaç kamera bağlıysa onları tutan bir dizi.

        private VideoCaptureDevice cam; //Bizim kullanacağımız aygıt.
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cam.IsRunning)

            {

                cam.Stop(); // Kamerayı durduruyoruz.

            }
            SaveFileDialog swf = new SaveFileDialog();

            swf.Filter = "(*.jpg)|*.jpg|Bitma*p(*.bmp)|*.bmp";

            DialogResult dialog = swf.ShowDialog();  //Resmi çekiyoruz ve aşağıda da kaydediyoruz.


            if (dialog == DialogResult.OK)

            {

                pictureBox1.Image.Save(swf.FileName);

            }
            cam.Start();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            webcam = new

           FilterInfoCollection(FilterCategory.VideoInputDevice); //webcam dizisine mevcut kameraları dolduruyoruz.

            foreach (FilterInfo item in webcam)

            {

                comboBox1.Items.Add(item.Name); //kameraları combobox a dolduruyoruz.

            }

            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cam = new

            VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString); //yandaki tanımladığımız cam değişkenine comboboxtta seçilmiş olan kamerayı atıyoruz.

            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);

            cam.Start(); // Kamerayı başlatıyoruz.
        }
        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)

        {

            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone(); // Kameradan alınan görüntüyü picturebox a atıyoruz.

            pictureBox1.Image = bmp;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*  SaveFileDialog swf = new SaveFileDialog();

            swf.Filter = "(*.jpg)|*.jpg|Bitma*p(*.bmp)|*.bmp";

            DialogResult dialog = swf.ShowDialog();  //Resmi çekiyoruz ve aşağıda da kaydediyoruz.


            if (dialog == DialogResult.OK)

            {

                pictureBox1.Image.Save(swf.FileName);

            } */
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
