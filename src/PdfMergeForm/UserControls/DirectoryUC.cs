using PdfMerger.Data.Domain.Enums;
using PdfMerger.Data.Domain.Interfaces;
using PdfMerger.Infrastructure.Services;
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
    public partial class DirectoryUC : UserControl
    {
        private readonly IPDFService _pdfService;
        public DirectoryUC()
        {
            InitializeComponent();

            _pdfService = new PDFService();
        }

        private void btn_Choose_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txt_SelectedDirectory.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private async void btn_Merge_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_SelectedDirectory.Text))
            {
                await _pdfService.MergeAsync(txt_SelectedDirectory.Text, SourceType.Directory);
            }
            else
            {
                MessageBox.Show("Please select a directory!", "No Directory Selected!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
