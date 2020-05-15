using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using openalprnet;
using AForge.Video;
using AForge.Video.DirectShow;

namespace PlakaTanima
{
    public partial class frmPlakaBul : Form
    {

        private FilterInfoCollection webcam; //BU değişken bilgisayarda kaç kamera bağlıysa onları tutan bir dizi.

        private VideoCaptureDevice cam; //Bizim kullanacağımız aygıt. 
        public frmPlakaBul()
        {
            InitializeComponent();
        }

        public static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public Rectangle boundingRectangle(List<Point> points)
        {
            // Add checks here, if necessary, to make sure that points is not null,
            // and that it contains at least one (or perhaps two?) elements

            var minX = points.Min(p => p.X);
            var minY = points.Min(p => p.Y);
            var maxX = points.Max(p => p.X);
            var maxY = points.Max(p => p.Y);

            return new Rectangle(new Point(minX, minY), new Size(maxX - minX, maxY - minY));
        }

        private static Image cropImage(Image img, Rectangle cropArea)
        {
            var bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        public static Bitmap combineImages(List<Image> images)
        {
            //read all images into memory
            Bitmap finalImage = null;

            try
            {
                var width = 0;
                var height = 0;

                foreach (var bmp in images)
                {
                    width += bmp.Width;
                    height = bmp.Height > height ? bmp.Height : height;
                }

                //create a bitmap to hold the combined image
                finalImage = new Bitmap(width, height);

                //get a graphics object from the image so we can draw on it
                using (var g = Graphics.FromImage(finalImage))
                {
                    //set background color
                    g.Clear(Color.Black);

                    //go through each image and draw it on the final image
                    var offset = 0;
                    foreach (Bitmap image in images)
                    {
                        g.DrawImage(image,
                                    new Rectangle(offset, 0, image.Width, image.Height));
                        offset += image.Width;
                    }
                }

                return finalImage;
            }
            catch (Exception ex)
            {
                if (finalImage != null)
                    finalImage.Dispose();

                throw ex;
            }
            finally
            {
                //clean up memory
                foreach (var image in images)
                {
                    image.Dispose();
                }
            }
        }

        private void processImageFile(string fileName)
        {
            resetControls();
            var region = rbUSA.Checked ? "us" : "eu";
            String config_file = Path.Combine(AssemblyDirectory, "openalpr.conf");
            String runtime_data_dir = Path.Combine(AssemblyDirectory, "runtime_data");
            using (var alpr = new AlprNet(region, config_file, runtime_data_dir))
            {
                if (!alpr.IsLoaded())
                {
                    lbxPlates.Items.Add("Error initializing OpenALPR");
                    return;
                }
                picOriginal.ImageLocation = fileName;
                picOriginal.Load();

                var results = alpr.Recognize(fileName);

                var images = new List<Image>(results.Plates.Count());
                var i = 1;
                foreach (var result in results.Plates)
                {
                    var rect = boundingRectangle(result.PlatePoints);
                    var img = Image.FromFile(fileName);
                    var cropped = cropImage(img, rect);
                    images.Add(cropped);

                    lbxPlates.Items.Add("\t\t-- Plate #" + i++ + " --");
                    foreach (var plate in result.TopNPlates)
                    {
                        lbxPlates.Items.Add(string.Format(@"{0} {1}% {2}",
                                                          plate.Characters.PadRight(12),
                                                          plate.OverallConfidence.ToString("N1").PadLeft(8),
                                                          plate.MatchesTemplate.ToString().PadLeft(8)));
                    }
                }

                if (images.Any())
                {
                    picLicensePlate.Image = combineImages(images);
                }
            }
        }

        private void resetControls()
        {
            picOriginal.Image = null;
            picLicensePlate.Image = null;
            lbxPlates.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webcam = new

          FilterInfoCollection(FilterCategory.VideoInputDevice); //webcam dizisine mevcut kameraları dolduruyoruz.

            foreach (FilterInfo item in webcam)

            {

                comboBox1.Items.Add(item.Name); //kameraları combobox a dolduruyoruz.

            }

            comboBox1.SelectedIndex = 0;
            resetControls();
        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                //openFileDialog.FileName =
                processImageFile(openFileDialog.FileName);
            }
        }

        private void rbUSA_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            button3.Visible = false;
            button2.Visible = false;
            comboBox1.Visible = false;
            webcam = new

         FilterInfoCollection(FilterCategory.VideoInputDevice); //webcam dizisine mevcut kameraları dolduruyoruz.

            foreach (FilterInfo item in webcam)

            {

                comboBox1.Items.Add(item.Name); //kameraları combobox a dolduruyoruz.

            }

            comboBox1.SelectedIndex = 0;
        }

        private void picOriginal_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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
                processImageFile(openFileDialog.FileName);

                //  processImageFile(fileName);

            }
            cam.Start();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void picLicensePlate_Click(object sender, EventArgs e)
        {

        }
      
        private void lbxPlates_SelectedIndexChanged(object sender, EventArgs e)
        {
          
           
            

    }

        private void button4_Click(object sender, EventArgs e)
        {
            //  lbxPlates.SelectedItem = frmAracKayit.textBox1.Text;


          /*  string secilen = lbxPlates.SelectedItem.ToString();
            frmAracKayit frmAracKayit = new frmAracKayit();
            
            frmAracKayit.gelen = secilen.Remove(7);
            frmAracKayit.Show();
            this.Hide();*/

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmAnaEkran f10 = new frmAnaEkran();
            f10.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string secilen = lbxPlates.SelectedItem.ToString();
            frmAracKayit frmAracKayit = new frmAracKayit();

            frmAracKayit.gelen = secilen.Remove(7);
            frmAracKayit.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            frmAnaEkran f65 = new frmAnaEkran();
            f65.Show();
            this.Hide();
        }
    }
}