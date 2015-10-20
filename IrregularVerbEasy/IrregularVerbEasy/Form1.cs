using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Layout;
using IrregularVerbEasy.Common;

namespace IrregularVerbEasy
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            layoutView1.OptionsView.ViewMode = LayoutViewMode.Carousel;
        }

        /// <summary>
        /// Load form with original data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon.ContextMenuStrip = notifyIconContextMenuStrip;
            gridControl1.DataSource = IrregularVerbHelper.Instance.GetOriginalDataTable();
        }

        /// <summary>
        /// Handle event double click notify icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Handle form closing </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            WindowState = FormWindowState.Minimized;
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon.Visible = true;
                Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon.Visible = false;
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Minimized;
            Hide();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Dispose();
            Dispose();
        }
    }
}
