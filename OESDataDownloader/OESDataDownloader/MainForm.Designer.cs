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
            this.btnIndicOed = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnFormat = new System.Windows.Forms.Button();
            this.gbLaunchInfo = new System.Windows.Forms.GroupBox();
            this.listBLaunchInfo = new System.Windows.Forms.ListBox();
            this.gbOperationsPerformed = new System.Windows.Forms.GroupBox();
            this.listBOpreationsPerfomed = new System.Windows.Forms.ListBox();
            this.gbSavedFiles = new System.Windows.Forms.GroupBox();
            this.listBSavedInfo = new System.Windows.Forms.ListBox();
            this.lbSavedFilePath = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.btnLangRus = new System.Windows.Forms.Button();
            this.btnLangFr = new System.Windows.Forms.Button();
            this.btnLangEng = new System.Windows.Forms.Button();
            this.btnProp = new System.Windows.Forms.Button();
            this.gbLaunchInfo.SuspendLayout();
            this.gbOperationsPerformed.SuspendLayout();
            this.gbSavedFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIndicEthernet
            // 
            this.btnIndicEthernet.BackColor = System.Drawing.Color.OrangeRed;
            resources.ApplyResources(this.btnIndicEthernet, "btnIndicEthernet");
            this.btnIndicEthernet.Name = "btnIndicEthernet";
            this.btnIndicEthernet.UseVisualStyleBackColor = false;
            // 
            // btnIndicUSB
            // 
            this.btnIndicUSB.BackColor = System.Drawing.Color.OrangeRed;
            resources.ApplyResources(this.btnIndicUSB, "btnIndicUSB");
            this.btnIndicUSB.Name = "btnIndicUSB";
            this.btnIndicUSB.UseVisualStyleBackColor = false;
            // 
            // btnIndicOed
            // 
            this.btnIndicOed.BackColor = System.Drawing.Color.OrangeRed;
            resources.ApplyResources(this.btnIndicOed, "btnIndicOed");
            this.btnIndicOed.Name = "btnIndicOed";
            this.btnIndicOed.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.gbLaunchInfo.Controls.Add(this.listBLaunchInfo);
            resources.ApplyResources(this.gbLaunchInfo, "gbLaunchInfo");
            this.gbLaunchInfo.Name = "gbLaunchInfo";
            this.gbLaunchInfo.TabStop = false;
            // 
            // listBLaunchInfo
            // 
            resources.ApplyResources(this.listBLaunchInfo, "listBLaunchInfo");
            this.listBLaunchInfo.FormattingEnabled = true;
            this.listBLaunchInfo.Name = "listBLaunchInfo";
            // 
            // gbOperationsPerformed
            // 
            this.gbOperationsPerformed.Controls.Add(this.listBOpreationsPerfomed);
            resources.ApplyResources(this.gbOperationsPerformed, "gbOperationsPerformed");
            this.gbOperationsPerformed.Name = "gbOperationsPerformed";
            this.gbOperationsPerformed.TabStop = false;
            // 
            // listBOpreationsPerfomed
            // 
            resources.ApplyResources(this.listBOpreationsPerfomed, "listBOpreationsPerfomed");
            this.listBOpreationsPerfomed.FormattingEnabled = true;
            this.listBOpreationsPerfomed.Name = "listBOpreationsPerfomed";
            // 
            // gbSavedFiles
            // 
            this.gbSavedFiles.Controls.Add(this.listBSavedInfo);
            resources.ApplyResources(this.gbSavedFiles, "gbSavedFiles");
            this.gbSavedFiles.Name = "gbSavedFiles";
            this.gbSavedFiles.TabStop = false;
            // 
            // listBSavedInfo
            // 
            resources.ApplyResources(this.listBSavedInfo, "listBSavedInfo");
            this.listBSavedInfo.FormattingEnabled = true;
            this.listBSavedInfo.Name = "listBSavedInfo";
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
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Controls.Add(this.btnIndicOed);
            this.Controls.Add(this.btnIndicUSB);
            this.Controls.Add(this.btnIndicEthernet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbLaunchInfo.ResumeLayout(false);
            this.gbOperationsPerformed.ResumeLayout(false);
            this.gbSavedFiles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIndicEthernet;
        private System.Windows.Forms.Button btnIndicUSB;
        private System.Windows.Forms.Button btnIndicOed;
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
        private System.Windows.Forms.Label lbSavedFilePath;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.ListBox listBOpreationsPerfomed;
        private System.Windows.Forms.ListBox listBLaunchInfo;
        private System.Windows.Forms.ListBox listBSavedInfo;
    }
}

