namespace PdfMerger.WinForm.UserControls
{
    partial class DirectoryUC
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
            folderBrowserDialog = new FolderBrowserDialog();
            txt_SelectedDirectory = new TextBox();
            label1 = new Label();
            btn_Choose = new Button();
            btn_Merge = new Button();
            SuspendLayout();
            // 
            // folderBrowserDialog
            // 
            folderBrowserDialog.ShowHiddenFiles = true;
            // 
            // txt_SelectedDirectory
            // 
            txt_SelectedDirectory.Font = new Font("Segoe UI", 12F);
            txt_SelectedDirectory.Location = new Point(3, 36);
            txt_SelectedDirectory.Name = "txt_SelectedDirectory";
            txt_SelectedDirectory.Size = new Size(658, 29);
            txt_SelectedDirectory.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(3, 12);
            label1.Name = "label1";
            label1.Size = new Size(136, 21);
            label1.TabIndex = 1;
            label1.Text = "Selected Directory";
            // 
            // btn_Choose
            // 
            btn_Choose.BackColor = Color.DarkGray;
            btn_Choose.FlatStyle = FlatStyle.Popup;
            btn_Choose.Font = new Font("Segoe UI", 12F);
            btn_Choose.Location = new Point(588, 3);
            btn_Choose.Name = "btn_Choose";
            btn_Choose.Size = new Size(73, 29);
            btn_Choose.TabIndex = 2;
            btn_Choose.Text = "Choose";
            btn_Choose.UseVisualStyleBackColor = false;
            btn_Choose.Click += btn_Choose_Click;
            // 
            // btn_Merge
            // 
            btn_Merge.BackColor = Color.IndianRed;
            btn_Merge.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            btn_Merge.Location = new Point(252, 97);
            btn_Merge.Name = "btn_Merge";
            btn_Merge.Size = new Size(153, 54);
            btn_Merge.TabIndex = 3;
            btn_Merge.Text = "MERGE";
            btn_Merge.UseVisualStyleBackColor = false;
            btn_Merge.Click += btn_Merge_Click;
            // 
            // DirectoryUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_Merge);
            Controls.Add(btn_Choose);
            Controls.Add(label1);
            Controls.Add(txt_SelectedDirectory);
            Name = "DirectoryUC";
            Size = new Size(664, 190);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog;
        private TextBox txt_SelectedDirectory;
        private Label label1;
        private Button btn_Choose;
        private Button btn_Merge;
    }
}
