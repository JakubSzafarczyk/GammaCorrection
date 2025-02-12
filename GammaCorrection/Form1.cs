using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;



namespace GammaCorrection
{
    public partial class FormGamCor : Form
    {
        
        Stopwatch stopwatch = new Stopwatch();
        private Image source;
        private Image result;

        public FormGamCor()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }


        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            openFileToLoadImage.ShowDialog();
            string filePath = openFileToLoadImage.FileName;
            source = Image.FromFile(filePath);
            pictureBoxLoad.Image = source;

        }

        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            if (source != null)
            {
                if (saveFileResult.ShowDialog() == DialogResult.OK)
                {
                    ImageFormat format;
                    switch (System.IO.Path.GetExtension(saveFileResult.FileName).ToLower())
                    {
                        case ".jpg":
                        case ".jpeg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".png":
                            format = ImageFormat.Png;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                        default:
                            MessageBox.Show("Unsupported file format.");
                            return;
                    }

                    result.Save(saveFileResult.FileName, format);
                    MessageBox.Show("Image saved successfully!");

                }
            }
            else
            {
                labelCorrectionStatus.Text = "Load image!";
            }
        }

        private void buttonCorrectImage_Click(object sender, EventArgs e)
        {
            if (checkBoxAsm.Checked && !checkBoxC.Checked)
            {
                if (source != null)
                {

                    asmCorrection();

                }
                else
                {
                    labelCorrectionStatus.Text = "Load image!";
                }
            }
            else if (!checkBoxAsm.Checked && checkBoxC.Checked)
            {
                if (source != null)
                {

                    cSharpCorrection();

                }
                else
                {
                    labelCorrectionStatus.Text = "Load image!";
                }
            }
            else if (checkBoxAsm.Checked && checkBoxC.Checked)
            {
                labelCorrectionStatus.Text = "Chose only one!";
            }
            else
            {
                if (source != null)
                {
                    labelCorrectionStatus.Text = "Chose method!";
                }
            }
        }

        private void trackBarGamma_Scroll(object sender, EventArgs e)
        {
            double gamma = trackBarGamma.Value / 100.0;
            labelGamma.Text = "Gamma: " + gamma.ToString();
        }

        public byte[] getImagePixels(Bitmap bitmap)
        {
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            byte[] pixelValues = new byte[Math.Abs(bmpData.Stride) * bitmap.Height];
            Marshal.Copy(bmpData.Scan0, pixelValues, 0, pixelValues.Length);
            bitmap.UnlockBits(bmpData);
            return pixelValues;
        }

        public void setImagePixels(Bitmap bitmap, byte[] pixelValues)
        {
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            Marshal.Copy(pixelValues, 0, bmpData.Scan0, pixelValues.Length);
            bitmap.UnlockBits(bmpData);
        }


        private List<int> threadsDivision(byte[] imagePixels)
        {
            List<int> divisionIndex = new List<int>();
            int partSize = imagePixels.Length / trackBarThreads.Value;
            int position = 0;
            for (int i = 0; i < trackBarThreads.Value; i++)
            {
                divisionIndex.Add(position);
                position += partSize;
            }
            return divisionIndex;
        }

        private void cSharpCorrection()
        {
            stopwatch.Start();
            byte[] lutTable = GamCorCSharp.GammaCorrection.GenerateLUTTable(trackBarGamma.Value/100);
            Bitmap bitmap = (Bitmap)source.Clone();
            result = bitmap;
            byte[] pixelValues = getImagePixels(bitmap);
            List<int> threads = threadsDivision(pixelValues);
            int partSize = pixelValues.Length;
            if (threads.Count > 1)
            {
                partSize = threads[1] - threads[0];
            }

            int completedThreads = 0;
            object lockObject = new object();

            // Create a manual reset event to wait for all threads to finish
            ManualResetEvent resetEvent = new ManualResetEvent(false);

            foreach (var start in threads)
            {
                // Queue the work item to the ThreadPool
                ThreadPool.QueueUserWorkItem((state) =>
                {
                    int startIndex = (int)state;
                    // Perform gamma correction on the assigned segment
                    GamCorCSharp.GammaCorrection.PerformGammaCorrection(pixelValues, lutTable, startIndex, startIndex + partSize);
                    // Check if all threads are completed
                    lock (lockObject)
                    {
                        completedThreads++;
                        if (completedThreads == threads.Count)
                        {
                            resetEvent.Set();
                        }
                    }
                }, start);
            }

            // Wait for all threads to complete
            resetEvent.WaitOne();
            setImagePixels(bitmap, pixelValues);
            pictureBoxResult.Image = bitmap;

            stopwatch.Stop();
            labelCorrectionTimer.Text = "Correction time: " + stopwatch.ElapsedMilliseconds.ToString() + "ms";
            stopwatch.Reset();
            labelCorrectionStatus.Text = "Correction complete!";
            pictureBoxResult.Image = result;
        }

        private void trackBarThreads_ValueChanged(object sender, EventArgs e)
        {
            TrackBar trackBar = sender as TrackBar; // Cast sender to TrackBar
            int[] allowedValues = { 1, 4, 8, 12, 16, 20, 24, 28, 32, 36, 40, 44, 48, 52, 56, 60, 64 };

            // Snap value to nearest allowed value
            int newValue = allowedValues.OrderBy(v => Math.Abs(v - trackBar.Value)).First();

            if (trackBar.Value != newValue)
            {
                trackBar.Value = newValue; // Update snapped value
            }
            labelThreads.Text = "Threads: " + trackBarThreads.Value.ToString();
        }

        private void asmCorrection()
        {
            stopwatch.Start();
            int[] lutTable = AsmInterface.GenerateLUTTable(trackBarGamma.Value / 100);
            Bitmap bitmap = (Bitmap)source.Clone();
            result = bitmap;
            byte[] pixelValues = getImagePixels(bitmap);
            List<int> threads = threadsDivision(pixelValues);
            int partSize = pixelValues.Length;
            if (threads.Count > 1)
            {
                partSize = threads[1] - threads[0];
            }

            int completedThreads = 0;
            object lockObject = new object();

            // Create a manual reset event to wait for all threads to finish
            ManualResetEvent resetEvent = new ManualResetEvent(false);

            foreach (var start in threads)
            {
                // Queue the work item to the ThreadPool
                ThreadPool.QueueUserWorkItem((state) =>
                {
                    int startIndex = (int)state;
                    // Perform gamma correction on the assigned segment
                    AsmInterface.PerformGammaCorrection(pixelValues, lutTable, startIndex, startIndex + partSize);
                    // Check if all threads are completed
                    lock (lockObject)
                    {
                        completedThreads++;
                        if (completedThreads == threads.Count)
                        {
                            resetEvent.Set();
                        }
                    }
                }, start);
            }

            // Wait for all threads to complete
            resetEvent.WaitOne();
            setImagePixels(bitmap, pixelValues);
            pictureBoxResult.Image = bitmap;

            stopwatch.Stop();
            labelCorrectionTimer.Text = "Correction time: " + stopwatch.ElapsedMilliseconds.ToString() + "ms";
            stopwatch.Reset();
            labelCorrectionStatus.Text = "Correction complete!";
            pictureBoxResult.Image = result;
        }
    }
}
