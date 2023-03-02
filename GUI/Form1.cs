using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ZCS : Form
    {

        public delegate void receive();
        public delegate void send();

        private string buttonMessage;
        private string messageBuffer;
        private int x = 125, y = 220, dir = 1, finihVal = 0;
        

        public ZCS()
        {
            messageBuffer = "";
            InitializeComponent();
            // action button template with adjustable instructions
            ActionBtn.Click += (s, e) => { serialPort.Write(buttonMessage); ActionBtn.Hide(); };
        }

        // GUI button controls
        private void Stoppingbar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                serialPort.Write("Q");
            }
        }

        private void ArrowDownBtn_Click(object sender, EventArgs e)
        {
            serialPort.Write("B");
        }

        private void ArrowUpBtn_Click(object sender, EventArgs e)
        {
            serialPort.Write("S");
        }

        private void ArrowLeftBtn_Click(object sender, EventArgs e)
        {
            serialPort.Write("L");
        }

        private void ArrowRightBtn_Click(object sender, EventArgs e)
        {
            serialPort.Write("R");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort.Write("Q");
        }

        // try accessing serial port 
        private void OpenSerial_Click(object sender, EventArgs e)
        {
            try
            {
               
                serialPort.Open();
                DeveloperConsole.AppendText("[ZCS] Serial Port " + serialPort.PortName.ToString() + " opened");
                DeveloperConsole.AppendText(Environment.NewLine);

                // show a button for connectin to the zumo
                ActionBtn.Text = "Connect";
                buttonMessage = "AC";
                ActionBtn.Show();
            }
            catch(Exception error)
            {
                // port might be taken or not existant (if xbee not connected)
                MessageBox.Show(error.ToString());
            }
            
        }

        // keyboard button control
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //capture up arrow key
            if (keyData == Keys.Up)
            {
                serialPort.Write("S");
                return true;
            }
            //capture down arrow key
            if (keyData == Keys.Down)
            {
                serialPort.Write("B");
                return true;
            }
            //capture left arrow key
            if (keyData == Keys.Left)
            {
                serialPort.Write("L");
                return true;
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                serialPort.Write("R");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // when packet is available in serial part
        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string data;
            data = serialPort.ReadExisting();

            // check if packet is complete (contains /) else combine upcoming packets into a single message buffer
            if (!data.Contains("/"))
            {
                messageBuffer += data;
            }
            else
            {
                messageBuffer += data;
                receive write = new receive(sendToForm);
                Invoke(write);
            }
        }

        // send data to GUI
        public void sendToForm()
        {
            // remove last char (delimeter)
            messageBuffer = messageBuffer.Remove(messageBuffer.Length - 1); 

            // message type 
            char Identifier = messageBuffer[0];

            switch (Identifier)
            {
                // message to developer console
                case 'M':
                    DeveloperConsole.AppendText("[ZUMO] " + messageBuffer.Substring(1));
                    DeveloperConsole.AppendText(Environment.NewLine);
                    break;

                // Zumo instruction for GUI
                case 'I':
                    switch (messageBuffer[1])
                    {
                        // show calibration button
                        case 'C':
                            ActionBtn.Text = "Calibrate";
                            buttonMessage = "IC";
                            ActionBtn.Show();
                            DeveloperConsole.AppendText("[ZUMO] Press \"Calibrate\"");
                            break;
                        // show start button
                        case 'S':
                            ActionBtn.Text = "Sart";
                            buttonMessage = "IS";
                            ActionBtn.Show();
                            break;
                        // show mode selection buttons
                        case 'M':
                            Mode1Btn.Show();
                            Mode2Btn.Show();
                            Mode3Btn.Show();
                            Mode1Btn.Click += (s, e) => { serialPort.Write("IM1"); Mode1Btn.FlatStyle = FlatStyle.Flat; Mode1Btn.FlatAppearance.BorderColor = Color.Green; Mode1Btn.Enabled = false; Mode2Btn.Enabled = false; Mode3Btn.Enabled = false; };
                            Mode2Btn.Click += (s, e) => { serialPort.Write("IM2"); Mode2Btn.FlatStyle = FlatStyle.Flat; Mode2Btn.FlatAppearance.BorderColor = Color.Green; Mode1Btn.Enabled = false; Mode2Btn.Enabled = false; Mode3Btn.Enabled = false; };
                            Mode3Btn.Click += (s, e) => { serialPort.Write("IM3"); Mode3Btn.FlatStyle = FlatStyle.Flat; Mode3Btn.FlatAppearance.BorderColor = Color.Green; Mode1Btn.Enabled = false; Mode2Btn.Enabled = false; Mode3Btn.Enabled = false; };
                            break;
                        // show room button
                        case 'R':
                            ActionBtn.Text = "Room";
                            buttonMessage = "IR";
                            ActionBtn.Show();
                            DeveloperConsole.AppendText("[ZUMO] Press \"Room\"");
                            DeveloperConsole.AppendText(Environment.NewLine);
                            break;
                    }
                    break;

                // Identifier for drawing a map
                case 'D':

                    // set up graphics for drawing on the map panel
                    Graphics graph = MapPanel.CreateGraphics();
                    Pen pencil = new Pen(Color.Black, 3);
                                        
                    try
                    {
                        // break down required data from the packet
                        int direction = int.Parse(messageBuffer[1].ToString());
                        int driveTime = int.Parse(messageBuffer.Remove(0, 2));
                        int distance;

                        if (driveTime < 8)
                        {
                            distance = 20;
                        }
                        else
                        {
                            distance = (driveTime);
                        }

                        // draw directio
                        switch (direction)
                        {
                            // left
                            case 0:
                                // draw line from last point to the driven point
                                graph.DrawLine(pencil, x, y, x - distance, y);
                                x -= distance;
                                MovementInstructions.AppendText("[Left] " + driveTime + "cm");
                                MovementInstructions.AppendText(Environment.NewLine);
                                break;
                            // up
                            case 1:
                                graph.DrawLine(pencil, x, y, x, y - distance);
                                y -= distance;
                                MovementInstructions.AppendText("[Straight] " + driveTime + "cm");
                                MovementInstructions.AppendText(Environment.NewLine);
                                break;
                            // right
                            case 2:
                                graph.DrawLine(pencil, x, y, x + distance, y);
                                x += distance;
                                MovementInstructions.AppendText("[Right] " + driveTime + "cm");
                                MovementInstructions.AppendText(Environment.NewLine);
                                break;
                            // down
                            case 3:
                                graph.DrawLine(pencil, x, y, x, y + distance);
                                y += distance;
                                MovementInstructions.AppendText("[Backwards] " + driveTime + "cm");
                                MovementInstructions.AppendText(Environment.NewLine);
                                break;
                            case 4:
                                MovementInstructions.AppendText("[Found a person]");
                                MovementInstructions.AppendText(Environment.NewLine);
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        MovementInstructions.AppendText("Error" + e);
                        MovementInstructions.AppendText(Environment.NewLine);
                    }
                    break;

                // draw a person on the pac
                case 'P':
                    Graphics graph2 = MapPanel.CreateGraphics();
                    Pen pencil2 = new Pen(Color.Black, 3);

                    // drawing a circle
                    graph2.DrawEllipse(pencil2, x - 5, y - 5,
                      5 + 5, 5 + 5);
                    break;

                // default message (mostly for testing purposes)
                default:
                    DeveloperConsole.AppendText("[D] " + messageBuffer);
                    DeveloperConsole.AppendText(Environment.NewLine);
                    break;
            }
            // reset message buffer
            messageBuffer = "";
        }

    // end of form
    }
}
