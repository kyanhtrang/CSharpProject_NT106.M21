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
    public partial class ForgotPass : Form
    {
        public static string InputMail = "";
        public static string Username = "";
        public static string VerifyCode = "";
        //Socket clientSocket = SignIn.clientSocket;
        public ForgotPass()
        {
            InitializeComponent();
        }

        
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbInputMail.TextLength==0)
            {
                return;
            }

            ServerConnect.Send(tbInputMail.Text, 0, 1);
            ServerConnect.WaitForData();

            if (ServerConnect.recvBytes[0] == 1)
            {
                InputMail = tbInputMail.Text;
                string recvString = Encoding.UTF8.GetString(ServerConnect.recvBytes, 1, ServerConnect.recvBytes.Length - 1);
                string[] stringArr = recvString.Split(' ');
                Username = stringArr[0];
                VerifyCode = stringArr[1];

                VerifyForm vs = new VerifyForm();
                this.Hide();
                vs.Show();
            }
            else
            {
                MessageBox.Show("Không tồn tại Mail này");
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Form login = new SignIn();
            this.Hide();
            login.Show();
        }
    }
}
