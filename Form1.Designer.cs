namespace PELSI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            speLabel = new Label();
            checkBoxLicense = new CheckBox();
            skipSoftware = new CheckBox();
            button4 = new Button();
            skipSettingsini = new CheckBox();
            skipNI = new CheckBox();
            skipREG = new CheckBox();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Cyan;
            button1.Location = new Point(0, 11);
            button1.Margin = new Padding(0, 5, 0, 5);
            button1.Name = "button1";
            button1.Size = new Size(247, 149);
            button1.TabIndex = 0;
            button1.Text = "Tech Install";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 255, 192);
            button2.Location = new Point(483, 93);
            button2.Margin = new Padding(5);
            button2.Name = "button2";
            button2.Size = new Size(349, 67);
            button2.TabIndex = 2;
            button2.Text = "Check For Designer Only";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // speLabel
            // 
            speLabel.AutoSize = true;
            speLabel.BackColor = SystemColors.ActiveCaptionText;
            speLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            speLabel.ForeColor = Color.Gold;
            speLabel.Location = new Point(194, 214);
            speLabel.Margin = new Padding(5, 0, 5, 0);
            speLabel.Name = "speLabel";
            speLabel.Size = new Size(125, 32);
            speLabel.TabIndex = 3;
            speLabel.Text = "SPE Boiz   ";
            speLabel.Click += speLabel_Click;
            // 
            // checkBoxLicense
            // 
            checkBoxLicense.AutoSize = true;
            checkBoxLicense.BackColor = Color.ForestGreen;
            checkBoxLicense.Location = new Point(269, 472);
            checkBoxLicense.Margin = new Padding(5);
            checkBoxLicense.Name = "checkBoxLicense";
            checkBoxLicense.Size = new Size(254, 29);
            checkBoxLicense.TabIndex = 5;
            checkBoxLicense.Text = "Skip AMI License/Config";
            checkBoxLicense.UseVisualStyleBackColor = false;
            checkBoxLicense.CheckedChanged += checkBoxLicense_CheckedChanged;
            // 
            // skipSoftware
            // 
            skipSoftware.AutoSize = true;
            skipSoftware.BackColor = Color.ForestGreen;
            skipSoftware.Location = new Point(269, 411);
            skipSoftware.Margin = new Padding(5);
            skipSoftware.Name = "skipSoftware";
            skipSoftware.Size = new Size(162, 29);
            skipSoftware.TabIndex = 6;
            skipSoftware.Text = "Skip Software";
            skipSoftware.UseVisualStyleBackColor = false;
            skipSoftware.CheckedChanged += skipSoftware_CheckedChanged;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ActiveCaption;
            button4.Location = new Point(483, 11);
            button4.Margin = new Padding(5);
            button4.Name = "button4";
            button4.Size = new Size(349, 77);
            button4.TabIndex = 7;
            button4.Text = "Pull and Store AMI License + Config Only";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // skipSettingsini
            // 
            skipSettingsini.Location = new Point(269, 436);
            skipSettingsini.Name = "skipSettingsini";
            skipSettingsini.Size = new Size(193, 36);
            skipSettingsini.TabIndex = 0;
            skipSettingsini.Text = "Skip Settings.ini";
            skipSettingsini.CheckedChanged += skipSettingsini_CheckedChanged;
            // 
            // skipNI
            // 
            skipNI.AutoSize = true;
            skipNI.Location = new Point(269, 500);
            skipNI.Name = "skipNI";
            skipNI.Size = new Size(189, 29);
            skipNI.TabIndex = 9;
            skipNI.Text = "Skip NI Services";
            skipNI.UseVisualStyleBackColor = true;
            skipNI.Click += skipNI_Click;
            // 
            // skipREG
            // 
            skipREG.AutoSize = true;
            skipREG.Location = new Point(269, 531);
            skipREG.Name = "skipREG";
            skipREG.Size = new Size(153, 29);
            skipREG.TabIndex = 10;
            skipREG.Text = "Skip REGBAK";
            skipREG.UseVisualStyleBackColor = true;
            skipREG.CheckedChanged += skipREG_CheckedChanged;
            skipREG.Click += skipREG_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.MenuHighlight;
            button3.Location = new Point(0, 411);
            button3.Margin = new Padding(0, 5, 0, 5);
            button3.Name = "button3";
            button3.Size = new Size(247, 149);
            button3.TabIndex = 11;
            button3.Text = "Check List, Click for help";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            BackgroundImage = Properties.Resources.NexTier_Oilfield_Solutions_Logo;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(846, 573);
            Controls.Add(button3);
            Controls.Add(skipNI);
            Controls.Add(skipREG);
            Controls.Add(skipSettingsini);
            Controls.Add(checkBoxLicense);
            Controls.Add(skipSoftware);
            Controls.Add(button4);
            Controls.Add(speLabel);
            Controls.Add(button2);
            Controls.Add(button1);
            Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(0, 5, 0, 5);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Etech Laptop Installer";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label speLabel;
        private CheckBox checkBoxLicense;
        private CheckBox skipSoftware;
        private Button button4;
        private CheckBox skipSettingsini;
        private CheckBox skipNI;
        private CheckBox skipREG;
        private Button button3;
    }
}