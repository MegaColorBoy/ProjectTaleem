namespace MetroFrameworkDLLExample
{
    partial class ReadAudioForm3
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
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.jollyPicBox = new System.Windows.Forms.PictureBox();
            this.backBtn = new MetroFramework.Controls.MetroTile();
            this.startBtn = new MetroFramework.Controls.MetroTile();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.jollyPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(324, 44);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(350, 350);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // jollyPicBox
            // 
            this.jollyPicBox.Location = new System.Drawing.Point(101, 75);
            this.jollyPicBox.Name = "jollyPicBox";
            this.jollyPicBox.Size = new System.Drawing.Size(169, 117);
            this.jollyPicBox.TabIndex = 2;
            this.jollyPicBox.TabStop = false;
            this.jollyPicBox.Click += new System.EventHandler(this.jollyPicBox_Click);
            // 
            // backBtn
            // 
            this.backBtn.ActiveControl = null;
            this.backBtn.Location = new System.Drawing.Point(23, 75);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(72, 53);
            this.backBtn.TabIndex = 3;
            this.backBtn.Text = "Back";
            this.backBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.backBtn.UseSelectable = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.ActiveControl = null;
            this.startBtn.Location = new System.Drawing.Point(101, 198);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(169, 100);
            this.startBtn.TabIndex = 4;
            this.startBtn.Text = "Say It !";
            this.startBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.startBtn.UseSelectable = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = null;
            // 
            // ReadAudioForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 400);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.jollyPicBox);
            this.Controls.Add(this.elementHost1);
            this.Name = "ReadAudioForm3";
            this.Text = "Say The Jolly phonic !";
            this.Load += new System.EventHandler(this.ReadAudioForm3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jollyPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.PictureBox jollyPicBox;
        private MetroFramework.Controls.MetroTile backBtn;
        private MetroFramework.Controls.MetroTile startBtn;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
    }
}