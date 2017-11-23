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
        private DownloadingForm dForm = new DownloadingForm();
        private readonly Ping _ping;
        private readonly UdpClient _sender;
        private readonly UdpClient _resiver; 
        private readonly IPEndPoint _endPoint;
        private IPEndPoint _remoteIpEndPoint;
        private static string _remoteIp;
        private bool _oedIsAvaliable;
   

        //private readonly byte[] _comGetStatus = { 10, 0, 0, 0, 1, 0, 0 };
        //private const int RemotePort = 3001;
        private readonly byte[] _comGetStatus = { 10, 0, 0, 0, 1, 0, 0, 1 };
        private const int RemotePort = 3000;
        private const int TimeOut = 10;
        private const int LocalPort = 3000;
        private const int ConnectionRetry = 1000;

        private readonly int[] _launchSize = new int[15];

        public MainForm()
        {
            LoadConfiguration();
            InitializeComponent();
            _endPoint = new IPEndPoint(IPAddress.Parse(_remoteIp), RemotePort);
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
                _remoteIp = "192.168.0.100";
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

        #region NETStatus
        // Работает в отдельном потоке
        // Проверка статуса подключений
        private void CheckNetStatus()
        {
            for (;;)
            {
                if (CheckEthernet())
                {
                    btnIndicEthernet.BackColor = Color.GreenYellow;
                    if (CheckUsb())
                    {
                        btnIndicUSB.BackColor = Color.GreenYellow;
                        if (CheckOed())
                        {
                            btnIndicOed.BackColor = Color.GreenYellow;

                            AddToOperationsPerfomed("Соединение с STM установлено.");
                            AddToOperationsPerfomed("Соединение по USB установлено.");
                            AddToOperationsPerfomed("Пуски считаны.");
                            _oedIsAvaliable = true;
                            break;
                        }
                        btnIndicOed.BackColor = Color.OrangeRed;
                    }
                    else
                    {
                        btnIndicUSB.BackColor = Color.OrangeRed;
                        btnIndicOed.BackColor = Color.OrangeRed;
                    }  
                }
                else
                {
                    btnIndicEthernet.BackColor = Color.OrangeRed;
                    btnIndicUSB.BackColor = Color.OrangeRed;
                    btnIndicOed.BackColor = Color.OrangeRed;
                }

                Thread.Sleep(ConnectionRetry);
            }
        }
        //Проверка наличия локальной сети
        private bool CheckEthernet()
        {
            if (!NetworkInterface.GetIsNetworkAvailable()) return false;
            try
            {
                var pingReply = _ping.Send(_remoteIp, TimeOut);
                if (pingReply != null && pingReply.Status == IPStatus.Success)
                    return true;
            }
            catch (Exception ex)
            {
                AddToOperationsPerfomed("Ошибка пинга STM: " + ex.Message);
            }
            return false;
        }
        //Проверка доступности STM
        private bool CheckUsb()
        {
            try
            {
                _sender.Send(_comGetStatus, _comGetStatus.Length, _endPoint);
                var resp = _resiver.Receive(ref _remoteIpEndPoint);
                //Проверка доступности ОЕД 
                if (resp[0] == 10 && resp[7] == 1)
                    return true;
            }
            catch (SocketException)
            {
                AddToOperationsPerfomed("STM не вернул статус USB соединения. TimeOut.");
            }
            return false;
        }
        //Проверка доступности ОЭД
        private bool CheckOed()
        {          
            try
            {                          
                var data = GetAllLaunch();
                if(ToLittleEndian(data, 5, 2) == 0x1506)
                {
                    for (int i = 1; i <= data[4]; i++)
                    {
                        _launchSize[i - 1] = ToLittleEndian(data, i * 7 + 3, 4);
                        AddToLaunchInfo(data[i*7], ToLittleEndian(data, i * 7 + 1, 2), _launchSize[i - 1]);                        
                    }
                    AddToOperationsPerfomed("Количество записанных пусков: " + data[4]);
                    return true;
                }
            }
            catch (SocketException)
            {
                AddToOperationsPerfomed("ОЕД не вернул список пусков. TimeOut.");
            }
            return false;
        }        
        #endregion

        /// <summary>
        /// Служебное сообщение (использует Invoke)
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        private void AddToOperationsPerfomed(string message)
        {
            Invoke(new MethodInvoker(delegate
            {
                listBOpreationsPerfomed.Items.Add(@"[" + DateTime.Now + @"] " + message);
                listBOpreationsPerfomed.SelectedIndex = listBOpreationsPerfomed.Items.Count - 1;
            }));
        } 
        /// <summary>
        /// Информация о пуске (использует Invoke)
        /// </summary>
        /// <param name="launch">Пуск</param>
        /// <param name="sizepack">Количество пакетов</param>
        /// <param name="size">Размер</param>
        private void AddToLaunchInfo(byte launch, int sizepack, int size)
        {
            Invoke(new MethodInvoker(delegate
            {
            listBLaunchInfo.Items.Add(@"Пуск: " + launch + @" Количество пакетов: " + sizepack +@" Размер: " + size);
            listBLaunchInfo.TopIndex = listBLaunchInfo.Items.Count - 1;
            }));
        }
        /// <summary>
        /// Добавление нового сохраненного файла
        /// </summary>
        /// <param name="index">Номер пуска</param>
        private void AddToSavedInfo(int index)
        {
            Invoke(new MethodInvoker(delegate
            {
                listBSavedInfo.Items.Add("Пуск номер: " + index);
            }));
        }
        /// <summary>
        /// Преобразование к порядку байтов Little Endian
        /// </summary>
        /// <param name="data">Массив</param>
        /// <param name="poss">Положение 1 байта числа</param>
        /// <param name="size">Размер числа в байтах</param>
        /// <returns></returns>
        private static int ToLittleEndian(byte[] data, int poss, int size)
        {
            var arr = new byte[size];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = data[poss + i];
            }
            return arr.Select((t, i) => t << i * 8).Sum();
        }
        /// <summary>
        /// Сохранение выбранного пуска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_oedIsAvaliable) return;
            var index = listBLaunchInfo.SelectedIndex;
            if (index != -1)
            {
                var data = GetLaunch(index);
                using (var bw = new BinaryWriter(new FileStream(index + ".imi", FileMode.Create)))
                {
                    bw.Write(data);
                }
                AddToSavedInfo(index);
            }
            else MessageBox.Show("Выберите пуск для скачивания!");
        }
        /// <summary>
        /// Отправка запроса на получение всех пусков из ОЕД
        /// </summary>
        /// <returns>Ответ ОЕД</returns>
        private byte[] GetAllLaunch()
        {   
            // Формирование команды получения всех пусков
            var request = new byte[71];
            request[0] = 12;// ОЭД
            request[2] = 1;
            request[4] = 2;
            request[7] = 5;

            _sender.Send(request, request.Length, _endPoint);
            var receivedData = _resiver.Receive(ref _remoteIpEndPoint);

            var data = new byte[128];
            for (int i = 0; i < receivedData.Length - 7; i++)
            {
                data[i] = receivedData[i + 7];
            }
            return data;
        }
        /// <summary>
        /// Запрос на получение пуска
        /// </summary>
        /// <param name="number">Номер пуска</param>
        /// <returns></returns>
        private byte[] GetLaunch(int number)
        {
            dForm.Show();
            dForm.pbDownloading.Maximum = _launchSize[number];

            var request = new byte[71];
            request[0] = 12;
            request[2] = 1;
            //request[4] = 16;
            request[4] = 1;
            request[7] = 6;
            request[8] = (byte)number;

            var request2 = new byte[7];
            request2[0] = 12;
            //request2[4] = 16;
            request2[4] = 1;

            _resiver.Client.ReceiveTimeout = 3000;

            var responce = new byte[_launchSize[number]];

            try
            {
                _sender.Send(request, request.Length, _endPoint);
                var resp = _resiver.Receive(ref _remoteIpEndPoint);
                for (int i = 0; i < resp.Length; i++)
                {
                    responce[i] = resp[i + 7];
                }

                var counter = resp.Length - 7;
                dForm.pbDownloading.Step = counter;
                dForm.pbDownloading.PerformStep();

                while (counter > responce.Length)
                {
                    _sender.Send(request2, request2.Length, _endPoint);
                    var resp2 = _resiver.Receive(ref _remoteIpEndPoint);
                    for (int i = 0; i < resp2.Length; i++)
                    {
                        responce[counter] = resp2[i + 7];
                        counter++;
                    }

                    dForm.pbDownloading.Step = counter;
                    dForm.pbDownloading.PerformStep();
                }
                dForm.Hide();
            }
            catch (SocketException)
            {
                AddToOperationsPerfomed("Нет входящих данных. TimeOut.");
            }
            return responce;
        }
    }
}
