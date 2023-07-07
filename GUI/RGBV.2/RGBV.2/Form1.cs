using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RGBV._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            updateColor();
            radiocheck();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((comboBox1.Text == "") || (comboBox2.Text == ""))
                {
                    MessageBox.Show("Please Select Port or Baud Rate", "Error");
                }
                else
                {
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);
                    serialPort1.Open();
                }
            }
            catch(InvalidOperationException)
            {
                MessageBox.Show("Erorrrrrrrrrrrrrrrrrrrrrrr");
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            getAvaialblePorts();
        }

        void getAvaialblePorts()
        {
            String[] ports = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(ports);
        }

        void updateColor()
        {
            if(serialPort1.IsOpen)
            {
                label9.Text = "Connect";
            }
            else
            {
                label9.Text = "Not Connect";
            }
            panel1.BackColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            label4.Text = trackBar1.Value.ToString();
            label4.BackColor = Color.FromArgb(((int)trackBar1.Value), 0, 0);
            label5.Text = trackBar2.Value.ToString();
            label5.BackColor = Color.FromArgb(0, ((int)trackBar2.Value), 0);
            label6.Text = trackBar3.Value.ToString();
            label6.BackColor = Color.FromArgb(0, 0, ((int)trackBar3.Value));
            label8.Text = "RGB(" + trackBar1.Value.ToString() + "," + trackBar2.Value.ToString() + "," + trackBar3.Value.ToString() + ")";
        }
    
        /*void keyboardfun(KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Return))
            {
                label7.BackColor = Color.Red;
            }
            else
            {
                label7.BackColor = Color.AliceBlue;
            }
        }*/

        void radiocheck()
        {
            if (radioButton1.Checked)
            {
                radioButton4.Enabled = true; 
                radioButton5.Enabled = false; 
                radioButton6.Enabled = false;
                
            }
            else if(radioButton2.Checked)
            {
                radioButton4.Enabled = false; 
                radioButton5.Enabled = true;
                radioButton6.Enabled = false;
                
            }
            else if (radioButton3.Checked)
            {
                radioButton4.Enabled = false;
                radioButton5.Enabled = false;
                radioButton6.Enabled = true;
                
            }
            else
            {
                radioButton4.Enabled = false;
                radioButton5.Enabled = false;
                radioButton6.Enabled = false;
            }
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("A" + trackBar1.Value.ToString());
                Readserial();
            }
            catch(Exception error)
            {
                MessageBox.Show("Please connect port first");
            }
            
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("B" + trackBar2.Value.ToString());
                Readserial();
            }
            catch (Exception error)
            {
                MessageBox.Show("Please connect port first");
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("C" + trackBar1.Value.ToString());
                Readserial();
            }
            catch (Exception error)
            {
                MessageBox.Show("Please connect port first");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Close();
                }
                catch(Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        void Readserial()
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    textBox1.Enabled = true;
                    textBox1.Text = serialPort1.ReadLine();
                }
                catch (TimeoutException)
                {
                    textBox1.Text = "Timeout";
                }
            }
            else
            {
                textBox1.Enabled = false;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }
    }
}
