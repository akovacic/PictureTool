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
    private bool draw, fill, dirty;
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
        ApplySepia();
        Changed();
      }
    }

    private void grayScale_Click(object sender, EventArgs e) {
      if (canvas.Image != null) {
        ApplyGrayscale();
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

    private void cW90ToolStripMenuItem_Click(object sender, EventArgs e) {
      ApplyRotation(90);
      Changed();
    }

    private void cCW90ToolStripMenuItem_Click(object sender, EventArgs e) {
      ApplyRotation(-90);
      Changed();
    }

    private void cW180ToolStripMenuItem_Click(object sender, EventArgs e) {
      ApplyRotation(180);
      Changed();
    }

    private void cCW180ToolStripMenuItem_Click(object sender, EventArgs e) {
      ApplyRotation(-180);
      Changed();
    }
  }
}