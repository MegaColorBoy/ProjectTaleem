namespace MetroFrameworkDLLExample
{
    partial class BlindModeForm
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
            this.moveLeftBtn = new System.Windows.Forms.Button();
            this.moveRightBtn = new System.Windows.Forms.Button();
            this.repeatBtn = new System.Windows.Forms.Button();
            this.recordBtn = new System.Windows.Forms.Button();
            this.askMeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // moveLeftBtn
            // 
            this.moveLeftBtn.Location = new System.Drawing.Point(23, 310);
            this.moveLeftBtn.Name = "moveLeftBtn";
            this.moveLeftBtn.Size = new System.Drawing.Size(377, 267);
            this.moveLeftBtn.TabIndex = 4;
            this.moveLeftBtn.Text = "PREV";
            this.moveLeftBtn.UseVisualStyleBackColor = true;
            this.moveLeftBtn.Click += new System.EventHandler(this.moveLeftBtn_Click);
            // 
            // moveRightBtn
            // 
            this.moveRightBtn.Location = new System.Drawing.Point(406, 310);
            this.moveRightBtn.Name = "moveRightBtn";
            this.moveRightBtn.Size = new System.Drawing.Size(377, 267);
            this.moveRightBtn.TabIndex = 5;
            this.moveRightBtn.Text = "NEXT";
            this.moveRightBtn.UseVisualStyleBackColor = true;
            this.moveRightBtn.Click += new System.EventHandler(this.moveRightBtn_Click);
            // 
            // repeatBtn
            // 
            this.repeatBtn.Location = new System.Drawing.Point(23, 63);
            this.repeatBtn.Name = "repeatBtn";
            this.repeatBtn.Size = new System.Drawing.Size(377, 242);
            this.repeatBtn.TabIndex = 6;
            this.repeatBtn.Text = "REPEAT";
            this.repeatBtn.UseVisualStyleBackColor = true;
            this.repeatBtn.Click += new System.EventHandler(this.repeatBtn_Click);
            // 
            // recordBtn
            // 
            this.recordBtn.Location = new System.Drawing.Point(406, 63);
            this.recordBtn.Name = "recordBtn";
            this.recordBtn.Size = new System.Drawing.Size(377, 242);
            this.recordBtn.TabIndex = 7;
            this.recordBtn.Text = "RECORD";
            this.recordBtn.UseVisualStyleBackColor = true;
            this.recordBtn.Click += new System.EventHandler(this.recordBtn_Click);
            // 
            // askMeBtn
            // 
            this.askMeBtn.Location = new System.Drawing.Point(623, 34);
            this.askMeBtn.Name = "askMeBtn";
            this.askMeBtn.Size = new System.Drawing.Size(154, 23);
            this.askMeBtn.TabIndex = 8;
            this.askMeBtn.Text = "Ask Me !";
            this.askMeBtn.UseVisualStyleBackColor = true;
            this.askMeBtn.Click += new System.EventHandler(this.askMeBtn_Click);
            // 
            // BlindModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.askMeBtn);
            this.Controls.Add(this.recordBtn);
            this.Controls.Add(this.repeatBtn);
            this.Controls.Add(this.moveRightBtn);
            this.Controls.Add(this.moveLeftBtn);
            this.Name = "BlindModeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button moveLeftBtn;
        private System.Windows.Forms.Button moveRightBtn;
        private System.Windows.Forms.Button repeatBtn;
        private System.Windows.Forms.Button recordBtn;
        private System.Windows.Forms.Button askMeBtn;
    }
}