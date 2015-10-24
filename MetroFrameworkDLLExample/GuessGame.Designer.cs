namespace MetroFrameworkDLLExample
{
    partial class GuessGame
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
            this.backBtn = new MetroFramework.Controls.MetroTile();
            this.timerLabel = new System.Windows.Forms.Label();
            this.restartBtn = new MetroFramework.Controls.MetroTile();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.soundPicBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.restartLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.soundPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.ActiveControl = null;
            this.backBtn.Location = new System.Drawing.Point(60, 90);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(64, 52);
            this.backBtn.Style = MetroFramework.MetroColorStyle.Orange;
            this.backBtn.TabIndex = 24;
            this.backBtn.Text = "Back";
            this.backBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.backBtn.UseSelectable = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.BackColor = System.Drawing.Color.DimGray;
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.ForeColor = System.Drawing.Color.White;
            this.timerLabel.Location = new System.Drawing.Point(373, 90);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(59, 25);
            this.timerLabel.TabIndex = 23;
            this.timerLabel.Text = "timer";
            this.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // restartBtn
            // 
            this.restartBtn.ActiveControl = null;
            this.restartBtn.Location = new System.Drawing.Point(60, 148);
            this.restartBtn.Name = "restartBtn";
            this.restartBtn.Size = new System.Drawing.Size(64, 52);
            this.restartBtn.Style = MetroFramework.MetroColorStyle.Teal;
            this.restartBtn.TabIndex = 27;
            this.restartBtn.Text = "Restart";
            this.restartBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.restartBtn.UseSelectable = true;
            this.restartBtn.Click += new System.EventHandler(this.restartBtn_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.DimGray;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(186, 427);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(424, 106);
            this.flowLayoutPanel1.TabIndex = 28;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // soundPicBox
            // 
            this.soundPicBox.Image = global::MetroFrameworkDLLExample.Properties.Resources.soundicon;
            this.soundPicBox.Location = new System.Drawing.Point(262, 148);
            this.soundPicBox.Name = "soundPicBox";
            this.soundPicBox.Size = new System.Drawing.Size(274, 237);
            this.soundPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.soundPicBox.TabIndex = 29;
            this.soundPicBox.TabStop = false;
            this.soundPicBox.Click += new System.EventHandler(this.soundPicBox_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::MetroFrameworkDLLExample.Properties.Resources.chalkboard;
            this.pictureBox1.Location = new System.Drawing.Point(20, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(760, 520);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(597, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 25);
            this.label1.TabIndex = 30;
            this.label1.Text = "Points:";
            // 
            // pointsLabel
            // 
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.BackColor = System.Drawing.Color.DimGray;
            this.pointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsLabel.ForeColor = System.Drawing.Color.White;
            this.pointsLabel.Location = new System.Drawing.Point(681, 90);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(70, 25);
            this.pointsLabel.TabIndex = 31;
            this.pointsLabel.Text = "label2";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.AutoSize = true;
            this.gameOverLabel.BackColor = System.Drawing.Color.DimGray;
            this.gameOverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameOverLabel.ForeColor = System.Drawing.Color.White;
            this.gameOverLabel.Location = new System.Drawing.Point(59, 255);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(70, 25);
            this.gameOverLabel.TabIndex = 32;
            this.gameOverLabel.Text = "label2";
            // 
            // restartLabel
            // 
            this.restartLabel.AutoSize = true;
            this.restartLabel.BackColor = System.Drawing.Color.DimGray;
            this.restartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartLabel.ForeColor = System.Drawing.Color.White;
            this.restartLabel.Location = new System.Drawing.Point(551, 255);
            this.restartLabel.Name = "restartLabel";
            this.restartLabel.Size = new System.Drawing.Size(70, 25);
            this.restartLabel.TabIndex = 33;
            this.restartLabel.Text = "label2";
            // 
            // GuessGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.restartLabel);
            this.Controls.Add(this.gameOverLabel);
            this.Controls.Add(this.pointsLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.soundPicBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.restartBtn);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "GuessGame";
            this.Text = "Guess the Phonics";
            this.Load += new System.EventHandler(this.GuessGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.soundPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTile backBtn;
        private System.Windows.Forms.Label timerLabel;
        private MetroFramework.Controls.MetroTile restartBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox soundPicBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.Label restartLabel;
    }
}