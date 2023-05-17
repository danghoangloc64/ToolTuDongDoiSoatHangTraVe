
namespace ToolTuDongDoiSoatHangTraVe
{
    partial class Form1
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
            this.txtDauVao1 = new System.Windows.Forms.TextBox();
            this.btnChon1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDauVao2 = new System.Windows.Forms.TextBox();
            this.btnChon2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDauVao3 = new System.Windows.Forms.TextBox();
            this.btnChon3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.btnChay = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đơn đầu vào 1:";
            // 
            // txtDauVao1
            // 
            this.txtDauVao1.Location = new System.Drawing.Point(228, 12);
            this.txtDauVao1.Name = "txtDauVao1";
            this.txtDauVao1.ReadOnly = true;
            this.txtDauVao1.Size = new System.Drawing.Size(490, 20);
            this.txtDauVao1.TabIndex = 0;
            // 
            // btnChon1
            // 
            this.btnChon1.Location = new System.Drawing.Point(724, 11);
            this.btnChon1.Name = "btnChon1";
            this.btnChon1.Size = new System.Drawing.Size(75, 23);
            this.btnChon1.TabIndex = 1;
            this.btnChon1.Text = "Chọn";
            this.btnChon1.UseVisualStyleBackColor = true;
            this.btnChon1.Click += new System.EventHandler(this.btnChon1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Đơn trả về khi đã up thông tin (đầu vào 2):";
            // 
            // txtDauVao2
            // 
            this.txtDauVao2.Location = new System.Drawing.Point(228, 38);
            this.txtDauVao2.Name = "txtDauVao2";
            this.txtDauVao2.ReadOnly = true;
            this.txtDauVao2.Size = new System.Drawing.Size(490, 20);
            this.txtDauVao2.TabIndex = 2;
            // 
            // btnChon2
            // 
            this.btnChon2.Location = new System.Drawing.Point(724, 37);
            this.btnChon2.Name = "btnChon2";
            this.btnChon2.Size = new System.Drawing.Size(75, 23);
            this.btnChon2.TabIndex = 3;
            this.btnChon2.Text = "Chọn";
            this.btnChon2.UseVisualStyleBackColor = true;
            this.btnChon2.Click += new System.EventHandler(this.btnChon2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Đơn đối soát trả về hàng tuần (đầu vào 3):";
            // 
            // txtDauVao3
            // 
            this.txtDauVao3.Location = new System.Drawing.Point(228, 64);
            this.txtDauVao3.Name = "txtDauVao3";
            this.txtDauVao3.ReadOnly = true;
            this.txtDauVao3.Size = new System.Drawing.Size(490, 20);
            this.txtDauVao3.TabIndex = 4;
            // 
            // btnChon3
            // 
            this.btnChon3.Location = new System.Drawing.Point(724, 63);
            this.btnChon3.Name = "btnChon3";
            this.btnChon3.Size = new System.Drawing.Size(75, 23);
            this.btnChon3.TabIndex = 5;
            this.btnChon3.Text = "Chọn";
            this.btnChon3.UseVisualStyleBackColor = true;
            this.btnChon3.Click += new System.EventHandler(this.btnChon3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBoxLog);
            this.groupBox1.Location = new System.Drawing.Point(12, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(787, 429);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Location = new System.Drawing.Point(6, 19);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(775, 404);
            this.richTextBoxLog.TabIndex = 0;
            this.richTextBoxLog.Text = "";
            // 
            // btnChay
            // 
            this.btnChay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChay.Location = new System.Drawing.Point(12, 525);
            this.btnChay.Name = "btnChay";
            this.btnChay.Size = new System.Drawing.Size(787, 36);
            this.btnChay.TabIndex = 6;
            this.btnChay.Text = "Chạy";
            this.btnChay.UseVisualStyleBackColor = true;
            this.btnChay.Click += new System.EventHandler(this.btnChay_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 573);
            this.Controls.Add(this.btnChay);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnChon3);
            this.Controls.Add(this.btnChon2);
            this.Controls.Add(this.btnChon1);
            this.Controls.Add(this.txtDauVao3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDauVao2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDauVao1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tool Tu Dong Doi Soat Hang Tra Ve";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDauVao1;
        private System.Windows.Forms.Button btnChon1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDauVao2;
        private System.Windows.Forms.Button btnChon2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDauVao3;
        private System.Windows.Forms.Button btnChon3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Button btnChay;
    }
}

