
namespace FormClient
{
    partial class dashboard
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
            this.btnSinglePlay = new System.Windows.Forms.Button();
            this.btnLan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSinglePlay
            // 
            this.btnSinglePlay.Location = new System.Drawing.Point(108, 203);
            this.btnSinglePlay.Name = "btnSinglePlay";
            this.btnSinglePlay.Size = new System.Drawing.Size(127, 68);
            this.btnSinglePlay.TabIndex = 4;
            this.btnSinglePlay.Text = "Single Play";
            this.btnSinglePlay.UseVisualStyleBackColor = true;
            this.btnSinglePlay.Click += new System.EventHandler(this.btnSinglePlay_Click);
            // 
            // btnLan
            // 
            this.btnLan.Location = new System.Drawing.Point(448, 203);
            this.btnLan.Name = "btnLan";
            this.btnLan.Size = new System.Drawing.Size(127, 68);
            this.btnLan.TabIndex = 5;
            this.btnLan.Text = "Connect to Local";
            this.btnLan.UseVisualStyleBackColor = true;
            this.btnLan.Click += new System.EventHandler(this.btnLan_Click);
            // 
            // dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLan);
            this.Controls.Add(this.btnSinglePlay);
            this.Name = "dashboard";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSinglePlay;
        private System.Windows.Forms.Button btnLan;
    }
}