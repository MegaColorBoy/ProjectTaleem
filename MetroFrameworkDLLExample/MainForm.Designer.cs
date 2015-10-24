namespace MetroFrameworkDLLExample
{
    partial class MainForm
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
            this.readTile = new MetroFramework.Controls.MetroTile();
            this.writeTile = new MetroFramework.Controls.MetroTile();
            this.exitTile = new MetroFramework.Controls.MetroTile();
            this.loginPic = new System.Windows.Forms.PictureBox();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.kidNameLabel = new MetroFramework.Controls.MetroLabel();
            this.classSectionLabel = new MetroFramework.Controls.MetroLabel();
            this.mathTile = new MetroFramework.Controls.MetroTile();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.wordBankBtn = new MetroFramework.Controls.MetroTile();
            this.spellTile = new MetroFramework.Controls.MetroTile();
            this.guessGameTile = new MetroFramework.Controls.MetroTile();
            this.viewProgressBtn = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.loginPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // readTile
            // 
            this.readTile.ActiveControl = null;
            this.readTile.Location = new System.Drawing.Point(130, 154);
            this.readTile.Name = "readTile";
            this.readTile.Size = new System.Drawing.Size(178, 156);
            this.readTile.TabIndex = 1;
            this.readTile.Text = "Learn Phonics";
            this.readTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.readTile.UseSelectable = true;
            this.readTile.Click += new System.EventHandler(this.readTile_Click);
            // 
            // writeTile
            // 
            this.writeTile.ActiveControl = null;
            this.writeTile.Location = new System.Drawing.Point(314, 154);
            this.writeTile.Name = "writeTile";
            this.writeTile.Size = new System.Drawing.Size(178, 156);
            this.writeTile.TabIndex = 2;
            this.writeTile.Text = "Write Letters";
            this.writeTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.writeTile.UseSelectable = true;
            this.writeTile.Click += new System.EventHandler(this.writeTile_Click);
            // 
            // exitTile
            // 
            this.exitTile.ActiveControl = null;
            this.exitTile.Location = new System.Drawing.Point(664, 61);
            this.exitTile.Name = "exitTile";
            this.exitTile.Size = new System.Drawing.Size(74, 33);
            this.exitTile.Style = MetroFramework.MetroColorStyle.Silver;
            this.exitTile.TabIndex = 3;
            this.exitTile.Text = "Exit";
            this.exitTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exitTile.UseSelectable = true;
            this.exitTile.Click += new System.EventHandler(this.exitTile_Click);
            // 
            // loginPic
            // 
            this.loginPic.Location = new System.Drawing.Point(58, 61);
            this.loginPic.Name = "loginPic";
            this.loginPic.Size = new System.Drawing.Size(66, 60);
            this.loginPic.TabIndex = 4;
            this.loginPic.TabStop = false;
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            // 
            // kidNameLabel
            // 
            this.kidNameLabel.AutoSize = true;
            this.kidNameLabel.Location = new System.Drawing.Point(130, 61);
            this.kidNameLabel.Name = "kidNameLabel";
            this.kidNameLabel.Size = new System.Drawing.Size(81, 19);
            this.kidNameLabel.TabIndex = 6;
            this.kidNameLabel.Text = "metroLabel1";
            // 
            // classSectionLabel
            // 
            this.classSectionLabel.AutoSize = true;
            this.classSectionLabel.Location = new System.Drawing.Point(130, 89);
            this.classSectionLabel.Name = "classSectionLabel";
            this.classSectionLabel.Size = new System.Drawing.Size(81, 19);
            this.classSectionLabel.TabIndex = 7;
            this.classSectionLabel.Text = "metroLabel1";
            // 
            // mathTile
            // 
            this.mathTile.ActiveControl = null;
            this.mathTile.Location = new System.Drawing.Point(498, 154);
            this.mathTile.Name = "mathTile";
            this.mathTile.Size = new System.Drawing.Size(178, 156);
            this.mathTile.TabIndex = 8;
            this.mathTile.Text = "Play with Math";
            this.mathTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mathTile.TileImage = global::MetroFrameworkDLLExample.Properties.Resources.soundicon;
            this.mathTile.UseSelectable = true;
            this.mathTile.Click += new System.EventHandler(this.mathTile_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::MetroFrameworkDLLExample.Properties.Resources.chalkboard;
            this.pictureBox1.Location = new System.Drawing.Point(20, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(760, 550);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // wordBankBtn
            // 
            this.wordBankBtn.ActiveControl = null;
            this.wordBankBtn.Location = new System.Drawing.Point(131, 316);
            this.wordBankBtn.Name = "wordBankBtn";
            this.wordBankBtn.Size = new System.Drawing.Size(177, 155);
            this.wordBankBtn.TabIndex = 10;
            this.wordBankBtn.Text = "Pronounce a word";
            this.wordBankBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.wordBankBtn.UseSelectable = true;
            this.wordBankBtn.Click += new System.EventHandler(this.wordBankBtn_Click);
            // 
            // spellTile
            // 
            this.spellTile.ActiveControl = null;
            this.spellTile.Location = new System.Drawing.Point(314, 316);
            this.spellTile.Name = "spellTile";
            this.spellTile.Size = new System.Drawing.Size(178, 155);
            this.spellTile.TabIndex = 11;
            this.spellTile.Text = "It\'s Spelling time";
            this.spellTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.spellTile.UseSelectable = true;
            this.spellTile.Click += new System.EventHandler(this.spellTile_Click);
            // 
            // guessGameTile
            // 
            this.guessGameTile.ActiveControl = null;
            this.guessGameTile.Location = new System.Drawing.Point(499, 316);
            this.guessGameTile.Name = "guessGameTile";
            this.guessGameTile.Size = new System.Drawing.Size(177, 155);
            this.guessGameTile.TabIndex = 12;
            this.guessGameTile.Text = "Guess the phonics";
            this.guessGameTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.guessGameTile.UseSelectable = true;
            this.guessGameTile.Click += new System.EventHandler(this.guessGameTile_Click);
            // 
            // viewProgressBtn
            // 
            this.viewProgressBtn.ActiveControl = null;
            this.viewProgressBtn.Location = new System.Drawing.Point(557, 61);
            this.viewProgressBtn.Name = "viewProgressBtn";
            this.viewProgressBtn.Size = new System.Drawing.Size(101, 33);
            this.viewProgressBtn.TabIndex = 13;
            this.viewProgressBtn.Text = "Progress";
            this.viewProgressBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.viewProgressBtn.UseSelectable = true;
            this.viewProgressBtn.Click += new System.EventHandler(this.viewProgressBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.viewProgressBtn);
            this.Controls.Add(this.guessGameTile);
            this.Controls.Add(this.spellTile);
            this.Controls.Add(this.wordBankBtn);
            this.Controls.Add(this.mathTile);
            this.Controls.Add(this.classSectionLabel);
            this.Controls.Add(this.kidNameLabel);
            this.Controls.Add(this.loginPic);
            this.Controls.Add(this.exitTile);
            this.Controls.Add(this.writeTile);
            this.Controls.Add(this.readTile);
            this.Controls.Add(this.pictureBox1);
            this.DisplayHeader = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Welcome";
            ((System.ComponentModel.ISupportInitialize)(this.loginPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile readTile;
        private MetroFramework.Controls.MetroTile writeTile;
        private MetroFramework.Controls.MetroTile exitTile;
        private System.Windows.Forms.PictureBox loginPic;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroLabel classSectionLabel;
        private MetroFramework.Controls.MetroLabel kidNameLabel;
        private MetroFramework.Controls.MetroTile mathTile;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTile wordBankBtn;
        private MetroFramework.Controls.MetroTile spellTile;
        private MetroFramework.Controls.MetroTile guessGameTile;
        private MetroFramework.Controls.MetroTile viewProgressBtn;


    }
}

