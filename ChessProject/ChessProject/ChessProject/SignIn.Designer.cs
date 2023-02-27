namespace ChessProject
{
    partial class SignIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignIn));
            this.header = new System.Windows.Forms.Panel();
            this.ForgotPass = new System.Windows.Forms.Label();
            this.SignUp = new System.Windows.Forms.Label();
            this.bckLogIn = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbAccount = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.Account = new System.Windows.Forms.Label();
            this.header.SuspendLayout();
            this.bckLogIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.header.Controls.Add(this.ForgotPass);
            this.header.Controls.Add(this.SignUp);
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(750, 100);
            this.header.TabIndex = 4;
            // 
            // ForgotPass
            // 
            this.ForgotPass.AutoSize = true;
            this.ForgotPass.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForgotPass.ForeColor = System.Drawing.Color.White;
            this.ForgotPass.Location = new System.Drawing.Point(488, 69);
            this.ForgotPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ForgotPass.Name = "ForgotPass";
            this.ForgotPass.Size = new System.Drawing.Size(156, 25);
            this.ForgotPass.TabIndex = 2;
            this.ForgotPass.Text = "Quên mật khẩu?";
            this.ForgotPass.Click += new System.EventHandler(this.ForgotPass_Click);
            // 
            // SignUp
            // 
            this.SignUp.AutoSize = true;
            this.SignUp.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUp.ForeColor = System.Drawing.Color.White;
            this.SignUp.Location = new System.Drawing.Point(656, 69);
            this.SignUp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SignUp.Name = "SignUp";
            this.SignUp.Size = new System.Drawing.Size(86, 25);
            this.SignUp.TabIndex = 1;
            this.SignUp.Text = "Đăng ký";
            this.SignUp.Click += new System.EventHandler(this.SignUp_Click);
            // 
            // bckLogIn
            // 
            this.bckLogIn.Controls.Add(this.btnLogin);
            this.bckLogIn.Controls.Add(this.tbPassword);
            this.bckLogIn.Controls.Add(this.tbAccount);
            this.bckLogIn.Controls.Add(this.Password);
            this.bckLogIn.Controls.Add(this.Account);
            this.bckLogIn.Location = new System.Drawing.Point(75, 135);
            this.bckLogIn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bckLogIn.Name = "bckLogIn";
            this.bckLogIn.Size = new System.Drawing.Size(600, 284);
            this.bckLogIn.TabIndex = 5;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(19, 203);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(562, 61);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassword.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(225, 122);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(357, 43);
            this.tbPassword.TabIndex = 4;
            // 
            // tbAccount
            // 
            this.tbAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAccount.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAccount.Location = new System.Drawing.Point(225, 41);
            this.tbAccount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbAccount.Name = "tbAccount";
            this.tbAccount.Size = new System.Drawing.Size(357, 43);
            this.tbAccount.TabIndex = 3;
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Segoe UI Semibold", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(46)))), ((int)(((byte)(51)))));
            this.Password.Location = new System.Drawing.Point(19, 122);
            this.Password.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(140, 37);
            this.Password.TabIndex = 2;
            this.Password.Text = "Mật khẩu:";
            // 
            // Account
            // 
            this.Account.AutoSize = true;
            this.Account.Font = new System.Drawing.Font("Segoe UI Semibold", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Account.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(46)))), ((int)(((byte)(51)))));
            this.Account.Location = new System.Drawing.Point(19, 41);
            this.Account.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(204, 37);
            this.Account.TabIndex = 1;
            this.Account.Text = "Tên đăng nhập:";
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.header);
            this.Controls.Add(this.bckLogIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.bckLogIn.ResumeLayout(false);
            this.bckLogIn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label ForgotPass;
        private System.Windows.Forms.Label SignUp;
        private System.Windows.Forms.Panel bckLogIn;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbAccount;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Label Account;
    }
}

