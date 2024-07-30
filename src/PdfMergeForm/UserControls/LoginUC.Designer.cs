namespace PdfMerger.WinForm.UserControls
{
    partial class LoginUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginUC));
            btn_Login = new Button();
            pb_UserName = new PictureBox();
            pb_Password = new PictureBox();
            label1 = new Label();
            txt_Password = new TextBox();
            txt_UserName = new TextBox();
            lbl_UserNamePassword = new Label();
            ((System.ComponentModel.ISupportInitialize)pb_UserName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_Password).BeginInit();
            SuspendLayout();
            // 
            // btn_Login
            // 
            btn_Login.BackColor = SystemColors.GradientInactiveCaption;
            btn_Login.Enabled = false;
            btn_Login.Font = new Font("Segoe UI", 15F);
            btn_Login.Location = new Point(10, 303);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(301, 56);
            btn_Login.TabIndex = 10;
            btn_Login.Text = "Login";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // pb_UserName
            // 
            pb_UserName.Image = (Image)resources.GetObject("pb_UserName.Image");
            pb_UserName.Location = new Point(31, 117);
            pb_UserName.Name = "pb_UserName";
            pb_UserName.Size = new Size(40, 40);
            pb_UserName.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_UserName.TabIndex = 6;
            pb_UserName.TabStop = false;
            // 
            // pb_Password
            // 
            pb_Password.Image = (Image)resources.GetObject("pb_Password.Image");
            pb_Password.Location = new Point(31, 207);
            pb_Password.Name = "pb_Password";
            pb_Password.Size = new Size(40, 40);
            pb_Password.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_Password.TabIndex = 7;
            pb_Password.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label1.Location = new Point(48, 15);
            label1.Name = "label1";
            label1.Size = new Size(230, 46);
            label1.TabIndex = 5;
            label1.Text = "PDF MERGER";
            // 
            // txt_Password
            // 
            txt_Password.Enabled = false;
            txt_Password.Font = new Font("Segoe UI", 15F);
            txt_Password.Location = new Point(95, 213);
            txt_Password.MaxLength = 16;
            txt_Password.Name = "txt_Password";
            txt_Password.PasswordChar = '*';
            txt_Password.PlaceholderText = "Password";
            txt_Password.Size = new Size(195, 34);
            txt_Password.TabIndex = 9;
            txt_Password.TextChanged += txt_Password_TextChanged;
            // 
            // txt_UserName
            // 
            txt_UserName.Font = new Font("Segoe UI", 15F);
            txt_UserName.Location = new Point(95, 123);
            txt_UserName.Name = "txt_UserName";
            txt_UserName.PlaceholderText = "UserName";
            txt_UserName.Size = new Size(195, 34);
            txt_UserName.TabIndex = 8;
            txt_UserName.TextChanged += txt_UserName_TextChanged;
            // 
            // lbl_UserNamePassword
            // 
            lbl_UserNamePassword.AutoSize = true;
            lbl_UserNamePassword.ForeColor = Color.Red;
            lbl_UserNamePassword.Location = new Point(71, 276);
            lbl_UserNamePassword.Name = "lbl_UserNamePassword";
            lbl_UserNamePassword.Size = new Size(0, 15);
            lbl_UserNamePassword.TabIndex = 11;
            // 
            // LoginUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbl_UserNamePassword);
            Controls.Add(btn_Login);
            Controls.Add(pb_UserName);
            Controls.Add(pb_Password);
            Controls.Add(label1);
            Controls.Add(txt_Password);
            Controls.Add(txt_UserName);
            Name = "LoginUC";
            Size = new Size(320, 380);
            ((System.ComponentModel.ISupportInitialize)pb_UserName).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_Password).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Login;
        private PictureBox pb_UserName;
        private PictureBox pb_Password;
        private Label label1;
        private TextBox txt_Password;
        private TextBox txt_UserName;
        private Label lbl_UserNamePassword;
    }
}
