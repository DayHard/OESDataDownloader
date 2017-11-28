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
using System.Threading.Tasks;

namespace OESDataDownloader
{
    public partial class MainForm : Form
    {
        #region Variable

        private DownloadingForm dForm = new DownloadingForm();
        private readonly Ping _ping;
        private readonly UdpClient _sender;
        private readonly UdpClient _resiver; 
        private readonly IPEndPoint _endPoint;
        private IPEndPoint _remoteIpEndPoint;
        private static string _remoteIp;
        private bool _oedIsAvaliable;


        private readonly byte[] _comGetStatus = { 10, 0, 0, 0, 1, 0, 0 };
        private const int RemotePort = 3001;
        //private readonly byte[] _comGetStatus = { 10, 0, 0, 0, 1, 0, 0, 1 };
        //private const int RemotePort = 3000;
        private const int TimeOut = 10;
        private const int LocalPort = 3000;
        private const int ConnectionRetry = 1000;

        private readonly int[] _launchSize = new int[15];

        #endregion
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
                if (CheckEthernet() && CheckUsb() && CheckOed())
                {
                    //USE ONLY WITH INVOKE
                    //btnSave.Enabled = btnDeleteAll.Enabled = btnFormat.Enabled = true;
                    _oedIsAvaliable = true;
                    break;
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
                {
                    btnIndicEthernet.BackColor = Color.GreenYellow;
                    return true;
                }
                AddToOperationsPerfomed("Ошибка пинга STM: TimeOut.");
                btnIndicEthernet.BackColor = Color.OrangeRed;              
            }
            catch (Exception ex)
            {
                AddToOperationsPerfomed("Ошибка пинга STM: " +ex.Message);
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
                {
                    btnIndicUSB.BackColor = Color.GreenYellow;
                    return true;
                }                   
            }
            catch (SocketException)
            {
                AddToOperationsPerfomed("STM не вернул статус USB соединения. TimeOut.");
            }
            btnIndicUSB.BackColor = Color.OrangeRed;
            return false;
        }
        //Проверка доступности ОЭД
        private bool CheckOed()
        {
            try
            {
                var data = GetAllLaunch();
                Thread.Sleep(100);
                if (ToLittleEndian(data, 5, 2) == 0x1506)
                {
                    for (int i = 1; i <= data[4]; i++)
                    {
                        _launchSize[i - 1] = ToLittleEndian(data, i * 7 + 3, 4);
                        AddToLaunchInfo(data[i * 7], ToLittleEndian(data, i * 7 + 1, 2), _launchSize[i - 1]);
                    }

                    AddToOperationsPerfomed("Соединение с STM установлено.");
                    AddToOperationsPerfomed("Соединение по USB установлено.");
                    AddToOperationsPerfomed("Пуски считаны.");
                    AddToOperationsPerfomed("Номер прибора: "+ ToLittleEndian(data,0,4));
                    AddToOperationsPerfomed("Количество записанных пусков: " + data[4]);
                }

                Thread.Sleep(500);
                var data2 = GetAllDiag();
                AddToLaunchInfo(ToBigEndian(data2, 2, 2), ToBigEndian(data2,4,4));
                AddToOperationsPerfomed("Количество записанных диагностик: " + ToBigEndian(data2, 2, 2));
                btnIndicOed.BackColor = Color.GreenYellow;
                return true;
            }
            catch (SocketException)
            {
                AddToOperationsPerfomed("ОЕД не вернул список пусков. TimeOut.");
            }
            btnIndicOed.BackColor = Color.OrangeRed;
            return false;
        }
        #endregion

        #region AddToList     
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
            listBLaunchInfo.Items.Add(@"Пуск: " + launch + @" Количество пакетов: " + sizepack +@" Размер: " + size + " B");
            listBLaunchInfo.TopIndex = listBLaunchInfo.Items.Count - 1;
            }));
        }        
        /// <summary>
        /// Информация о диагностике (использует Invoke)
        /// </summary>
        /// <param name="sizediag">Количесвто диагностик</param>
        /// <param name="size"> Размер диагностик в B</param>
        private void AddToLaunchInfo(int sizediag, int size)
        {
            Invoke(new MethodInvoker(delegate
            {
                listBLaunchInfo.Items.Add(@"Количество диагностик: " + sizediag + @" Размер: " + size + " B");
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
        #endregion

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
        /// Преобразование к порядку байтов Big Endian
        /// </summary>
        /// <param name="data">Массив</param>
        /// <param name="poss">Положение 1 байта числа</param>
        /// <param name="size">Размер числа в байтах</param>
        /// <returns></returns>
        private static int ToBigEndian(byte[] data, int poss, int size)
        {
            var arr = new byte[size];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = data[poss + i];
            }
            int result = 0;
            for (int i = 0; i <arr.Length ; i++)
            {
                result |= arr[i] << 8*(size - 1 - i);
            }
            return result;
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
            var launch = index + 1;
            if (index != -1)
            {
                dForm.lbBytesReceived.Text = @"0/" + _launchSize[index];
                dForm.pbDownloading.Value = 0;
                dForm.pbDownloading.Maximum = _launchSize[index];

                dForm.Show();

                var cancellationTokenSource = new CancellationTokenSource();
                dForm.CancellationToken = cancellationTokenSource;

                Task.Factory.StartNew(() =>
                {
                    var data = GetLaunch(launch);
                    using (var bw = new BinaryWriter(new FileStream(launch + ".imi", FileMode.OpenOrCreate)))
                    {
                        bw.Write(data);
                    }
                    AddToSavedInfo(launch);
                }, cancellationTokenSource.Token);
            }
            else MessageBox.Show("Выберите пуск для скачивания!");
        }

        #region ControlsCommands

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

            // Очистка буфера приема UDP
            if (_resiver.Available > 1)
            {
                _resiver.Receive(ref _remoteIpEndPoint);
            }


            _sender.Send(request, request.Length, _endPoint);
            var receivedData = _resiver.Receive(ref _remoteIpEndPoint);

            var data = new byte[128];
            //Array.Copy(receivedData, 7, data, 0, receivedData.Length);

            for (int i = 0; i < receivedData.Length - 7; i++)
            {
                data[i] = receivedData[i + 7];
            }
            return data;
        }

        /// <summary>
        /// Отправка запроса на получение информации о диагностике
        /// </summary>
        /// <returns>Ответ ОЭД</returns>
        private byte[] GetAllDiag()
        {
            // Формирование команды получения всех пусков
            var request = new byte[71];
            request[0] = 12;// ОЭД
            request[2] = 1;
            request[4] = 1;
            request[7] = 16;

            // Очистка буфера приема UDP
            if (_resiver.Available > 1)
            {
                _resiver.Receive(ref _remoteIpEndPoint);
            }

            _sender.Send(request, request.Length, _endPoint);
            var receivedData = _resiver.Receive(ref _remoteIpEndPoint);

            var data = new byte[128];
            //Array.Copy(receivedData, 7, data, 0, data.Length);
            //Array.Copy(rdata, 7, data, counter, rdata.Length);
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
            #region ArrayDefinitions

            // Команда
            // Скачать пуск номер number (привести к byte)
            var req = new byte[71];
            req[0] = 12;
            //req[1] = 0;
            req[2] = 1;
            //req[3] = 0;
            //req[4] = 0;
            //req[5] = 0;
            req[6] = 6;
            req[7] = 6;
            req[8] = (byte)number;

            //Команда
            // Заполнить буфер (2048 байт)
            var req2 = new byte[71];
            req2[0] = 12;
            //req2[1] = 0;
            req2[2] = 1;
            //req2[3] = 0;
            //req2[4] = 0;
            //req2[5] = 0;
            req2[6] = 4;
            req2[7] = 4;
            
            // Команда
            // Выдать пакет данных
            var req3 = new byte[7];
            req3[0] = 12;
            //req3[1] = 0;
            //req3[2] = 0;
            //req3[3] = 0;
            req3[4] = 16;
            //req3[5] = 0;
            req3[6] = 22;

            var index = number - 1;
            var counter = 0;
            var data = new byte[_launchSize[index]];

            for (int i = 0; i < data.Length; i++)
                data[i] = 0;
            _resiver.Client.ReceiveTimeout = 3000;

            #endregion

            _sender.Send(req, req.Length, _endPoint);
            // должно быть 5-6 секунд
            Thread.Sleep(6000); 
            do
            {
                _sender.Send(req2, req2.Length, _endPoint);
                Thread.Sleep(3);

                //!!!! Должно быть 16
                for (int i = 0; i < 2; i++)
                {
                    _sender.Send(req3, req3.Length, _endPoint);
                    try
                    {
                        var rdata = _resiver.Receive(ref _remoteIpEndPoint);
                        for (int j = 7; j < rdata.Length; j++)
                        {
                            if (counter == data.Length) break;
                        
                            data[counter] = rdata[j];
                            counter++;
                        }
                    }
                    catch (SocketException)
                    {
                        AddToOperationsPerfomed("Ошибка считывания пуска с ОЕД. TimeOut.");
                    }

                    Invoke(new MethodInvoker(delegate
                    {
                        dForm.pbDownloading.Value = counter;
                        //dForm.pbDownloading.PerformStep();
                        dForm.lbBytesReceived.Text = counter + @"/" + _launchSize[index];
                    }));

                }
            } while (_launchSize[index]> counter);
            return data;
        }

        #endregion

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
        }
    }
}
