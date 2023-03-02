
namespace GUI
{
    partial class ZCS
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
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.DeveloperConsole = new System.Windows.Forms.TextBox();
            this.DevConsoleLabel = new System.Windows.Forms.Label();
            this.MapPanel = new System.Windows.Forms.Panel();
            this.MapLabel = new System.Windows.Forms.Label();
            this.MovementInstructions = new System.Windows.Forms.TextBox();
            this.FindInstructionLabel = new System.Windows.Forms.Label();
            this.ActionBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Mode3Btn = new System.Windows.Forms.Button();
            this.Mode2Btn = new System.Windows.Forms.Button();
            this.Mode1Btn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Stoppingbar = new System.Windows.Forms.TextBox();
            this.ArrowRightBtn = new System.Windows.Forms.Button();
            this.ArrowLeftBtn = new System.Windows.Forms.Button();
            this.ArrowDownBtn = new System.Windows.Forms.Button();
            this.ArrowUpBtn = new System.Windows.Forms.Button();
            this.OpenSerial = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.DtrEnable = true;
            this.serialPort.PortName = "COM7";
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // DeveloperConsole
            // 
            this.DeveloperConsole.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DeveloperConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DeveloperConsole.ForeColor = System.Drawing.SystemColors.Window;
            this.DeveloperConsole.Location = new System.Drawing.Point(16, 73);
            this.DeveloperConsole.Margin = new System.Windows.Forms.Padding(6);
            this.DeveloperConsole.Multiline = true;
            this.DeveloperConsole.Name = "DeveloperConsole";
            this.DeveloperConsole.ReadOnly = true;
            this.DeveloperConsole.Size = new System.Drawing.Size(500, 479);
            this.DeveloperConsole.TabIndex = 0;
            // 
            // DevConsoleLabel
            // 
            this.DevConsoleLabel.AutoSize = true;
            this.DevConsoleLabel.Location = new System.Drawing.Point(164, 23);
            this.DevConsoleLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.DevConsoleLabel.Name = "DevConsoleLabel";
            this.DevConsoleLabel.Size = new System.Drawing.Size(195, 25);
            this.DevConsoleLabel.TabIndex = 1;
            this.DevConsoleLabel.Text = "Developer Console";
            // 
            // MapPanel
            // 
            this.MapPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MapPanel.Location = new System.Drawing.Point(532, 73);
            this.MapPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MapPanel.Name = "MapPanel";
            this.MapPanel.Size = new System.Drawing.Size(502, 479);
            this.MapPanel.TabIndex = 3;
            // 
            // MapLabel
            // 
            this.MapLabel.AutoSize = true;
            this.MapLabel.Location = new System.Drawing.Point(762, 23);
            this.MapLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.MapLabel.Name = "MapLabel";
            this.MapLabel.Size = new System.Drawing.Size(54, 25);
            this.MapLabel.TabIndex = 5;
            this.MapLabel.Text = "Map";
            // 
            // MovementInstructions
            // 
            this.MovementInstructions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MovementInstructions.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MovementInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MovementInstructions.ForeColor = System.Drawing.SystemColors.MenuText;
            this.MovementInstructions.Location = new System.Drawing.Point(1062, 73);
            this.MovementInstructions.Margin = new System.Windows.Forms.Padding(6);
            this.MovementInstructions.Multiline = true;
            this.MovementInstructions.Name = "MovementInstructions";
            this.MovementInstructions.ReadOnly = true;
            this.MovementInstructions.Size = new System.Drawing.Size(248, 839);
            this.MovementInstructions.TabIndex = 7;
            // 
            // FindInstructionLabel
            // 
            this.FindInstructionLabel.AutoSize = true;
            this.FindInstructionLabel.Location = new System.Drawing.Point(1142, 23);
            this.FindInstructionLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.FindInstructionLabel.Name = "FindInstructionLabel";
            this.FindInstructionLabel.Size = new System.Drawing.Size(112, 25);
            this.FindInstructionLabel.TabIndex = 8;
            this.FindInstructionLabel.Text = "Drive Path";
            // 
            // ActionBtn
            // 
            this.ActionBtn.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.ActionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActionBtn.Location = new System.Drawing.Point(18, 50);
            this.ActionBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ActionBtn.Name = "ActionBtn";
            this.ActionBtn.Size = new System.Drawing.Size(236, 88);
            this.ActionBtn.TabIndex = 9;
            this.ActionBtn.Text = "Btn";
            this.ActionBtn.UseVisualStyleBackColor = true;
            this.ActionBtn.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OpenSerial);
            this.groupBox1.Controls.Add(this.ActionBtn);
            this.groupBox1.Location = new System.Drawing.Point(16, 562);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(272, 352);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zumo Actions";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Mode3Btn);
            this.groupBox2.Controls.Add(this.Mode2Btn);
            this.groupBox2.Controls.Add(this.Mode1Btn);
            this.groupBox2.Location = new System.Drawing.Point(316, 562);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(272, 352);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mode Selection";
            // 
            // Mode3Btn
            // 
            this.Mode3Btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Mode3Btn.Location = new System.Drawing.Point(18, 242);
            this.Mode3Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Mode3Btn.Name = "Mode3Btn";
            this.Mode3Btn.Size = new System.Drawing.Size(236, 88);
            this.Mode3Btn.TabIndex = 11;
            this.Mode3Btn.Text = "Mode 3";
            this.Mode3Btn.UseVisualStyleBackColor = true;
            this.Mode3Btn.Visible = false;
            // 
            // Mode2Btn
            // 
            this.Mode2Btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Mode2Btn.Location = new System.Drawing.Point(18, 146);
            this.Mode2Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Mode2Btn.Name = "Mode2Btn";
            this.Mode2Btn.Size = new System.Drawing.Size(236, 88);
            this.Mode2Btn.TabIndex = 10;
            this.Mode2Btn.Text = "Mode 2";
            this.Mode2Btn.UseVisualStyleBackColor = true;
            this.Mode2Btn.Visible = false;
            // 
            // Mode1Btn
            // 
            this.Mode1Btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Mode1Btn.Location = new System.Drawing.Point(18, 50);
            this.Mode1Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Mode1Btn.Name = "Mode1Btn";
            this.Mode1Btn.Size = new System.Drawing.Size(236, 88);
            this.Mode1Btn.TabIndex = 9;
            this.Mode1Btn.Text = "Mode 1";
            this.Mode1Btn.UseVisualStyleBackColor = true;
            this.Mode1Btn.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.Stoppingbar);
            this.groupBox3.Controls.Add(this.ArrowRightBtn);
            this.groupBox3.Controls.Add(this.ArrowLeftBtn);
            this.groupBox3.Controls.Add(this.ArrowDownBtn);
            this.groupBox3.Controls.Add(this.ArrowUpBtn);
            this.groupBox3.Location = new System.Drawing.Point(616, 562);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(420, 352);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Movement Controlls";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 242);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(308, 45);
            this.button1.TabIndex = 15;
            this.button1.Text = "STOP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Stoppingbar
            // 
            this.Stoppingbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Stoppingbar.Location = new System.Drawing.Point(58, 300);
            this.Stoppingbar.Multiline = true;
            this.Stoppingbar.Name = "Stoppingbar";
            this.Stoppingbar.Size = new System.Drawing.Size(308, 36);
            this.Stoppingbar.TabIndex = 14;
            this.Stoppingbar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Stoppingbar_KeyDown);
            // 
            // ArrowRightBtn
            // 
            this.ArrowRightBtn.Location = new System.Drawing.Point(274, 144);
            this.ArrowRightBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ArrowRightBtn.Name = "ArrowRightBtn";
            this.ArrowRightBtn.Size = new System.Drawing.Size(92, 88);
            this.ArrowRightBtn.TabIndex = 13;
            this.ArrowRightBtn.Text = ">";
            this.ArrowRightBtn.UseVisualStyleBackColor = true;
            this.ArrowRightBtn.Click += new System.EventHandler(this.ArrowRightBtn_Click);
            // 
            // ArrowLeftBtn
            // 
            this.ArrowLeftBtn.Location = new System.Drawing.Point(58, 144);
            this.ArrowLeftBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ArrowLeftBtn.Name = "ArrowLeftBtn";
            this.ArrowLeftBtn.Size = new System.Drawing.Size(92, 88);
            this.ArrowLeftBtn.TabIndex = 13;
            this.ArrowLeftBtn.Text = "<";
            this.ArrowLeftBtn.UseVisualStyleBackColor = true;
            this.ArrowLeftBtn.Click += new System.EventHandler(this.ArrowLeftBtn_Click);
            // 
            // ArrowDownBtn
            // 
            this.ArrowDownBtn.Location = new System.Drawing.Point(166, 144);
            this.ArrowDownBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ArrowDownBtn.Name = "ArrowDownBtn";
            this.ArrowDownBtn.Size = new System.Drawing.Size(92, 88);
            this.ArrowDownBtn.TabIndex = 12;
            this.ArrowDownBtn.Text = "|";
            this.ArrowDownBtn.UseVisualStyleBackColor = true;
            this.ArrowDownBtn.Click += new System.EventHandler(this.ArrowDownBtn_Click);
            // 
            // ArrowUpBtn
            // 
            this.ArrowUpBtn.Location = new System.Drawing.Point(166, 39);
            this.ArrowUpBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ArrowUpBtn.Name = "ArrowUpBtn";
            this.ArrowUpBtn.Size = new System.Drawing.Size(92, 88);
            this.ArrowUpBtn.TabIndex = 11;
            this.ArrowUpBtn.Text = "^";
            this.ArrowUpBtn.UseVisualStyleBackColor = true;
            this.ArrowUpBtn.Click += new System.EventHandler(this.ArrowUpBtn_Click);
            // 
            // OpenSerial
            // 
            this.OpenSerial.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.OpenSerial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenSerial.Location = new System.Drawing.Point(18, 248);
            this.OpenSerial.Margin = new System.Windows.Forms.Padding(4);
            this.OpenSerial.Name = "OpenSerial";
            this.OpenSerial.Size = new System.Drawing.Size(236, 88);
            this.OpenSerial.TabIndex = 10;
            this.OpenSerial.Text = "Open serial";
            this.OpenSerial.UseVisualStyleBackColor = true;
            this.OpenSerial.Click += new System.EventHandler(this.OpenSerial_Click);
            // 
            // ZCS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1348, 933);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.FindInstructionLabel);
            this.Controls.Add(this.MovementInstructions);
            this.Controls.Add(this.MapLabel);
            this.Controls.Add(this.MapPanel);
            this.Controls.Add(this.DevConsoleLabel);
            this.Controls.Add(this.DeveloperConsole);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ZCS";
            this.ShowIcon = false;
            this.Text = "Zumo Control Software";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.TextBox DeveloperConsole;
        private System.Windows.Forms.Label DevConsoleLabel;
        private System.Windows.Forms.Panel MapPanel;
        private System.Windows.Forms.Label MapLabel;
        private System.Windows.Forms.TextBox MovementInstructions;
        private System.Windows.Forms.Label FindInstructionLabel;
        private System.Windows.Forms.Button ActionBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Mode3Btn;
        private System.Windows.Forms.Button Mode2Btn;
        private System.Windows.Forms.Button Mode1Btn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ArrowRightBtn;
        private System.Windows.Forms.Button ArrowLeftBtn;
        private System.Windows.Forms.Button ArrowDownBtn;
        private System.Windows.Forms.Button ArrowUpBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Stoppingbar;
        private System.Windows.Forms.Button OpenSerial;
    }
}

