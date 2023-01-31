namespace MySudokuGomting
{
    partial class SudokuInput
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
            this.tePuzzle = new System.Windows.Forms.TextBox();
            this.lbDesc = new System.Windows.Forms.Label();
            this.teEx = new System.Windows.Forms.TextBox();
            this.lbEx = new System.Windows.Forms.Label();
            this.sbOK = new System.Windows.Forms.Button();
            this.grPreview = new System.Windows.Forms.GroupBox();
            this.dgPreview = new System.Windows.Forms.DataGridView();
            this.grPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // tePuzzle
            // 
            this.tePuzzle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tePuzzle.Location = new System.Drawing.Point(12, 57);
            this.tePuzzle.Multiline = true;
            this.tePuzzle.Name = "tePuzzle";
            this.tePuzzle.Size = new System.Drawing.Size(548, 78);
            this.tePuzzle.TabIndex = 0;
            this.tePuzzle.TextChanged += new System.EventHandler(this.tePuzzle_TextChanged);
            // 
            // lbDesc
            // 
            this.lbDesc.AutoSize = true;
            this.lbDesc.Location = new System.Drawing.Point(12, 9);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(449, 12);
            this.lbDesc.TabIndex = 1;
            this.lbDesc.Text = "* 스도쿠 퍼즐을 좌측에서 우측 방향으로 입력해주세요. 빈 칸은 0으로 입력합니다.";
            // 
            // teEx
            // 
            this.teEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teEx.Location = new System.Drawing.Point(52, 30);
            this.teEx.Name = "teEx";
            this.teEx.ReadOnly = true;
            this.teEx.Size = new System.Drawing.Size(508, 21);
            this.teEx.TabIndex = 2;
            this.teEx.Text = "500370100000096000007004680103709820000000900960230701070080205609400300032000000" +
    "";
            // 
            // lbEx
            // 
            this.lbEx.AutoSize = true;
            this.lbEx.Location = new System.Drawing.Point(12, 33);
            this.lbEx.Name = "lbEx";
            this.lbEx.Size = new System.Drawing.Size(34, 12);
            this.lbEx.TabIndex = 3;
            this.lbEx.Text = "예시)";
            // 
            // sbOK
            // 
            this.sbOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sbOK.Location = new System.Drawing.Point(12, 401);
            this.sbOK.Name = "sbOK";
            this.sbOK.Size = new System.Drawing.Size(548, 23);
            this.sbOK.TabIndex = 4;
            this.sbOK.Text = "입력";
            this.sbOK.UseVisualStyleBackColor = true;
            this.sbOK.Click += new System.EventHandler(this.sbOK_Click);
            // 
            // grPreview
            // 
            this.grPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grPreview.Controls.Add(this.dgPreview);
            this.grPreview.Location = new System.Drawing.Point(14, 152);
            this.grPreview.Name = "grPreview";
            this.grPreview.Size = new System.Drawing.Size(544, 243);
            this.grPreview.TabIndex = 6;
            this.grPreview.TabStop = false;
            this.grPreview.Text = "미리보기";
            // 
            // dgPreview
            // 
            this.dgPreview.AllowUserToAddRows = false;
            this.dgPreview.AllowUserToDeleteRows = false;
            this.dgPreview.AllowUserToResizeColumns = false;
            this.dgPreview.AllowUserToResizeRows = false;
            this.dgPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPreview.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgPreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgPreview.ColumnHeadersVisible = false;
            this.dgPreview.Location = new System.Drawing.Point(160, 17);
            this.dgPreview.MultiSelect = false;
            this.dgPreview.Name = "dgPreview";
            this.dgPreview.ReadOnly = true;
            this.dgPreview.RowHeadersVisible = false;
            this.dgPreview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgPreview.RowTemplate.Height = 23;
            this.dgPreview.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgPreview.Size = new System.Drawing.Size(220, 210);
            this.dgPreview.TabIndex = 6;
            this.dgPreview.Resize += new System.EventHandler(this.dgPreview_Resize);
            // 
            // SudokuInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(570, 430);
            this.Controls.Add(this.grPreview);
            this.Controls.Add(this.sbOK);
            this.Controls.Add(this.lbEx);
            this.Controls.Add(this.teEx);
            this.Controls.Add(this.lbDesc);
            this.Controls.Add(this.tePuzzle);
            this.Name = "SudokuInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "퍼즐 입력";
            this.Load += new System.EventHandler(this.SudokuInput_Load);
            this.grPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tePuzzle;
        private System.Windows.Forms.Label lbDesc;
        private System.Windows.Forms.TextBox teEx;
        private System.Windows.Forms.Label lbEx;
        private System.Windows.Forms.Button sbOK;
        private System.Windows.Forms.GroupBox grPreview;
        private System.Windows.Forms.DataGridView dgPreview;
    }
}