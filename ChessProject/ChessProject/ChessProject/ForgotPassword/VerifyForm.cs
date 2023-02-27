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
    public partial class VerifyForm : Form
    {
        public static string VerifyCode = ForgotPass.VerifyCode;
        public static string userMail = ForgotPass.InputMail;
        public VerifyForm()
        {
            InitializeComponent();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {

            if (tbCode.Text == VerifyCode)
            {
                ResetPass sp = new ResetPass();
                this.Hide();
                sp.Show();
            }
            else
            {
                MessageBox.Show("Nhập sai mã xác thực!");
            }
        }

        private  void btnSendAgain_Click(object sender, EventArgs e)
        {

            ServerConnect.Send(userMail, 0, 1);
            ServerConnect.WaitForData();

            if (ServerConnect.recvBytes[0] == 1)
            {
                string recvString = Encoding.UTF8.GetString(ServerConnect.recvBytes, 1, ServerConnect.recvBytes.Length - 1);
                string[] stringArr = recvString.Split(' ');
                ForgotPass.Username = stringArr[0];

                VerifyCode = stringArr[1];
            }
            else
            {
                MessageBox.Show("Có lỗi gì đó xảy ra!");
                return;
            }

        }
    }
}
