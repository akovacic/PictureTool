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
using System.Drawing.Drawing2D;

namespace PictureTool {
  public partial class Form1 : Form {
    public enum Tool { Pencil, Brush, Line, Rectangle, Ellipse, Eraser, Crop };

    public bool draw, fill, dirty;
    public Color color;
    public Tool tool;
    public int size;
    public Point start, current, end;
    public Graphics graphics;
    public Stack<Image> history = new Stack<Image>();
    public bool useAspectRatio;

    public Form1() {
      InitializeComponent();

      tool = Tool.Pencil;
      color = Color.Black;
      useAspectRatio = true;
    }

    public void Form1_Load(object sender, EventArgs e) {
      NewImage();
    }

    public void newButton_Click(object sender, EventArgs e)  { ResolveDirty(NewImage); }
    public void openButton_Click(object sender, EventArgs e) { ResolveDirty(OpenImage); }
    public void saveButton_Click(object sender, EventArgs e) { SaveImage(); }
    public void undoButton_Click(object sender, EventArgs e) { Undo(); }

    public void pencilButton_Click(object sender, EventArgs e) {
      tool = Tool.Pencil;
      ResetToolSelection();
      pencilButton.Checked = true;
    }

    public void brushButton_Click(object sender, EventArgs e) {
      tool = Tool.Brush; size = 10;
      ResetToolSelection();
      brushButton.Checked = true;
    }

    public void lineButton_Click(object sender, EventArgs e) {
      tool = Tool.Line; size = 1;
      ResetToolSelection();
      lineButton.Checked = true;
    }

    public void rectangleButton_Click(object sender, EventArgs e) {
      tool = Tool.Rectangle; size = 1;
      ResetToolSelection();
      rectangleButton.Checked = true;
    }

    public void ellipseButton_Click(object sender, EventArgs e) {
      tool = Tool.Ellipse; size = 1;
      ResetToolSelection();
      ellipseButton.Checked = true;
    }

    public void eraserButton_Click(object sender, EventArgs e) {
      tool = Tool.Eraser; size = 10;
      ResetToolSelection();
      eraserButton.Checked = true;
    }

    private void cropButton_Click(object sender, EventArgs e) {
      tool = Tool.Crop; size = 1;
      ResetToolSelection();
      cropButton.Checked = true;
    }

    private void fillButton_Click(object sender, EventArgs e) {
      fill = true;
      fillButton.Checked = true;
      noFillButton.Checked = false;
    }

    public void noFillButton_Click(object sender, EventArgs e) {
      fill = false;
      noFillButton.Checked = true;
      fillButton.Checked = false;
    }

    public void ResetToolSelection() {
      pencilButton.Checked = false;
      brushButton.Checked = false;
      lineButton.Checked = false;
      rectangleButton.Checked = false;
      ellipseButton.Checked = false;
      eraserButton.Checked = false;
      cropButton.Checked = false;

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

    public void colorPicker_Click(object sender, EventArgs e) {
      ColorDialog colorPicker = new ColorDialog();
      colorPicker.Color = color;
      if (colorPicker.ShowDialog() == DialogResult.OK) {
        this.color = colorPicker.Color;
        selectedColorButton.BackColor = colorPicker.Color;
      }
    }

    public void canvas_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        start = end = e.Location;

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

        canvas.Invalidate();
        draw = true;
      }
    }

    public void canvas_MouseMove(object sender, MouseEventArgs e) {
      Rectangle frame;

      if (draw) {
        current = end;
        end = e.Location;

        Pen pen = new Pen(color, 1);
        Graphics canvasGraphics = canvas.CreateGraphics();
        canvasGraphics.SmoothingMode = SmoothingMode.AntiAlias;
        switch (tool) {
          case Tool.Pencil:
            graphics.DrawLine(pen, current, end);
            canvas.Invalidate();
            break;
          case Tool.Brush:
            graphics.FillEllipse(new SolidBrush(color), current.X - size / 2, current.Y - size / 2, size, size);
            canvas.Invalidate();
            break;
          case Tool.Line:
            canvas.Refresh();
            canvasGraphics.DrawLine(pen, start, end);
            break;
          case Tool.Rectangle:
            canvas.Refresh();
            frame = PointRectangle(start, end);
            canvasGraphics.DrawRectangle(pen, frame);
            if (fill) canvas.CreateGraphics().FillRectangle(new SolidBrush(color), frame);
            break;
          case Tool.Ellipse:
            canvas.Refresh();
            frame = PointRectangle(start, end);
            canvasGraphics.DrawEllipse(pen, frame);
            if (fill) canvas.CreateGraphics().FillEllipse(new SolidBrush(color), frame);
            break;
          case Tool.Eraser:
            Pen erasingPen = new Pen(Color.White, 10);
            graphics.DrawLine(erasingPen, current, end);
            graphics.FillEllipse(new SolidBrush(Color.White), current.X - size / 2, current.Y - size / 2, size, size);
            canvas.Invalidate();
            break;
          case Tool.Crop:
            canvas.Refresh();
            frame = PointRectangle(start, end);
            pen = new Pen(Color.Black, 2);
            pen.DashPattern = new float[] {5, 2, 15, 4};
            canvasGraphics.DrawRectangle(pen, frame);
            break;
        }
      }
    }

    public void canvas_MouseUp(object sender, MouseEventArgs e) {
      Rectangle frame;

      if (draw) {
        Pen pen = new Pen(color, size);
        switch (tool) {
          case Tool.Line:
            graphics.DrawLine(pen, start, end);
            break;
          case Tool.Rectangle:
            frame = PointRectangle(start, end);
            graphics.DrawRectangle(pen, frame);
            if (fill) graphics.FillRectangle(new SolidBrush(color), frame);
            break;
          case Tool.Ellipse:
            frame = PointRectangle(start, end);
            graphics.DrawEllipse(pen, frame);
            if (fill) graphics.FillEllipse(new SolidBrush(color), frame);
            break;
          case Tool.Crop:
            if (start.X != end.X && start.Y!=end.Y && start.X<canvas.Width && start.Y<canvas.Height && end.X < canvas.Width && end.Y < canvas.Height ) {
              frame = PointRectangle(start, end);
              ChangeImage(((Bitmap)canvas.Image).Clone(frame, ((Bitmap)canvas.Image).PixelFormat));
            }
            break;
        }

        draw = false;
        Changed();
      }
    }

    public void Sepia_Click(object sender, EventArgs e) {
      ApplySepia();
      Changed();
    }

    public void grayScale_Click(object sender, EventArgs e) {
      ApplyGrayscale();
      Changed();
    }

    protected override void OnFormClosing(FormClosingEventArgs e) {
      if (dirty) {
        DialogResult answer = MessageBox.Show("Save image?", "Picture tool", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        if (answer == DialogResult.Yes) answer = SaveImage();
        if (answer == DialogResult.Cancel) {
          e.Cancel = true;
          base.OnFormClosing(e);
        }
      }
    }

    public void cW90ToolStripMenuItem_Click(object sender, EventArgs e) {
      ApplyRotation(90);
      Changed();
    }

    public void cW270ToolStripMenuItem_Click(object sender, EventArgs e) {
      ApplyRotation(270);
      Changed();
    }

    public void cW180ToolStripMenuItem_Click(object sender, EventArgs e) {
      ApplyRotation(180);
      Changed();
    }


    public void resizeToolStripMenuItem_Click(object sender, EventArgs e) {
      Resize resizeForm = new Resize();
      resizeForm.pictureTool = this;
      resizeForm.Location = new Point(200, 200);
      resizeForm.ShowDialog();
      Changed();
    }

    public void toolStripMenuItem3times3_Click(object sender, EventArgs e) {
      ApplyTemplate(3, 3);
      Changed();
    }

    public void toolStripMenuItem4times4_Click(object sender, EventArgs e) {
      ApplyTemplate(4, 4);
      Changed();
    }

    public void toolStripMenuItem5times5_Click(object sender, EventArgs e) {
      ApplyTemplate(5, 5);
      Changed();
    }

    public void customToolStripMenuItem_Click(object sender, EventArgs e) {
      Template templateForm = new Template();
      templateForm.pictureTool = this;
      templateForm.Location = new Point(200, 200);
      templateForm.ShowDialog();
    }

    private void blackToolStripButton_Click(object sender, EventArgs e) {
      color = Color.Black;
      selectedColorButton.BackColor = Color.Black;
    }

    private void whiteToolStripButton_Click(object sender, EventArgs e) {
      color = Color.White;
      selectedColorButton.BackColor = Color.White;
    }

    private void redToolStripButton_Click(object sender, EventArgs e) {
      color = Color.Red;
      selectedColorButton.BackColor = Color.Red;
    }

    private void greenToolStripButton_Click(object sender, EventArgs e) {
      color = Color.Green;
      selectedColorButton.BackColor = Color.Green;
    }

    private void blueToolStripButton_Click(object sender, EventArgs e) {
      color = Color.Blue;
      selectedColorButton.BackColor = Color.Blue;
    }

   
  }
}