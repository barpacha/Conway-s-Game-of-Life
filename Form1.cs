using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GOL;
namespace gol_test_visual
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            field = new Field();
            field.init(bitmapsize, bitmapsize, 80);
            TimerOn();
        }
        private void TimerOn()
        {
            timer1.Tick += new EventHandler(OnTimedEvent);
            timer1.Interval = timeRate;
            OnTimedEvent(this,null);
            timer1.Start();
        }
        private Bitmap bitmap(int x, int y)
        {
            Bitmap bitmp = new Bitmap(x, y);
            Random rnd = new Random();
            Organism[,] m =  field.frame();
            for (int i = 0; i < y; i++)
                for (int j = 0; j < x; j++)
                {
                    if (m[j,i].id == 1)
                        bitmp.SetPixel(j, i, Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                    else bitmp.SetPixel(j, i, Color.FromName("write"));
                }
            return bitmp;
        }
        private void OnTimedEvent(Object source, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(bitmap(bitmapsize, bitmapsize), new Size(pictureSize, pictureSize));
            pictureBox1.Update();
            textBox1.Text = field.iter.ToString();
            textBox1.Update();
        }
        private void Form1_Resize(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            pictureSize = Math.Min(control.Size.Width, control.Size.Height);
            textBox1.Location = new System.Drawing.Point(pictureSize + 20, 13);
            Image_Resize();
        }
        private void Image_Resize()
        {
            pictureBox1.Width = pictureSize;
            pictureBox1.Height = pictureSize;
            pictureBox1.Image = new Bitmap(pictureBox1.Image, new Size(pictureSize, pictureSize));
            pictureBox1.Update();
        }
    }
}
