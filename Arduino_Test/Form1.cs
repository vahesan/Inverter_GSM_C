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

namespace Arduino_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        communicator comport = new communicator();
        Boolean portConnection = false;

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //foreach (string port in SerialPort.GetPortNames()) // Adds all port names to ports list
            //{
            //    cbPorts.Items.Add(port); // adds ports to Ports combo-box
            //}
            //if (cbPorts.Items.Count > 0) // if there is at least one port available, select the             first one as default
            //{
            //    cbPorts.SelectedIndex = 0;
            //    btnOpen.Enabled = true;
            //}
            //else // no ports available
            //{
            //    cbPorts.Text = "No Ports Available";
            //    MessageBox.Show("Could not locate any available serial ports.", "No serial ports", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //btnOpen.Enabled = false;
            //}
            //btnSendA.Enabled = false;
            //btnSendB.Enabled = false;
            //btnClose.Enabled = false;
            txt1.Enabled = false;
            txt2.Enabled = false;
            btnSendA.Enabled = false;
            btnSendB.Enabled = false;
            btnClose.Enabled = false;
        }

        private void btnOpen_Click_1(object sender, EventArgs e)
        {
            if (comport.connect(9600, "I'M ARDUINO", 4, 8, 16))
            {
                lblStatus.Text = "Connection Successful - Connected to  " + comport.port;
                portConnection = true;
                //cbPorts.Enabled = false;
                btnOpen.Enabled = false;
                btnSendA.Enabled = true;
                btnSendB.Enabled = true;
                btnClose.Enabled = true;
                txt1.Enabled = true;
                txt2.Enabled = true;
            }
            else
            {
                lblStatus.Text = "Not connected . . . ";
                portConnection = false;
                //cbPorts.Enabled = true;
                btnOpen.Enabled = true;
                btnSendA.Enabled = false;
                btnSendB.Enabled = false;
                btnClose.Enabled = false;
                txt1.Enabled = false;
                txt2.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            serialPort.Close();
            lblStatus.Text = "Not connected . . . ";
            portConnection = false;
            // Change the Enabled flag for the buttons to prevent user error
            //cbPorts.Enabled = true;
            btnOpen.Enabled = true;
            btnSendA.Enabled = false;
            btnSendB.Enabled = false;
            btnClose.Enabled = false;
            txt1.Enabled = false;
            txt2.Enabled = false;
        }

        private void btnSendA_Click(object sender, EventArgs e)
        {
            txt1.Text = comport.message(4, 8, 32);
        }

        private void btnSendB_Click(object sender, EventArgs e)
        {
            txt2.Text = comport.message(4, 8, 33);
        }

        private void btnUpdate1_Click(object sender, EventArgs e)
        {

            comport.send(4,8,34,txt1.Text, "Done");
            txt1.Text = "";
        }

        private void btnUpdate2_Click(object sender, EventArgs e)
        {
            comport.send(4, 8, 35, txt2.Text, "Done");
            txt2.Text = "";
        }
    }
}

