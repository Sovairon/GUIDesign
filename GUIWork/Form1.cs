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

        private void Connect(string portName)
        {
            var port = new SerialPort(portName);
            //var portfrm = comboBox1.SelectedItem;
            if (!port.IsOpen)
            {
                port.BaudRate = 19200;
                port.Open();
                MessageBox.Show("Connected!");
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
            comboBox1.SelectedIndex = 0;
        }
    }
}

