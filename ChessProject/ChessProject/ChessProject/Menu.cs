using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;

namespace ChessProject
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        
        
        private void btnHome_Click(object sender, EventArgs e)
        { 
            pnContent.Controls.Clear();
            Home TrangChu = new Home()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            this.pnContent.Controls.Add(TrangChu);
            TrangChu.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            Home TrangChu = new Home()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            this.pnContent.Controls.Add(TrangChu);
            TrangChu.Show();
        }

        private void btnInfor_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            Infor ThongTin = new Infor()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            this.pnContent.Controls.Add(ThongTin);
            ThongTin.Show();
        }

        private void btnRank_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            Ranking BXH = new Ranking()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            this.pnContent.Controls.Add(BXH);
            BXH.Show();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            PlayGame playGame = new PlayGame()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            this.pnContent.Controls.Add(playGame);
            playGame.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ServerConnect.username = "";
            this.Close();
            SignIn si = new SignIn();
            si.Show();
        }
    }
}
