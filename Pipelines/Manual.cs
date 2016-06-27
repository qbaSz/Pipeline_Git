using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pipelines
{
    public partial class Manual : Form
    {

        /// <summary>
        /// variables used for loading manaul from file
        /// </summary>
        FileHelper fh = null;
        List<string> manual = null;

        /// <summary>
        /// form is initialized and manual is loaded in list box
        /// </summary>

        public Manual()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            fh = new FileHelper();
          //  manual = fh.GettingManual();
            this.WindowState = FormWindowState.Normal;
          


        }
        /// <summary>
        /// open manual in pdf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btopenPDF_Click_1(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;//binary position
            path = path + "Manual.pdf";
            System.Diagnostics.Process.Start(path);
        }
        /// <summary>
        /// open manual in pdf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btopenTXT_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;//binary position.
            path = path + "Manual.txt";
            System.Diagnostics.Process.Start(path);
        }
        /// <summary>
        /// open manual in word
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       

        private void btopen_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;//binary position.
            path = path + "Manual.docx";
            System.Diagnostics.Process.Start(path);
        }
    }
}
