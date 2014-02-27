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
    public Rectangle PointRectangle(Point p1, Point p2) {
      Rectangle rectangle = new Rectangle();
      rectangle.X = (p1.X > p2.X ? p2.X : p1.X);
      rectangle.Y = (p1.Y > p2.Y ? p2.Y : p1.Y);
      rectangle.Width = Math.Abs(p1.X - p2.X);
      rectangle.Height = Math.Abs(p1.Y - p2.Y);

      return rectangle;
    }

    public void NewImage() {
      ChangeImage(new Bitmap(canvas.Width, canvas.Height));
      graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(canvas.Location, canvas.Size));
      this.Text = "untitled";

      ClearHistory();

      dirty = false;
    }

    public void OpenImage() {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp";
      if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
        canvas.SizeMode = PictureBoxSizeMode.AutoSize;
        ChangeImage(Image.FromFile(openFileDialog.FileName));
        this.Text = openFileDialog.FileName;
        ClearHistory();
      }
    }

    public DialogResult SaveImage() {
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

    public void ResolveDirty(Action action) {
      if (!dirty) action();
      else {
        DialogResult answer = MessageBox.Show("Save image?", "Picture tool", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        if (answer == DialogResult.Yes) answer = SaveImage();
        if (answer != DialogResult.Cancel) action();
      }
    }

    public void ClearHistory() {
      history.Clear();
      history.Push(new Bitmap(canvas.Image));
      undoButtonQuick.Enabled = false;
      undoButtonMenu.Enabled = false;
    }

    public void Changed() {
      canvas.Invalidate();
      history.Push(new Bitmap(canvas.Image));
      undoButtonQuick.Enabled = true;
      undoButtonMenu.Enabled = true;
      dirty = true;
    }

    public void Undo() {
      if (history.Count > 1) {
        history.Pop();
        ChangeImage(history.Peek());
      }

      if (history.Count == 1) {
        undoButtonQuick.Enabled = false;
        undoButtonMenu.Enabled = false;
      }
    }

    public Rectangle CanvasFrame() {
      return new Rectangle(canvas.Location.X, canvas.Location.Y, canvas.Width, canvas.Height);
    }

    public void ApplySepia() {
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

    public void ApplyGrayscale() {
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

    public void ApplyRotation(float angle) {
      Color bkColor = Color.White;
      angle = angle % 360;
      if (angle > 180)
        angle -= 360;

      System.Drawing.Imaging.PixelFormat pf = default(System.Drawing.Imaging.PixelFormat);
      if (bkColor == Color.Transparent) {
        pf = System.Drawing.Imaging.PixelFormat.Format32bppArgb;
      }
      else {
        pf = canvas.Image.PixelFormat;
      }

      float sin = (float)Math.Abs(Math.Sin(angle * Math.PI / 180.0)); // this function takes radians
      float cos = (float)Math.Abs(Math.Cos(angle * Math.PI / 180.0)); // this one too
      float newImgWidth = sin * canvas.Image.Height + cos * canvas.Image.Width;
      float newImgHeight = sin * canvas.Image.Width + cos * canvas.Image.Height;
      float originX = 0f;
      float originY = 0f;

      if (angle > 0) {
        if (angle <= 90)
          originX = sin * canvas.Image.Height;
        else {
          originX = newImgWidth;
          originY = newImgHeight - sin * canvas.Image.Width;
        }
      }
      else {
        if (angle >= -90)
          originY = sin * canvas.Image.Width;
        else {
          originX = newImgWidth - sin * canvas.Image.Height;
          originY = newImgHeight;
        }
      }

      Bitmap newImg = new Bitmap((int)newImgWidth, (int)newImgHeight, pf);
      Graphics g = Graphics.FromImage(newImg);
      g.Clear(bkColor);
      g.TranslateTransform(originX, originY); // offset the origin to our calculated values
      g.RotateTransform(angle); // set up rotate
      g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
      g.DrawImageUnscaled(canvas.Image, 0, 0); // draw the image at 0, 0
      g.Dispose();

      ChangeImage(newImg);
    }

    public void ApplyTemplate(int rows, int columns) {
      int width = canvas.Width / columns;
      int height = canvas.Height / rows;
      Image miniImage = new Bitmap(canvas.Image, new Size(width, height));
      canvas.SizeMode = PictureBoxSizeMode.Normal;
      canvas.Size = new Size(columns * width, rows * height);
      Bitmap newImage = new Bitmap(canvas.Width, canvas.Height);
      Graphics g = Graphics.FromImage(newImage);

      int startX = 0, startY = 0;

      for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < columns; ++j) {
          g.DrawImage(miniImage, new Point(startX, startY));
          startX += width;
        }
        startX = 0;
        startY += height;
      }

      ChangeImage(new Bitmap(newImage, canvas.Size));
    }

    public void ChangeImage(Image image) {
      canvas.Image = image;
      canvas.Size = image.Size;
      graphics = Graphics.FromImage(canvas.Image);
    }
  }
}
