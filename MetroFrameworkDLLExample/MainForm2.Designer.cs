namespace MetroFrameworkDLLExample
{
    partial class MainForm2
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
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.kidNameLabel = new MetroFramework.Controls.MetroLabel();
            this.classSectionLabel = new MetroFramework.Controls.MetroLabel();
            this.viewProgressBtn = new MetroFramework.Controls.MetroTile();
            this.exitTile = new MetroFramework.Controls.MetroTile();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.loginPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginPic)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            // 
            // kidNameLabel
            // 
            this.kidNameLabel.AutoSize = true;
            this.kidNameLabel.Location = new System.Drawing.Point(95, 35);
            this.kidNameLabel.Name = "kidNameLabel";
            this.kidNameLabel.Size = new System.Drawing.Size(81, 19);
            this.kidNameLabel.TabIndex = 7;
            this.kidNameLabel.Text = "metroLabel1";
            // 
            // classSectionLabel
            // 
            this.classSectionLabel.AutoSize = true;
            this.classSectionLabel.Location = new System.Drawing.Point(95, 54);
            this.classSectionLabel.Name = "classSectionLabel";
            this.classSectionLabel.Size = new System.Drawing.Size(81, 19);
            this.classSectionLabel.TabIndex = 8;
            this.classSectionLabel.Text = "metroLabel1";
            // 
            // viewProgressBtn
            // 
            this.viewProgressBtn.ActiveControl = null;
            this.viewProgressBtn.Location = new System.Drawing.Point(580, 46);
            this.viewProgressBtn.Name = "viewProgressBtn";
            this.viewProgressBtn.Size = new System.Drawing.Size(101, 33);
            this.viewProgressBtn.TabIndex = 16;
            this.viewProgressBtn.Text = "Progress";
            this.viewProgressBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.viewProgressBtn.UseSelectable = true;
            this.viewProgressBtn.Click += new System.EventHandler(this.viewProgressBtn_Click);
            // 
            // exitTile
            // 
            this.exitTile.ActiveControl = null;
            this.exitTile.Location = new System.Drawing.Point(687, 46);
            this.exitTile.Name = "exitTile";
            this.exitTile.Size = new System.Drawing.Size(74, 33);
            this.exitTile.Style = MetroFramework.MetroColorStyle.Silver;
            this.exitTile.TabIndex = 14;
            this.exitTile.Text = "Exit";
            this.exitTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exitTile.UseSelectable = true;
            this.exitTile.Click += new System.EventHandler(this.exitTile_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(23, 99);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(738, 490);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // loginPic
            // 
            this.loginPic.Location = new System.Drawing.Point(23, 33);
            this.loginPic.Name = "loginPic";
            this.loginPic.Size = new System.Drawing.Size(66, 60);
            this.loginPic.TabIndex = 5;
            this.loginPic.TabStop = false;
            // 
            // MainForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.viewProgressBtn);
            this.Controls.Add(this.exitTile);
            this.Controls.Add(this.classSectionLabel);
            this.Controls.Add(this.kidNameLabel);
            this.Controls.Add(this.loginPic);
            this.DisplayHeader = false;
            this.Name = "MainForm2";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Text = "MainForm2";
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private System.Windows.Forms.PictureBox loginPic;
        private MetroFramework.Controls.MetroLabel kidNameLabel;
        private MetroFramework.Controls.MetroLabel classSectionLabel;
        private MetroFramework.Controls.MetroTile viewProgressBtn;
        private MetroFramework.Controls.MetroTile exitTile;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;





    }
}