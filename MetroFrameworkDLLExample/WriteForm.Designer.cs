namespace MetroFrameworkDLLExample
{
    partial class WriteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WriteForm));
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.letterLabel = new System.Windows.Forms.Label();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.backBtn = new MetroFramework.Controls.MetroTile();
            this.axShockwaveFlash1 = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.axShockwaveFlash2 = new AxShockwaveFlashObjects.AxShockwaveFlash();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash2)).BeginInit();
            this.SuspendLayout();
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(159, 63);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(600, 600);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // letterLabel
            // 
            this.letterLabel.AutoSize = true;
            this.letterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterLabel.Location = new System.Drawing.Point(24, 63);
            this.letterLabel.Name = "letterLabel";
            this.letterLabel.Size = new System.Drawing.Size(109, 39);
            this.letterLabel.TabIndex = 1;
            this.letterLabel.Text = "label1";
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = null;
            // 
            // backBtn
            // 
            this.backBtn.ActiveControl = null;
            this.backBtn.Location = new System.Drawing.Point(24, 106);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(109, 88);
            this.backBtn.TabIndex = 2;
            this.backBtn.Text = "Back";
            this.backBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.backBtn.UseSelectable = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // axShockwaveFlash1
            // 
            this.axShockwaveFlash1.Enabled = true;
            this.axShockwaveFlash1.Location = new System.Drawing.Point(793, 63);
            this.axShockwaveFlash1.Name = "axShockwaveFlash1";
            this.axShockwaveFlash1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlash1.OcxState")));
            this.axShockwaveFlash1.Size = new System.Drawing.Size(192, 192);
            this.axShockwaveFlash1.TabIndex = 3;
            // 
            // axShockwaveFlash2
            // 
            this.axShockwaveFlash2.Enabled = true;
            this.axShockwaveFlash2.Location = new System.Drawing.Point(793, 63);
            this.axShockwaveFlash2.Name = "axShockwaveFlash2";
            this.axShockwaveFlash2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlash2.OcxState")));
            this.axShockwaveFlash2.Size = new System.Drawing.Size(192, 192);
            this.axShockwaveFlash2.TabIndex = 4;
            // 
            // WriteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 670);
            this.Controls.Add(this.axShockwaveFlash2);
            this.Controls.Add(this.axShockwaveFlash1);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.letterLabel);
            this.Controls.Add(this.elementHost1);
            this.Name = "WriteForm";
            this.Text = "Write this letter";
            this.Load += new System.EventHandler(this.WriteForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Label letterLabel;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroTile backBtn;
        private AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash1;
        private AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash2;
    }
}