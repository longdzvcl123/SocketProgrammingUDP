
namespace Server
{
    partial class formCom
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.endConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(694, 293);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // endConnect
            // 
            this.endConnect.Location = new System.Drawing.Point(582, 311);
            this.endConnect.Name = "endConnect";
            this.endConnect.Size = new System.Drawing.Size(124, 37);
            this.endConnect.TabIndex = 1;
            this.endConnect.TabStop = false;
            this.endConnect.Text = "Stop";
            this.endConnect.UseVisualStyleBackColor = true;
            this.endConnect.Click += new System.EventHandler(this.endConnect_Click);
            // 
            // formCom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 360);
            this.Controls.Add(this.endConnect);
            this.Controls.Add(this.richTextBox1);
            this.Name = "formCom";
            this.Text = "Communication";
            this.Load += new System.EventHandler(this.Communication_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button endConnect;
    }
}