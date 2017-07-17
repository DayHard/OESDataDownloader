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
            this.btnLangRus = new System.Windows.Forms.Button();
            this.btnLangFr = new System.Windows.Forms.Button();
            this.btnLangEng = new System.Windows.Forms.Button();
            this.btnProp = new System.Windows.Forms.Button();
            this.gbLaunchInfo = new System.Windows.Forms.GroupBox();
            this.gbOperationsPerformed = new System.Windows.Forms.GroupBox();
            this.gbSavedFiles = new System.Windows.Forms.GroupBox();
            this.tbSavedFiles = new System.Windows.Forms.TextBox();
            this.tbLauchInfo = new System.Windows.Forms.TextBox();
            this.tbOperationsPerformed = new System.Windows.Forms.TextBox();
            this.gbLaunchInfo.SuspendLayout();
            this.gbOperationsPerformed.SuspendLayout();
            this.gbSavedFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIndicEthernet
            // 
            this.btnIndicEthernet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnIndicEthernet.Enabled = false;
            this.btnIndicEthernet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIndicEthernet.Location = new System.Drawing.Point(12, 12);
            this.btnIndicEthernet.Name = "btnIndicEthernet";
            this.btnIndicEthernet.Size = new System.Drawing.Size(300, 23);
            this.btnIndicEthernet.TabIndex = 0;
            this.btnIndicEthernet.Text = "Наличие соединения по Ethernet";
            this.btnIndicEthernet.UseVisualStyleBackColor = false;
            // 
            // btnIndicUSB
            // 
            this.btnIndicUSB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnIndicUSB.Enabled = false;
            this.btnIndicUSB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIndicUSB.Location = new System.Drawing.Point(307, 12);
            this.btnIndicUSB.Name = "btnIndicUSB";
            this.btnIndicUSB.Size = new System.Drawing.Size(300, 23);
            this.btnIndicUSB.TabIndex = 1;
            this.btnIndicUSB.Text = "Наличие соединения по USB";
            this.btnIndicUSB.UseVisualStyleBackColor = false;
            // 
            // btnIndicConnection
            // 
            this.btnIndicConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnIndicConnection.Enabled = false;
            this.btnIndicConnection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIndicConnection.Location = new System.Drawing.Point(603, 12);
            this.btnIndicConnection.Name = "btnIndicConnection";
            this.btnIndicConnection.Size = new System.Drawing.Size(300, 23);
            this.btnIndicConnection.TabIndex = 2;
            this.btnIndicConnection.Text = "Наличие связи с ОЭД";
            this.btnIndicConnection.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(251, 615);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(357, 615);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteAll.TabIndex = 10;
            this.btnDeleteAll.Text = "Удалить всё";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            // 
            // btnFormat
            // 
            this.btnFormat.Location = new System.Drawing.Point(463, 615);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(100, 30);
            this.btnFormat.TabIndex = 11;
            this.btnFormat.Text = "Форматировать";
            this.btnFormat.UseVisualStyleBackColor = true;
            // 
            // btnLangRus
            // 
            this.btnLangRus.BackgroundImage = global::OESDataDownloader.Properties.Resources.download;
            this.btnLangRus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLangRus.Location = new System.Drawing.Point(732, 615);
            this.btnLangRus.Name = "btnLangRus";
            this.btnLangRus.Size = new System.Drawing.Size(35, 30);
            this.btnLangRus.TabIndex = 8;
            this.btnLangRus.UseVisualStyleBackColor = true;
            // 
            // btnLangFr
            // 
            this.btnLangFr.BackgroundImage = global::OESDataDownloader.Properties.Resources.Flag_of_France_svg;
            this.btnLangFr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLangFr.Location = new System.Drawing.Point(773, 615);
            this.btnLangFr.Name = "btnLangFr";
            this.btnLangFr.Size = new System.Drawing.Size(35, 30);
            this.btnLangFr.TabIndex = 7;
            this.btnLangFr.UseVisualStyleBackColor = true;
            // 
            // btnLangEng
            // 
            this.btnLangEng.BackgroundImage = global::OESDataDownloader.Properties.Resources._5035f86647d206_31869991;
            this.btnLangEng.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLangEng.Location = new System.Drawing.Point(814, 615);
            this.btnLangEng.Name = "btnLangEng";
            this.btnLangEng.Size = new System.Drawing.Size(35, 30);
            this.btnLangEng.TabIndex = 6;
            this.btnLangEng.UseVisualStyleBackColor = true;
            // 
            // btnProp
            // 
            this.btnProp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProp.BackgroundImage")));
            this.btnProp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProp.Location = new System.Drawing.Point(868, 615);
            this.btnProp.Name = "btnProp";
            this.btnProp.Size = new System.Drawing.Size(35, 30);
            this.btnProp.TabIndex = 5;
            this.btnProp.UseVisualStyleBackColor = true;
            // 
            // gbLaunchInfo
            // 
            this.gbLaunchInfo.Controls.Add(this.tbLauchInfo);
            this.gbLaunchInfo.Location = new System.Drawing.Point(468, 41);
            this.gbLaunchInfo.Name = "gbLaunchInfo";
            this.gbLaunchInfo.Size = new System.Drawing.Size(440, 405);
            this.gbLaunchInfo.TabIndex = 12;
            this.gbLaunchInfo.TabStop = false;
            this.gbLaunchInfo.Text = "Информация о пусках";
            // 
            // gbOperationsPerformed
            // 
            this.gbOperationsPerformed.Controls.Add(this.tbOperationsPerformed);
            this.gbOperationsPerformed.Location = new System.Drawing.Point(12, 452);
            this.gbOperationsPerformed.Name = "gbOperationsPerformed";
            this.gbOperationsPerformed.Size = new System.Drawing.Size(896, 144);
            this.gbOperationsPerformed.TabIndex = 13;
            this.gbOperationsPerformed.TabStop = false;
            this.gbOperationsPerformed.Text = "Выполняемые операции";
            // 
            // gbSavedFiles
            // 
            this.gbSavedFiles.Controls.Add(this.tbSavedFiles);
            this.gbSavedFiles.Location = new System.Drawing.Point(12, 41);
            this.gbSavedFiles.Name = "gbSavedFiles";
            this.gbSavedFiles.Size = new System.Drawing.Size(440, 405);
            this.gbSavedFiles.TabIndex = 0;
            this.gbSavedFiles.TabStop = false;
            this.gbSavedFiles.Text = "Сохраненные файлы";
            // 
            // tbSavedFiles
            // 
            this.tbSavedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSavedFiles.Enabled = false;
            this.tbSavedFiles.Location = new System.Drawing.Point(3, 16);
            this.tbSavedFiles.Multiline = true;
            this.tbSavedFiles.Name = "tbSavedFiles";
            this.tbSavedFiles.Size = new System.Drawing.Size(434, 386);
            this.tbSavedFiles.TabIndex = 0;
            // 
            // tbLauchInfo
            // 
            this.tbLauchInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLauchInfo.Enabled = false;
            this.tbLauchInfo.Location = new System.Drawing.Point(3, 16);
            this.tbLauchInfo.Multiline = true;
            this.tbLauchInfo.Name = "tbLauchInfo";
            this.tbLauchInfo.Size = new System.Drawing.Size(434, 386);
            this.tbLauchInfo.TabIndex = 1;
            // 
            // tbOperationsPerformed
            // 
            this.tbOperationsPerformed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOperationsPerformed.Enabled = false;
            this.tbOperationsPerformed.Location = new System.Drawing.Point(3, 16);
            this.tbOperationsPerformed.Multiline = true;
            this.tbOperationsPerformed.Name = "tbOperationsPerformed";
            this.tbOperationsPerformed.Size = new System.Drawing.Size(890, 125);
            this.tbOperationsPerformed.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 657);
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
            this.Text = "OESDataDownloader";
            this.gbLaunchInfo.ResumeLayout(false);
            this.gbLaunchInfo.PerformLayout();
            this.gbOperationsPerformed.ResumeLayout(false);
            this.gbOperationsPerformed.PerformLayout();
            this.gbSavedFiles.ResumeLayout(false);
            this.gbSavedFiles.PerformLayout();
            this.ResumeLayout(false);

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
    }
}

