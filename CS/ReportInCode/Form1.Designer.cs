namespace ReportInCode {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnReportCreate = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnReportCreate
            // 
            this.btnReportCreate.Location = new System.Drawing.Point(61, 16);
            this.btnReportCreate.Name = "btnReportCreate";
            this.btnReportCreate.Size = new System.Drawing.Size(170, 23);
            this.btnReportCreate.TabIndex = 0;
            this.btnReportCreate.Text = "Create and Edit the Report";
            this.btnReportCreate.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 55);
            this.Controls.Add(this.btnReportCreate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnReportCreate;
    }
}

