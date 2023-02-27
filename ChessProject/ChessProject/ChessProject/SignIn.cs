using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace ChessProject
{
    
    public partial class SignIn : Form
    {
        

        public SignIn()
        {
            InitializeComponent();
        }
        private void ForgotPass_Click(object sender, EventArgs e)
        {
            ForgotPass fg = new ForgotPass();
            this.Hide();
            fg.Show();
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            SignUp su = new SignUp();
            this.Hide();
            su.Show();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbAccount.TextLength == 0 || tbPassword.TextLength == 0)
            {
                return;
            }

            RSA rsa = new RSA();
            byte[] pass = Encoding.ASCII.GetBytes(tbPassword.Text);
            byte[] encryptedpass = rsa.encrypt(pass);
            string encryptedpassString = Convert.ToBase64String(encryptedpass);

            string sendString = tbAccount.Text + " " + encryptedpassString;

            ServerConnect.Send(sendString, 0, 4);
            ServerConnect.WaitForData();


            if (ServerConnect.recvBytes[0] == 1) 
            {
                ServerConnect.username = tbAccount.Text;
                MessageBox.Show("Đăng nhập thành công!");
                Form menu = new Menu();
                this.Hide();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu");
                return;
            }
        }
    }
}
