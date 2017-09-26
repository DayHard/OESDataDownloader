using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace OESDataDownloader
{
    public partial class UARTForm : Form
    {
        public SerialPort SerialPort = new SerialPort();
        private bool isOpen;
        public UARTForm()
        {
            InitializeComponent();
        }
        //Событие получения данных
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] data = new byte[SerialPort.BytesToRead];
            SerialPort.Read(data, 0, data.Length);
        }
        //Подписи событий, определение начальных значений настрое COM
        private void UART_Load(object sender, EventArgs e)
        {
            //Подписи на события
            SerialPort.DataReceived += SerialPort_DataReceived;

            //Установка начальных идексов параметров COM
            cbRate.SelectedIndex = 6;
            cbStopBits.SelectedIndex = 0;
            cbDataBits.SelectedIndex = 3;
            Array parities = Enum.GetValues(typeof(Parity));
            foreach (Parity p in parities) cbParity.Items.Add(p);
            cbParity.SelectedIndex = 2;
            cbPortName.Items.AddRange(SerialPort.GetPortNames());
            if (cbPortName.Items.Count != 0)
                cbPortName.SelectedIndex = cbPortName.SelectionStart;
        }
        //Переопределение события закрытия формы
        private void UARTForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
        //Подключение-Отключение от COM
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isOpen)
                {
                    SerialPort.PortName = cbPortName.Text;
                    SerialPort.BaudRate = int.Parse(cbRate.Text);
                    SerialPort.Parity = (Parity)Enum.Parse(typeof(Parity), cbParity.Text);
                    SerialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cbStopBits.Text);
                    SerialPort.DataBits = int.Parse(cbDataBits.Text);
                    SerialPort.Open();
                    SerialPort.Write("Testing...");
                    btnConnect.Text = @"Disconnect";
                    isOpen = !isOpen;
                }
                else
                {
                    SerialPort.Close();
                    btnConnect.Text = @"Connect";
                    isOpen = !isOpen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Посылка команды управления
        public bool Write(byte[] data)
        {
            try
            {
                SerialPort.Write(data, 0, data.Length);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void btnTestCommand_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[64];
            data[0] = 5;
            Write(data);
        }
    }
}
