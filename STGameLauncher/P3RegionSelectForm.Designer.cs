namespace STGameLauncher
{
    partial class GameRegionSet
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
            this.label1 = new System.Windows.Forms.Label();
            this.digUS = new System.Windows.Forms.RadioButton();
            this.digEU = new System.Windows.Forms.RadioButton();
            this.digJP = new System.Windows.Forms.RadioButton();
            this.digTW = new System.Windows.Forms.RadioButton();
            this.labDig = new System.Windows.Forms.Label();
            this.physUS = new System.Windows.Forms.RadioButton();
            this.physEU = new System.Windows.Forms.RadioButton();
            this.physJP = new System.Windows.Forms.RadioButton();
            this.labPhys = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Game Region:";
            // 
            // digUS
            // 
            this.digUS.AutoSize = true;
            this.digUS.Location = new System.Drawing.Point(12, 78);
            this.digUS.Name = "digUS";
            this.digUS.Size = new System.Drawing.Size(40, 17);
            this.digUS.TabIndex = 1;
            this.digUS.TabStop = true;
            this.digUS.Text = "US";
            this.digUS.UseVisualStyleBackColor = true;
            // 
            // digEU
            // 
            this.digEU.AutoSize = true;
            this.digEU.Location = new System.Drawing.Point(58, 78);
            this.digEU.Name = "digEU";
            this.digEU.Size = new System.Drawing.Size(40, 17);
            this.digEU.TabIndex = 2;
            this.digEU.TabStop = true;
            this.digEU.Text = "EU";
            this.digEU.UseVisualStyleBackColor = true;
            // 
            // digJP
            // 
            this.digJP.AutoSize = true;
            this.digJP.Location = new System.Drawing.Point(104, 78);
            this.digJP.Name = "digJP";
            this.digJP.Size = new System.Drawing.Size(37, 17);
            this.digJP.TabIndex = 3;
            this.digJP.TabStop = true;
            this.digJP.Text = "JP";
            this.digJP.UseVisualStyleBackColor = true;
            // 
            // digTW
            // 
            this.digTW.AutoSize = true;
            this.digTW.Location = new System.Drawing.Point(148, 78);
            this.digTW.Name = "digTW";
            this.digTW.Size = new System.Drawing.Size(43, 17);
            this.digTW.TabIndex = 4;
            this.digTW.TabStop = true;
            this.digTW.Text = "TW";
            this.digTW.UseVisualStyleBackColor = true;
            // 
            // labDig
            // 
            this.labDig.AutoSize = true;
            this.labDig.Location = new System.Drawing.Point(9, 62);
            this.labDig.Name = "labDig";
            this.labDig.Size = new System.Drawing.Size(39, 13);
            this.labDig.TabIndex = 5;
            this.labDig.Text = "Digital:";
            // 
            // physUS
            // 
            this.physUS.AutoSize = true;
            this.physUS.Location = new System.Drawing.Point(12, 42);
            this.physUS.Name = "physUS";
            this.physUS.Size = new System.Drawing.Size(40, 17);
            this.physUS.TabIndex = 6;
            this.physUS.TabStop = true;
            this.physUS.Text = "US";
            this.physUS.UseVisualStyleBackColor = true;
            this.physUS.CheckedChanged += new System.EventHandler(this.physUS_CheckedChanged);
            // 
            // physEU
            // 
            this.physEU.AutoSize = true;
            this.physEU.Location = new System.Drawing.Point(59, 42);
            this.physEU.Name = "physEU";
            this.physEU.Size = new System.Drawing.Size(40, 17);
            this.physEU.TabIndex = 7;
            this.physEU.TabStop = true;
            this.physEU.Text = "EU";
            this.physEU.UseVisualStyleBackColor = true;
            this.physEU.CheckedChanged += new System.EventHandler(this.physEU_CheckedChanged);
            // 
            // physJP
            // 
            this.physJP.AutoSize = true;
            this.physJP.Location = new System.Drawing.Point(106, 42);
            this.physJP.Name = "physJP";
            this.physJP.Size = new System.Drawing.Size(37, 17);
            this.physJP.TabIndex = 8;
            this.physJP.TabStop = true;
            this.physJP.Text = "JP";
            this.physJP.UseVisualStyleBackColor = true;
            // 
            // labPhys
            // 
            this.labPhys.AutoSize = true;
            this.labPhys.Location = new System.Drawing.Point(9, 26);
            this.labPhys.Name = "labPhys";
            this.labPhys.Size = new System.Drawing.Size(46, 13);
            this.labPhys.TabIndex = 9;
            this.labPhys.Text = "Physical";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GameRegionSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 137);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labPhys);
            this.Controls.Add(this.physJP);
            this.Controls.Add(this.physEU);
            this.Controls.Add(this.physUS);
            this.Controls.Add(this.labDig);
            this.Controls.Add(this.digTW);
            this.Controls.Add(this.digJP);
            this.Controls.Add(this.digEU);
            this.Controls.Add(this.digUS);
            this.Controls.Add(this.label1);
            this.Name = "GameRegionSet";
            this.Text = "Region Select";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameRegionSet_FormClosed);
            this.Load += new System.EventHandler(this.GameRegionSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton digUS;
        private System.Windows.Forms.RadioButton digEU;
        private System.Windows.Forms.RadioButton digJP;
        private System.Windows.Forms.RadioButton digTW;
        private System.Windows.Forms.Label labDig;
        private System.Windows.Forms.RadioButton physUS;
        private System.Windows.Forms.RadioButton physEU;
        private System.Windows.Forms.RadioButton physJP;
        private System.Windows.Forms.Label labPhys;
        private System.Windows.Forms.Button button1;
    }
}