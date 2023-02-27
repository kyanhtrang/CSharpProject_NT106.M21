using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessProject
{
    public partial class ResetPass : Form
    {
        public ResetPass()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbPassword.TextLength == 0 || tbReType.TextLength == 0 || tbPassword.Text != tbReType.Text)
            {
                return;
            }

            RSA rsa = new RSA();
            byte[] pass = Encoding.ASCII.GetBytes(tbPassword.Text);
            byte[] encryptedpass = rsa.encrypt(pass);
            string encryptedpassString = Convert.ToBase64String(encryptedpass);

            ServerConnect.Send(ForgotPass.Username, encryptedpassString, 0, 3);
            ServerConnect.WaitForData();

            if (ServerConnect.recvBytes[0] == 1)
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
                Form si = new SignIn();
                this.Hide();
                si.Show();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại, vui lòng nhập mật khẩu khác!");
                return;
            }
        }
    }
}
