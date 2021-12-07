
namespace Client
{
    partial class clientForm
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.connectServer = new System.Windows.Forms.Button();
            this.disconnectServer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ordinalNumber = new System.Windows.Forms.TextBox();
            this.displayAll = new System.Windows.Forms.Button();
            this.searchData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(12, 62);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(76, 24);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "Autofill";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(247, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Port";
            // 
            // portBox
            // 
            this.portBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.portBox.Location = new System.Drawing.Point(251, 32);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(198, 24);
            this.portBox.TabIndex = 9;
            this.portBox.TabStop = false;
            this.portBox.Text = "Enter port";
            this.portBox.Click += new System.EventHandler(this.portBox_Click);
            this.portBox.Leave += new System.EventHandler(this.portBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ip Address";
            // 
            // ipBox
            // 
            this.ipBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.ipBox.Location = new System.Drawing.Point(12, 32);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(198, 24);
            this.ipBox.TabIndex = 7;
            this.ipBox.TabStop = false;
            this.ipBox.Text = "Enter IP";
            this.ipBox.Click += new System.EventHandler(this.ipBox_Click);
            this.ipBox.Leave += new System.EventHandler(this.ipBox_Leave);
            // 
            // connectServer
            // 
            this.connectServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectServer.Location = new System.Drawing.Point(485, 29);
            this.connectServer.Name = "connectServer";
            this.connectServer.Size = new System.Drawing.Size(118, 31);
            this.connectServer.TabIndex = 12;
            this.connectServer.TabStop = false;
            this.connectServer.Text = "Connection";
            this.connectServer.UseVisualStyleBackColor = true;
            this.connectServer.Click += new System.EventHandler(this.connectServer_Click);
            // 
            // disconnectServer
            // 
            this.disconnectServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disconnectServer.Location = new System.Drawing.Point(609, 29);
            this.disconnectServer.Name = "disconnectServer";
            this.disconnectServer.Size = new System.Drawing.Size(121, 31);
            this.disconnectServer.TabIndex = 13;
            this.disconnectServer.TabStop = false;
            this.disconnectServer.Text = "Disconnection";
            this.disconnectServer.UseVisualStyleBackColor = true;
            this.disconnectServer.Click += new System.EventHandler(this.disconnectServer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Request";
            // 
            // ordinalNumber
            // 
            this.ordinalNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ordinalNumber.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.ordinalNumber.Location = new System.Drawing.Point(418, 137);
            this.ordinalNumber.Name = "ordinalNumber";
            this.ordinalNumber.Size = new System.Drawing.Size(312, 24);
            this.ordinalNumber.TabIndex = 15;
            this.ordinalNumber.TabStop = false;
            this.ordinalNumber.Text = "Enter ordinal number (1-10)";
            this.ordinalNumber.Click += new System.EventHandler(this.ordinalNumber_Click);
            this.ordinalNumber.Leave += new System.EventHandler(this.ordinalNumber_Leave);
            // 
            // displayAll
            // 
            this.displayAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayAll.Location = new System.Drawing.Point(71, 134);
            this.displayAll.Name = "displayAll";
            this.displayAll.Size = new System.Drawing.Size(161, 29);
            this.displayAll.TabIndex = 16;
            this.displayAll.TabStop = false;
            this.displayAll.Text = "Display all locations";
            this.displayAll.UseVisualStyleBackColor = true;
            this.displayAll.Click += new System.EventHandler(this.displayAll_Click);
            // 
            // searchData
            // 
            this.searchData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchData.Location = new System.Drawing.Point(251, 134);
            this.searchData.Name = "searchData";
            this.searchData.Size = new System.Drawing.Size(161, 29);
            this.searchData.TabIndex = 17;
            this.searchData.TabStop = false;
            this.searchData.Text = "Search";
            this.searchData.UseVisualStyleBackColor = true;
            this.searchData.Click += new System.EventHandler(this.search_Click);
            // 
            // clientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(743, 221);
            this.Controls.Add(this.searchData);
            this.Controls.Add(this.displayAll);
            this.Controls.Add(this.ordinalNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.disconnectServer);
            this.Controls.Add(this.connectServer);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipBox);
            this.MaximizeBox = false;
            this.Name = "clientForm";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ipBox;
        private System.Windows.Forms.Button connectServer;
        private System.Windows.Forms.Button disconnectServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ordinalNumber;
        private System.Windows.Forms.Button displayAll;
        private System.Windows.Forms.Button searchData;
    }
}

