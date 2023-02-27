namespace ChessProject
{
    partial class SignUp
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            this.Title = new System.Windows.Forms.Label();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.cbFemale = new System.Windows.Forms.CheckBox();
            this.cbMale = new System.Windows.Forms.CheckBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbConfirm = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.Label();
            this.Sex = new System.Windows.Forms.Label();
            this.Confirm = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.Label();
            this.PNSignUp = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.pnTitle.SuspendLayout();
            this.PNSignUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(101, 25);
            this.Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(347, 45);
            this.Title.TabIndex = 0;
            this.Title.Text = "TẠO TÀI KHOẢN MỚI";
            // 
            // pnTitle
            // 
            this.pnTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.pnTitle.Controls.Add(this.Title);
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(550, 75);
            this.pnTitle.TabIndex = 6;
            // 
            // tbEmail
            // 
            this.tbEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEmail.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmail.Location = new System.Drawing.Point(200, 125);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbEmail.Multiline = true;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(325, 27);
            this.tbEmail.TabIndex = 26;
            // 
            // cbFemale
            // 
            this.cbFemale.AutoSize = true;
            this.cbFemale.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFemale.Location = new System.Drawing.Point(375, 75);
            this.cbFemale.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbFemale.Name = "cbFemale";
            this.cbFemale.Size = new System.Drawing.Size(56, 29);
            this.cbFemale.TabIndex = 24;
            this.cbFemale.Text = "Nữ";
            this.cbFemale.UseVisualStyleBackColor = true;
            // 
            // cbMale
            // 
            this.cbMale.AutoSize = true;
            this.cbMale.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMale.Location = new System.Drawing.Point(200, 75);
            this.cbMale.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbMale.Name = "cbMale";
            this.cbMale.Size = new System.Drawing.Size(71, 29);
            this.cbMale.TabIndex = 23;
            this.cbMale.Text = "Nam";
            this.cbMale.UseVisualStyleBackColor = true;
            // 
            // tbPassword
            // 
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassword.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(200, 175);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPassword.Multiline = true;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(325, 27);
            this.tbPassword.TabIndex = 21;
            // 
            // tbUsername
            // 
            this.tbUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUsername.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.tbUsername.Location = new System.Drawing.Point(200, 25);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbUsername.Multiline = true;
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(325, 27);
            this.tbUsername.TabIndex = 20;
            // 
            // tbConfirm
            // 
            this.tbConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbConfirm.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConfirm.Location = new System.Drawing.Point(200, 225);
            this.tbConfirm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbConfirm.Multiline = true;
            this.tbConfirm.Name = "tbConfirm";
            this.tbConfirm.PasswordChar = '*';
            this.tbConfirm.Size = new System.Drawing.Size(325, 27);
            this.tbConfirm.TabIndex = 19;
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.Email.Location = new System.Drawing.Point(15, 125);
            this.Email.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(64, 25);
            this.Email.TabIndex = 15;
            this.Email.Text = "Email:";
            // 
            // Sex
            // 
            this.Sex.AutoSize = true;
            this.Sex.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.Sex.Location = new System.Drawing.Point(15, 75);
            this.Sex.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Sex.Name = "Sex";
            this.Sex.Size = new System.Drawing.Size(91, 25);
            this.Sex.TabIndex = 13;
            this.Sex.Text = "Giới tính:";
            // 
            // Confirm
            // 
            this.Confirm.AutoSize = true;
            this.Confirm.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Confirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.Confirm.Location = new System.Drawing.Point(15, 225);
            this.Confirm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(175, 25);
            this.Confirm.TabIndex = 11;
            this.Confirm.Text = "Nhập lại mật khẩu:";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.Password.Location = new System.Drawing.Point(15, 175);
            this.Password.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(99, 25);
            this.Password.TabIndex = 10;
            this.Password.Text = "Mật khẩu:";
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.Username.Location = new System.Drawing.Point(15, 25);
            this.Username.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(143, 25);
            this.Username.TabIndex = 9;
            this.Username.Text = "Tên đăng nhập:";
            // 
            // PNSignUp
            // 
            this.PNSignUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.PNSignUp.Controls.Add(this.btnCancel);
            this.PNSignUp.Controls.Add(this.tbEmail);
            this.PNSignUp.Controls.Add(this.cbFemale);
            this.PNSignUp.Controls.Add(this.cbMale);
            this.PNSignUp.Controls.Add(this.tbPassword);
            this.PNSignUp.Controls.Add(this.tbUsername);
            this.PNSignUp.Controls.Add(this.tbConfirm);
            this.PNSignUp.Controls.Add(this.btnSignUp);
            this.PNSignUp.Controls.Add(this.Email);
            this.PNSignUp.Controls.Add(this.Sex);
            this.PNSignUp.Controls.Add(this.Confirm);
            this.PNSignUp.Controls.Add(this.Password);
            this.PNSignUp.Controls.Add(this.Username);
            this.PNSignUp.Location = new System.Drawing.Point(0, 75);
            this.PNSignUp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PNSignUp.Name = "PNSignUp";
            this.PNSignUp.Size = new System.Drawing.Size(550, 325);
            this.PNSignUp.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(250, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 35);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSignUp
            // 
            this.btnSignUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.btnSignUp.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUp.ForeColor = System.Drawing.Color.White;
            this.btnSignUp.Location = new System.Drawing.Point(400, 265);
            this.btnSignUp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(125, 35);
            this.btnSignUp.TabIndex = 18;
            this.btnSignUp.Text = "Đăng Ký";
            this.btnSignUp.UseVisualStyleBackColor = false;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(550, 400);
            this.Controls.Add(this.pnTitle);
            this.Controls.Add(this.PNSignUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SignUp";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignUp";
            this.pnTitle.ResumeLayout(false);
            this.pnTitle.PerformLayout();
            this.PNSignUp.ResumeLayout(false);
            this.PNSignUp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Panel pnTitle;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.CheckBox cbFemale;
        private System.Windows.Forms.CheckBox cbMale;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbConfirm;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.Label Sex;
        private System.Windows.Forms.Label Confirm;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Panel PNSignUp;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Button btnCancel;
    }
}