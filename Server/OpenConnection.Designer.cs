
namespace Server
{
    partial class OpenConnection
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
            this.ipBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stopConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ipBox
            // 
            this.ipBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.ipBox.Location = new System.Drawing.Point(100, 92);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(198, 26);
            this.ipBox.TabIndex = 0;
            this.ipBox.TabStop = false;
            this.ipBox.Text = "Enter IP";
            this.ipBox.Click += new System.EventHandler(this.ipBox_Click);
            this.ipBox.Leave += new System.EventHandler(this.ipBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ip Address";
            // 
            // portBox
            // 
            this.portBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.portBox.Location = new System.Drawing.Point(100, 127);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(198, 26);
            this.portBox.TabIndex = 2;
            this.portBox.TabStop = false;
            this.portBox.Text = "Enter port";
            this.portBox.Click += new System.EventHandler(this.portBox_Click);
            this.portBox.Leave += new System.EventHandler(this.portBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(100, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 33);
            this.button1.TabIndex = 4;
            this.button1.TabStop = false;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(100, 159);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(76, 24);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "Autofill";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(327, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "The server opens the connection";
            // 
            // stopConnect
            // 
            this.stopConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopConnect.Location = new System.Drawing.Point(223, 182);
            this.stopConnect.Name = "stopConnect";
            this.stopConnect.Size = new System.Drawing.Size(75, 33);
            this.stopConnect.TabIndex = 7;
            this.stopConnect.Text = "Stop";
            this.stopConnect.UseVisualStyleBackColor = true;
            this.stopConnect.Click += new System.EventHandler(this.stopConnect_Click);
            // 
            // OpenConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 288);
            this.Controls.Add(this.stopConnect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "OpenConnection";
            this.Text = "OpenConnection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button stopConnect;
    }
}

