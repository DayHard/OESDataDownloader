namespace OESDataDownloader
{
    partial class DownloadingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadingForm));
            this.pbDownloading = new System.Windows.Forms.ProgressBar();
            this.lbDownload = new System.Windows.Forms.Label();
            this.btnAbort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pbDownloading
            // 
            resources.ApplyResources(this.pbDownloading, "pbDownloading");
            this.pbDownloading.Name = "pbDownloading";
            this.pbDownloading.Value = 30;
            // 
            // lbDownload
            // 
            resources.ApplyResources(this.lbDownload, "lbDownload");
            this.lbDownload.Name = "lbDownload";
            // 
            // btnAbort
            // 
            resources.ApplyResources(this.btnAbort, "btnAbort");
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // DownloadingForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.lbDownload);
            this.Controls.Add(this.pbDownloading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbDownloading;
        private System.Windows.Forms.Label lbDownload;
        private System.Windows.Forms.Button btnAbort;
    }
}