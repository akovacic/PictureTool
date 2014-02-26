﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace PictureTool {
  public partial class Form1 {
    private Rectangle PointRectangle(Point p1, Point p2) {
      Rectangle rectangle = new Rectangle();
      rectangle.X = (p1.X > p2.X ? p2.X : p1.X);
      rectangle.Y = (p1.Y > p2.Y ? p2.Y : p1.Y);
      rectangle.Width = Math.Abs(p1.X - p2.X);
      rectangle.Height = Math.Abs(p1.Y - p2.Y);

      return rectangle;
    }

    private void NewImage() {
      canvas.Refresh();
      canvas.Image = null;
      this.Text = "untitled";

      ClearHistory();

      dirty = false;
    }

    private void OpenImage() {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp";
      if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
        canvas.Image = ResizeImageToFit((Image)Image.FromFile(openFileDialog.FileName), new Size(canvas.Width, canvas.Height));
        this.Text = openFileDialog.FileName;
        ClearHistory();
      }
    }

    private DialogResult SaveImage() {
      DialogResult answer;
      ImageFormat format;

      Bitmap image = (Bitmap)canvas.Image;
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.FileName = this.Text;
      saveFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp";
      answer = saveFileDialog.ShowDialog();
      if (answer == DialogResult.OK) {
        switch (Path.GetExtension(saveFileDialog.FileName)) {
          case ".jpg":
          case ".jpeg": format = ImageFormat.Jpeg; break;
          case ".png": format = ImageFormat.Png; break;
          case ".gif": format = ImageFormat.Gif; break;
          case ".bmp": format = ImageFormat.Bmp; break;
          default: format = ImageFormat.Jpeg; break;
        }
        image.Save(saveFileDialog.FileName, format);
        this.Text = saveFileDialog.FileName;
        canvas.Image = image;
        dirty = false;
      }

      return answer;
    }

    private void Undo() {
      history.Pop();
      canvas.Image = history.Peek();

      if (history.Count == 1) {
        undoButtonQuick.Enabled = false;
        undoButtonMenu.Enabled = false;
      }
    }

    private void ResolveDirty(Action action) {
      if (!dirty) action();
      else {
        DialogResult answer = MessageBox.Show("Save image?", "Picture tool", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        if (answer == DialogResult.Yes) answer = SaveImage();
        if (answer != DialogResult.Cancel) action();
      }
    }

    private void Changed() {
      canvas.Image = ImageFromCanvas();
      history.Push(canvas.Image);
      undoButtonQuick.Enabled = true;
      undoButtonMenu.Enabled = true;
      dirty = true;
    }

    private void ClearHistory() {
      history.Clear();
      history.Push(canvas.Image);
      undoButtonQuick.Enabled = false;
      undoButtonMenu.Enabled = false;
    }

    private Image ImageFromCanvas() {
      Image image = new Bitmap(canvas.Width, canvas.Height);
      Graphics graphics = Graphics.FromImage(image);
      Rectangle rectangle = canvas.RectangleToScreen(canvas.ClientRectangle);
      graphics.CopyFromScreen(rectangle.Location, Point.Empty, canvas.Size);
      graphics.Dispose();

      return image;
    }

    private Rectangle CanvasFrame() {
      return new Rectangle(canvas.Location.X, canvas.Location.Y, canvas.Width, canvas.Height);
    }

    private void ApplySepia() {
      Graphics graphics = canvas.CreateGraphics();
      ImageAttributes sepiaAttributes = new ImageAttributes();
      sepiaAttributes.SetColorMatrix(new ColorMatrix(
        new float[][] {
          new float[]{.393f, .349f, .272f, 0, 0},
          new float[]{.769f, .686f, .534f, 0, 0},
          new float[]{.189f, .168f, .131f, 0, 0},
          new float[]{0, 0, 0, 1, 0},
          new float[]{0, 0, 0, 0, 1}
        }
      ));
      graphics.DrawImage(canvas.Image, CanvasFrame(), 0, 0, canvas.Width, canvas.Height, GraphicsUnit.Pixel, sepiaAttributes);
    }

    private void ApplyGrayscale() {
      Graphics graphics = canvas.CreateGraphics();
      ImageAttributes grayscaleAttributes = new ImageAttributes();
      grayscaleAttributes.SetColorMatrix(new ColorMatrix(
         new float[][]  {
           new float[] {0.299f, 0.299f, 0.299f, 0, 0},
           new float[] {0.587f, 0.587f, 0.587f, 0, 0},
           new float[] {.114f, .114f, .114f, 0, 0},
           new float[] {0, 0, 0, 1, 0},
           new float[] {0, 0, 0, 0, 1}
        }
      ));
      graphics.DrawImage(canvas.Image, CanvasFrame(), 0, 0, canvas.Width, canvas.Height, GraphicsUnit.Pixel, grayscaleAttributes);
    }

    private Image ResizeImageToFit(Image image, Size size) {
      double aspectRatio = (double)image.Width / (double)image.Height;
      canvas.Width = (int)((double)canvas.Height * aspectRatio);
      return new Bitmap(image, new Size(canvas.Width, canvas.Height));
    }

    private void ApplyRotation(int angle) {
      Bitmap bmp = new Bitmap(canvas.Image.Width, canvas.Image.Height);
      Graphics gfx = canvas.CreateGraphics();

      gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
      gfx.RotateTransform(angle);
      gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
      gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
      gfx.DrawImage(canvas.Image, new Point(0, 0));
      gfx.Dispose();

      if (Math.Abs(angle) == 90) {
        int temp = canvas.Width;
        canvas.Width = canvas.Height;
        canvas.Height = temp;
      }
    }
  }
}
