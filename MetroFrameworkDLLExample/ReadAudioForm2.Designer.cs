namespace MetroFrameworkDLLExample
{
    partial class ReadAudioForm2
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
            this.countTimer = new System.Windows.Forms.Timer(this.components);
            this.secsLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.jollyPicBox = new System.Windows.Forms.PictureBox();
            this.recBtn = new MetroFramework.Controls.MetroTile();
            this.backBtn = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jollyPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // countTimer
            // 
            this.countTimer.Interval = 1000;
            this.countTimer.Tick += new System.EventHandler(this.countTimer_Tick);
            // 
            // secsLabel
            // 
            this.secsLabel.AutoSize = true;
            this.secsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secsLabel.Location = new System.Drawing.Point(221, 288);
            this.secsLabel.Name = "secsLabel";
            this.secsLabel.Size = new System.Drawing.Size(0, 31);
            this.secsLabel.TabIndex = 5;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(56, 288);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(126, 31);
            this.timeLabel.TabIndex = 7;
            this.timeLabel.Text = "Time left:";
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = null;
            // 
            // jollyPicBox
            // 
            this.jollyPicBox.Location = new System.Drawing.Point(99, 63);
            this.jollyPicBox.Name = "jollyPicBox";
            this.jollyPicBox.Size = new System.Drawing.Size(166, 143);
            this.jollyPicBox.TabIndex = 0;
            this.jollyPicBox.TabStop = false;
            this.jollyPicBox.Click += new System.EventHandler(this.jollyPicBox_Click_1);
            // 
            // recBtn
            // 
            this.recBtn.ActiveControl = null;
            this.recBtn.Location = new System.Drawing.Point(99, 212);
            this.recBtn.Name = "recBtn";
            this.recBtn.Size = new System.Drawing.Size(166, 47);
            this.recBtn.TabIndex = 1;
            this.recBtn.Text = "Say It !";
            this.recBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.recBtn.UseSelectable = true;
            this.recBtn.Click += new System.EventHandler(this.recBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.ActiveControl = null;
            this.backBtn.Location = new System.Drawing.Point(23, 63);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(60, 51);
            this.backBtn.TabIndex = 2;
            this.backBtn.Text = "Back";
            this.backBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.backBtn.UseSelectable = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click_1);
            // 
            // ReadAudioForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 280);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.jollyPicBox);
            this.Controls.Add(this.recBtn);
            this.Controls.Add(this.secsLabel);
            this.Name = "ReadAudioForm2";
            this.Text = "Say The Jollyphonic";
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jollyPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer countTimer;
        private System.Windows.Forms.Label secsLabel;
        private System.Windows.Forms.Label timeLabel;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private System.Windows.Forms.PictureBox jollyPicBox;
        private MetroFramework.Controls.MetroTile recBtn;
        private MetroFramework.Controls.MetroTile backBtn;
    }
}