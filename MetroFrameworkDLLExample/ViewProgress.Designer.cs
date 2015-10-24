namespace MetroFrameworkDLLExample
{
    partial class ViewProgress
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
            this.readProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.writeProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // readProgressBar
            // 
            this.readProgressBar.HideProgressText = false;
            this.readProgressBar.Location = new System.Drawing.Point(103, 63);
            this.readProgressBar.Name = "readProgressBar";
            this.readProgressBar.Size = new System.Drawing.Size(209, 23);
            this.readProgressBar.TabIndex = 0;
            this.readProgressBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // writeProgressBar
            // 
            this.writeProgressBar.HideProgressText = false;
            this.writeProgressBar.Location = new System.Drawing.Point(103, 95);
            this.writeProgressBar.Name = "writeProgressBar";
            this.writeProgressBar.Size = new System.Drawing.Size(209, 23);
            this.writeProgressBar.TabIndex = 1;
            this.writeProgressBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Read: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Write: ";
            // 
            // ViewProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 132);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.writeProgressBar);
            this.Controls.Add(this.readProgressBar);
            this.Name = "ViewProgress";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroProgressBar readProgressBar;
        private MetroFramework.Controls.MetroProgressBar writeProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}