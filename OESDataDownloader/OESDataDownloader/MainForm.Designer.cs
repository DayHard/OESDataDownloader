namespace OESDataDownloader
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnIndicEthernet = new System.Windows.Forms.Button();
            this.btnIndicUSB = new System.Windows.Forms.Button();
            this.btnIndicConnection = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnFormat = new System.Windows.Forms.Button();
            this.gbLaunchInfo = new System.Windows.Forms.GroupBox();
            this.tbLauchInfo = new System.Windows.Forms.TextBox();
            this.gbOperationsPerformed = new System.Windows.Forms.GroupBox();
            this.tbOperationsPerformed = new System.Windows.Forms.TextBox();
            this.gbSavedFiles = new System.Windows.Forms.GroupBox();
            this.tbSavedFiles = new System.Windows.Forms.TextBox();
            this.lbSavedFilePath = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.btnLangRus = new System.Windows.Forms.Button();
            this.btnLangFr = new System.Windows.Forms.Button();
            this.btnLangEng = new System.Windows.Forms.Button();
            this.btnProp = new System.Windows.Forms.Button();
            this.btnUART = new System.Windows.Forms.Button();
            this.gbLaunchInfo.SuspendLayout();
            this.gbOperationsPerformed.SuspendLayout();
            this.gbSavedFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIndicEthernet
            // 
            this.btnIndicEthernet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.btnIndicEthernet, "btnIndicEthernet");
            this.btnIndicEthernet.Name = "btnIndicEthernet";
            this.btnIndicEthernet.UseVisualStyleBackColor = false;
            // 
            // btnIndicUSB
            // 
            this.btnIndicUSB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.btnIndicUSB, "btnIndicUSB");
            this.btnIndicUSB.Name = "btnIndicUSB";
            this.btnIndicUSB.UseVisualStyleBackColor = false;
            // 
            // btnIndicConnection
            // 
            this.btnIndicConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.btnIndicConnection, "btnIndicConnection");
            this.btnIndicConnection.Name = "btnIndicConnection";
            this.btnIndicConnection.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAll
            // 
            resources.ApplyResources(this.btnDeleteAll, "btnDeleteAll");
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            // 
            // btnFormat
            // 
            resources.ApplyResources(this.btnFormat, "btnFormat");
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.UseVisualStyleBackColor = true;
            // 
            // gbLaunchInfo
            // 
            this.gbLaunchInfo.Controls.Add(this.tbLauchInfo);
            resources.ApplyResources(this.gbLaunchInfo, "gbLaunchInfo");
            this.gbLaunchInfo.Name = "gbLaunchInfo";
            this.gbLaunchInfo.TabStop = false;
            // 
            // tbLauchInfo
            // 
            resources.ApplyResources(this.tbLauchInfo, "tbLauchInfo");
            this.tbLauchInfo.Name = "tbLauchInfo";
            // 
            // gbOperationsPerformed
            // 
            this.gbOperationsPerformed.Controls.Add(this.tbOperationsPerformed);
            resources.ApplyResources(this.gbOperationsPerformed, "gbOperationsPerformed");
            this.gbOperationsPerformed.Name = "gbOperationsPerformed";
            this.gbOperationsPerformed.TabStop = false;
            // 
            // tbOperationsPerformed
            // 
            resources.ApplyResources(this.tbOperationsPerformed, "tbOperationsPerformed");
            this.tbOperationsPerformed.Name = "tbOperationsPerformed";
            // 
            // gbSavedFiles
            // 
            this.gbSavedFiles.Controls.Add(this.tbSavedFiles);
            resources.ApplyResources(this.gbSavedFiles, "gbSavedFiles");
            this.gbSavedFiles.Name = "gbSavedFiles";
            this.gbSavedFiles.TabStop = false;
            // 
            // tbSavedFiles
            // 
            resources.ApplyResources(this.tbSavedFiles, "tbSavedFiles");
            this.tbSavedFiles.Name = "tbSavedFiles";
            // 
            // lbSavedFilePath
            // 
            resources.ApplyResources(this.lbSavedFilePath, "lbSavedFilePath");
            this.lbSavedFilePath.Name = "lbSavedFilePath";
            // 
            // lbVersion
            // 
            resources.ApplyResources(this.lbVersion, "lbVersion");
            this.lbVersion.Name = "lbVersion";
            // 
            // btnLangRus
            // 
            this.btnLangRus.BackgroundImage = global::OESDataDownloader.Properties.Resources.download;
            resources.ApplyResources(this.btnLangRus, "btnLangRus");
            this.btnLangRus.Name = "btnLangRus";
            this.btnLangRus.UseVisualStyleBackColor = true;
            this.btnLangRus.Click += new System.EventHandler(this.btnLangRus_Click);
            // 
            // btnLangFr
            // 
            this.btnLangFr.BackgroundImage = global::OESDataDownloader.Properties.Resources.Flag_of_France_svg;
            resources.ApplyResources(this.btnLangFr, "btnLangFr");
            this.btnLangFr.Name = "btnLangFr";
            this.btnLangFr.UseVisualStyleBackColor = true;
            this.btnLangFr.Click += new System.EventHandler(this.btnLangFr_Click);
            // 
            // btnLangEng
            // 
            this.btnLangEng.BackgroundImage = global::OESDataDownloader.Properties.Resources._5035f86647d206_31869991;
            resources.ApplyResources(this.btnLangEng, "btnLangEng");
            this.btnLangEng.Name = "btnLangEng";
            this.btnLangEng.UseVisualStyleBackColor = true;
            this.btnLangEng.Click += new System.EventHandler(this.btnLangEng_Click);
            // 
            // btnProp
            // 
            resources.ApplyResources(this.btnProp, "btnProp");
            this.btnProp.Name = "btnProp";
            this.btnProp.UseVisualStyleBackColor = true;
            this.btnProp.Click += new System.EventHandler(this.btnProp_Click);
            // 
            // btnUART
            // 
            resources.ApplyResources(this.btnUART, "btnUART");
            this.btnUART.Name = "btnUART";
            this.btnUART.UseVisualStyleBackColor = true;
            this.btnUART.Click += new System.EventHandler(this.btnUART_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUART);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.lbSavedFilePath);
            this.Controls.Add(this.gbSavedFiles);
            this.Controls.Add(this.gbOperationsPerformed);
            this.Controls.Add(this.gbLaunchInfo);
            this.Controls.Add(this.btnFormat);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLangRus);
            this.Controls.Add(this.btnLangFr);
            this.Controls.Add(this.btnLangEng);
            this.Controls.Add(this.btnProp);
            this.Controls.Add(this.btnIndicConnection);
            this.Controls.Add(this.btnIndicUSB);
            this.Controls.Add(this.btnIndicEthernet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbLaunchInfo.ResumeLayout(false);
            this.gbLaunchInfo.PerformLayout();
            this.gbOperationsPerformed.ResumeLayout(false);
            this.gbOperationsPerformed.PerformLayout();
            this.gbSavedFiles.ResumeLayout(false);
            this.gbSavedFiles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIndicEthernet;
        private System.Windows.Forms.Button btnIndicUSB;
        private System.Windows.Forms.Button btnIndicConnection;
        private System.Windows.Forms.Button btnProp;
        private System.Windows.Forms.Button btnLangEng;
        private System.Windows.Forms.Button btnLangFr;
        private System.Windows.Forms.Button btnLangRus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.GroupBox gbLaunchInfo;
        private System.Windows.Forms.GroupBox gbOperationsPerformed;
        private System.Windows.Forms.GroupBox gbSavedFiles;
        private System.Windows.Forms.TextBox tbLauchInfo;
        private System.Windows.Forms.TextBox tbOperationsPerformed;
        private System.Windows.Forms.TextBox tbSavedFiles;
        private System.Windows.Forms.Label lbSavedFilePath;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Button btnUART;
    }
}

