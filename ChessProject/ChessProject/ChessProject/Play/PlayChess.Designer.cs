namespace ChessProject
{
    partial class PlayChess
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayChess));
            this.coordinates = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.boardLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbInput = new System.Windows.Forms.TextBox();
            this.lstChatBox = new System.Windows.Forms.ListView();
            this.btnResign = new System.Windows.Forms.Button();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnMute = new System.Windows.Forms.Button();
            this.btnChat = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.boardLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.boardLayoutPanel, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(50, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 650F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(650, 650);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // boardLayoutPanel
            // 
            this.boardLayoutPanel.ColumnCount = 9;
            this.boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.80226F));
            this.boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.29944F));
            this.boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.29944F));
            this.boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.29944F));
            this.boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.29944F));
            this.boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.29944F));
            this.boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.29944F));
            this.boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.29944F));
            this.boardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.29944F));
            this.boardLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.boardLayoutPanel.Controls.Add(this.label2, 1, 0);
            this.boardLayoutPanel.Controls.Add(this.label3, 2, 0);
            this.boardLayoutPanel.Controls.Add(this.label4, 3, 0);
            this.boardLayoutPanel.Controls.Add(this.label5, 4, 0);
            this.boardLayoutPanel.Controls.Add(this.label6, 5, 0);
            this.boardLayoutPanel.Controls.Add(this.label7, 6, 0);
            this.boardLayoutPanel.Controls.Add(this.label8, 7, 0);
            this.boardLayoutPanel.Controls.Add(this.label9, 8, 0);
            this.boardLayoutPanel.Controls.Add(this.label10, 0, 1);
            this.boardLayoutPanel.Controls.Add(this.label11, 0, 2);
            this.boardLayoutPanel.Controls.Add(this.label12, 0, 3);
            this.boardLayoutPanel.Controls.Add(this.label13, 0, 4);
            this.boardLayoutPanel.Controls.Add(this.label14, 0, 5);
            this.boardLayoutPanel.Controls.Add(this.label15, 0, 6);
            this.boardLayoutPanel.Controls.Add(this.label16, 0, 7);
            this.boardLayoutPanel.Controls.Add(this.label17, 0, 8);
            this.boardLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boardLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.boardLayoutPanel.Name = "boardLayoutPanel";
            this.boardLayoutPanel.RowCount = 9;
            this.boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.80226F));
            this.boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.29944F));
            this.boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.29944F));
            this.boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.29944F));
            this.boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.29944F));
            this.boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.29944F));
            this.boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.29944F));
            this.boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.29944F));
            this.boardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.29944F));
            this.boardLayoutPanel.Size = new System.Drawing.Size(644, 644);
            this.boardLayoutPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 32);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "a";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(111, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "b";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(187, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "c";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(263, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "d";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(339, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 32);
            this.label6.TabIndex = 5;
            this.label6.Text = "e";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(415, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 32);
            this.label7.TabIndex = 6;
            this.label7.Text = "f";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(491, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 32);
            this.label8.TabIndex = 7;
            this.label8.Text = "g";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(567, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 32);
            this.label9.TabIndex = 8;
            this.label9.Text = "h";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 76);
            this.label10.TabIndex = 9;
            this.label10.Text = "8";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 76);
            this.label11.TabIndex = 10;
            this.label11.Text = "7";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 76);
            this.label12.TabIndex = 11;
            this.label12.Text = "6";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 260);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 76);
            this.label13.TabIndex = 12;
            this.label13.Text = "5";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 336);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 76);
            this.label14.TabIndex = 13;
            this.label14.Text = "4";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(3, 412);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 76);
            this.label15.TabIndex = 14;
            this.label15.Text = "3";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(3, 488);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 76);
            this.label16.TabIndex = 15;
            this.label16.Text = "2";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(3, 564);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(26, 80);
            this.label17.TabIndex = 16;
            this.label17.Text = "1";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbInput
            // 
            this.tbInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInput.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInput.Location = new System.Drawing.Point(50, 725);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(650, 33);
            this.tbInput.TabIndex = 1;
            // 
            // lstChatBox
            // 
            this.lstChatBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstChatBox.HideSelection = false;
            this.lstChatBox.Location = new System.Drawing.Point(725, 200);
            this.lstChatBox.Name = "lstChatBox";
            this.lstChatBox.Size = new System.Drawing.Size(450, 500);
            this.lstChatBox.TabIndex = 2;
            this.lstChatBox.UseCompatibleStateImageBehavior = false;
            // 
            // btnResign
            // 
            this.btnResign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.btnResign.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResign.ForeColor = System.Drawing.SystemColors.Control;
            this.btnResign.Location = new System.Drawing.Point(975, 150);
            this.btnResign.Name = "btnResign";
            this.btnResign.Size = new System.Drawing.Size(200, 35);
            this.btnResign.TabIndex = 3;
            this.btnResign.Text = "Đầu hàng";
            this.btnResign.UseVisualStyleBackColor = false;
            // 
            // btnDraw
            // 
            this.btnDraw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.btnDraw.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDraw.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDraw.Location = new System.Drawing.Point(725, 150);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(200, 35);
            this.btnDraw.TabIndex = 4;
            this.btnDraw.Text = "Cầu hòa";
            this.btnDraw.UseVisualStyleBackColor = false;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.btnSend.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSend.Location = new System.Drawing.Point(725, 725);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 35);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Gửi";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnMute
            // 
            this.btnMute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.btnMute.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMute.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMute.Location = new System.Drawing.Point(1025, 725);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(150, 35);
            this.btnMute.TabIndex = 6;
            this.btnMute.Text = "Tắt chat";
            this.btnMute.UseVisualStyleBackColor = false;
            // 
            // btnChat
            // 
            this.btnChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.btnChat.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChat.ForeColor = System.Drawing.SystemColors.Control;
            this.btnChat.Location = new System.Drawing.Point(850, 725);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(150, 35);
            this.btnChat.TabIndex = 7;
            this.btnChat.Text = "Bật chat";
            this.btnChat.UseVisualStyleBackColor = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(155)))), ((int)(((byte)(123)))));
            this.label18.Font = new System.Drawing.Font("Segoe UI Black", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(810, 50);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(274, 86);
            this.label18.TabIndex = 8;
            this.label18.Text = "SCHESS";
            // 
            // PlayChess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(155)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btnChat);
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.btnResign);
            this.Controls.Add(this.lstChatBox);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlayChess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlayChess";
            this.Load += new System.EventHandler(this.Form_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.boardLayoutPanel.ResumeLayout(false);
            this.boardLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip coordinates;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel boardLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.ListView lstChatBox;
        private System.Windows.Forms.Button btnResign;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.Label label18;
    }
}