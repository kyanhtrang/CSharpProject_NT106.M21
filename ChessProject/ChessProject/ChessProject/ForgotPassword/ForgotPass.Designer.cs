namespace ChessProject
{
    partial class ForgotPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgotPass));
            this.pnForgot = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.Verify = new System.Windows.Forms.Label();
            this.tbInputMail = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
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
            this.pnForgot.TabIndex = 15;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.Title.Location = new System.Drawing.Point(75, 25);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(249, 37);
            this.Title.TabIndex = 12;
            this.Title.Text = "XÁC NHẬN EMAIL";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.btnNext.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(275, 175);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 35);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "Tiếp tục";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // Verify
            // 
            this.Verify.AutoSize = true;
            this.Verify.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Verify.Location = new System.Drawing.Point(36, 100);
            this.Verify.Name = "Verify";
            this.Verify.Size = new System.Drawing.Size(327, 20);
            this.Verify.TabIndex = 14;
            this.Verify.Text = "Nhập email bạn đã dùng để đăng ký tài khoản";
            // 
            // tbInputMail
            // 
            this.tbInputMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInputMail.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInputMail.Location = new System.Drawing.Point(25, 135);
            this.tbInputMail.Name = "tbInputMail";
            this.tbInputMail.Size = new System.Drawing.Size(350, 30);
            this.tbInputMail.TabIndex = 13;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(150, 175);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ForgotPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(400, 225);
            this.Controls.Add(this.pnForgot);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.Verify);
            this.Controls.Add(this.tbInputMail);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ForgotPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForgotPass";
            this.pnForgot.ResumeLayout(false);
            this.pnForgot.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnForgot;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label Verify;
        private System.Windows.Forms.TextBox tbInputMail;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button btnCancel;
    }
}