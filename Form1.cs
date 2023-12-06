using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace cam_rewrite
{


    public partial class Form1 : Form
    {
        FilterInfoCollection fic;
        VideoCaptureDevice camera;
        int Old_X = 0;
        int Old_Y = 0;
        int New_X = 0;
        int New_Y = 0;
        bool saveposition = false;
        bool lineon = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterinfo in fic)
            {
                selectcam.Items.Add(filterinfo.Name);
                selectcam.SelectedIndex = 0;
                camera = new VideoCaptureDevice();
            }
        }
        void programloop(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            updateframe(eventArgs, frame);
            GrabPixels(eventArgs, frame);
            DisplaySpeed(eventArgs, frame);

        }
        void DisplaySpeed(NewFrameEventArgs eventArgs, Bitmap frame)
        {
            int speedX = New_X - Old_X;
            int speedY = New_Y - Old_Y;
            test("oldspeedx: ", Old_X.ToString() + " oldspeedY: " + Old_Y.ToString());

            test("newspeedx: ", New_X.ToString() + " newspeedY: " + New_Y.ToString());

            if (speedX < 0) { speedX = -speedX; }
            if (speedY < 0) { speedY = -speedY; }

            //pythagoras theorem used to determine how much the object moved       
            double speed = Math.Sqrt(speedX * speedX + speedY * speedY);
            // Round to one decimal place
            speed = Math.Round(speed, 1);

            // Update UI control on the UI thread
            this.Invoke((MethodInvoker)delegate
            {
                speedLB.Text = "speedX: " + speedX.ToString() + " pixel/frame";
                speedYLB.Text = "speedY: " + speedY.ToString() + " pixel/frame";
                totalLB.Text = "speed: " + speed.ToString() + " pixel/frame";
                Thread.Sleep(1000);
            });
            //code that has to be revamped before being added
            //used for displaying the highest speed an object has reached
            /*
            OtopS = speed;
            speed1.Text = X.ToString() + " " + Y.ToString();

            //SpeedTB.Text = speed.ToString() + "cm/s";
            if (OtopS >= topS)
            {
                topS = OtopS;
                topspeed.Text = topS.ToString() + "cm/s";
            }*/
        }
        //most complicated and hardes part of the code
        void GrabPixels(NewFrameEventArgs eventArgs, Bitmap frame)
        {
            Rectangle rect = new Rectangle(0, 0, frame.Width, frame.Height);
            BitmapData bmpData = frame.LockBits(rect, ImageLockMode.ReadOnly, frame.PixelFormat);
            bool didhit = false;
            try
            {
                int bytesPerPixel = Image.GetPixelFormatSize(frame.PixelFormat) / 8;
                int stride = bmpData.Stride;

                IntPtr scan0 = bmpData.Scan0;
                int x = 0;
                int y = 0;
                for (y = 0; y < frame.Height; y += 100)
                {
                    for (x = 0; x < frame.Width; x += 100)
                    {
                        int index = y * stride + x * bytesPerPixel;

                        byte[] pixelData = new byte[bytesPerPixel];
                        Marshal.Copy(scan0 + index, pixelData, 0, bytesPerPixel);

                        float brightness = 0;

                        for (int i = 0; i < pixelData.Length; i++)
                        {
                            brightness += pixelData[i];
                        }

                        brightness /= pixelData.Length;
                        if (brightness >= 208)
                        {
                            test("pixelcheck: ", x.ToString() + ", " + y.ToString() + "savepos: " + saveposition.ToString());
                            if (!saveposition)
                            {
                                Old_X = x;
                                Old_Y = y;
                            }
                            else { New_X = x; New_Y = y; }
                            saveposition = !saveposition;
                            didhit = true;

                        }
                        if (didhit) { break; }
                    }
                    if (didhit) { break; }
                }
                drawscreen(x, y, eventArgs, frame);
            }
            finally
            {
                frame.UnlockBits(bmpData);
            }
        }
        //renders visualisation for code compleatly optional it just shows you what the code is calculating
        void drawscreen(int x, int y, NewFrameEventArgs eventArgs, Bitmap frame)
        {
            try
            {
                Bitmap newframe = (Bitmap)eventArgs.Frame.Clone();
                using (Graphics graphics = Graphics.FromImage(newframe))
                {
                    Brush redBrush = Brushes.Red;
                    Brush blueBrush = Brushes.Blue;

                    graphics.FillRectangle(redBrush, x, y, 100, 100);
                    
                    if (lineon)
                    {

                        Pen RedPen = new Pen(Color.Red, 50);
                        Pen GreenPen = new Pen(Color.Green, 50);

                        //male eine gerade linie für die X kathete
                        graphics.DrawLine(RedPen, Old_X, Old_Y, New_X, Old_Y);
                        graphics.DrawLine(RedPen, New_X, Old_Y, New_X, New_Y);
                        graphics.DrawLine(GreenPen, Old_X, Old_Y, New_X, New_Y);

                    }
                }

                new_display.Image = newframe;
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }

        void test(object sender, string log)
        {
            Debug.WriteLine(sender + log);
        }

        void updateframe(NewFrameEventArgs eventArgs, Bitmap frame)
        {

            old_display.Image = (Bitmap)eventArgs.Frame.Clone();

        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            camera = new VideoCaptureDevice(fic[selectcam.SelectedIndex].MonikerString);

            camera.NewFrame += programloop;

            camera.Stop();
            camera.Start();

        }
        //used to check console commands
        private void ConsoleTB_TextChanged(object sender, EventArgs e)
        {
            if (ConsoleTB.Text == "drawlines") { lineon = !lineon; ConsoleTB.Text = ""; }
        }

        //i cant remove this and i dont know why
        private void totalLB_Click(object sender, EventArgs e)
        {

        }
    }
}