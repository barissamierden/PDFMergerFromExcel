namespace PdfMerger.WinForm.Forms
{
    partial class MainForm
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
            loginUC = new UserControls.LoginUC();
            methodSelectionUC = new UserControls.MethodSelectionUC();
            directoryUC = new UserControls.DirectoryUC();
            SuspendLayout();
            // 
            // loginUC
            // 
            loginUC.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            loginUC.Location = new Point(215, 80);
            loginUC.Name = "loginUC";
            loginUC.Size = new Size(320, 380);
            loginUC.TabIndex = 0;
            // 
            // methodSelectionUC
            // 
            methodSelectionUC.Location = new Point(215, 80);
            methodSelectionUC.Name = "methodSelectionUC";
            methodSelectionUC.Size = new Size(320, 380);
            methodSelectionUC.TabIndex = 1;
            methodSelectionUC.Visible = false;
            // 
            // directoryUC
            // 
            directoryUC.Location = new Point(37, 172);
            directoryUC.Name = "directoryUC";
            directoryUC.Size = new Size(664, 190);
            directoryUC.TabIndex = 2;
            directoryUC.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 561);
            Controls.Add(directoryUC);
            Controls.Add(methodSelectionUC);
            Controls.Add(loginUC);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainForm";
            Text = "PDF MERGER";
            ResumeLayout(false);
        }

        #endregion

        private UserControls.LoginUC loginUC;
        private UserControls.MethodSelectionUC methodSelectionUC;
        private UserControls.DirectoryUC directoryUC;
    }
}