using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PictureTool
{
    public partial class Resize : Form
    {
        public Form1 pictureTool;
 
        public Resize()
        {
            InitializeComponent();
        }

        private void Resize_Load(object sender, EventArgs e)
        {
            WidthNumericUpDown.Value = pictureTool.canvas.Width;
            HeightNumericUpDown.Value = pictureTool.canvas.Height;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
          int width = (int)WidthNumericUpDown.Value;
          int height = (int)HeightNumericUpDown.Value;

          pictureTool.canvas.SizeMode = PictureBoxSizeMode.Normal;
          Image newImage = pictureTool.canvas.Image;
          pictureTool.canvas.Size = new Size(width, height);
          if (newImage != null) pictureTool.canvas.Image = new Bitmap(newImage, pictureTool.canvas.Size);
          pictureTool.Changed();
          this.Close();     
        }

        private void WidthNumericUpDown_ValueChanged(object sender, KeyEventArgs e) {
          double aspectRatio = (double)pictureTool.canvas.Height / (double)pictureTool.canvas.Width;
          int width = (int)WidthNumericUpDown.Value;
          HeightNumericUpDown.Value = (int)((double)width * aspectRatio);
        }

        private void HeightNumericUpDown_ValueChanged(object sender, KeyEventArgs e) {
          double aspectRatio = (double)pictureTool.canvas.Width / (double)pictureTool.canvas.Height;
          int height = (int)HeightNumericUpDown.Value;
          WidthNumericUpDown.Value = (int)((double)height * aspectRatio);
        }

        private void WidthNumericUpDown_MouseUp(object sender, MouseEventArgs e) {
          double aspectRatio = (double)pictureTool.canvas.Height / (double)pictureTool.canvas.Width;
          int width = (int)WidthNumericUpDown.Value;
          HeightNumericUpDown.Value = (int)((double)width * aspectRatio);
        }

        private void HeightNumericUpDown_MouseUp(object sender, MouseEventArgs e) {
          double aspectRatio = (double)pictureTool.canvas.Width / (double)pictureTool.canvas.Height;
          int height = (int)HeightNumericUpDown.Value;
          WidthNumericUpDown.Value = (int)((double)height * aspectRatio);
        }
    }
}
