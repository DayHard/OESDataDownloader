namespace OESDataDownloader
{
    partial class UARTForm
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
            this.labPortName = new System.Windows.Forms.Label();
            this.labRate = new System.Windows.Forms.Label();
            this.labParity = new System.Windows.Forms.Label();
            this.labStopBits = new System.Windows.Forms.Label();
            this.labDataBits = new System.Windows.Forms.Label();
            this.cbPortName = new System.Windows.Forms.ComboBox();
            this.cbRate = new System.Windows.Forms.ComboBox();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.cbDataBits = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnTestCommand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labPortName
            // 
            this.labPortName.AutoSize = true;
            this.labPortName.Location = new System.Drawing.Point(12, 9);
            this.labPortName.Name = "labPortName";
            this.labPortName.Size = new System.Drawing.Size(29, 13);
            this.labPortName.TabIndex = 1;
            this.labPortName.Text = "Port:";
            // 
            // labRate
            // 
            this.labRate.AutoSize = true;
            this.labRate.Location = new System.Drawing.Point(12, 38);
            this.labRate.Name = "labRate";
            this.labRate.Size = new System.Drawing.Size(33, 13);
            this.labRate.TabIndex = 6;
            this.labRate.Text = "Rate:";
            // 
            // labParity
            // 
            this.labParity.AutoSize = true;
            this.labParity.Location = new System.Drawing.Point(12, 65);
            this.labParity.Name = "labParity";
            this.labParity.Size = new System.Drawing.Size(36, 13);
            this.labParity.TabIndex = 7;
            this.labParity.Text = "Parity:";
            // 
            // labStopBits
            // 
            this.labStopBits.AutoSize = true;
            this.labStopBits.Location = new System.Drawing.Point(12, 92);
            this.labStopBits.Name = "labStopBits";
            this.labStopBits.Size = new System.Drawing.Size(51, 13);
            this.labStopBits.TabIndex = 8;
            this.labStopBits.Text = "Stop bits:";
            // 
            // labDataBits
            // 
            this.labDataBits.AutoSize = true;
            this.labDataBits.Location = new System.Drawing.Point(11, 119);
            this.labDataBits.Name = "labDataBits";
            this.labDataBits.Size = new System.Drawing.Size(52, 13);
            this.labDataBits.TabIndex = 9;
            this.labDataBits.Text = "Data bits:";
            // 
            // cbPortName
            // 
            this.cbPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPortName.FormattingEnabled = true;
            this.cbPortName.Location = new System.Drawing.Point(69, 6);
            this.cbPortName.Name = "cbPortName";
            this.cbPortName.Size = new System.Drawing.Size(79, 21);
            this.cbPortName.TabIndex = 10;
            // 
            // cbRate
            // 
            this.cbRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRate.FormattingEnabled = true;
            this.cbRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.cbRate.Location = new System.Drawing.Point(69, 35);
            this.cbRate.Name = "cbRate";
            this.cbRate.Size = new System.Drawing.Size(79, 21);
            this.cbRate.TabIndex = 11;
            // 
            // cbParity
            // 
            this.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(69, 62);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(79, 21);
            this.cbParity.TabIndex = 12;
            // 
            // cbStopBits
            // 
            this.cbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cbStopBits.Location = new System.Drawing.Point(69, 89);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(79, 21);
            this.cbStopBits.TabIndex = 13;
            // 
            // cbDataBits
            // 
            this.cbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cbDataBits.Location = new System.Drawing.Point(69, 116);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(79, 21);
            this.cbDataBits.TabIndex = 14;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(33, 152);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(145, 32);
            this.btnConnect.TabIndex = 16;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnTestCommand
            // 
            this.btnTestCommand.Location = new System.Drawing.Point(194, 6);
            this.btnTestCommand.Name = "btnTestCommand";
            this.btnTestCommand.Size = new System.Drawing.Size(75, 23);
            this.btnTestCommand.TabIndex = 17;
            this.btnTestCommand.Text = "5";
            this.btnTestCommand.UseVisualStyleBackColor = true;
            this.btnTestCommand.Click += new System.EventHandler(this.btnTestCommand_Click);
            // 
            // UARTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 196);
            this.Controls.Add(this.btnTestCommand);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cbDataBits);
            this.Controls.Add(this.cbStopBits);
            this.Controls.Add(this.cbParity);
            this.Controls.Add(this.cbRate);
            this.Controls.Add(this.cbPortName);
            this.Controls.Add(this.labDataBits);
            this.Controls.Add(this.labStopBits);
            this.Controls.Add(this.labParity);
            this.Controls.Add(this.labRate);
            this.Controls.Add(this.labPortName);
            this.Name = "UARTForm";
            this.Text = "UART";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UARTForm_FormClosing);
            this.Load += new System.EventHandler(this.UART_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labPortName;
        private System.Windows.Forms.Label labRate;
        private System.Windows.Forms.Label labParity;
        private System.Windows.Forms.Label labStopBits;
        private System.Windows.Forms.Label labDataBits;
        private System.Windows.Forms.ComboBox cbPortName;
        private System.Windows.Forms.ComboBox cbRate;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.ComboBox cbDataBits;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnTestCommand;
    }
}