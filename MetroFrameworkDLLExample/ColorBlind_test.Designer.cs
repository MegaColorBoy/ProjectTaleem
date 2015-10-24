namespace MetroFrameworkDLLExample
{
    partial class ColorBlind_test
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
            this.changeBtn = new MetroFramework.Controls.MetroButton();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.testBtn = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // changeBtn
            // 
            this.changeBtn.Location = new System.Drawing.Point(24, 82);
            this.changeBtn.Name = "changeBtn";
            this.changeBtn.Size = new System.Drawing.Size(152, 76);
            this.changeBtn.TabIndex = 0;
            this.changeBtn.Text = "Change";
            this.changeBtn.UseSelectable = true;
            this.changeBtn.Click += new System.EventHandler(this.changeBtn_Click);
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(24, 185);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(152, 76);
            this.testBtn.TabIndex = 1;
            this.testBtn.Text = "Test";
            this.testBtn.UseSelectable = true;
            // 
            // ColorBlind_test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.changeBtn);
            this.Name = "ColorBlind_test";
            this.Text = "ColorBlind_test";
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton changeBtn;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroButton testBtn;
    }
}