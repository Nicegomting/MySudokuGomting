using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuTester
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            lbDesc.Text = Properties.Resources.ABOUT_COPYRIGHT;
            lbEMailTitle.Text = Properties.Resources.ABOUT_EMAIL_TITLE;
        }

        private void About_Load(object sender, EventArgs e)
        {
        }

        private void sbClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
