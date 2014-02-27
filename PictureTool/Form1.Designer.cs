

namespace PictureTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.toolbar = new System.Windows.Forms.ToolStrip();
      this.pencilButton = new System.Windows.Forms.ToolStripButton();
      this.brushButton = new System.Windows.Forms.ToolStripButton();
      this.lineButton = new System.Windows.Forms.ToolStripButton();
      this.rectangleButton = new System.Windows.Forms.ToolStripButton();
      this.ellipseButton = new System.Windows.Forms.ToolStripButton();
      this.eraserButton = new System.Windows.Forms.ToolStripButton();
      this.grayScale = new System.Windows.Forms.ToolStripButton();
      this.Sepia = new System.Windows.Forms.ToolStripButton();
      this.cropButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.noFillButton = new System.Windows.Forms.ToolStripButton();
      this.fillButton = new System.Windows.Forms.ToolStripButton();
      this.quickbar = new System.Windows.Forms.ToolStrip();
      this.newButtonQuick = new System.Windows.Forms.ToolStripButton();
      this.openButtonQuick = new System.Windows.Forms.ToolStripButton();
      this.saveButtonQuick = new System.Windows.Forms.ToolStripButton();
      this.undoButtonQuick = new System.Windows.Forms.ToolStripButton();
      this.colorbar = new System.Windows.Forms.ToolStrip();
      this.blackToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.whiteToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.redToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.greenToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.blueToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.colorPickerButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
      this.selectedColorButton = new System.Windows.Forms.ToolStripButton();
      this.canvas = new System.Windows.Forms.PictureBox();
      this.panel = new System.Windows.Forms.Panel();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newButtonMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.openButtonMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.saveButtonMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.undoButtonMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.cW90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.cCW90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.cW180ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.effectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sepiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.templatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem3times3 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem4times4 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem5times5 = new System.Windows.Forms.ToolStripMenuItem();
      this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menu = new System.Windows.Forms.MenuStrip();
      this.toolbar.SuspendLayout();
      this.quickbar.SuspendLayout();
      this.colorbar.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
      this.panel.SuspendLayout();
      this.menu.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolbar
      // 
      this.toolbar.Dock = System.Windows.Forms.DockStyle.Left;
      this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pencilButton,
            this.brushButton,
            this.lineButton,
            this.rectangleButton,
            this.ellipseButton,
            this.eraserButton,
            this.grayScale,
            this.Sepia,
            this.cropButton,
            this.toolStripLabel1,
            this.noFillButton,
            this.fillButton});
      this.toolbar.Location = new System.Drawing.Point(0, 24);
      this.toolbar.Name = "toolbar";
      this.toolbar.Size = new System.Drawing.Size(24, 442);
      this.toolbar.TabIndex = 2;
      this.toolbar.Text = "toolStrip1";
      // 
      // pencilButton
      // 
      this.pencilButton.Checked = true;
      this.pencilButton.CheckOnClick = true;
      this.pencilButton.CheckState = System.Windows.Forms.CheckState.Checked;
      this.pencilButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.pencilButton.Image = ((System.Drawing.Image)(resources.GetObject("pencilButton.Image")));
      this.pencilButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.pencilButton.Name = "pencilButton";
      this.pencilButton.Size = new System.Drawing.Size(21, 20);
      this.pencilButton.Text = "Pencil";
      this.pencilButton.Click += new System.EventHandler(this.pencilButton_Click);
      // 
      // brushButton
      // 
      this.brushButton.CheckOnClick = true;
      this.brushButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.brushButton.Image = ((System.Drawing.Image)(resources.GetObject("brushButton.Image")));
      this.brushButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.brushButton.Name = "brushButton";
      this.brushButton.Size = new System.Drawing.Size(21, 20);
      this.brushButton.Text = "Brush";
      this.brushButton.Click += new System.EventHandler(this.brushButton_Click);
      // 
      // lineButton
      // 
      this.lineButton.CheckOnClick = true;
      this.lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.lineButton.Image = ((System.Drawing.Image)(resources.GetObject("lineButton.Image")));
      this.lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.lineButton.Name = "lineButton";
      this.lineButton.Size = new System.Drawing.Size(21, 20);
      this.lineButton.Text = "Line";
      this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
      // 
      // rectangleButton
      // 
      this.rectangleButton.CheckOnClick = true;
      this.rectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.rectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("rectangleButton.Image")));
      this.rectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.rectangleButton.Name = "rectangleButton";
      this.rectangleButton.Size = new System.Drawing.Size(21, 20);
      this.rectangleButton.Text = "Rectangle";
      this.rectangleButton.Click += new System.EventHandler(this.rectangleButton_Click);
      // 
      // ellipseButton
      // 
      this.ellipseButton.CheckOnClick = true;
      this.ellipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.ellipseButton.Image = ((System.Drawing.Image)(resources.GetObject("ellipseButton.Image")));
      this.ellipseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ellipseButton.Name = "ellipseButton";
      this.ellipseButton.Size = new System.Drawing.Size(21, 20);
      this.ellipseButton.Text = "Ellipse";
      this.ellipseButton.Click += new System.EventHandler(this.ellipseButton_Click);
      // 
      // eraserButton
      // 
      this.eraserButton.CheckOnClick = true;
      this.eraserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.eraserButton.Image = ((System.Drawing.Image)(resources.GetObject("eraserButton.Image")));
      this.eraserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.eraserButton.Name = "eraserButton";
      this.eraserButton.Size = new System.Drawing.Size(21, 20);
      this.eraserButton.Text = "Eraser";
      this.eraserButton.Click += new System.EventHandler(this.eraserButton_Click);
      // 
      // grayScale
      // 
      this.grayScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.grayScale.Image = ((System.Drawing.Image)(resources.GetObject("grayScale.Image")));
      this.grayScale.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.grayScale.Name = "grayScale";
      this.grayScale.Size = new System.Drawing.Size(21, 20);
      this.grayScale.Text = "Grayscale";
      this.grayScale.Click += new System.EventHandler(this.grayScale_Click);
      // 
      // Sepia
      // 
      this.Sepia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.Sepia.Image = ((System.Drawing.Image)(resources.GetObject("Sepia.Image")));
      this.Sepia.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.Sepia.Name = "Sepia";
      this.Sepia.Size = new System.Drawing.Size(21, 20);
      this.Sepia.Text = "Sepia";
      this.Sepia.Click += new System.EventHandler(this.Sepia_Click);
      // 
      // cropButton
      // 
      this.cropButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.cropButton.Image = ((System.Drawing.Image)(resources.GetObject("cropButton.Image")));
      this.cropButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.cropButton.Name = "cropButton";
      this.cropButton.Size = new System.Drawing.Size(21, 20);
      this.cropButton.Text = "Crop";
      this.cropButton.ToolTipText = "Crop";
      this.cropButton.Click += new System.EventHandler(this.cropButton_Click);
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(0, 20, 0, 2);
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(23, 15);
      this.toolStripLabel1.Text = "Fill:";
      this.toolStripLabel1.Visible = false;
      // 
      // noFillButton
      // 
      this.noFillButton.Checked = true;
      this.noFillButton.CheckOnClick = true;
      this.noFillButton.CheckState = System.Windows.Forms.CheckState.Checked;
      this.noFillButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.noFillButton.Image = ((System.Drawing.Image)(resources.GetObject("noFillButton.Image")));
      this.noFillButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.noFillButton.Name = "noFillButton";
      this.noFillButton.Size = new System.Drawing.Size(21, 20);
      this.noFillButton.Visible = false;
      this.noFillButton.Click += new System.EventHandler(this.noFillButton_Click);
      // 
      // fillButton
      // 
      this.fillButton.CheckOnClick = true;
      this.fillButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.fillButton.Image = ((System.Drawing.Image)(resources.GetObject("fillButton.Image")));
      this.fillButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.fillButton.Name = "fillButton";
      this.fillButton.Size = new System.Drawing.Size(21, 20);
      this.fillButton.Visible = false;
      this.fillButton.Click += new System.EventHandler(this.fillButton_Click);
      // 
      // quickbar
      // 
      this.quickbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButtonQuick,
            this.openButtonQuick,
            this.saveButtonQuick,
            this.undoButtonQuick});
      this.quickbar.Location = new System.Drawing.Point(24, 24);
      this.quickbar.Name = "quickbar";
      this.quickbar.Size = new System.Drawing.Size(668, 25);
      this.quickbar.TabIndex = 1;
      this.quickbar.Text = "toolStrip2";
      // 
      // newButtonQuick
      // 
      this.newButtonQuick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.newButtonQuick.Image = ((System.Drawing.Image)(resources.GetObject("newButtonQuick.Image")));
      this.newButtonQuick.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.newButtonQuick.Name = "newButtonQuick";
      this.newButtonQuick.Size = new System.Drawing.Size(23, 22);
      this.newButtonQuick.Text = "New";
      this.newButtonQuick.Click += new System.EventHandler(this.newButton_Click);
      // 
      // openButtonQuick
      // 
      this.openButtonQuick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.openButtonQuick.Image = ((System.Drawing.Image)(resources.GetObject("openButtonQuick.Image")));
      this.openButtonQuick.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.openButtonQuick.Name = "openButtonQuick";
      this.openButtonQuick.Size = new System.Drawing.Size(23, 22);
      this.openButtonQuick.Text = "Open";
      this.openButtonQuick.Click += new System.EventHandler(this.openButton_Click);
      // 
      // saveButtonQuick
      // 
      this.saveButtonQuick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.saveButtonQuick.Image = ((System.Drawing.Image)(resources.GetObject("saveButtonQuick.Image")));
      this.saveButtonQuick.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.saveButtonQuick.Name = "saveButtonQuick";
      this.saveButtonQuick.Size = new System.Drawing.Size(23, 22);
      this.saveButtonQuick.Text = "Save";
      this.saveButtonQuick.Click += new System.EventHandler(this.saveButton_Click);
      // 
      // undoButtonQuick
      // 
      this.undoButtonQuick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.undoButtonQuick.Enabled = false;
      this.undoButtonQuick.Image = ((System.Drawing.Image)(resources.GetObject("undoButtonQuick.Image")));
      this.undoButtonQuick.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.undoButtonQuick.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
      this.undoButtonQuick.Name = "undoButtonQuick";
      this.undoButtonQuick.Size = new System.Drawing.Size(23, 22);
      this.undoButtonQuick.Text = "Undo";
      this.undoButtonQuick.Click += new System.EventHandler(this.undoButton_Click);
      // 
      // colorbar
      // 
      this.colorbar.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.colorbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackToolStripButton,
            this.whiteToolStripButton,
            this.redToolStripButton,
            this.greenToolStripButton,
            this.blueToolStripButton,
            this.colorPickerButton,
            this.toolStripLabel2,
            this.selectedColorButton});
      this.colorbar.Location = new System.Drawing.Point(24, 441);
      this.colorbar.Name = "colorbar";
      this.colorbar.Size = new System.Drawing.Size(668, 25);
      this.colorbar.Stretch = true;
      this.colorbar.TabIndex = 3;
      this.colorbar.Text = "toolStrip3";
      // 
      // blackToolStripButton
      // 
      this.blackToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.blackToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("blackToolStripButton.Image")));
      this.blackToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.blackToolStripButton.Name = "blackToolStripButton";
      this.blackToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.blackToolStripButton.Text = "Black";
      this.blackToolStripButton.Click += new System.EventHandler(this.blackToolStripButton_Click);
      // 
      // whiteToolStripButton
      // 
      this.whiteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.whiteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("whiteToolStripButton.Image")));
      this.whiteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.whiteToolStripButton.Name = "whiteToolStripButton";
      this.whiteToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.whiteToolStripButton.Text = "White";
      this.whiteToolStripButton.Click += new System.EventHandler(this.whiteToolStripButton_Click);
      // 
      // redToolStripButton
      // 
      this.redToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.redToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("redToolStripButton.Image")));
      this.redToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.redToolStripButton.Name = "redToolStripButton";
      this.redToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.redToolStripButton.Text = "Red";
      this.redToolStripButton.Click += new System.EventHandler(this.redToolStripButton_Click);
      // 
      // greenToolStripButton
      // 
      this.greenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.greenToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("greenToolStripButton.Image")));
      this.greenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.greenToolStripButton.Name = "greenToolStripButton";
      this.greenToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.greenToolStripButton.Text = "Green";
      this.greenToolStripButton.Click += new System.EventHandler(this.greenToolStripButton_Click);
      // 
      // blueToolStripButton
      // 
      this.blueToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.blueToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("blueToolStripButton.Image")));
      this.blueToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.blueToolStripButton.Name = "blueToolStripButton";
      this.blueToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.blueToolStripButton.Text = "Blue";
      this.blueToolStripButton.Click += new System.EventHandler(this.blueToolStripButton_Click);
      // 
      // colorPickerButton
      // 
      this.colorPickerButton.AutoSize = false;
      this.colorPickerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.colorPickerButton.Image = ((System.Drawing.Image)(resources.GetObject("colorPickerButton.Image")));
      this.colorPickerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.colorPickerButton.Name = "colorPickerButton";
      this.colorPickerButton.Size = new System.Drawing.Size(33, 22);
      this.colorPickerButton.Text = "Colors";
      this.colorPickerButton.Click += new System.EventHandler(this.colorPicker_Click);
      // 
      // toolStripLabel2
      // 
      this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
      this.toolStripLabel2.Name = "toolStripLabel2";
      this.toolStripLabel2.Size = new System.Drawing.Size(84, 22);
      this.toolStripLabel2.Text = "Selected color:";
      // 
      // selectedColorButton
      // 
      this.selectedColorButton.BackColor = System.Drawing.Color.Black;
      this.selectedColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
      this.selectedColorButton.Enabled = false;
      this.selectedColorButton.Image = ((System.Drawing.Image)(resources.GetObject("selectedColorButton.Image")));
      this.selectedColorButton.ImageTransparentColor = System.Drawing.Color.Black;
      this.selectedColorButton.Margin = new System.Windows.Forms.Padding(5);
      this.selectedColorButton.Name = "selectedColorButton";
      this.selectedColorButton.Size = new System.Drawing.Size(23, 15);
      // 
      // canvas
      // 
      this.canvas.BackColor = System.Drawing.Color.White;
      this.canvas.Cursor = System.Windows.Forms.Cursors.Cross;
      this.canvas.Location = new System.Drawing.Point(0, 0);
      this.canvas.Name = "canvas";
      this.canvas.Size = new System.Drawing.Size(600, 350);
      this.canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.canvas.TabIndex = 4;
      this.canvas.TabStop = false;
      this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
      this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
      this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
      // 
      // panel
      // 
      this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel.AutoScroll = true;
      this.panel.Controls.Add(this.canvas);
      this.panel.Location = new System.Drawing.Point(27, 52);
      this.panel.Name = "panel";
      this.panel.Size = new System.Drawing.Size(665, 386);
      this.panel.TabIndex = 5;
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButtonMenu,
            this.openButtonMenu,
            this.saveButtonMenu});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // newButtonMenu
      // 
      this.newButtonMenu.BackColor = System.Drawing.SystemColors.Control;
      this.newButtonMenu.Image = ((System.Drawing.Image)(resources.GetObject("newButtonMenu.Image")));
      this.newButtonMenu.Name = "newButtonMenu";
      this.newButtonMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.newButtonMenu.Size = new System.Drawing.Size(146, 22);
      this.newButtonMenu.Text = "New";
      this.newButtonMenu.Click += new System.EventHandler(this.newButton_Click);
      // 
      // openButtonMenu
      // 
      this.openButtonMenu.BackColor = System.Drawing.SystemColors.Control;
      this.openButtonMenu.Image = ((System.Drawing.Image)(resources.GetObject("openButtonMenu.Image")));
      this.openButtonMenu.Name = "openButtonMenu";
      this.openButtonMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.openButtonMenu.Size = new System.Drawing.Size(146, 22);
      this.openButtonMenu.Text = "Open";
      this.openButtonMenu.Click += new System.EventHandler(this.openButton_Click);
      // 
      // saveButtonMenu
      // 
      this.saveButtonMenu.BackColor = System.Drawing.SystemColors.Control;
      this.saveButtonMenu.Image = ((System.Drawing.Image)(resources.GetObject("saveButtonMenu.Image")));
      this.saveButtonMenu.Name = "saveButtonMenu";
      this.saveButtonMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.saveButtonMenu.Size = new System.Drawing.Size(146, 22);
      this.saveButtonMenu.Text = "Save";
      this.saveButtonMenu.Click += new System.EventHandler(this.saveButton_Click);
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoButtonMenu});
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
      this.editToolStripMenuItem.Text = "Edit";
      // 
      // undoButtonMenu
      // 
      this.undoButtonMenu.BackColor = System.Drawing.SystemColors.Control;
      this.undoButtonMenu.Enabled = false;
      this.undoButtonMenu.Image = ((System.Drawing.Image)(resources.GetObject("undoButtonMenu.Image")));
      this.undoButtonMenu.Name = "undoButtonMenu";
      this.undoButtonMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
      this.undoButtonMenu.Size = new System.Drawing.Size(144, 22);
      this.undoButtonMenu.Text = "Undo";
      this.undoButtonMenu.Click += new System.EventHandler(this.undoButton_Click);
      // 
      // imageToolStripMenuItem
      // 
      this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resizeToolStripMenuItem,
            this.rotateToolStripMenuItem,
            this.effectsToolStripMenuItem});
      this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
      this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
      this.imageToolStripMenuItem.Text = "Image";
      // 
      // resizeToolStripMenuItem
      // 
      this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
      this.resizeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.resizeToolStripMenuItem.Text = "Resize";
      this.resizeToolStripMenuItem.Click += new System.EventHandler(this.resizeToolStripMenuItem_Click);
      // 
      // rotateToolStripMenuItem
      // 
      this.rotateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cW90ToolStripMenuItem,
            this.cW180ToolStripMenuItem,
            this.cCW90ToolStripMenuItem});
      this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
      this.rotateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.rotateToolStripMenuItem.Text = "Rotate";
      // 
      // cW90ToolStripMenuItem
      // 
      this.cW90ToolStripMenuItem.Name = "cW90ToolStripMenuItem";
      this.cW90ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.cW90ToolStripMenuItem.Text = "CW 90°";
      this.cW90ToolStripMenuItem.Click += new System.EventHandler(this.cW90ToolStripMenuItem_Click);
      // 
      // cCW90ToolStripMenuItem
      // 
      this.cCW90ToolStripMenuItem.Name = "cCW90ToolStripMenuItem";
      this.cCW90ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.cCW90ToolStripMenuItem.Text = "CW 270°";
      this.cCW90ToolStripMenuItem.Click += new System.EventHandler(this.cW270ToolStripMenuItem_Click);
      // 
      // cW180ToolStripMenuItem
      // 
      this.cW180ToolStripMenuItem.Name = "cW180ToolStripMenuItem";
      this.cW180ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.cW180ToolStripMenuItem.Text = "CW 180°";
      this.cW180ToolStripMenuItem.Click += new System.EventHandler(this.cW180ToolStripMenuItem_Click);
      // 
      // effectsToolStripMenuItem
      // 
      this.effectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayscaleToolStripMenuItem,
            this.sepiaToolStripMenuItem});
      this.effectsToolStripMenuItem.Name = "effectsToolStripMenuItem";
      this.effectsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.effectsToolStripMenuItem.Text = "Effects";
      // 
      // grayscaleToolStripMenuItem
      // 
      this.grayscaleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("grayscaleToolStripMenuItem.Image")));
      this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
      this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
      this.grayscaleToolStripMenuItem.Text = "Grayscale";
      this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.grayScale_Click);
      // 
      // sepiaToolStripMenuItem
      // 
      this.sepiaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sepiaToolStripMenuItem.Image")));
      this.sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
      this.sepiaToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
      this.sepiaToolStripMenuItem.Text = "Sepia";
      this.sepiaToolStripMenuItem.Click += new System.EventHandler(this.Sepia_Click);
      // 
      // templatesToolStripMenuItem
      // 
      this.templatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3times3,
            this.toolStripMenuItem4times4,
            this.toolStripMenuItem5times5,
            this.customToolStripMenuItem});
      this.templatesToolStripMenuItem.Name = "templatesToolStripMenuItem";
      this.templatesToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
      this.templatesToolStripMenuItem.Text = "Templates";
      // 
      // toolStripMenuItem3times3
      // 
      this.toolStripMenuItem3times3.Name = "toolStripMenuItem3times3";
      this.toolStripMenuItem3times3.Size = new System.Drawing.Size(152, 22);
      this.toolStripMenuItem3times3.Text = "3×3";
      this.toolStripMenuItem3times3.Click += new System.EventHandler(this.toolStripMenuItem3times3_Click);
      // 
      // toolStripMenuItem4times4
      // 
      this.toolStripMenuItem4times4.Name = "toolStripMenuItem4times4";
      this.toolStripMenuItem4times4.Size = new System.Drawing.Size(152, 22);
      this.toolStripMenuItem4times4.Text = "4×4";
      this.toolStripMenuItem4times4.Click += new System.EventHandler(this.toolStripMenuItem4times4_Click);
      // 
      // toolStripMenuItem5times5
      // 
      this.toolStripMenuItem5times5.Name = "toolStripMenuItem5times5";
      this.toolStripMenuItem5times5.Size = new System.Drawing.Size(152, 22);
      this.toolStripMenuItem5times5.Text = "5×5";
      this.toolStripMenuItem5times5.Click += new System.EventHandler(this.toolStripMenuItem5times5_Click);
      // 
      // customToolStripMenuItem
      // 
      this.customToolStripMenuItem.Name = "customToolStripMenuItem";
      this.customToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.customToolStripMenuItem.Text = "Custom";
      this.customToolStripMenuItem.Click += new System.EventHandler(this.customToolStripMenuItem_Click);
      // 
      // menu
      // 
      this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.templatesToolStripMenuItem});
      this.menu.Location = new System.Drawing.Point(0, 0);
      this.menu.Name = "menu";
      this.menu.Size = new System.Drawing.Size(692, 24);
      this.menu.TabIndex = 0;
      this.menu.Text = "menuStrip1";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(692, 466);
      this.Controls.Add(this.panel);
      this.Controls.Add(this.colorbar);
      this.Controls.Add(this.quickbar);
      this.Controls.Add(this.toolbar);
      this.Controls.Add(this.menu);
      this.MainMenuStrip = this.menu;
      this.Name = "Form1";
      this.Text = "untitled";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.Load += new System.EventHandler(this.Form1_Load);
      this.toolbar.ResumeLayout(false);
      this.toolbar.PerformLayout();
      this.quickbar.ResumeLayout(false);
      this.quickbar.PerformLayout();
      this.colorbar.ResumeLayout(false);
      this.colorbar.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
      this.panel.ResumeLayout(false);
      this.panel.PerformLayout();
      this.menu.ResumeLayout(false);
      this.menu.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton pencilButton;
        private System.Windows.Forms.ToolStripButton lineButton;
        private System.Windows.Forms.ToolStripButton rectangleButton;
        private System.Windows.Forms.ToolStripButton ellipseButton;
        private System.Windows.Forms.ToolStrip quickbar;
        private System.Windows.Forms.ToolStripButton newButtonQuick;
        private System.Windows.Forms.ToolStripButton openButtonQuick;
        private System.Windows.Forms.ToolStripButton saveButtonQuick;
        public System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.ToolStripButton eraserButton;
        private System.Windows.Forms.ToolStripButton noFillButton;
        private System.Windows.Forms.ToolStripButton fillButton;
        private System.Windows.Forms.ToolStripButton brushButton;
        private System.Windows.Forms.ToolStripButton colorPickerButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton selectedColorButton;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStripButton undoButtonQuick;
        public System.Windows.Forms.ToolStrip colorbar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton Sepia;
        private System.Windows.Forms.ToolStripButton grayScale;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newButtonMenu;
        private System.Windows.Forms.ToolStripMenuItem openButtonMenu;
        private System.Windows.Forms.ToolStripMenuItem saveButtonMenu;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoButtonMenu;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cW90ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cCW90ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cW180ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem effectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sepiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem templatesToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3times3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4times4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5times5;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton cropButton;
        private System.Windows.Forms.ToolStripButton blackToolStripButton;
        private System.Windows.Forms.ToolStripButton whiteToolStripButton;
        private System.Windows.Forms.ToolStripButton redToolStripButton;
        private System.Windows.Forms.ToolStripButton greenToolStripButton;
        private System.Windows.Forms.ToolStripButton blueToolStripButton;
    }
}

