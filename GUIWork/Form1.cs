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

namespace GUIWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetPorts();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect(comboBox1.SelectedItem.ToString());
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

        SerialPort port = new SerialPort();

        private void Connect(string portName)
        {
            //var portfrm = comboBox1.SelectedItem;

            try
            {
                if (!port.IsOpen)
                {
                    port = new SerialPort(portName);
                    port.BaudRate = 9600;
                    port.Open();
                    port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    port.DtrEnable = true;
                    MessageBox.Show("Connected!");
                    //ConnectBtn.Enabled = false;
                }
            }
            catch
            {
                Console.WriteLine("Exception at SerialPort. GZ you managed to break it.");
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
                //throw;
            }
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private static void AddText(string Text, RichTextBox txtbox)
        {
            txtbox.AppendText(Text);
        }

        //string new_data;
        SerialPort sp;
        string indata;

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
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
            //Console.WriteLine("Data Received:");
            //AddText(indata, richTextBox1);
            //richTextBox1.AppendText(indata);
            SetText(indata);


            Console.Write(indata);

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}

