namespace CodeLogOut
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnImportFile = new System.Windows.Forms.Button();
            this.btnOutFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnImportFile
            // 
            this.btnImportFile.Location = new System.Drawing.Point(337, 24);
            this.btnImportFile.Name = "btnImportFile";
            this.btnImportFile.Size = new System.Drawing.Size(75, 30);
            this.btnImportFile.TabIndex = 0;
            this.btnImportFile.Text = "打开文件";
            this.btnImportFile.UseVisualStyleBackColor = true;
            this.btnImportFile.Click += new System.EventHandler(this.btnImportFile_Click);
            // 
            // btnOutFile
            // 
            this.btnOutFile.Location = new System.Drawing.Point(337, 70);
            this.btnOutFile.Name = "btnOutFile";
            this.btnOutFile.Size = new System.Drawing.Size(75, 30);
            this.btnOutFile.TabIndex = 0;
            this.btnOutFile.Text = "输出文件";
            this.btnOutFile.UseVisualStyleBackColor = true;
            this.btnOutFile.Click += new System.EventHandler(this.btnOutFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(54, 30);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(277, 21);
            this.txtFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "文件";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 133);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnOutFile);
            this.Controls.Add(this.btnImportFile);
            this.Name = "Form1";
            this.Text = "代码日志输出";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportFile;
        private System.Windows.Forms.Button btnOutFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
    }
}

