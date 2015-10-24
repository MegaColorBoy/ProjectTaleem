namespace MetroFrameworkDLLExample
{
    partial class WriteLetter_Test
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
            this.LetterLabel = new MetroFramework.Controls.MetroLabel();
            this.recogBtn = new MetroFramework.Controls.MetroButton();
            this.eraseBtn = new MetroFramework.Controls.MetroButton();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.backBtn = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // LetterLabel
            // 
            this.LetterLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.LetterLabel.Location = new System.Drawing.Point(23, 78);
            this.LetterLabel.Name = "LetterLabel";
            this.LetterLabel.Size = new System.Drawing.Size(100, 100);
            this.LetterLabel.TabIndex = 0;
            this.LetterLabel.Text = "metroLabel1";
            // 
            // recogBtn
            // 
            this.recogBtn.Location = new System.Drawing.Point(24, 142);
            this.recogBtn.Name = "recogBtn";
            this.recogBtn.Size = new System.Drawing.Size(75, 23);
            this.recogBtn.TabIndex = 1;
            this.recogBtn.Text = "Submit";
            this.recogBtn.UseSelectable = true;
            this.recogBtn.Click += new System.EventHandler(this.recogBtn_Click);
            // 
            // eraseBtn
            // 
            this.eraseBtn.Location = new System.Drawing.Point(24, 182);
            this.eraseBtn.Name = "eraseBtn";
            this.eraseBtn.Size = new System.Drawing.Size(75, 23);
            this.eraseBtn.TabIndex = 2;
            this.eraseBtn.Text = "Eraser";
            this.eraseBtn.UseSelectable = true;
            this.eraseBtn.Click += new System.EventHandler(this.eraseBtn_Click);
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = null;
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(23, 222);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 3;
            this.backBtn.Text = "Back";
            this.backBtn.UseSelectable = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // WriteLetter_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.eraseBtn);
            this.Controls.Add(this.recogBtn);
            this.Controls.Add(this.LetterLabel);
            this.Name = "WriteLetter_Test";
            this.Text = "Write the following letter";
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel LetterLabel;
        private MetroFramework.Controls.MetroButton recogBtn;
        private MetroFramework.Controls.MetroButton eraseBtn;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroButton backBtn;
    }
}