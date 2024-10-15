using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UPeryf_modemy
{
    public partial class Form1 : Form
    {
        SerialPort _serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);

        public Form1()
        {
            InitializeComponent();
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            _serialPort.Open(); // Open the serial port - it remains open till the program is closed
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            // Read the data coming from the serial port
            string data = _serialPort.ReadExisting();

            richTextBoxMessages.AppendText(data + "\n");

            // Optionally scroll to the bottom of the RichTextBox
            richTextBoxMessages.SelectionStart = richTextBoxMessages.Text.Length;
            richTextBoxMessages.ScrollToCaret();
        }

        private void buttonCall_Click(object sender, EventArgs e)
        {
            _serialPort.Write("atd\r");
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            _serialPort.Write("ata\r");
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            _serialPort.Write("+++ath\r");
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            _serialPort.Write(textBoxMessage.Text + "\r");
            textBoxMessage.Text = "";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _serialPort.Close();
            base.OnFormClosed(e);
        }

        private void buttonSendFile_Click(object sender, EventArgs e)
        {
            /*
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    XModem xmodem = new XModem(_serialPort);
                    xmodem.SendFile(openFileDialog.FileName);
                }
            }
            */
        }

        private void buttonReceiveFile_Click(object sender, EventArgs e)
        {
            /*
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    XModem xmodem = new XModem(_serialPort);
                    xmodem.ReceiveFile(saveFileDialog.FileName);
                }
            }
            */
        }

    }
}
