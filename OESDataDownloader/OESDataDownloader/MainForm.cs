using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Net.NetworkInformation;

namespace OESDataDownloader
{
    public partial class MainForm : Form
    {
        private static UARTForm uart = new UARTForm();
        private bool OEDIsAvalible;
        public MainForm()
        {
            LoadConfiguration();
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lbVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateConfiguration();
        }
        #region LanguageConfiguration
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
        // Загрузка файла setting для установки текущей культуры
        private void LoadConfiguration()
        {
            if (File.Exists("setting.xml"))
            {
                XDocument xDoc = XDocument.Load("setting.xml");
                XElement xLang = xDoc.Descendants("Language").First();
                ChooseLanguage(xLang.Value);
            }
            else
            {
                ChooseLanguage(CultureInfo.CurrentCulture.Name);
            }
        }
        //Выбор текущего языка
        private void ChooseLanguage(string lang)
        {
            switch (lang)
            {
                case "ru-RU":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
                    break;
                case "ru-BY":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
                    break;
                case "en-US":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    break;
                case "fr-FR":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
                    break;
                default:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-BY");
                    break;
            }
        }

        private void UpdateConfiguration()
        {
            XmlTextWriter writer = new XmlTextWriter("setting.xml", Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("xml");
            writer.WriteEndElement();
            writer.Close();

            XmlDocument doc = new XmlDocument();
            doc.Load("setting.xml");
            XmlNode element = doc.CreateElement("OESDataDownloader");
            doc.DocumentElement?.AppendChild(element);

            XmlNode languageEl = doc.CreateElement("Language"); // даём имя
            languageEl.InnerText = Thread.CurrentThread.CurrentUICulture.ToString(); // и значение
            element.AppendChild(languageEl); // и указываем кому принадлежит

            doc.Save("setting.xml");
        }
        #endregion
        private void btnProp_Click(object sender, EventArgs e)
        {
            DownloadingForm f = new DownloadingForm();
            f.Show();
        }

        private void btnUART_Click(object sender, EventArgs e)
        {
            uart.Show();
        }

        private void timer_Update_LAN_Tick(object sender, EventArgs e)
        {
            //Проверка наличия локальной сети
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                btnIndicEthernet.BackColor = Color.GreenYellow;
                //Проверка наличия USB соединения
                if (false)
                {
                    btnIndicUSB.BackColor = Color.GreenYellow;
                    //Проверка доступности ОЕД 
                    if (true)
                    {
                        btnIndicConnection.BackColor = Color.GreenYellow;
                        OEDIsAvalible = true;
                    }
                    else
                    {
                        OEDIsAvalible = false;
                        btnIndicConnection.BackColor = Color.OrangeRed;
                    }
                }
                else
                {
                    OEDIsAvalible = false;
                    btnIndicUSB.BackColor = Color.OrangeRed;
                    btnIndicConnection.BackColor = Color.OrangeRed;
                }
            }
            else
            {
                OEDIsAvalible = false;
                btnIndicEthernet.BackColor = Color.OrangeRed;
                btnIndicUSB.BackColor = Color.OrangeRed;
                btnIndicConnection.BackColor = Color.OrangeRed;
            }

        }
    }
}
