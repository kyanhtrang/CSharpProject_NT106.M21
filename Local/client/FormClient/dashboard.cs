using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormClient
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
            localPlay = false;
        }
        public static bool localPlay;
        private void btnSinglePlay_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChessPlay newChessGame = new ChessPlay();
            newChessGame.ShowDialog();
        }

        private void btnLan_Click(object sender, EventArgs e)
        {
            this.Hide();
            localPlay = true;
            ChessPlay newChessGame = new ChessPlay();
            newChessGame.ShowDialog();
        }

    }
}
