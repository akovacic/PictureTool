using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PictureTool {
    public partial class Resize : Form {
      public Form1 pictureTool;
 
        public Resize() {
          InitializeComponent();
        }

        public void Resize_Load(object sender, EventArgs e) {
          WidthNumericUpDown.Value = pictureTool.canvas.Width;
          HeightNumericUpDown.Value = pictureTool.canvas.Height;
          aspectRatioCheckBox.Checked = pictureTool.useAspectRatio;
        }

        public void CancelButton_Click(object sender, EventArgs e) {
          this.Close();
        }

        public void OKButton_Click(object sender, EventArgs e) {
          int width = (int)WidthNumericUpDown.Value;
          int height = (int)HeightNumericUpDown.Value;

          pictureTool.canvas.SizeMode = PictureBoxSizeMode.Normal;
          Image newImage = pictureTool.canvas.Image;
          pictureTool.canvas.Size = new Size(width, height);
          pictureTool.ChangeImage(new Bitmap(newImage, pictureTool.canvas.Size));
          this.Close();
        }

        public void WidthChanged(object sender, EventArgs e) {
          if (pictureTool.useAspectRatio) {
            double aspectRatio = (double)pictureTool.canvas.Height / (double)pictureTool.canvas.Width;
            int width = (int)WidthNumericUpDown.Value;
            HeightNumericUpDown.Value = (int)((double)width * aspectRatio);
          }
        }

        public void HeightChanged(object sender, EventArgs e) {
          if (pictureTool.useAspectRatio) {
            double aspectRatio = (double)pictureTool.canvas.Width / (double)pictureTool.canvas.Height;
            int height = (int)HeightNumericUpDown.Value;
            WidthNumericUpDown.Value = (int)((double)height * aspectRatio);
          }
        }

        public void AspectRatioToggled(object sender, EventArgs e) {
          pictureTool.useAspectRatio = aspectRatioCheckBox.Checked;
        }
    }
}
