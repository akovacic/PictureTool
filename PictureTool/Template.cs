using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PictureTool {
  public partial class Template : Form {
    public Form1 pictureTool;

    public Template() {
      InitializeComponent();
    }

    private void OKButton_Click(object sender, EventArgs e) {
      int rows = (int)rowsNumericUpDown.Value;
      int columns = (int)columnsNumericUpDown.Value;

      if (pictureTool.canvas.Image != null) {
        pictureTool.ApplyTemplate(rows, columns);
        pictureTool.Changed();
      }

      this.Close();
    }

    private void CancelButton_Click(object sender, EventArgs e) {
      this.Close();
    }
  }
}
