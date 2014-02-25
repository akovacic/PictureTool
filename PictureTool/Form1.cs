using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace PictureTool {
  enum Tool { Pencil, Brush, Line, Rectangle, Ellipse, Eraser };

  public partial class Form1 : Form {
    private bool draw, fill, dirty
    private Color color;
    private Tool tool;
    private int size;
    private Point start, current, end;
    private Stack<Image> history = new Stack<Image>();

    public Form1() {
      InitializeComponent();

      tool = Tool.Pencil;
      color = Color.Black;
    }

    private void Form1_Load(object sender, EventArgs e) {
      NewImage();
    }

    private void newButton_Click(object sender, EventArgs e)  { ResolveDirty(NewImage); }
    private void openButton_Click(object sender, EventArgs e) { ResolveDirty(OpenImage); }
    private void saveButton_Click(object sender, EventArgs e) { SaveImage(); }
    private void undoButton_Click(object sender, EventArgs e) { Undo(); }

    private void pencilButton_Click(object sender, EventArgs e) {
      tool = Tool.Pencil;
      ResetToolSelection();
      pencilButton.Checked = true;
    }

    private void brushButton_Click(object sender, EventArgs e) {
      tool = Tool.Brush; size = 10;
      ResetToolSelection();
      brushButton.Checked = true;
    }

    private void lineButton_Click(object sender, EventArgs e) {
      tool = Tool.Line; size = 1;
      ResetToolSelection();
      lineButton.Checked = true;
    }

    private void rectangleButton_Click(object sender, EventArgs e) {
      tool = Tool.Rectangle; size = 1;
      ResetToolSelection();
      rectangleButton.Checked = true;
    }

    private void ellipseButton_Click(object sender, EventArgs e) {
      tool = Tool.Ellipse; size = 1;
      ResetToolSelection();
      ellipseButton.Checked = true;
    }

    private void eraserButton_Click(object sender, EventArgs e) {
      tool = Tool.Eraser; size = 10;
      ResetToolSelection();
      eraserButton.Checked = true;
    }

    private void fillButton_Click(object sender, EventArgs e) {
      fill = true;
      fillButton.Checked = true;
      noFillButton.Checked = false;
    }

    private void noFillButton_Click(object sender, EventArgs e) {
      fill = false;
      noFillButton.Checked = true;
      fillButton.Checked = false;
    }

    private void ResetToolSelection() {
      pencilButton.Checked = false;
      brushButton.Checked = false;
      lineButton.Checked = false;
      rectangleButton.Checked = false;
      ellipseButton.Checked = false;
      eraserButton.Checked = false;

      if (tool == Tool.Rectangle || tool == Tool.Ellipse) {
        toolStripLabel1.Visible = true;
        noFillButton.Visible = true;
        fillButton.Visible = true;
      }
      else {
        toolStripLabel1.Visible = false;
        noFillButton.Visible = false;
        fillButton.Visible = false;
      }
    }

    private void colorPicker_Click(object sender, EventArgs e) {
      ColorDialog colorPicker = new ColorDialog();
      colorPicker.Color = color;
      if (colorPicker.ShowDialog() == DialogResult.OK) {
        this.color = colorPicker.Color;
        selectedColorButton.BackColor = colorPicker.Color;
      }
    }

    private void canvas_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        draw = true;
        start = end = e.Location;

        Graphics graphics = canvas.CreateGraphics();
        switch (tool) {
          case Tool.Pencil:
            graphics.FillRectangle(new SolidBrush(color), start.X, start.Y, 1, 1);
            break;
          case Tool.Brush:
            graphics.FillEllipse(new SolidBrush(color), start.X - size / 2, start.Y - size / 2, size, size);
            break;
          case Tool.Eraser:
            graphics.FillRectangle(new SolidBrush(Color.White), start.X - size / 2, start.Y - size / 2, size, size);
            break;
        }
      }
    }

    private void canvas_MouseMove(object sender, MouseEventArgs e) {
      Rectangle frame;
      Graphics graphics = canvas.CreateGraphics();

      if (draw) {
        current = end;
        end = e.Location;

        Pen pen = new Pen(color, size);
        switch (tool) {
          case Tool.Pencil:
            graphics.DrawLine(pen, current, end);
            break;
          case Tool.Brush:
            graphics = canvas.CreateGraphics();
            graphics.FillEllipse(new SolidBrush(color), current.X - size / 2, current.Y - size / 2, size, size);
            break;
          case Tool.Line:
            canvas.Refresh();
            graphics.DrawLine(pen, start, end);
            break;
          case Tool.Rectangle:
            canvas.Refresh();
            frame = PointRectangle(start, end);
            graphics.DrawRectangle(pen, frame);
            if (fill) graphics.FillRectangle(new SolidBrush(color), frame);
            break;
          case Tool.Ellipse:
            canvas.Refresh();
            frame = PointRectangle(start, end);
            graphics.DrawEllipse(pen, frame);
            if (fill) graphics.FillEllipse(new SolidBrush(color), frame);
            break;
          case Tool.Eraser:
            graphics.FillRectangle(new SolidBrush(Color.White), current.X - size / 2, current.Y - size / 2, size, size);
            break;
        }
      }
    }

    private void canvas_MouseUp(object sender, MouseEventArgs e) {
      if (draw) {
        draw = false;
        Changed();
      }
    }

    private void Sepia_Click(object sender, EventArgs e) {
      if (canvas.Image != null) {
        SepiaEffect();
        Changed();
      }
    }

    private void grayScale_Click(object sender, EventArgs e) {
      if (canvas.Image != null) {
        GrayscaleEffect();
        Changed();
      }
    }

    protected override void OnFormClosing(FormClosingEventArgs e) {
      if (dirty) {
        DialogResult answer = SaveImage();
        if (answer == DialogResult.Cancel) {
          e.Cancel = true;
          base.OnFormClosing(e);
        }
      }
    }

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
        canvas.Image = (Image)Image.FromFile(openFileDialog.FileName).Clone();
        this.Text = openFileDialog.FileName;
        ClearHistory();
      }
    }

    private DialogResult SaveImage() {
      DialogResult answer;
      ImageFormat format;

      answer = MessageBox.Show("Save image?", "Picture tool", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
      if (answer == DialogResult.No || answer == DialogResult.Cancel) return answer;

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
        DialogResult answer = SaveImage();
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

    private void SepiaEffect() {
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

    private void GrayscaleEffect() {
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

    public Rectangle CanvasFrame() {
      return new Rectangle(canvas.Location.X, canvas.Location.Y, canvas.Width, canvas.Height);
    }
  }
}