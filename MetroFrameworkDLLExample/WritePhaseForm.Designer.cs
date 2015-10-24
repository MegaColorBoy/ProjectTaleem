namespace MetroFrameworkDLLExample
{
    partial class WritePhaseForm
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
            this.tilePanel = new MetroFramework.Controls.MetroPanel();
            this.backBtn = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = null;
            // 
            // tilePanel
            // 
            this.tilePanel.AutoScroll = true;
            this.tilePanel.BackgroundImage = global::MetroFrameworkDLLExample.Properties.Resources.chalkboard;
            this.tilePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tilePanel.HorizontalScrollbar = true;
            this.tilePanel.HorizontalScrollbarBarColor = true;
            this.tilePanel.HorizontalScrollbarHighlightOnWheel = false;
            this.tilePanel.HorizontalScrollbarSize = 10;
            this.tilePanel.Location = new System.Drawing.Point(24, 54);
            this.tilePanel.Name = "tilePanel";
            this.tilePanel.Size = new System.Drawing.Size(753, 483);
            this.tilePanel.TabIndex = 0;
            this.tilePanel.VerticalScrollbar = true;
            this.tilePanel.VerticalScrollbarBarColor = true;
            this.tilePanel.VerticalScrollbarHighlightOnWheel = false;
            this.tilePanel.VerticalScrollbarSize = 10;
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(24, 543);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 1;
            this.backBtn.Text = "Back";
            this.backBtn.UseSelectable = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // WritePhaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.tilePanel);
            this.Name = "WritePhaseForm";
            this.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Text = "Pick A Letter";
            this.Load += new System.EventHandler(this.WritePhaseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroPanel tilePanel;
        private MetroFramework.Controls.MetroButton backBtn;
    }
}