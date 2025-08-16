using System.Drawing;
using System.Windows.Forms;

namespace ELFInjector
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
            this.ps4ipLabel = new System.Windows.Forms.Label();
            this.ps4Ip = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.ps4connectionGroupBox = new System.Windows.Forms.GroupBox();
            this.payloadStatusLabel = new System.Windows.Forms.Label();
            this.sendPayloadButton = new System.Windows.Forms.Button();
            this.payloadPortLabel = new System.Windows.Forms.Label();
            this.payloadIpLabel = new System.Windows.Forms.Label();
            this.payloadPort = new System.Windows.Forms.TextBox();
            this.payloadIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.heartLabel = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.processListLabel = new System.Windows.Forms.Label();
            this.injectElfButton = new System.Windows.Forms.Button();
            this.processListComboBox = new System.Windows.Forms.ComboBox();
            this.helpLabel = new System.Windows.Forms.Label();
            this.ps4connectionGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ps4ipLabel
            // 
            this.ps4ipLabel.AutoSize = true;
            this.ps4ipLabel.Location = new System.Drawing.Point(5, 16);
            this.ps4ipLabel.Name = "ps4ipLabel";
            this.ps4ipLabel.Size = new System.Drawing.Size(43, 13);
            this.ps4ipLabel.TabIndex = 0;
            this.ps4ipLabel.Text = "PS4 IP:";
            // 
            // ps4Ip
            // 
            this.ps4Ip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.ps4Ip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ps4Ip.ForeColor = System.Drawing.Color.White;
            this.ps4Ip.Location = new System.Drawing.Point(5, 32);
            this.ps4Ip.Name = "ps4Ip";
            this.ps4Ip.Size = new System.Drawing.Size(105, 20);
            this.ps4Ip.TabIndex = 1;
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.connectButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Location = new System.Drawing.Point(5, 57);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(105, 28);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = false;
            // 
            // ps4connectionGroupBox
            // 
            this.ps4connectionGroupBox.Controls.Add(this.payloadStatusLabel);
            this.ps4connectionGroupBox.Controls.Add(this.sendPayloadButton);
            this.ps4connectionGroupBox.Controls.Add(this.payloadPortLabel);
            this.ps4connectionGroupBox.Controls.Add(this.payloadIpLabel);
            this.ps4connectionGroupBox.Controls.Add(this.payloadPort);
            this.ps4connectionGroupBox.Controls.Add(this.payloadIp);
            this.ps4connectionGroupBox.ForeColor = System.Drawing.Color.White;
            this.ps4connectionGroupBox.Location = new System.Drawing.Point(10, 3);
            this.ps4connectionGroupBox.Name = "ps4connectionGroupBox";
            this.ps4connectionGroupBox.Size = new System.Drawing.Size(180, 110);
            this.ps4connectionGroupBox.TabIndex = 3;
            this.ps4connectionGroupBox.TabStop = false;
            this.ps4connectionGroupBox.Text = "Payload Sender";
            // 
            // payloadStatusLabel
            // 
            this.payloadStatusLabel.AutoSize = true;
            this.payloadStatusLabel.Location = new System.Drawing.Point(6, 88);
            this.payloadStatusLabel.Name = "payloadStatusLabel";
            this.payloadStatusLabel.Size = new System.Drawing.Size(60, 13);
            this.payloadStatusLabel.TabIndex = 5;
            this.payloadStatusLabel.Text = "Status: Idle";
            // 
            // sendPayloadButton
            // 
            this.sendPayloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.sendPayloadButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.sendPayloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendPayloadButton.Location = new System.Drawing.Point(5, 57);
            this.sendPayloadButton.Name = "sendPayloadButton";
            this.sendPayloadButton.Size = new System.Drawing.Size(162, 28);
            this.sendPayloadButton.TabIndex = 4;
            this.sendPayloadButton.Text = "Browse and Send Payload";
            this.sendPayloadButton.UseVisualStyleBackColor = false;
            // 
            // payloadPortLabel
            // 
            this.payloadPortLabel.AutoSize = true;
            this.payloadPortLabel.Location = new System.Drawing.Point(126, 16);
            this.payloadPortLabel.Name = "payloadPortLabel";
            this.payloadPortLabel.Size = new System.Drawing.Size(29, 13);
            this.payloadPortLabel.TabIndex = 3;
            this.payloadPortLabel.Text = "Port:";
            // 
            // payloadIpLabel
            // 
            this.payloadIpLabel.AutoSize = true;
            this.payloadIpLabel.Location = new System.Drawing.Point(5, 16);
            this.payloadIpLabel.Name = "payloadIpLabel";
            this.payloadIpLabel.Size = new System.Drawing.Size(43, 13);
            this.payloadIpLabel.TabIndex = 2;
            this.payloadIpLabel.Text = "PS4 IP:";
            // 
            // payloadPort
            // 
            this.payloadPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.payloadPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.payloadPort.ForeColor = System.Drawing.Color.White;
            this.payloadPort.Location = new System.Drawing.Point(126, 32);
            this.payloadPort.Name = "payloadPort";
            this.payloadPort.Size = new System.Drawing.Size(42, 20);
            this.payloadPort.TabIndex = 1;
            this.payloadPort.Text = "9090";
            // 
            // payloadIp
            // 
            this.payloadIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.payloadIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.payloadIp.ForeColor = System.Drawing.Color.White;
            this.payloadIp.Location = new System.Drawing.Point(5, 32);
            this.payloadIp.Name = "payloadIp";
            this.payloadIp.Size = new System.Drawing.Size(109, 20);
            this.payloadIp.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Status: Not Connected";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.heartLabel);
            this.groupBox1.Controls.Add(this.refreshButton);
            this.groupBox1.Controls.Add(this.processListLabel);
            this.groupBox1.Controls.Add(this.injectElfButton);
            this.groupBox1.Controls.Add(this.processListComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ps4ipLabel);
            this.groupBox1.Controls.Add(this.connectButton);
            this.groupBox1.Controls.Add(this.ps4Ip);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(196, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 183);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ELF Injector";
            // 
            // heartLabel
            // 
            this.heartLabel.AutoSize = true;
            this.heartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.heartLabel.ForeColor = System.Drawing.Color.Aqua;
            this.heartLabel.Location = new System.Drawing.Point(153, 13);
            this.heartLabel.Name = "heartLabel";
            this.heartLabel.Size = new System.Drawing.Size(21, 16);
            this.heartLabel.TabIndex = 6;
            this.heartLabel.Text = "<3";
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.refreshButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Location = new System.Drawing.Point(151, 109);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(24, 22);
            this.refreshButton.TabIndex = 7;
            this.refreshButton.Text = "↻";
            this.refreshButton.UseVisualStyleBackColor = false;
            // 
            // processListLabel
            // 
            this.processListLabel.AutoSize = true;
            this.processListLabel.Location = new System.Drawing.Point(2, 93);
            this.processListLabel.Name = "processListLabel";
            this.processListLabel.Size = new System.Drawing.Size(67, 13);
            this.processListLabel.TabIndex = 6;
            this.processListLabel.Text = "Process List:";
            // 
            // injectElfButton
            // 
            this.injectElfButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.injectElfButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.injectElfButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.injectElfButton.Location = new System.Drawing.Point(4, 136);
            this.injectElfButton.Name = "injectElfButton";
            this.injectElfButton.Size = new System.Drawing.Size(170, 25);
            this.injectElfButton.TabIndex = 5;
            this.injectElfButton.Text = "Browse and Inject ELF";
            this.injectElfButton.UseVisualStyleBackColor = false;
            // 
            // processListComboBox
            // 
            this.processListComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.processListComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.processListComboBox.ForeColor = System.Drawing.Color.White;
            this.processListComboBox.FormattingEnabled = true;
            this.processListComboBox.Location = new System.Drawing.Point(4, 109);
            this.processListComboBox.Name = "processListComboBox";
            this.processListComboBox.Size = new System.Drawing.Size(141, 21);
            this.processListComboBox.TabIndex = 4;
            // 
            // helpLabel
            // 
            this.helpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helpLabel.AutoSize = true;
            this.helpLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.helpLabel.ForeColor = System.Drawing.Color.Cyan;
            this.helpLabel.Location = new System.Drawing.Point(2, 122);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(192, 42);
            this.helpLabel.TabIndex = 5;
            this.helpLabel.Text = "DON\'T SEND PS4DEBUG\r\nIF ALREADY SENT BEFORE";
            this.helpLabel.UseMnemonic = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(384, 189);
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ps4connectionGroupBox);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ELF Injector";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ps4connectionGroupBox.ResumeLayout(false);
            this.ps4connectionGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label ps4ipLabel;
        private TextBox ps4Ip;
        private Button connectButton;
        private GroupBox ps4connectionGroupBox;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox payloadPort;
        private TextBox payloadIp;
        private Label payloadIpLabel;
        private Label payloadPortLabel;
        private Button sendPayloadButton;
        private Label payloadStatusLabel;
        private Label processListLabel;
        private Button injectElfButton;
        private ComboBox processListComboBox;
        private Label helpLabel;
        private Button refreshButton;
        private Label heartLabel;
    }
}