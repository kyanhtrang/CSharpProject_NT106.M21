namespace ChessProject
{
    partial class Infor
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
            System.Windows.Forms.Button btnChangePass;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Infor));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblWinRatio1 = new System.Windows.Forms.Label();
            this.lblSumWin1 = new System.Windows.Forms.Label();
            this.lblWinRatio = new System.Windows.Forms.Label();
            this.lblSumWin = new System.Windows.Forms.Label();
            this.lblCurRank1 = new System.Windows.Forms.Label();
            this.lblCurRank = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblMatchSum1 = new System.Windows.Forms.Label();
            this.lblMatchSum = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            btnChangePass = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChangePass
            // 
            btnChangePass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            btnChangePass.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            btnChangePass.FlatAppearance.BorderSize = 0;
            btnChangePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnChangePass.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            btnChangePass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            btnChangePass.Location = new System.Drawing.Point(735, 102);
            btnChangePass.Name = "btnChangePass";
            btnChangePass.Size = new System.Drawing.Size(137, 45);
            btnChangePass.TabIndex = 1;
            btnChangePass.TabStop = false;
            btnChangePass.Text = "Đổi mật khẩu";
            btnChangePass.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            btnChangePass.UseCompatibleTextRendering = true;
            btnChangePass.UseVisualStyleBackColor = false;
            btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ChessProject.Properties.Resources._284515049_446015590687536_464088055087704388_n;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(375, 200);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(275, 275);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // lblWinRatio1
            // 
            this.lblWinRatio1.AutoSize = true;
            this.lblWinRatio1.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblWinRatio1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.lblWinRatio1.Location = new System.Drawing.Point(250, 400);
            this.lblWinRatio1.Name = "lblWinRatio1";
            this.lblWinRatio1.Size = new System.Drawing.Size(39, 46);
            this.lblWinRatio1.TabIndex = 10;
            this.lblWinRatio1.Text = "0";
            // 
            // lblSumWin1
            // 
            this.lblSumWin1.AutoSize = true;
            this.lblSumWin1.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblSumWin1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.lblSumWin1.Location = new System.Drawing.Point(250, 325);
            this.lblSumWin1.Name = "lblSumWin1";
            this.lblSumWin1.Size = new System.Drawing.Size(39, 46);
            this.lblSumWin1.TabIndex = 9;
            this.lblSumWin1.Text = "0";
            // 
            // lblWinRatio
            // 
            this.lblWinRatio.AutoSize = true;
            this.lblWinRatio.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.lblWinRatio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.lblWinRatio.Location = new System.Drawing.Point(16, 400);
            this.lblWinRatio.Name = "lblWinRatio";
            this.lblWinRatio.Size = new System.Drawing.Size(170, 40);
            this.lblWinRatio.TabIndex = 8;
            this.lblWinRatio.Text = "Tỷ lệ thắng:";
            // 
            // lblSumWin
            // 
            this.lblSumWin.AutoSize = true;
            this.lblSumWin.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.lblSumWin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.lblSumWin.Location = new System.Drawing.Point(15, 325);
            this.lblSumWin.Name = "lblSumWin";
            this.lblSumWin.Size = new System.Drawing.Size(202, 40);
            this.lblSumWin.TabIndex = 6;
            this.lblSumWin.Text = "Số trận thắng:";
            // 
            // lblCurRank1
            // 
            this.lblCurRank1.AutoSize = true;
            this.lblCurRank1.Font = new System.Drawing.Font("Segoe UI Black", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurRank1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.lblCurRank1.Location = new System.Drawing.Point(302, 100);
            this.lblCurRank1.Name = "lblCurRank1";
            this.lblCurRank1.Size = new System.Drawing.Size(93, 106);
            this.lblCurRank1.TabIndex = 5;
            this.lblCurRank1.Text = "0";
            // 
            // lblCurRank
            // 
            this.lblCurRank.AutoSize = true;
            this.lblCurRank.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurRank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.lblCurRank.Location = new System.Drawing.Point(94, 14);
            this.lblCurRank.Name = "lblCurRank";
            this.lblCurRank.Size = new System.Drawing.Size(646, 106);
            this.lblCurRank.TabIndex = 2;
            this.lblCurRank.Text = "HẠNG HIỆN TẠI";
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 30F, System.Drawing.FontStyle.Bold);
            this.lbUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.lbUsername.Location = new System.Drawing.Point(49, 42);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(314, 67);
            this.lbUsername.TabIndex = 0;
            this.lbUsername.Text = "lblUsername";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(btnChangePass);
            this.panel1.Controls.Add(this.lbUsername);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(875, 150);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.lblMatchSum1);
            this.panel3.Controls.Add(this.lblMatchSum);
            this.panel3.Controls.Add(this.lblWinRatio1);
            this.panel3.Controls.Add(this.lblSumWin1);
            this.panel3.Controls.Add(this.lblWinRatio);
            this.panel3.Controls.Add(this.lblSumWin);
            this.panel3.Controls.Add(this.lblCurRank1);
            this.panel3.Controls.Add(this.lblCurRank);
            this.panel3.Location = new System.Drawing.Point(90, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(700, 500);
            this.panel3.TabIndex = 0;
            // 
            // lblMatchSum1
            // 
            this.lblMatchSum1.AutoSize = true;
            this.lblMatchSum1.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblMatchSum1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.lblMatchSum1.Location = new System.Drawing.Point(250, 250);
            this.lblMatchSum1.Name = "lblMatchSum1";
            this.lblMatchSum1.Size = new System.Drawing.Size(39, 46);
            this.lblMatchSum1.TabIndex = 12;
            this.lblMatchSum1.Text = "0";
            // 
            // lblMatchSum
            // 
            this.lblMatchSum.AutoSize = true;
            this.lblMatchSum.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.lblMatchSum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.lblMatchSum.Location = new System.Drawing.Point(15, 250);
            this.lblMatchSum.Name = "lblMatchSum";
            this.lblMatchSum.Size = new System.Drawing.Size(264, 40);
            this.lblMatchSum.TabIndex = 11;
            this.lblMatchSum.Text = "Tổng số trận hạng:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(875, 650);
            this.panel2.TabIndex = 5;
            // 
            // Infor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 800);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Infor";
            this.Text = "Infor";
            this.Load += new System.EventHandler(this.Infor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblWinRatio1;
        private System.Windows.Forms.Label lblSumWin1;
        private System.Windows.Forms.Label lblWinRatio;
        private System.Windows.Forms.Label lblSumWin;
        private System.Windows.Forms.Label lblCurRank1;
        private System.Windows.Forms.Label lblCurRank;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblMatchSum1;
        private System.Windows.Forms.Label lblMatchSum;
        private System.Windows.Forms.Panel panel2;
    }
}