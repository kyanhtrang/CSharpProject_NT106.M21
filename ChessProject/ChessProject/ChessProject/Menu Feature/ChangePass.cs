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
    public partial class ChangePass : Form
    {
        public ChangePass()
        {
            InitializeComponent();
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            if (tbPassword.TextLength == 0 || tbNewPass.TextLength == 0
                || tbConfirm.TextLength == 0)
            {
                MessageBox.Show("Không được để trống bất kỳ ô nào!");
                return;
            }    
                
            if (tbNewPass.Text != tbConfirm.Text)
            {
                MessageBox.Show("Nhập mật khẩu mới không trùng khớp!");
                return;
            }    
                

            RSA rsa = new RSA();
            byte[] oldPass = Encoding.ASCII.GetBytes(tbPassword.Text);
            string encryptedOldPass = Convert.ToBase64String(rsa.encrypt(oldPass));
            byte[] newPass = Encoding.ASCII.GetBytes(tbNewPass.Text);
            string encryptedNewPass = Convert.ToBase64String(rsa.encrypt(newPass));


            string stringData = ServerConnect.username + " " + encryptedOldPass + " " + encryptedNewPass;
            ServerConnect.Send(stringData,1,0);
            ServerConnect.WaitForData();
            if (ServerConnect.recvBytes[0] == 1)
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
                this.Close();
            }
            else
                MessageBox.Show("Đổi mật khẩu thất bại!");
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
