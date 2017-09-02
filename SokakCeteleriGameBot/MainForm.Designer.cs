namespace SokakCeteleriGameBot
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbZehir = new System.Windows.Forms.Label();
            this.lbRisk = new System.Windows.Forms.Label();
            this.lbEnerji = new System.Windows.Forms.Label();
            this.lbCan = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.startPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.startPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbZehir);
            this.panel1.Controls.Add(this.lbRisk);
            this.panel1.Controls.Add(this.lbEnerji);
            this.panel1.Controls.Add(this.lbCan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1093, 188);
            this.panel1.TabIndex = 0;
            // 
            // lbZehir
            // 
            this.lbZehir.AutoSize = true;
            this.lbZehir.Location = new System.Drawing.Point(12, 118);
            this.lbZehir.Name = "lbZehir";
            this.lbZehir.Size = new System.Drawing.Size(57, 20);
            this.lbZehir.TabIndex = 0;
            this.lbZehir.Text = "Zehir : ";
            // 
            // lbRisk
            // 
            this.lbRisk.AutoSize = true;
            this.lbRisk.Location = new System.Drawing.Point(12, 87);
            this.lbRisk.Name = "lbRisk";
            this.lbRisk.Size = new System.Drawing.Size(52, 20);
            this.lbRisk.TabIndex = 0;
            this.lbRisk.Text = "Risk : ";
            // 
            // lbEnerji
            // 
            this.lbEnerji.AutoSize = true;
            this.lbEnerji.Location = new System.Drawing.Point(12, 55);
            this.lbEnerji.Name = "lbEnerji";
            this.lbEnerji.Size = new System.Drawing.Size(61, 20);
            this.lbEnerji.TabIndex = 0;
            this.lbEnerji.Text = "Enerji : ";
            // 
            // lbCan
            // 
            this.lbCan.AutoSize = true;
            this.lbCan.Location = new System.Drawing.Point(12, 24);
            this.lbCan.Name = "lbCan";
            this.lbCan.Size = new System.Drawing.Size(50, 20);
            this.lbCan.TabIndex = 0;
            this.lbCan.Text = "Can : ";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(188, 79);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(133, 41);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = " Başla";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(18, 20);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(93, 20);
            this.lbUserName.TabIndex = 0;
            this.lbUserName.Text = "Kullanici Adi";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(69, 50);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(42, 20);
            this.lbPassword.TabIndex = 0;
            this.lbPassword.Text = "Sifre";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(117, 17);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(204, 26);
            this.txtUserName.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(117, 47);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(204, 26);
            this.txtPassword.TabIndex = 3;
            // 
            // startPanel
            // 
            this.startPanel.Controls.Add(this.lbUserName);
            this.startPanel.Controls.Add(this.txtPassword);
            this.startPanel.Controls.Add(this.btnStart);
            this.startPanel.Controls.Add(this.txtUserName);
            this.startPanel.Controls.Add(this.lbPassword);
            this.startPanel.Location = new System.Drawing.Point(12, 194);
            this.startPanel.Name = "startPanel";
            this.startPanel.Size = new System.Drawing.Size(350, 137);
            this.startPanel.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 557);
            this.Controls.Add(this.startPanel);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.startPanel.ResumeLayout(false);
            this.startPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbZehir;
        private System.Windows.Forms.Label lbRisk;
        private System.Windows.Forms.Label lbEnerji;
        private System.Windows.Forms.Label lbCan;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel startPanel;
    }
}

