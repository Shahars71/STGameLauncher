namespace STGameLauncher
{
    partial class SpecSettingsForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cmb_console = new System.Windows.Forms.ComboBox();
            this.cmb_emul = new System.Windows.Forms.ComboBox();
            this.btn_applyEmul = new System.Windows.Forms.Button();
            this.lbl_applyEmulToConsole = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Apply arguments to all games for a single emulator";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Type cmd argument here";
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Mega Drive",
            "Master System",
            "Game Gear",
            "Sega Saturn",
            "Dreamcast",
            "GameCube",
            "Wii",
            "Wii U",
            "Switch",
            "PS2",
            "PS3",
            "OG XBox",
            "XBox 360",
            "Neo Geo Pocket Color",
            "Game Boy Advance",
            "DS",
            "3DS",
            "PSP",
            ""});
            this.comboBox1.Location = new System.Drawing.Point(206, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // cmb_console
            // 
            this.cmb_console.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_console.FormattingEnabled = true;
            this.cmb_console.Location = new System.Drawing.Point(12, 105);
            this.cmb_console.Name = "cmb_console";
            this.cmb_console.Size = new System.Drawing.Size(166, 21);
            this.cmb_console.TabIndex = 4;
            this.cmb_console.SelectedIndexChanged += new System.EventHandler(this.cmb_console_SelectedIndexChanged);
            // 
            // cmb_emul
            // 
            this.cmb_emul.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_emul.FormattingEnabled = true;
            this.cmb_emul.Location = new System.Drawing.Point(192, 105);
            this.cmb_emul.Name = "cmb_emul";
            this.cmb_emul.Size = new System.Drawing.Size(135, 21);
            this.cmb_emul.TabIndex = 5;
            this.cmb_emul.SelectedIndexChanged += new System.EventHandler(this.cmb_emul_SelectedIndexChanged);
            // 
            // btn_applyEmul
            // 
            this.btn_applyEmul.Location = new System.Drawing.Point(337, 105);
            this.btn_applyEmul.Name = "btn_applyEmul";
            this.btn_applyEmul.Size = new System.Drawing.Size(82, 23);
            this.btn_applyEmul.TabIndex = 6;
            this.btn_applyEmul.Text = "Apply";
            this.btn_applyEmul.UseVisualStyleBackColor = true;
            this.btn_applyEmul.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbl_applyEmulToConsole
            // 
            this.lbl_applyEmulToConsole.AutoSize = true;
            this.lbl_applyEmulToConsole.Location = new System.Drawing.Point(12, 83);
            this.lbl_applyEmulToConsole.Name = "lbl_applyEmulToConsole";
            this.lbl_applyEmulToConsole.Size = new System.Drawing.Size(212, 13);
            this.lbl_applyEmulToConsole.TabIndex = 7;
            this.lbl_applyEmulToConsole.Text = "Select an emulator to be used for a console";
            // 
            // SpecSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 138);
            this.Controls.Add(this.lbl_applyEmulToConsole);
            this.Controls.Add(this.btn_applyEmul);
            this.Controls.Add(this.cmb_emul);
            this.Controls.Add(this.cmb_console);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "SpecSettingsForm";
            this.Text = "Special Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cmb_console;
        private System.Windows.Forms.ComboBox cmb_emul;
        private System.Windows.Forms.Button btn_applyEmul;
        private System.Windows.Forms.Label lbl_applyEmulToConsole;
    }
}