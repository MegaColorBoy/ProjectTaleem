namespace MetroFrameworkDLLExample
{
    partial class SpellingGame
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
            this.restartBtn = new MetroFramework.Controls.MetroTile();
            this.backBtn = new MetroFramework.Controls.MetroTile();
            this.timerLabel = new System.Windows.Forms.Label();
            this.jumbledWordLabel = new System.Windows.Forms.Label();
            this.answerLabel = new System.Windows.Forms.Label();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.numOfWordsLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.wordPicBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.wordPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // restartBtn
            // 
            this.restartBtn.ActiveControl = null;
            this.restartBtn.Location = new System.Drawing.Point(63, 150);
            this.restartBtn.Name = "restartBtn";
            this.restartBtn.Size = new System.Drawing.Size(64, 52);
            this.restartBtn.Style = MetroFramework.MetroColorStyle.Teal;
            this.restartBtn.TabIndex = 13;
            this.restartBtn.Text = "Restart";
            this.restartBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.restartBtn.UseSelectable = true;
            this.restartBtn.Click += new System.EventHandler(this.restartBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.ActiveControl = null;
            this.backBtn.Location = new System.Drawing.Point(63, 92);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(64, 52);
            this.backBtn.Style = MetroFramework.MetroColorStyle.Orange;
            this.backBtn.TabIndex = 11;
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
            this.timerLabel.Location = new System.Drawing.Point(374, 92);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(59, 25);
            this.timerLabel.TabIndex = 10;
            this.timerLabel.Text = "timer";
            this.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // jumbledWordLabel
            // 
            this.jumbledWordLabel.AutoSize = true;
            this.jumbledWordLabel.BackColor = System.Drawing.Color.DimGray;
            this.jumbledWordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jumbledWordLabel.ForeColor = System.Drawing.Color.White;
            this.jumbledWordLabel.Location = new System.Drawing.Point(340, 150);
            this.jumbledWordLabel.Name = "jumbledWordLabel";
            this.jumbledWordLabel.Size = new System.Drawing.Size(138, 25);
            this.jumbledWordLabel.TabIndex = 15;
            this.jumbledWordLabel.Text = "jumbledWord";
            this.jumbledWordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.BackColor = System.Drawing.Color.DimGray;
            this.answerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerLabel.ForeColor = System.Drawing.Color.White;
            this.answerLabel.Location = new System.Drawing.Point(343, 414);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(132, 25);
            this.answerLabel.TabIndex = 16;
            this.answerLabel.Text = "answerWord";
            this.answerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pointsLabel
            // 
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.BackColor = System.Drawing.Color.DimGray;
            this.pointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsLabel.Location = new System.Drawing.Point(722, 92);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(0, 25);
            this.pointsLabel.TabIndex = 9;
            // 
            // numOfWordsLabel
            // 
            this.numOfWordsLabel.AutoSize = true;
            this.numOfWordsLabel.BackColor = System.Drawing.Color.DimGray;
            this.numOfWordsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOfWordsLabel.ForeColor = System.Drawing.Color.White;
            this.numOfWordsLabel.Location = new System.Drawing.Point(638, 131);
            this.numOfWordsLabel.Name = "numOfWordsLabel";
            this.numOfWordsLabel.Size = new System.Drawing.Size(86, 25);
            this.numOfWordsLabel.TabIndex = 18;
            this.numOfWordsLabel.Text = "Words: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(638, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Points:";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // wordPicBox
            // 
            this.wordPicBox.Location = new System.Drawing.Point(302, 181);
            this.wordPicBox.Name = "wordPicBox";
            this.wordPicBox.Size = new System.Drawing.Size(214, 218);
            this.wordPicBox.TabIndex = 14;
            this.wordPicBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::MetroFrameworkDLLExample.Properties.Resources.chalkboard;
            this.pictureBox1.Location = new System.Drawing.Point(20, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(760, 520);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // SpellingGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.numOfWordsLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.answerLabel);
            this.Controls.Add(this.jumbledWordLabel);
            this.Controls.Add(this.wordPicBox);
            this.Controls.Add(this.restartBtn);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.pointsLabel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SpellingGame";
            this.Text = "Spelling Game";
            this.Load += new System.EventHandler(this.SpellingGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wordPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile restartBtn;
        private MetroFramework.Controls.MetroTile backBtn;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.PictureBox wordPicBox;
        private System.Windows.Forms.Label jumbledWordLabel;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.Label numOfWordsLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}