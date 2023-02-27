namespace ChessProject
{
    partial class PlayGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayGame));
            this.pnRank = new System.Windows.Forms.Panel();
            this.btnRank = new System.Windows.Forms.Button();
            this.Rank = new System.Windows.Forms.PictureBox();
            this.pnPractice = new System.Windows.Forms.Panel();
            this.btnPractise = new System.Windows.Forms.Button();
            this.practise = new System.Windows.Forms.PictureBox();
            this.pnRank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Rank)).BeginInit();
            this.pnPractice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.practise)).BeginInit();
            this.SuspendLayout();
            // 
            // pnRank
            // 
            this.pnRank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.pnRank.Controls.Add(this.btnRank);
            this.pnRank.Controls.Add(this.Rank);
            this.pnRank.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnRank.Location = new System.Drawing.Point(233, 554);
            this.pnRank.Margin = new System.Windows.Forms.Padding(5);
            this.pnRank.Name = "pnRank";
            this.pnRank.Size = new System.Drawing.Size(700, 123);
            this.pnRank.TabIndex = 12;
            // 
            // btnRank
            // 
            this.btnRank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.btnRank.FlatAppearance.BorderSize = 0;
            this.btnRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRank.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRank.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRank.Location = new System.Drawing.Point(125, 0);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(575, 125);
            this.btnRank.TabIndex = 3;
            this.btnRank.Text = "Đấu hạng";
            this.btnRank.UseVisualStyleBackColor = false;
            this.btnRank.Click += new System.EventHandler(this.btnRank_Click);
            // 
            // Rank
            // 
            this.Rank.BackgroundImage = global::ChessProject.Properties.Resources.icons8_chess_64;
            this.Rank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Rank.Location = new System.Drawing.Point(0, 0);
            this.Rank.Margin = new System.Windows.Forms.Padding(5);
            this.Rank.Name = "Rank";
            this.Rank.Size = new System.Drawing.Size(125, 125);
            this.Rank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Rank.TabIndex = 1;
            this.Rank.TabStop = false;
            // 
            // pnPractice
            // 
            this.pnPractice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.pnPractice.Controls.Add(this.btnPractise);
            this.pnPractice.Controls.Add(this.practise);
            this.pnPractice.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnPractice.Location = new System.Drawing.Point(233, 308);
            this.pnPractice.Margin = new System.Windows.Forms.Padding(5);
            this.pnPractice.Name = "pnPractice";
            this.pnPractice.Size = new System.Drawing.Size(700, 123);
            this.pnPractice.TabIndex = 13;
            // 
            // btnPractise
            // 
            this.btnPractise.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.btnPractise.FlatAppearance.BorderSize = 0;
            this.btnPractise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPractise.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPractise.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPractise.Location = new System.Drawing.Point(125, 0);
            this.btnPractise.Name = "btnPractise";
            this.btnPractise.Size = new System.Drawing.Size(575, 125);
            this.btnPractise.TabIndex = 2;
            this.btnPractise.Text = "Đấu tập";
            this.btnPractise.UseVisualStyleBackColor = false;
            this.btnPractise.Click += new System.EventHandler(this.btnPractise_Click);
            // 
            // practise
            // 
            this.practise.Image = global::ChessProject.Properties.Resources.icons8_book_50;
            this.practise.Location = new System.Drawing.Point(0, 0);
            this.practise.Margin = new System.Windows.Forms.Padding(5);
            this.practise.Name = "practise";
            this.practise.Size = new System.Drawing.Size(125, 125);
            this.practise.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.practise.TabIndex = 1;
            this.practise.TabStop = false;
            // 
            // PlayGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1167, 985);
            this.Controls.Add(this.pnRank);
            this.Controls.Add(this.pnPractice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PlayGame";
            this.Text = "PlayGame";
            this.pnRank.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Rank)).EndInit();
            this.pnPractice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.practise)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnRank;
        private System.Windows.Forms.PictureBox Rank;
        private System.Windows.Forms.Panel pnPractice;
        private System.Windows.Forms.PictureBox practise;
        private System.Windows.Forms.Button btnRank;
        private System.Windows.Forms.Button btnPractise;
    }
}