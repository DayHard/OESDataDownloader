using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OESDataDownloader
{
    public partial class DownloadingForm : Form
    {
        public CancellationTokenSource CancellationToken;
        public DownloadingForm()
        {
            InitializeComponent();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationToken.Cancel();
            }
            catch (AggregateException aex)
            {
                MessageBox.Show(aex.Message);
            }
            finally
            {
                CancellationToken.Dispose();
            }
            Hide();
        }
    }
}
