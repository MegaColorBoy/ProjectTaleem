namespace MetroFrameworkDLLExample
{
    partial class ReadLetter_Test
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
            this.voiceIn_Btn = new MetroFramework.Controls.MetroButton();
            this.reference_btn = new MetroFramework.Controls.MetroButton();
            this.goBack_btn = new MetroFramework.Controls.MetroButton();
            this.compare_Btn = new MetroFramework.Controls.MetroButton();
            this.voiceIn_Label = new MetroFramework.Controls.MetroLabel();
            this.refIn_Label = new MetroFramework.Controls.MetroLabel();
            this.compareLabel = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // voiceIn_Btn
            // 
            this.voiceIn_Btn.Location = new System.Drawing.Point(24, 120);
            this.voiceIn_Btn.Name = "voiceIn_Btn";
            this.voiceIn_Btn.Size = new System.Drawing.Size(98, 23);
            this.voiceIn_Btn.TabIndex = 0;
            this.voiceIn_Btn.Text = "Voice Input";
            this.voiceIn_Btn.UseSelectable = true;
            this.voiceIn_Btn.Click += new System.EventHandler(this.voiceIn_Btn_Click);
            // 
            // reference_btn
            // 
            this.reference_btn.Location = new System.Drawing.Point(23, 159);
            this.reference_btn.Name = "reference_btn";
            this.reference_btn.Size = new System.Drawing.Size(98, 23);
            this.reference_btn.TabIndex = 1;
            this.reference_btn.Text = "Reference Input";
            this.reference_btn.UseSelectable = true;
            this.reference_btn.Click += new System.EventHandler(this.reference_btn_Click);
            // 
            // goBack_btn
            // 
            this.goBack_btn.Location = new System.Drawing.Point(24, 197);
            this.goBack_btn.Name = "goBack_btn";
            this.goBack_btn.Size = new System.Drawing.Size(98, 26);
            this.goBack_btn.TabIndex = 2;
            this.goBack_btn.Text = "Go back";
            this.goBack_btn.UseSelectable = true;
            this.goBack_btn.Click += new System.EventHandler(this.goBack_btn_Click);
            // 
            // compare_Btn
            // 
            this.compare_Btn.Location = new System.Drawing.Point(24, 241);
            this.compare_Btn.Name = "compare_Btn";
            this.compare_Btn.Size = new System.Drawing.Size(97, 23);
            this.compare_Btn.TabIndex = 3;
            this.compare_Btn.Text = "Compare";
            this.compare_Btn.UseSelectable = true;
            this.compare_Btn.Click += new System.EventHandler(this.compare_Btn_Click);
            // 
            // voiceIn_Label
            // 
            this.voiceIn_Label.AutoSize = true;
            this.voiceIn_Label.Location = new System.Drawing.Point(141, 120);
            this.voiceIn_Label.Name = "voiceIn_Label";
            this.voiceIn_Label.Size = new System.Drawing.Size(59, 19);
            this.voiceIn_Label.TabIndex = 4;
            this.voiceIn_Label.Text = "voice dir";
            // 
            // refIn_Label
            // 
            this.refIn_Label.AutoSize = true;
            this.refIn_Label.Location = new System.Drawing.Point(141, 159);
            this.refIn_Label.Name = "refIn_Label";
            this.refIn_Label.Size = new System.Drawing.Size(45, 19);
            this.refIn_Label.TabIndex = 5;
            this.refIn_Label.Text = "ref dir";
            // 
            // compareLabel
            // 
            this.compareLabel.AutoSize = true;
            this.compareLabel.Location = new System.Drawing.Point(141, 241);
            this.compareLabel.Name = "compareLabel";
            this.compareLabel.Size = new System.Drawing.Size(93, 19);
            this.compareLabel.TabIndex = 7;
            this.compareLabel.Text = "compareLabel";
            // 
            // ReadLetter_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.compareLabel);
            this.Controls.Add(this.refIn_Label);
            this.Controls.Add(this.voiceIn_Label);
            this.Controls.Add(this.compare_Btn);
            this.Controls.Add(this.goBack_btn);
            this.Controls.Add(this.reference_btn);
            this.Controls.Add(this.voiceIn_Btn);
            this.Name = "ReadLetter_Test";
            this.Text = "ReadLetter_Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton voiceIn_Btn;
        private MetroFramework.Controls.MetroButton reference_btn;
        private MetroFramework.Controls.MetroButton goBack_btn;
        private MetroFramework.Controls.MetroButton compare_Btn;
        private MetroFramework.Controls.MetroLabel voiceIn_Label;
        private MetroFramework.Controls.MetroLabel refIn_Label;
        private MetroFramework.Controls.MetroLabel compareLabel;
    }
}