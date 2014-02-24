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

namespace PictureTool
{
    enum Tool {Pencil, Brush, Line, Rectangle, Ellipse, Eraser};

    public partial class Form1 : Form
    {
        private bool draw, filled, saved, pictureOpened;
        private Color color;
        private Tool tool;
        private int size;
        private Point start, current, end;
        private Stack<Bitmap> history = new Stack<Bitmap>();

        public Form1()
        {
            InitializeComponent();
            saved = true;
            tool = Tool.Pencil;
            pictureOpened = false;
            color = Color.Black;
        }

        private Rectangle PointRectangle(Point p1, Point p2)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.X = (p1.X > p2.X ? p2.X : p1.X);
            rectangle.Y = (p1.Y > p2.Y ? p2.Y : p1.Y);
            rectangle.Width = Math.Abs(p1.X - p2.X);
            rectangle.Height = Math.Abs(p1.Y - p2.Y);

            return rectangle;
        }

        private Bitmap BitmapFromCanvas()
        { 
            Bitmap bitmap = new Bitmap(canvas.Width, canvas.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            Rectangle rectangle = canvas.RectangleToScreen(canvas.ClientRectangle);
            graphics.CopyFromScreen(rectangle.Location, Point.Empty, canvas.Size);
            graphics.Dispose();

            return bitmap;
        }

        private void NewImage()
        {
            canvas.Refresh();
            canvas.Image = null;
            this.Text = "untitled";
            saved = true;
            undoButtonQuick.Enabled = false;
            undoButtonMenu.Enabled = false;
            history.Clear();
            history.Push(BitmapFromCanvas());
        }

        private void OpenImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                canvas.Image = (Image)Image.FromFile(openFileDialog.FileName).Clone();
                this.Text = openFileDialog.FileName;
                saved = true;
                undoButtonQuick.Enabled = false;
                undoButtonMenu.Enabled = false;
                history.Clear();
                history.Push(BitmapFromCanvas());
                pictureOpened = true;
            }
        }

        private void SaveImage()
        {
            Bitmap picture = BitmapFromCanvas();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = this.Text;
            saveFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               if (saveFileDialog.FileName.Contains(".jpg") || saveFileDialog.FileName.Contains(".jpeg"))
               {
                   picture.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
               }
               else if (saveFileDialog.FileName.Contains(".png"))
               {
                   picture.Save(saveFileDialog.FileName, ImageFormat.Png);
               }
               else if (saveFileDialog.FileName.Contains(".gif"))
               {
                   picture.Save(saveFileDialog.FileName, ImageFormat.Gif);
               }
               else if (saveFileDialog.FileName.Contains(".bmp"))
               {
                   picture.Save(saveFileDialog.FileName, ImageFormat.Bmp);
               }
               this.Text = saveFileDialog.FileName;
               saved = true;
            }

            canvas.Image = (Image)picture;
        }

        private void Undo()
        {
            saved = false;
            history.Pop();
            if (history.Count != 1) canvas.Image = (Image)history.Peek();
            if (history.Count == 1)
            {
                undoButtonQuick.Enabled = false;
                undoButtonMenu.Enabled = false;
                if (!pictureOpened) NewImage();
                else
                {
                    canvas.Image = (Image)Image.FromFile(this.Text).Clone();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NewImage();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            pictureOpened = false;
            if (saved)
            {
                NewImage();
            }

            else
            {
                DialogResult result = MessageBox.Show("Save image?", "Picture tool", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    SaveImage();

                    if (saved)
                    {
                        NewImage();
                    }
                }

                else if (result == DialogResult.No)
                {
                    NewImage();
                }
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (saved)
            {
                OpenImage();
            }

            else
            {
                DialogResult result = MessageBox.Show("Save image?", "Picture tool", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    SaveImage();

                    if (saved)
                    {
                        OpenImage();
                    }
                }

                else if (result == DialogResult.No)
                {
                    OpenImage();
                }
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saved)
            {
                NewImage();
            }

            else
            {
                DialogResult result = MessageBox.Show("Save image?", "Picture tool", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    SaveImage();

                    if (saved)
                    {
                        NewImage();
                    }
                }

                else if (result == DialogResult.No)
                {
                    NewImage();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saved)
            {
                OpenImage();
            }

            else
            {
                DialogResult result = MessageBox.Show("Save image?", "Picture tool", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    SaveImage();

                    if (saved)
                    {
                        OpenImage();
                    }
                }

                else if (result == DialogResult.No)
                {
                    OpenImage();
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tool = Tool.Pencil;

            brushButton.Checked = false;
            lineButton.Checked = false;
            rectangleButton.Checked = false;
            ellipseButton.Checked = false;
            eraserButton.Checked = false;

            toolStripLabel1.Visible = false;
            noFillButton.Visible = false;
            fillButton.Visible = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            tool = Tool.Brush;
            size = 10;

            pencilButton.Checked = false;
            lineButton.Checked = false;
            rectangleButton.Checked = false;
            ellipseButton.Checked = false;
            eraserButton.Checked = false;

            toolStripLabel1.Visible = false;
            noFillButton.Visible = false;
            fillButton.Visible = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            tool = Tool.Line;
            size = 1;

            pencilButton.Checked = false;
            brushButton.Checked = false;
            rectangleButton.Checked = false;
            ellipseButton.Checked = false;
            eraserButton.Checked = false;

            toolStripLabel1.Visible = false;
            noFillButton.Visible = false;
            fillButton.Visible = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            tool = Tool.Rectangle;
            size = 1;

            pencilButton.Checked = false;
            brushButton.Checked = false;
            lineButton.Checked = false;
            ellipseButton.Checked = false;
            eraserButton.Checked = false;

            toolStripLabel1.Visible = true;
            noFillButton.Visible = true;
            fillButton.Visible = true;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            tool = Tool.Ellipse;
            size = 1;

            pencilButton.Checked = false;
            brushButton.Checked = false;
            lineButton.Checked = false;
            rectangleButton.Checked = false;
            eraserButton.Checked = false;

            toolStripLabel1.Visible = true;
            noFillButton.Visible = true;
            fillButton.Visible = true;
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            tool = Tool.Eraser;
            size = 10;

            pencilButton.Checked = false;
            brushButton.Checked = false;
            lineButton.Checked = false;
            rectangleButton.Checked = false;
            ellipseButton.Checked = false;

            toolStripLabel1.Visible = false;
            noFillButton.Visible = false;
            fillButton.Visible = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // this.Cursor = Cursors.Cross;
            if (e.Button == MouseButtons.Left)
            {
                draw = true;
                start = end = e.Location;
                saved = false;

                Graphics graphics = canvas.CreateGraphics();
                switch (tool)
                {
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

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                current = end;
                end = e.Location;

                Graphics graphics = canvas.CreateGraphics();
                switch (tool)
                {
                    case Tool.Pencil:
                        Pen pen = new Pen(color, 1);
                        graphics.DrawLine(pen, current, end);
                        break;
                    case Tool.Brush:
                        graphics.FillEllipse(new SolidBrush(color), current.X - size / 2, current.Y - size / 2, size, size);
                        break;
                    case Tool.Eraser:
                        graphics.FillRectangle(new SolidBrush(Color.White), current.X - size / 2, current.Y - size / 2, size, size);
                        break;
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Rectangle frame;

            if (draw)
            {
                end = e.Location;

                Pen pen = new Pen(color, size);
                Graphics graphics = canvas.CreateGraphics();
                switch (tool)
                {
                    case Tool.Line:
                        graphics.DrawLine(pen, start, end);
                        break;
                    case Tool.Rectangle:
                        frame = PointRectangle(start, end);
                        graphics.DrawRectangle(pen, frame);
                        if (filled) graphics.FillRectangle(new SolidBrush(color), frame);
                        break;
                    case Tool.Ellipse:
                        frame = PointRectangle(start, end);
                        graphics.DrawEllipse(pen, frame);
                        if (filled) graphics.FillEllipse(new SolidBrush(color), frame);
                        break;
                }

                undoButtonQuick.Enabled = true;
                undoButtonMenu.Enabled = true;
                Bitmap picture = BitmapFromCanvas();
                history.Push(picture);
            }

            draw = false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            filled = false;
            fillButton.Checked = false;
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            filled = true;
            noFillButton.Checked = false;
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            colorPicker.Color = color;
            if (colorPicker.ShowDialog() == DialogResult.OK) UpdateColor(colorPicker.Color);
        }

        private void UpdateColor(Color color)
        {
            this.color = color;
            selectedColorButton.BackColor = color;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved && MessageBox.Show("Save image?", "Picture tool", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SaveImage();
            }
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }
    }
}
