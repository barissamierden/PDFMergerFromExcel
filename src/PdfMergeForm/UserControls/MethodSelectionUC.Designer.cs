namespace PdfMerger.WinForm.UserControls
{
    partial class MethodSelectionUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_ByDirectory = new Button();
            btn_ByExcel = new Button();
            SuspendLayout();
            // 
            // btn_ByDirectory
            // 
            btn_ByDirectory.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            btn_ByDirectory.Location = new Point(3, 69);
            btn_ByDirectory.Name = "btn_ByDirectory";
            btn_ByDirectory.Size = new Size(314, 87);
            btn_ByDirectory.TabIndex = 0;
            btn_ByDirectory.Text = "DIRECTORY";
            btn_ByDirectory.UseVisualStyleBackColor = true;
            btn_ByDirectory.Click += btn_ByDirectory_Click;
            // 
            // btn_ByExcel
            // 
            btn_ByExcel.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            btn_ByExcel.Location = new Point(3, 206);
            btn_ByExcel.Name = "btn_ByExcel";
            btn_ByExcel.Size = new Size(314, 87);
            btn_ByExcel.TabIndex = 0;
            btn_ByExcel.Text = "EXCEL";
            btn_ByExcel.UseVisualStyleBackColor = true;
            // 
            // MethodSelectionUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_ByExcel);
            Controls.Add(btn_ByDirectory);
            Name = "MethodSelectionUC";
            Size = new Size(320, 380);
            ResumeLayout(false);
        }

        #endregion

        private Button btn_ByDirectory;
        private Button btn_ByExcel;
    }
}
