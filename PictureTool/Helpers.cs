using System;
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
      canvas.Image = new Bitmap(canvas.Size.Width, canvas.Size.Height);
      graphics = Graphics.FromImage(canvas.Image);
      this.Text = "untitled";

      ClearHistory();

      dirty = false;
    }

    private void OpenImage() {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp";
      if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
        canvas.SizeMode = PictureBoxSizeMode.AutoSize;
        canvas.Image = Image.FromFile(openFileDialog.FileName);
        this.Text = openFileDialog.FileName;
        ClearHistory();
      }
    }

    private DialogResult SaveImage() {
      DialogResult answer;
      ImageFormat format;

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
        canvas.Image.Save(saveFileDialog.FileName, format);
        this.Text = saveFileDialog.FileName;
        dirty = false;
      }

      return answer;
    }

    private void ResolveDirty(Action action) {
      if (!dirty) action();
      else {
        DialogResult answer = MessageBox.Show("Save image?", "Picture tool", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        if (answer == DialogResult.Yes) answer = SaveImage();
        if (answer != DialogResult.Cancel) action();
      }
    }

    private void ClearHistory() {
      history.Clear();
      history.Push(graphics.Save());
      undoButtonQuick.Enabled = false;
      undoButtonMenu.Enabled = false;
    }

    public void Changed() {
      history.Push(graphics.Save());
      undoButtonQuick.Enabled = true;
      undoButtonMenu.Enabled = true;
      dirty = true;
    }

    private void Undo() {
      if (history.Count > 1) {
        graphics.Restore(history.Pop());
        canvas.Invalidate();
      }

      if (history.Count == 1) {
        undoButtonQuick.Enabled = false;
        undoButtonMenu.Enabled = false;
      }
    }

    private Rectangle CanvasFrame() {
      return new Rectangle(canvas.Location.X, canvas.Location.Y, canvas.Width, canvas.Height);
    }

    private void ApplySepia() {
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

      graphics.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
      graphics.RotateTransform(angle);
      graphics.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
      graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
      graphics.DrawImage(canvas.Image, new Point(0, 0));
      graphics.Dispose();

      if (Math.Abs(angle) == 90) {
        int temp = canvas.Width;
        canvas.Width = canvas.Height;
        canvas.Height = temp;
      }
    }

    public void ApplyTemplate(int rows, int columns) {
      int width = canvas.Width / columns;
      int height = canvas.Height / rows;
      Image miniImage = new Bitmap(canvas.Image, new Size(width, height));
      canvas.SizeMode = PictureBoxSizeMode.Normal;
      canvas.Size = new Size(columns * width, rows * height);

      Bitmap newImage = new Bitmap(canvas.Size.Width, canvas.Size.Height);
      Graphics graphics = Graphics.FromImage(newImage);

      int startX = 0, startY = 0;

      for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < columns; ++j) {
          graphics.DrawImage(miniImage, new Point(startX, startY));
          startX += width;
        }
        startX = 0;
        startY += height;
      }

      canvas.Image = newImage;
    }
  }
}
