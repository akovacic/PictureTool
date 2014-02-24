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
        private bool draw, filled, dirty, pictureOpened;
        private Color color;
        private Tool tool;
        private int size;
        private Point start, current, end;
        private Stack<Bitmap> history = new Stack<Bitmap>();

        public Form1()
        {
            InitializeComponent();
            tool = Tool.Pencil;
            color = Color.Black;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NewImage();
        }

        private void newButton_Click(object sender, EventArgs e)  { ResolveDirty(NewImage);  }
        private void openButton_Click(object sender, EventArgs e) { ResolveDirty(OpenImage); }
        private void saveButton_Click(object sender, EventArgs e) { SaveImage();             }
        private void undoButton_Click(object sender, EventArgs e) { Undo();                  }

        private void pencilButton_Click(object sender, EventArgs e)
        {
            tool = Tool.Pencil;
            FocusTool(pencilButton);
        }

        private void brushButton_Click(object sender, EventArgs e)
        {
            tool = Tool.Brush;
            size = 10;
            FocusTool(brushButton);
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            tool = Tool.Line;
            size = 1;
            FocusTool(lineButton);
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            tool = Tool.Rectangle;
            size = 1;
            FocusTool(rectangleButton);
        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            tool = Tool.Ellipse;
            size = 1;
            FocusTool(ellipseButton);
        }

        private void eraserButton_Click(object sender, EventArgs e)
        {
            tool = Tool.Eraser;
            size = 10;
            FocusTool(eraserButton);
        }

        private void FocusTool(ToolStripButton button)
        {
            brushButton.Checked = false;
            lineButton.Checked = false;
            rectangleButton.Checked = false;
            ellipseButton.Checked = false;
            eraserButton.Checked = false;

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
                dirty = true;

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
            if (dirty && MessageBox.Show("Save image?", "Picture tool", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SaveImage();
            }
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
            ClearHistory();
            pictureOpened = false;
            dirty = false;
        }

        private void ClearHistory()
        {
            history.Clear();
            history.Push(BitmapFromCanvas());
            undoButtonQuick.Enabled = false;
            undoButtonMenu.Enabled = false;
        }

        private void OpenImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                canvas.Image = (Image)Image.FromFile(openFileDialog.FileName).Clone();
                this.Text = openFileDialog.FileName;
                ClearHistory();
                pictureOpened = true;
            }
        }

        private void SaveImage()
        {
            Bitmap image = BitmapFromCanvas();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = this.Text;
            saveFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ImageFormat format;
                switch (Path.GetExtension(saveFileDialog.FileName))
                {
                    case ".jpg":
                    case ".jpeg": format = ImageFormat.Jpeg; break;
                    case ".png": format = ImageFormat.Png; break;
                    case ".gif": format = ImageFormat.Gif; break;
                    case ".bmp": format = ImageFormat.Bmp; break;
                    default: format = ImageFormat.Jpeg; break;
                }
                image.Save(saveFileDialog.FileName, format);
                this.Text = saveFileDialog.FileName;
                dirty = false;
            }
            canvas.Image = image;
        }

        private void Undo()
        {
            if (history.Count > 1) history.Pop();
            if (history.Count > 1) canvas.Image = history.Peek();
            else
            {
                // Workaround za malfunction na zadnjem undou.
                if (pictureOpened) canvas.Image = (Image)Image.FromFile(this.Text).Clone();
                else canvas.Image = null;

                undoButtonQuick.Enabled = false;
                undoButtonMenu.Enabled = false;
            }
        }

        private void ResolveDirty(Action action)
        {
            if (!dirty) action();
            else
            {
                switch (MessageBox.Show("Save image?", "Picture tool", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes:
                        SaveImage();
                        if (!dirty) action();
                        break;
                    case DialogResult.No:
                        action();
                        break;
                }
            }
        }

        private void Sepia_Click(object sender, EventArgs e)
        {
            undoButtonQuick.Enabled = true;
            undoButtonMenu.Enabled = true;
            Bitmap picture = BitmapFromCanvas();
            history.Push(picture);
            float[][] sepiaValues = {
            new float[]{.393f, .349f, .272f, 0, 0},
            new float[]{.769f, .686f, .534f, 0, 0},
            new float[]{.189f, .168f, .131f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}};
            System.Drawing.Imaging.ColorMatrix sepiaMatrix = new System.Drawing.Imaging.ColorMatrix(sepiaValues);
            System.Drawing.Imaging.ImageAttributes IA = new System.Drawing.Imaging.ImageAttributes();
            IA.SetColorMatrix(sepiaMatrix);
            Bitmap sepiaEffect = BitmapFromCanvas();
            using (Graphics G = Graphics.FromImage(sepiaEffect))
            {
                G.DrawImage(canvas.Image, new Rectangle(0, 0, sepiaEffect.Width, sepiaEffect.Height), 0, 0, sepiaEffect.Width, sepiaEffect.Height, GraphicsUnit.Pixel, IA);
            }
            canvas.Image = sepiaEffect;
        }

        private void grayScale_Click(object sender, EventArgs e)
        {
            undoButtonQuick.Enabled = true;
            undoButtonMenu.Enabled = true;
            Bitmap picture = BitmapFromCanvas();
            history.Push(picture);
            Bitmap newBitmap = new Bitmap(canvas.Image.Width, canvas.Image.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][] 
                {
                     new float[] {0.299f, 0.299f, 0.299f, 0, 0},
                     new float[] {0.587f, 0.587f, 0.587f, 0, 0},
                     new float[] {.114f, .114f, .114f, 0, 0},
                     new float[] {0, 0, 0, 1, 0},
                     new float[] {0, 0, 0, 0, 1}
                });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);
            g.DrawImage(canvas.Image, new Rectangle(0, 0, canvas.Image.Width, canvas.Image.Height),
               0, 0, canvas.Image.Width, canvas.Image.Height, GraphicsUnit.Pixel, attributes);
            canvas.Image = newBitmap;
        }
    }
}
