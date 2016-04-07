using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AE_Dev_J.Form
{
    public partial class ClassificationForm : DevExpress.XtraEditors.XtraForm
    {
        public ClassificationForm()
        {
            InitializeComponent();
        }

        #region Select Method Page
        
        /// <summary>
        /// choose supervised method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void supervise_checkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (supervise_checkEdit.Checked == true)
            {
                this.superviseMethod_radioGroup.Enabled = true;
                this.unsupervise_checkEdit.Checked = false;
            }
            else { this.superviseMethod_radioGroup.Enabled = false;}
        }

        /// <summary>
        /// choose unsupervised method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void unsupervise_checkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (unsupervise_checkEdit.Checked == true)
            {
                this.unsuperviseMethod_radioGroup.Enabled = true;
                this.supervise_checkEdit.Checked = false;
            }
            else{ this.unsuperviseMethod_radioGroup.Enabled = false; }
        }

        #endregion Select Method Page

        /// <summary>
        /// 用于控制面板的翻页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPageControl_windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}