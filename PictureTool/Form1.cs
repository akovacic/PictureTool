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
        private Color color = Color.Black;
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
        }

        private Rectangle rectangle(Point p1, Point p2)
        {
            Rectangle r = new Rectangle();
            r.X = (p1.X > p2.X ? p2.X : p1.X);
            r.Y = (p1.Y > p2.Y ? p2.Y : p1.Y);
            r.Width = Math.Abs(p1.X - p2.X);
            r.Height = Math.Abs(p1.Y - p2.Y);

            return r;
        }

        private Bitmap bitmap()
        { 
            Bitmap b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics graphics = Graphics.FromImage(b);
            Rectangle r = pictureBox1.RectangleToScreen(pictureBox1.ClientRectangle);
            graphics.CopyFromScreen(r.Location, Point.Empty, pictureBox1.Size);
            graphics.Dispose();

            return b;
        }

        private void newImage()
        {
            pictureBox1.Refresh();
            pictureBox1.Image = null;
            this.Text = "untitled";
            saved = true;
            toolStripButton19.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            history.Clear();
            history.Push(bitmap());
        }

        private void openImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image = (Image)Image.FromFile(openFileDialog.FileName).Clone();
                this.Text = openFileDialog.FileName;
                saved = true;
                toolStripButton19.Enabled = false;
                undoToolStripMenuItem.Enabled = false;
                history.Clear();
                history.Push(bitmap());
                pictureOpened = true;
            }
        }

        private void saveImage()
        {
            Bitmap picture = bitmap();
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
            pictureBox1.Image = (Image)picture;
           
            
        }

        private void undo()
        {
            saved = false;
            history.Pop();
            if (history.Count != 1) pictureBox1.Image = (Image)history.Peek();
            if (history.Count == 1)
            {
                toolStripButton19.Enabled = false;
                undoToolStripMenuItem.Enabled = false;
                if (!pictureOpened) newImage();
                else
                {
                    pictureBox1.Image = (Image)Image.FromFile(this.Text).Clone();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            newImage();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            pictureOpened = false;
            if (saved)
            {
                newImage();
            }

            else
            {
                DialogResult result = MessageBox.Show("Save image?", "Picture tool", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    saveImage();

                    if (saved)
                    {
                        newImage();
                    }
                }

                else if (result == DialogResult.No)
                {
                    newImage();
                }
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (saved)
            {
                openImage();
            }

            else
            {
                DialogResult result = MessageBox.Show("Save image?", "Picture tool", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    saveImage();

                    if (saved)
                    {
                        openImage();
                    }
                }

                else if (result == DialogResult.No)
                {
                    openImage();
                }
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            saveImage();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saved)
            {
                newImage();
            }

            else
            {
                DialogResult result = MessageBox.Show("Save image?", "Picture tool", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    saveImage();

                    if (saved)
                    {
                        newImage();
                    }
                }

                else if (result == DialogResult.No)
                {
                    newImage();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saved)
            {
                openImage();
            }

            else
            {
                DialogResult result = MessageBox.Show("Save image?", "Picture tool", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    saveImage();

                    if (saved)
                    {
                        openImage();
                    }
                }

                else if (result == DialogResult.No)
                {
                    openImage();
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveImage();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tool = Tool.Pencil;

            toolStripButton2.Checked = false;
            toolStripButton3.Checked = false;
            toolStripButton4.Checked = false;
            toolStripButton5.Checked = false;
            toolStripButton14.Checked = false;

            toolStripLabel1.Visible = false;
            toolStripButton15.Visible = false;
            toolStripButton16.Visible = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            tool = Tool.Brush;
            size = 10;

            toolStripButton1.Checked = false;
            toolStripButton3.Checked = false;
            toolStripButton4.Checked = false;
            toolStripButton5.Checked = false;
            toolStripButton14.Checked = false;

            toolStripLabel1.Visible = false;
            toolStripButton15.Visible = false;
            toolStripButton16.Visible = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            tool = Tool.Line;
            size = 1;

            toolStripButton1.Checked = false;
            toolStripButton2.Checked = false;
            toolStripButton4.Checked = false;
            toolStripButton5.Checked = false;
            toolStripButton14.Checked = false;

            toolStripLabel1.Visible = false;
            toolStripButton15.Visible = false;
            toolStripButton16.Visible = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            tool = Tool.Rectangle;
            size = 1;

            toolStripButton1.Checked = false;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = false;
            toolStripButton5.Checked = false;
            toolStripButton14.Checked = false;

            toolStripLabel1.Visible = true;
            toolStripButton15.Visible = true;
            toolStripButton16.Visible = true;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            tool = Tool.Ellipse;
            size = 1;

            toolStripButton1.Checked = false;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = false;
            toolStripButton4.Checked = false;
            toolStripButton14.Checked = false;

            toolStripLabel1.Visible = true;
            toolStripButton15.Visible = true;
            toolStripButton16.Visible = true;
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            tool = Tool.Eraser;
            size = 10;

            toolStripButton1.Checked = false;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = false;
            toolStripButton4.Checked = false;
            toolStripButton5.Checked = false;

            toolStripLabel1.Visible = false;
            toolStripButton15.Visible = false;
            toolStripButton16.Visible = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // this.Cursor = Cursors.Cross;
            if (e.Button == MouseButtons.Left)
            {
                draw = true;
                start = end = e.Location;
                saved = false;

                Graphics graphics = pictureBox1.CreateGraphics();
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

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                current = end;
                end = e.Location;

                Graphics graphics = pictureBox1.CreateGraphics();
                switch (tool) {
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
            Rectangle r;

            if (draw) {
                end = e.Location;

                Pen pen = new Pen(color, size);
                Graphics graphics = pictureBox1.CreateGraphics();
                switch (tool) {
                    case Tool.Line:
                        graphics.DrawLine(pen, start, end);
                        break;
                    case Tool.Rectangle:
                        r = rectangle(start, end);
                        graphics.DrawRectangle(pen, r);
                        if (filled) graphics.FillRectangle(new SolidBrush(color), r);
                        break;
                    case Tool.Ellipse:
                        r = rectangle(start, end);
                        graphics.DrawEllipse(pen, r);
                        if (filled) graphics.FillEllipse(new SolidBrush(color), r);
                        break;
                }

                toolStripButton19.Enabled = true;
                undoToolStripMenuItem.Enabled = true;
                Bitmap picture = bitmap();
                history.Push(picture);
            }

            draw = false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            color = Color.Black;
            toolStripButton18.BackColor = color;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            color = Color.White;
            toolStripButton18.BackColor = color;
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            color = Color.Red;
            toolStripButton18.BackColor = color;
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            color = Color.Green;
            toolStripButton18.BackColor = color;
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            color = Color.Blue;
            toolStripButton18.BackColor = color;
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            filled = false;
            toolStripButton16.Checked = false;
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            filled = true;
            toolStripButton15.Checked = false;
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = color;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                color = dlg.Color;
                toolStripButton18.BackColor = color;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved && MessageBox.Show("Save image?", "Picture tool", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                saveImage();
            }
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            undo();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undo();
        }
    }
}
