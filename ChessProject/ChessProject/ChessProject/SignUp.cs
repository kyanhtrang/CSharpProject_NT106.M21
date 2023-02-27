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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (tbUsername.TextLength == 0 || tbPassword.TextLength == 0 ||
                tbEmail.TextLength == 0 || tbPassword.Text != tbConfirm.Text ||
                (!cbMale.Checked && !cbFemale.Checked))
            {
                return;
            }
            RSA rsa = new RSA();
            byte[] pass = Encoding.ASCII.GetBytes(tbPassword.Text);
            byte[] encryptedpass = rsa.encrypt(pass);
            string encryptedpassString = Convert.ToBase64String(encryptedpass);

            ServerConnect.Send(tbUsername.Text, encryptedpassString, tbEmail.Text, 0, 6);
            ServerConnect.WaitForData();


            if (ServerConnect.recvBytes[0] == 1)
            {
                MessageBox.Show("Đăng ký thành công!");
                Form login = new SignIn();
                this.Hide();
                login.Show();
            }
            else
            {
                MessageBox.Show("Đăng ký không thành công!");
                return;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form si = new SignIn();
            this.Hide();
            si.Show();
        }
    }
}
