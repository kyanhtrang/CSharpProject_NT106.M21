namespace ChessProject
{
    partial class VerifyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerifyForm));
            this.pnForgot = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.Verify = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.btnSendAgain = new System.Windows.Forms.Button();
            this.pnForgot.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnForgot
            // 
            this.pnForgot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.pnForgot.Controls.Add(this.Title);
            this.pnForgot.Location = new System.Drawing.Point(0, 0);
            this.pnForgot.Name = "pnForgot";
            this.pnForgot.Size = new System.Drawing.Size(400, 75);
            this.pnForgot.TabIndex = 14;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.Title.Location = new System.Drawing.Point(40, 25);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(322, 37);
            this.Title.TabIndex = 15;
            this.Title.Text = "XÁC NHẬN DANH TÍNH";
            // 
            // btnVerify
            // 
            this.btnVerify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.btnVerify.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.ForeColor = System.Drawing.Color.White;
            this.btnVerify.Location = new System.Drawing.Point(275, 175);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(100, 35);
            this.btnVerify.TabIndex = 18;
            this.btnVerify.Text = "Xác nhận";
            this.btnVerify.UseVisualStyleBackColor = false;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // Verify
            // 
            this.Verify.AutoSize = true;
            this.Verify.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Verify.Location = new System.Drawing.Point(25, 100);
            this.Verify.Name = "Verify";
            this.Verify.Size = new System.Drawing.Size(321, 20);
            this.Verify.TabIndex = 17;
            this.Verify.Text = "Nhập mã xác nhận được gửi về email của bạn";
            // 
            // tbCode
            // 
            this.tbCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCode.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCode.Location = new System.Drawing.Point(25, 135);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(350, 30);
            this.tbCode.TabIndex = 16;
            // 
            // btnSendAgain
            // 
            this.btnSendAgain.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendAgain.Location = new System.Drawing.Point(150, 175);
            this.btnSendAgain.Name = "btnSendAgain";
            this.btnSendAgain.Size = new System.Drawing.Size(100, 35);
            this.btnSendAgain.TabIndex = 19;
            this.btnSendAgain.Text = "Gửi lại mã";
            this.btnSendAgain.UseVisualStyleBackColor = true;
            this.btnSendAgain.Click += new System.EventHandler(this.btnSendAgain_Click);
            // 
            // VerifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(400, 225);
            this.Controls.Add(this.btnSendAgain);
            this.Controls.Add(this.pnForgot);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.Verify);
            this.Controls.Add(this.tbCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VerifyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VerifyCode";
            this.pnForgot.ResumeLayout(false);
            this.pnForgot.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnForgot;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Label Verify;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button btnSendAgain;
    }
}