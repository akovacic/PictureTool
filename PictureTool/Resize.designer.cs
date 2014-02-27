namespace PictureTool
{
    partial class Resize
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
          this.label1 = new System.Windows.Forms.Label();
          this.label2 = new System.Windows.Forms.Label();
          this.OKButton = new System.Windows.Forms.Button();
          this.CancelButton = new System.Windows.Forms.Button();
          this.label3 = new System.Windows.Forms.Label();
          this.label4 = new System.Windows.Forms.Label();
          this.WidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
          this.HeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
          this.aspectRatioCheckBox = new System.Windows.Forms.CheckBox();
          ((System.ComponentModel.ISupportInitialize)(this.WidthNumericUpDown)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.HeightNumericUpDown)).BeginInit();
          this.SuspendLayout();
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(9, 9);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(38, 13);
          this.label1.TabIndex = 0;
          this.label1.Text = "&Width:";
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(9, 38);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(41, 13);
          this.label2.TabIndex = 2;
          this.label2.Text = "&Height:";
          // 
          // OKButton
          // 
          this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
          this.OKButton.Location = new System.Drawing.Point(105, 102);
          this.OKButton.Name = "OKButton";
          this.OKButton.Size = new System.Drawing.Size(75, 23);
          this.OKButton.TabIndex = 4;
          this.OKButton.Text = "OK";
          this.OKButton.UseVisualStyleBackColor = true;
          this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
          // 
          // CancelButton
          // 
          this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
          this.CancelButton.Location = new System.Drawing.Point(105, 131);
          this.CancelButton.Name = "CancelButton";
          this.CancelButton.Size = new System.Drawing.Size(75, 23);
          this.CancelButton.TabIndex = 5;
          this.CancelButton.Text = "Cancel";
          this.CancelButton.UseVisualStyleBackColor = true;
          this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
          // 
          // label3
          // 
          this.label3.Location = new System.Drawing.Point(112, 12);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(35, 13);
          this.label3.TabIndex = 0;
          this.label3.Text = "px";
          // 
          // label4
          // 
          this.label4.Location = new System.Drawing.Point(112, 38);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(35, 13);
          this.label4.TabIndex = 0;
          this.label4.Text = "px";
          // 
          // WidthNumericUpDown
          // 
          this.WidthNumericUpDown.Location = new System.Drawing.Point(56, 7);
          this.WidthNumericUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
          this.WidthNumericUpDown.Name = "WidthNumericUpDown";
          this.WidthNumericUpDown.Size = new System.Drawing.Size(50, 20);
          this.WidthNumericUpDown.TabIndex = 1;
          this.WidthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
          this.WidthNumericUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WidthChanged);
          this.WidthNumericUpDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WidthChanged);
          // 
          // HeightNumericUpDown
          // 
          this.HeightNumericUpDown.Location = new System.Drawing.Point(56, 36);
          this.HeightNumericUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
          this.HeightNumericUpDown.Name = "HeightNumericUpDown";
          this.HeightNumericUpDown.Size = new System.Drawing.Size(50, 20);
          this.HeightNumericUpDown.TabIndex = 3;
          this.HeightNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
          this.HeightNumericUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HeightChanged);
          this.HeightNumericUpDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HeightChanged);
          // 
          // aspectRaitoCheckBox
          // 
          this.aspectRatioCheckBox.AutoSize = true;
          this.aspectRatioCheckBox.Checked = true;
          this.aspectRatioCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
          this.aspectRatioCheckBox.Location = new System.Drawing.Point(12, 62);
          this.aspectRatioCheckBox.Name = "aspectRaitoCheckBox";
          this.aspectRatioCheckBox.Size = new System.Drawing.Size(124, 17);
          this.aspectRatioCheckBox.TabIndex = 6;
          this.aspectRatioCheckBox.Text = "&Maintain aspect ratio";
          this.aspectRatioCheckBox.UseVisualStyleBackColor = true;
          this.aspectRatioCheckBox.CheckedChanged += new System.EventHandler(this.AspectRatioToggled);
          // 
          // Resize
          // 
          this.AcceptButton = this.OKButton;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(192, 166);
          this.Controls.Add(this.aspectRatioCheckBox);
          this.Controls.Add(this.HeightNumericUpDown);
          this.Controls.Add(this.WidthNumericUpDown);
          this.Controls.Add(this.label4);
          this.Controls.Add(this.label3);
          this.Controls.Add(this.CancelButton);
          this.Controls.Add(this.OKButton);
          this.Controls.Add(this.label2);
          this.Controls.Add(this.label1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "Resize";
          this.Text = "Resize";
          this.Load += new System.EventHandler(this.Resize_Load);
          ((System.ComponentModel.ISupportInitialize)(this.WidthNumericUpDown)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.HeightNumericUpDown)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown WidthNumericUpDown;
        private System.Windows.Forms.NumericUpDown HeightNumericUpDown;
        private System.Windows.Forms.CheckBox aspectRatioCheckBox;
    }
}