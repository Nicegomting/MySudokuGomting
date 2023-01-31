using MySudokuGomting;

namespace SudokuTester
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.퍼즐ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mOpenSudoku = new System.Windows.Forms.ToolStripMenuItem();
            this.mInputPuzzle = new System.Windows.Forms.ToolStripMenuItem();
            this.mClose = new System.Windows.Forms.ToolStripMenuItem();
            this.옵션ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mShowSolution = new System.Windows.Forms.ToolStripMenuItem();
            this.mInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.meMain = new System.Windows.Forms.MenuStrip();
            this.ucSudoku = new MySudokuGomting.CanvasControl();
            this.meMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // 퍼즐ToolStripMenuItem
            // 
            this.퍼즐ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mOpenSudoku,
            this.mInputPuzzle,
            this.mClose});
            this.퍼즐ToolStripMenuItem.Name = "퍼즐ToolStripMenuItem";
            this.퍼즐ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.퍼즐ToolStripMenuItem.Text = "퍼즐";
            // 
            // mOpenSudoku
            // 
            this.mOpenSudoku.Name = "mOpenSudoku";
            this.mOpenSudoku.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mOpenSudoku.Size = new System.Drawing.Size(166, 22);
            this.mOpenSudoku.Text = "열기";
            this.mOpenSudoku.Click += new System.EventHandler(this.mOpenSudoku_Click);
            // 
            // mInputPuzzle
            // 
            this.mInputPuzzle.Name = "mInputPuzzle";
            this.mInputPuzzle.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mInputPuzzle.Size = new System.Drawing.Size(166, 22);
            this.mInputPuzzle.Text = "직접 입력";
            this.mInputPuzzle.Click += new System.EventHandler(this.mInputPuzzle_Click);
            // 
            // mClose
            // 
            this.mClose.Name = "mClose";
            this.mClose.Size = new System.Drawing.Size(166, 22);
            this.mClose.Text = "끝내기";
            this.mClose.Click += new System.EventHandler(this.mClose_Click);
            // 
            // 옵션ToolStripMenuItem
            // 
            this.옵션ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mShowSolution});
            this.옵션ToolStripMenuItem.Name = "옵션ToolStripMenuItem";
            this.옵션ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.옵션ToolStripMenuItem.Text = "옵션";
            // 
            // mShowSolution
            // 
            this.mShowSolution.Name = "mShowSolution";
            this.mShowSolution.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mShowSolution.Size = new System.Drawing.Size(188, 22);
            this.mShowSolution.Text = "해답 보기 On/Off";
            this.mShowSolution.Click += new System.EventHandler(this.mShowSolution_Click);
            // 
            // mInfo
            // 
            this.mInfo.Name = "mInfo";
            this.mInfo.Size = new System.Drawing.Size(43, 20);
            this.mInfo.Text = "정보";
            this.mInfo.Click += new System.EventHandler(this.mInfo_Click);
            // 
            // meMain
            // 
            this.meMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.퍼즐ToolStripMenuItem,
            this.옵션ToolStripMenuItem,
            this.mInfo});
            this.meMain.Location = new System.Drawing.Point(0, 0);
            this.meMain.Name = "meMain";
            this.meMain.Size = new System.Drawing.Size(584, 24);
            this.meMain.TabIndex = 1;
            this.meMain.Text = "menuStrip1";
            // 
            // ucSudoku
            // 
            this.ucSudoku.BackColor = System.Drawing.Color.White;
            this.ucSudoku.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSudoku.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucSudoku.IsShownSolution = false;
            this.ucSudoku.Location = new System.Drawing.Point(0, 24);
            this.ucSudoku.Name = "ucSudoku";
            this.ucSudoku.Size = new System.Drawing.Size(584, 537);
            this.ucSudoku.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.ucSudoku);
            this.Controls.Add(this.meMain);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MainMenuStrip = this.meMain;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Main Screen";
            this.Load += new System.EventHandler(this.Main_Load);
            this.meMain.ResumeLayout(false);
            this.meMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CanvasControl ucSudoku;
        private System.Windows.Forms.ToolStripMenuItem 퍼즐ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mOpenSudoku;
        private System.Windows.Forms.ToolStripMenuItem mInputPuzzle;
        private System.Windows.Forms.ToolStripMenuItem mClose;
        private System.Windows.Forms.ToolStripMenuItem 옵션ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mShowSolution;
        private System.Windows.Forms.ToolStripMenuItem mInfo;
        private System.Windows.Forms.MenuStrip meMain;
    }
}