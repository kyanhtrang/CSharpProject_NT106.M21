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
    public partial class Infor : Form
    {
        public Infor()
        {
            InitializeComponent();
        }
        private void Infor_Load(object sender, EventArgs e)
        {
            lbUsername.Text = ServerConnect.username;
            ServerConnect.Send(ServerConnect.username, 0, 8);
            ServerConnect.WaitForData();

            if (ServerConnect.recvBytes[0] == 1)
            {
                string[] dataString = Encoding.UTF8.GetString(ServerConnect.recvBytes, 1, ServerConnect.recvBytes.Length - 1).Split(' ');
                lblMatchSum1.Text = dataString[0];
                lblCurRank1.Text = dataString[1];
                lblSumWin1.Text = dataString[2];
                lblWinRatio1.Text = dataString[3];
            }
            else
            {
                MessageBox.Show("Load thông tin cá nhân thất bại!");
                return;
            }
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            ChangePass cp = new ChangePass();
            cp.Show();
        }
    }
}
