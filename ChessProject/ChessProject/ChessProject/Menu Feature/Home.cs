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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnHuongDan_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://tk-ank.github.io/ChessRule/");
        }

        private void btnQuestion_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://tk-ank.github.io/Question/");
        
        }
    }
}
