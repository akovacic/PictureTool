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
    public enum Tool { Pencil, Brush, Line, Rectangle, Ellipse, Eraser };

    public bool draw, fill, dirty;
    public Color color;
    public Tool tool;
    public int size;
    public Point start, current, end;
    public Graphics graphics;
    public Stack<GraphicsState> history = new Stack<GraphicsState>();
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

    public void fillButton_Click(object sender, EventArgs e) {
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
        switch (tool) {
          case Tool.Pencil:
            graphics.DrawLine(pen, current, end);
            break;
          case Tool.Brush:
            graphics.FillEllipse(new SolidBrush(color), current.X - size / 2, current.Y - size / 2, size, size);
            break;
          case Tool.Line:
            canvas.Refresh();
            canvas.CreateGraphics().DrawLine(pen, start, end);
            break;
          case Tool.Rectangle:
            canvas.Refresh();
            frame = PointRectangle(start, end);
            canvas.CreateGraphics().DrawRectangle(pen, frame);
            if (fill) canvas.CreateGraphics().FillRectangle(new SolidBrush(color), frame);
            break;
          case Tool.Ellipse:
            canvas.Refresh();
            frame = PointRectangle(start, end);
            canvas.CreateGraphics().DrawEllipse(pen, frame);
            if (fill) canvas.CreateGraphics().FillEllipse(new SolidBrush(color), frame);
            break;
          case Tool.Eraser:
            graphics.FillRectangle(new SolidBrush(Color.White), current.X - size / 2, current.Y - size / 2, size, size);
            break;
        }

        if (tool != Tool.Line && tool != Tool.Rectangle && tool != Tool.Ellipse) canvas.Invalidate();
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
        }

        draw = false;
        canvas.Invalidate();
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

    public void cCW90ToolStripMenuItem_Click(object sender, EventArgs e) {
      ApplyRotation(-90);
      Changed();
    }

    public void cW180ToolStripMenuItem_Click(object sender, EventArgs e) {
      ApplyRotation(180);
      Changed();
    }

    public void cCW180ToolStripMenuItem_Click(object sender, EventArgs e) {
      ApplyRotation(-180);
      Changed();
    }

    public void resizeToolStripMenuItem_Click(object sender, EventArgs e) {
      Resize resizeForm = new Resize();
      resizeForm.pictureTool = this;
      resizeForm.Location = new Point(200, 200);
      resizeForm.ShowDialog();
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
  }
}