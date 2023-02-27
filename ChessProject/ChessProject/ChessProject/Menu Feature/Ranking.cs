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
    public partial class Ranking : Form
    {
        public Ranking()
        {
            InitializeComponent();
        }

        private void Ranking_Load(object sender, EventArgs e)
        {
            if (ServerConnect.username.Length == 0)
            {
                return;
            }
            
            ServerConnect.Send(ServerConnect.username, 0, 7);
            ServerConnect.WaitForData();

            if (ServerConnect.recvBytes[0] != 0)
            {
                string recvData = Encoding.UTF8.GetString(ServerConnect.recvBytes, 1, ServerConnect.recvBytes.Length-1).Trim();
                string[] stringArr = recvData.Split(' ');
                lblTop1.Text = stringArr[0];
                lblTop2.Text = stringArr[2];
                lblTop3.Text = stringArr[4];
                lblUser.Text = stringArr[6];
                lblUserPoint.Text = stringArr[7];
                lblUserRank.Text = stringArr[8];
            }
            else
            {
                MessageBox.Show("Load bảng xếp hạng thất bại!");
                return;
            }
        }
    }
}
