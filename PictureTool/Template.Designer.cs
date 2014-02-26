namespace PictureTool {
  partial class Template {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.label1 = new System.Windows.Forms.Label();
      this.rowsNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.label2 = new System.Windows.Forms.Label();
      this.columnsNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.OKButton = new System.Windows.Forms.Button();
      this.CancelButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.rowsNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.columnsNumericUpDown)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(37, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "&Rows:";
      // 
      // rowsNumericUpDown
      // 
      this.rowsNumericUpDown.Location = new System.Drawing.Point(68, 7);
      this.rowsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.rowsNumericUpDown.Name = "rowsNumericUpDown";
      this.rowsNumericUpDown.Size = new System.Drawing.Size(50, 20);
      this.rowsNumericUpDown.TabIndex = 1;
      this.rowsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 35);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(50, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "&Columns:";
      // 
      // columnsNumericUpDown
      // 
      this.columnsNumericUpDown.Location = new System.Drawing.Point(68, 33);
      this.columnsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.columnsNumericUpDown.Name = "columnsNumericUpDown";
      this.columnsNumericUpDown.Size = new System.Drawing.Size(50, 20);
      this.columnsNumericUpDown.TabIndex = 3;
      this.columnsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // OKButton
      // 
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
      this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CancelButton.Location = new System.Drawing.Point(105, 131);
      this.CancelButton.Name = "CancelButton";
      this.CancelButton.Size = new System.Drawing.Size(75, 23);
      this.CancelButton.TabIndex = 5;
      this.CancelButton.Text = "Cancel";
      this.CancelButton.UseVisualStyleBackColor = true;
      this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // Template
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.CancelButton;
      this.ClientSize = new System.Drawing.Size(192, 166);
      this.Controls.Add(this.CancelButton);
      this.Controls.Add(this.OKButton);
      this.Controls.Add(this.columnsNumericUpDown);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.rowsNumericUpDown);
      this.Controls.Add(this.label1);
      this.Name = "Template";
      this.Text = "Template";
      ((System.ComponentModel.ISupportInitialize)(this.rowsNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.columnsNumericUpDown)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown rowsNumericUpDown;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown columnsNumericUpDown;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button CancelButton;
  }
}