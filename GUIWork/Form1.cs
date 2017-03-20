using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

//toplanan verilerin ayni klasorde toplanmasi


namespace GUIWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetPorts();
            comboBox2.SelectedIndex = 9;

        }

        SerialPort port = new SerialPort();
        SerialPort sp;
        string indata;
        static string csvFilePath = "C:/Test/csv.txt"; //Work In Progress
        int baudRate = 300;
        System.IO.StreamWriter csv = new System.IO.StreamWriter(@csvFilePath);


        private void button1_Click(object sender, EventArgs e)
        {
            if (!port.IsOpen && comboBox1.SelectedIndex>-1)
            {
                Connect(comboBox1.SelectedItem.ToString());
            }
            else if (port.IsOpen)
            {
                Disconnect();
            }
            else
            {
                labelStatus.Text = "Select Port";
                labelStatus.ForeColor = System.Drawing.Color.Crimson;
                Console.WriteLine("Error on connection. GZ, you managed to break it.");
            }

                   
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


        private void Connect(string portName)
        {
            try
            {
                port = new SerialPort(portName);
                port.BaudRate = baudRate;
                port.Open();
                port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                port.DtrEnable = true;
                //MessageBox.Show("Connected!");
                labelStatus.ForeColor = System.Drawing.Color.MidnightBlue;
                labelStatus.Text = "Connected";
                ConnectBtn.Text = "Disconnect";
            }
            catch
            {
                Console.WriteLine("Exception at SerialPort. GZ you managed to break it.");
            }
            
        }

        private void Disconnect()
        {
            try
            {
                port.Close();
                //MessageBox.Show("Disconnected!");
                labelStatus.ForeColor = System.Drawing.Color.Firebrick;
                labelStatus.Text = "Disconnected";
                ConnectBtn.Text = "Connect";
            }
            catch
            { 

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GetPorts();
        }

        private void GetPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            foreach (string comport in ports)
            {
                comboBox1.Items.Add(comport);
            }
            try
            {
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception)
            {
                Console.WriteLine("No Ports Available");
            }
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private static void AddText(string Text, RichTextBox txtbox)
        {
            txtbox.AppendText(Text);
        }



        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richTextBox1.AppendText(text);
            }
        }

        private void DataReceivedHandler( object sender, SerialDataReceivedEventArgs e)
        {
            sp = (SerialPort)sender;
            indata = sp.ReadLine();
            SetText(indata);

            Console.Write(indata);
            csv.WriteLine(indata);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    baudRate = 300;
                    break;
                case 1:
                    baudRate = 1200;
                    break;
                case 2:
                    baudRate = 2400;
                    break;
                case 3:
                    baudRate = 4800;
                    break;
                case 4:
                    baudRate = 9600;
                    break;
                case 5:
                    baudRate = 19200;
                    break;
                case 6:
                    baudRate = 38400;
                    break;
                case 7:
                    baudRate = 57600;
                    break;
                case 8:
                    baudRate = 74880;
                    break;
                case 9:
                    baudRate = 115200;
                    break;
                case 10:
                    baudRate = 230400;
                    break;
                case 11:
                    baudRate = 250000;
                    break;
                default:
                    break;
            }
        }
        //public void csvFileLocation(string filename) {
        //    csvFilePath = "C:/GUIWorkCSV/test.csv";
        //}
    }
}

