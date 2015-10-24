namespace MetroFrameworkDLLExample
{
    partial class LoginForm
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
            this.kidImgList = new System.Windows.Forms.ImageList(this.components);
            this.buttonPanel = new MetroFramework.Controls.MetroPanel();
            this.kidPicBox = new System.Windows.Forms.PictureBox();
            this.kidNameLabel = new System.Windows.Forms.Label();
            this.loginPicBox = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kidPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // kidImgList
            // 
            this.kidImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.kidImgList.ImageSize = new System.Drawing.Size(16, 16);
            this.kidImgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // buttonPanel
            // 
            this.buttonPanel.AutoScroll = true;
            this.buttonPanel.HorizontalScrollbar = true;
            this.buttonPanel.HorizontalScrollbarBarColor = true;
            this.buttonPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.buttonPanel.HorizontalScrollbarSize = 10;
            this.buttonPanel.Location = new System.Drawing.Point(534, 81);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(218, 35);
            this.buttonPanel.TabIndex = 0;
            this.buttonPanel.VerticalScrollbar = true;
            this.buttonPanel.VerticalScrollbarBarColor = true;
            this.buttonPanel.VerticalScrollbarHighlightOnWheel = false;
            this.buttonPanel.VerticalScrollbarSize = 10;
            this.buttonPanel.Visible = false;
            // 
            // kidPicBox
            // 
            this.kidPicBox.Location = new System.Drawing.Point(319, 241);
            this.kidPicBox.Name = "kidPicBox";
            this.kidPicBox.Size = new System.Drawing.Size(161, 116);
            this.kidPicBox.TabIndex = 1;
            this.kidPicBox.TabStop = false;
            this.kidPicBox.Click += new System.EventHandler(this.kidPicBox_Click);
            // 
            // kidNameLabel
            // 
            this.kidNameLabel.AutoSize = true;
            this.kidNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kidNameLabel.Location = new System.Drawing.Point(498, 287);
            this.kidNameLabel.Name = "kidNameLabel";
            this.kidNameLabel.Size = new System.Drawing.Size(0, 25);
            this.kidNameLabel.TabIndex = 2;
            // 
            // loginPicBox
            // 
            this.loginPicBox.Location = new System.Drawing.Point(305, 81);
            this.loginPicBox.Name = "loginPicBox";
            this.loginPicBox.Size = new System.Drawing.Size(188, 155);
            this.loginPicBox.TabIndex = 3;
            this.loginPicBox.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(144, 364);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(511, 175);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.loginPicBox);
            this.Controls.Add(this.kidNameLabel);
            this.Controls.Add(this.kidPicBox);
            this.Controls.Add(this.buttonPanel);
            this.Name = "LoginForm";
            this.Text = "Which one is you ?";
            ((System.ComponentModel.ISupportInitialize)(this.kidPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList kidImgList;
        private MetroFramework.Controls.MetroPanel buttonPanel;
        private System.Windows.Forms.PictureBox kidPicBox;
        private System.Windows.Forms.Label kidNameLabel;
        private System.Windows.Forms.PictureBox loginPicBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}