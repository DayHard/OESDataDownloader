using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace OESDataDownloader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            UpdateConfiguration();
            //LoadConfiguration();
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            InitializeComponent();
        }
        // Переключение локализации на русский
        private void btnLangRus_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            Controls.Clear();
            InitializeComponent();
        }
        // Переключение локализации на французкий
        private void btnLangFr_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
            Controls.Clear();
            InitializeComponent();
        }
        // Переключение локализации на английский
        private void btnLangEng_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Controls.Clear();
            InitializeComponent();
        }
        // Загрузка файла config для установки текущей культуры
        private void LoadConfiguration()
        {
            if (File.Exists("setting.xml"))
            {
                XDocument xDoc = XDocument.Load("setting.xml");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(CultureInfo.CurrentCulture.Name);
            }
        }

        private void UpdateConfiguration()
        {
            XDocument xDoc = new XDocument();
            XElement xEl = new XElement(this.Text);
            XAttribute xAt = new XAttribute("language", Thread.CurrentThread.CurrentUICulture);
            xEl.Add(xAt);
            xDoc.Save("setting.xml");
        }
    }
}
