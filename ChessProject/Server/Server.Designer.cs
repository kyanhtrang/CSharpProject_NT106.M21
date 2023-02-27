
namespace Server
{
    partial class Server
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server));
            this.btnListen = new System.Windows.Forms.Button();
            this.lblLocalName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbLocalName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnListen
            // 
            this.btnListen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.btnListen.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListen.ForeColor = System.Drawing.SystemColors.Control;
            this.btnListen.Location = new System.Drawing.Point(300, 100);
            this.btnListen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(125, 35);
            this.btnListen.TabIndex = 0;
            this.btnListen.Text = "Host";
            this.btnListen.UseVisualStyleBackColor = false;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // lblLocalName
            // 
            this.lblLocalName.AutoSize = true;
            this.lblLocalName.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalName.Location = new System.Drawing.Point(15, 15);
            this.lblLocalName.Name = "lblLocalName";
            this.lblLocalName.Size = new System.Drawing.Size(62, 23);
            this.lblLocalName.TabIndex = 1;
            this.lblLocalName.Text = "SQL ID";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(15, 65);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(82, 23);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            // 
            // tbLocalName
            // 
            this.tbLocalName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLocalName.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLocalName.Location = new System.Drawing.Point(125, 12);
            this.tbLocalName.Name = "tbLocalName";
            this.tbLocalName.Size = new System.Drawing.Size(300, 30);
            this.tbLocalName.TabIndex = 3;
            this.tbLocalName.Text = "DESKTOP-AG3SDR7\\SQLEXPRESS";
            // 
            // tbPassword
            // 
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassword.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(125, 62);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(300, 30);
            this.tbPassword.TabIndex = 4;
            this.tbPassword.Text = "123321";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(434, 146);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbLocalName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblLocalName);
            this.Controls.Add(this.btnListen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chess Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.Label lblLocalName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbLocalName;
        private System.Windows.Forms.TextBox tbPassword;
    }
}

