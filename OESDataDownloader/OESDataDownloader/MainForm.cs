using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace OESDataDownloader
{
    public partial class MainForm : Form
    {
        private readonly Ping _ping;
        private readonly UdpClient _sender;
        private readonly UdpClient _resiver; 
        private IPEndPoint _endPoint;
        private IPEndPoint _remoteIpEndPoint;
        private static string _remoteIp;

        private readonly byte[] _comGetStatus = { 10, 0, 0, 0, 1, 0, 0 };
        private const int TimeOut = 10;
        private const int RemotePort = 3001;
        private const int LocalPort = 3000;
        private const int ConnectionUpdate = 1000;


        public MainForm()
        {
            LoadConfiguration();
            InitializeComponent();
            _ping = new Ping();
            _sender = new UdpClient();
            _resiver = new UdpClient(LocalPort) {Client = {ReceiveTimeout = TimeOut}};
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lbVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            // Установка таймаута приемника проверки статуса соединения
            var thread = new Thread(CheckNetStatus) {IsBackground = true};
            thread.Start();
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
        private static void LoadConfiguration()
        {
            if (File.Exists("setting.xml"))
            {
                XDocument xDoc = XDocument.Load("setting.xml");
                XElement xLang = xDoc.Descendants("Language").First();
                ChooseLanguage(xLang.Value);
                // Установка ClientIP
                XElement xClientIp = xDoc.Descendants("ClientIP").First();
                _remoteIp = xClientIp.Value;               
            }
            else
            {
                ChooseLanguage(CultureInfo.CurrentCulture.Name);
                _remoteIp = "192.168.10.100";
            }
        }
        //Выбор текущего языка
        private static void ChooseLanguage(string lang)
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

        private static void UpdateConfiguration()
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

            XmlNode clientIpEl = doc.CreateElement("ClientIP"); // даём имя
            clientIpEl.InnerText = _remoteIp; // и значение
            element.AppendChild(clientIpEl); // и указываем кому принадлежит

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
            //uart.Show();
        }

        #region NETStatus
        // Работает в отдельном потоке
        // Проверка статуса подключений
        private void CheckNetStatus()
        {
            while (true)
            {
                if (CheckEthernet())
                    if (CheckStm())
                        CheckOed();
                Thread.Sleep(ConnectionUpdate);
            }
            // ReSharper disable once FunctionNeverReturns
        }
        //Проверка наличия локальной сети
        private bool CheckEthernet()
        {          
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                btnIndicEthernet.BackColor = Color.GreenYellow;
                return true;
            }
            btnIndicEthernet.BackColor = Color.OrangeRed;
            btnIndicUSB.BackColor = Color.OrangeRed;
            btnIndicConnection.BackColor = Color.OrangeRed;
            return false;
        }
        //Проверка доступности STM
        private bool CheckStm()
        {
            try
            {
                var pingReply = _ping.Send(_remoteIp, TimeOut);
                if (pingReply != null && pingReply.Status != IPStatus.TimedOut)
                {
                    btnIndicUSB.BackColor = Color.GreenYellow;
                    return true;
                }
                btnIndicUSB.BackColor = Color.OrangeRed;
                btnIndicConnection.BackColor = Color.OrangeRed;
                return false;
            }
            catch
            {
                return false;
            }
        }
        //Проверка доступности ОЭД
        private void CheckOed()
        {
            try
            {
                _endPoint = new IPEndPoint(IPAddress.Parse(_remoteIp), RemotePort);
                _sender.Send(_comGetStatus, _comGetStatus.Length, _endPoint);
                var responce = _resiver.Receive(ref _remoteIpEndPoint);
                //Проверка доступности ОЕД 
                if (responce[0] != 0)
                {
                    btnIndicConnection.BackColor = Color.GreenYellow;
                    return;
                }
                btnIndicConnection.BackColor = Color.OrangeRed;
            }
            catch (SocketException)
            {
                btnIndicConnection.BackColor = Color.OrangeRed;
            }
        }        
        #endregion
    }
}
