using PdfMerger.Data.Domain.Interfaces;
using PdfMerger.Infrastructure.Services;
using PdfMerger.WinForm.Forms;
using PdfMerger.WinForm.UserControls;
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
    public partial class LoginUC : UserControl
    {
        private readonly IUserService _userService;

        public LoginUC()
        {
            InitializeComponent();

            _userService = new UserService();
        }

        private void txt_UserName_TextChanged(object sender, EventArgs e)
        {
            if (txt_UserName.Text.Length > 3)
            {
                txt_Password.Enabled = true;

                if (txt_Password.Text.Length > 5)
                {
                    btn_Login.Enabled = true;
                }
            }
            else
            {
                txt_Password.Enabled = false;
                btn_Login.Enabled = false;
            }
        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {
            if (txt_Password.Text.Length > 5)
            {
                btn_Login.Enabled = true;
            }
            else
            {
                btn_Login.Enabled = false;
            }
        }

        private async void btn_Login_Click(object sender, EventArgs e)
        {
            var userName = txt_UserName.Text;
            var password = txt_Password.Text;

            if (await _userService.ValidateUserAsync(userName, password))
            {
                lbl_UserNamePassword.Text = "";
                this.Visible = false;

                Form mainForm = this.Parent as Form;
                UserControl methodSelectionUC = mainForm.Controls["methodSelectionUC"] as UserControl;

                methodSelectionUC.Visible = true;
            }
            else
            {
                lbl_UserNamePassword.Text = "Incorrect User Name Or Password!!!";
            }
        }
    }
}