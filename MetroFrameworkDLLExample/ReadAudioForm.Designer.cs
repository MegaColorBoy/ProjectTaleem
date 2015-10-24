namespace MetroFrameworkDLLExample
{
    partial class ReadAudioForm
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
            this.recBtn = new MetroFramework.Controls.MetroButton();
            this.stopBtn = new MetroFramework.Controls.MetroButton();
            this.playBtn = new MetroFramework.Controls.MetroButton();
            this.pauseButton = new MetroFramework.Controls.MetroButton();
            this.compareBtn = new MetroFramework.Controls.MetroButton();
            this.compareLabel = new MetroFramework.Controls.MetroLabel();
            this.recStpBtn = new MetroFramework.Controls.MetroButton();
            this.jollyLabel = new MetroFramework.Controls.MetroLabel();
            this.jollyPicBox = new System.Windows.Forms.PictureBox();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.backBtn = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.jollyPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // recBtn
            // 
            this.recBtn.Location = new System.Drawing.Point(663, 85);
            this.recBtn.Name = "recBtn";
            this.recBtn.Size = new System.Drawing.Size(75, 23);
            this.recBtn.TabIndex = 0;
            this.recBtn.Text = "Record";
            this.recBtn.UseSelectable = true;
            this.recBtn.Click += new System.EventHandler(this.recBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(663, 115);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(75, 23);
            this.stopBtn.TabIndex = 1;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseSelectable = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(663, 145);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(75, 23);
            this.playBtn.TabIndex = 2;
            this.playBtn.Text = "Play";
            this.playBtn.UseSelectable = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(663, 175);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 3;
            this.pauseButton.Text = "pause";
            this.pauseButton.UseSelectable = true;
            // 
            // compareBtn
            // 
            this.compareBtn.Location = new System.Drawing.Point(22, 115);
            this.compareBtn.Name = "compareBtn";
            this.compareBtn.Size = new System.Drawing.Size(75, 23);
            this.compareBtn.TabIndex = 4;
            this.compareBtn.Text = "Compare";
            this.compareBtn.UseSelectable = true;
            this.compareBtn.Click += new System.EventHandler(this.compareBtn_Click);
            // 
            // compareLabel
            // 
            this.compareLabel.AutoSize = true;
            this.compareLabel.Location = new System.Drawing.Point(104, 118);
            this.compareLabel.Name = "compareLabel";
            this.compareLabel.Size = new System.Drawing.Size(83, 19);
            this.compareLabel.TabIndex = 5;
            this.compareLabel.Text = "metroLabel1";
            // 
            // recStpBtn
            // 
            this.recStpBtn.Location = new System.Drawing.Point(22, 85);
            this.recStpBtn.Name = "recStpBtn";
            this.recStpBtn.Size = new System.Drawing.Size(75, 23);
            this.recStpBtn.TabIndex = 6;
            this.recStpBtn.Text = "Record/Stop";
            this.recStpBtn.UseSelectable = true;
            this.recStpBtn.Click += new System.EventHandler(this.recStpBtn_Click);
            // 
            // jollyLabel
            // 
            this.jollyLabel.AutoSize = true;
            this.jollyLabel.Location = new System.Drawing.Point(23, 60);
            this.jollyLabel.Name = "jollyLabel";
            this.jollyLabel.Size = new System.Drawing.Size(63, 19);
            this.jollyLabel.TabIndex = 7;
            this.jollyLabel.Text = "jollyLabel";
            // 
            // jollyPicBox
            // 
            this.jollyPicBox.Location = new System.Drawing.Point(410, 85);
            this.jollyPicBox.Name = "jollyPicBox";
            this.jollyPicBox.Size = new System.Drawing.Size(225, 169);
            this.jollyPicBox.TabIndex = 8;
            this.jollyPicBox.TabStop = false;
            this.jollyPicBox.Click += new System.EventHandler(this.jollyPicBox_Click);
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = null;
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(23, 145);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 10;
            this.backBtn.Text = "Back";
            this.backBtn.UseSelectable = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // ReadAudioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.jollyPicBox);
            this.Controls.Add(this.jollyLabel);
            this.Controls.Add(this.recStpBtn);
            this.Controls.Add(this.compareLabel);
            this.Controls.Add(this.compareBtn);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.recBtn);
            this.Name = "ReadAudioForm";
            this.Text = "Say the Jollyphonic";
            ((System.ComponentModel.ISupportInitialize)(this.jollyPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton recBtn;
        private MetroFramework.Controls.MetroButton stopBtn;
        private MetroFramework.Controls.MetroButton playBtn;
        private MetroFramework.Controls.MetroButton pauseButton;
        private MetroFramework.Controls.MetroButton compareBtn;
        private MetroFramework.Controls.MetroLabel compareLabel;
        private MetroFramework.Controls.MetroButton recStpBtn;
        private MetroFramework.Controls.MetroLabel jollyLabel;
        private System.Windows.Forms.PictureBox jollyPicBox;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroButton backBtn;
    }
}