using System;
using System.Windows.Forms;

namespace OESDataDownloader
{
    public partial class DownloadingForm : Form
    {
        public DownloadingForm()
        {
            InitializeComponent();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
