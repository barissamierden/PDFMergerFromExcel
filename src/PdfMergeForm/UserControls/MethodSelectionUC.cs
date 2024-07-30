using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfMerger.WinForm.UserControls
{
    public partial class MethodSelectionUC : UserControl
    {
        public MethodSelectionUC()
        {
            InitializeComponent();
        }

        private void btn_ByDirectory_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            Form mainForm =  this.Parent as Form;
            UserControl directoryUC = mainForm.Controls["directoryUC"] as UserControl;

            directoryUC.Visible = true;
        }
    }
}
