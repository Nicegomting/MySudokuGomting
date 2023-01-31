namespace SudokuTester
{
    partial class About
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
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lbDesc = new System.Windows.Forms.Label();
            this.lbEMailTitle = new System.Windows.Forms.Label();
            this.lbEMail = new System.Windows.Forms.Label();
            this.sbClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.BackgroundImage = Properties.Resources.sudokuIconLarge;
            this.picIcon.Location = new System.Drawing.Point(26, 22);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(50, 50);
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // lbDesc
            // 
            this.lbDesc.Location = new System.Drawing.Point(93, 22);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(276, 29);
            this.lbDesc.TabIndex = 1;
            this.lbDesc.Text = "이 프로그램은 개인 사용자 및 비 상업적 용도로 자유로운 배포가 가능합니다.";
            // 
            // lbEMailTitle
            // 
            this.lbEMailTitle.AutoSize = true;
            this.lbEMailTitle.Location = new System.Drawing.Point(93, 72);
            this.lbEMailTitle.Name = "lbEMailTitle";
            this.lbEMailTitle.Size = new System.Drawing.Size(88, 12);
            this.lbEMailTitle.TabIndex = 2;
            this.lbEMailTitle.Text = "제작자 E-MAIL";
            // 
            // lbEMail
            // 
            this.lbEMail.AutoSize = true;
            this.lbEMail.Location = new System.Drawing.Point(93, 93);
            this.lbEMail.Name = "lbEMail";
            this.lbEMail.Size = new System.Drawing.Size(136, 12);
            this.lbEMail.TabIndex = 3;
            this.lbEMail.Text = "ggoo.kang@gmail.com";
            // 
            // sbClose
            // 
            this.sbClose.Location = new System.Drawing.Point(153, 126);
            this.sbClose.Name = "sbClose";
            this.sbClose.Size = new System.Drawing.Size(85, 23);
            this.sbClose.TabIndex = 4;
            this.sbClose.Text = "닫기";
            this.sbClose.UseVisualStyleBackColor = true;
            this.sbClose.Click += new System.EventHandler(this.sbClose_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.sbClose);
            this.Controls.Add(this.lbEMail);
            this.Controls.Add(this.lbEMailTitle);
            this.Controls.Add(this.lbDesc);
            this.Controls.Add(this.picIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Sudoku Gomting...";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lbDesc;
        private System.Windows.Forms.Label lbEMailTitle;
        private System.Windows.Forms.Label lbEMail;
        private System.Windows.Forms.Button sbClose;
    }
}