using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace TBotGUI
{
    public partial class Form1 : Form
    {

        RunPython runPy;
        ProcessStartInfo pythonInfo;
        Process python;
        const int port = 50999;
        string ipAddr = "127.0.0.1";

        public Form1()
        {
            runPy = new RunPython();
            pythonInfo = new ProcessStartInfo();

            try
            {
                pythonInfo.FileName = @"C:\Users\Nate\AppData\Local\Programs\Python\Python36-32\python.exe";
                pythonInfo.Arguments = @".\src\TBot2.py";
                pythonInfo.CreateNoWindow = true;
                pythonInfo.UseShellExecute = false;
                pythonInfo.ErrorDialog = false;

                pythonInfo.RedirectStandardError = true;
                pythonInfo.RedirectStandardInput = true;
                pythonInfo.RedirectStandardOutput = true;
            }
            catch
            {
                Console.WriteLine("Error in RunPython Constructor");
            }

            //Thread pyConn = new Thread(ReceivePyData);
            //pyConn.Start();

            //Thread pyRead = new Thread(ReadCmdFile);
            //pyRead.Start();

            
            InitializeComponent();
            ReadConfig();
        }

        

        private void startBot_Click(object sender, EventArgs e)
        {
            startBot.Enabled = false;
            botBox.Enabled = false;
            oAuthBox.Enabled = false;
            streamBox.Enabled = false;
            currBox.Enabled = false;
            awardBox.Enabled = false;
            timeBox.Enabled = false;
            addModToolStripMenuItem.Enabled = false;
            addCommandToolStripMenuItem.Enabled = false;
            updateBut.Enabled = false;

            startBot.Text = "Connected!";
            Thread pyThread = new Thread(StartPython);
            pyThread.IsBackground = true;
            pyThread.Start();
            stopBot.Enabled = true;
        }

        private void stopBot_Click(object sender, EventArgs e)
        {
            stopBot.Enabled = false;
            StopPython();
            startBot.Enabled = true;
            botBox.Enabled = true;
            oAuthBox.Enabled = true;
            streamBox.Enabled = true;
            currBox.Enabled = true;
            awardBox.Enabled = true;
            timeBox.Enabled = true;
            addModToolStripMenuItem.Enabled = true;
            addCommandToolStripMenuItem.Enabled = true;
            updateBut.Enabled = true;
            startBot.Text = "Start";
        }
        

        /// <summary>
        /// method for running python scripts
        /// </summary>
        private void StartPython()
        {
            try
            {
                Console.WriteLine("Python Starting");
                python = new Process();
                python.StartInfo = pythonInfo;
                python.OutputDataReceived += (s, e) => Console.WriteLine(e.Data);
                python.Start();
                python.BeginOutputReadLine();

                python.WaitForExit();
                python.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Error starting python script! " + exc.StackTrace);
            }

        }

        /// <summary>
        /// method for killing python scripts
        /// </summary>
        private void StopPython()
        {
            try
            {
                python.Kill();
                Console.WriteLine("Python killed");
            }
            catch
            {
                Console.WriteLine("Error stopping python");
            }
        }

        public void ReceivePyData()
        {
            try
            {
                IPAddress ip = IPAddress.Parse(ipAddr);
                TcpListener listener = new TcpListener(ip, port);

                listener.Start();

                while (true)
                {
                    Console.WriteLine("Waiting for python connection...");

                    Socket sock = listener.AcceptSocket();
                    Console.WriteLine("Connected to python!");


                    StreamReader sr = new StreamReader(new NetworkStream(sock));

                    string data = sr.ReadLine();
                    Console.WriteLine(data);

                    sock.Close();
                }
            }
            catch(Exception exc)
            {
                Console.WriteLine("ERROR in receivepydata" + exc.StackTrace);
            }
        }

        private void ReadCmdFile()
        {
            while (true)
            {
                try
                {
                    StreamReader sr = new StreamReader("pyCconn");

                    string newLine = sr.ReadLine();
                    //cmdBox.AppendText(newLine + "\n");
                    sr.Close();
                }
                catch
                {

                }
                
            }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void updateBut_Click(object sender, EventArgs e)
        {
            updateBut.Enabled = false;

            int testNum;
            int testNum2;
            if (currBox.Text == null || awardBox.Text == null || timeBox.Text == null || botBox.Text == null || oAuthBox.Text == null || streamBox.Text == null || !Int32.TryParse(awardBox.Text, out testNum) || !Int32.TryParse(timeBox.Text, out testNum2))
            {
                updateBut.Enabled = true;
                return;
            }

            StreamReader sr = new StreamReader(@".\src\config.py");
            List<string> strList = new List<string>();
            List<string> newList = new List<string>();

            string nextLine = "";
            while ((nextLine = sr.ReadLine()) != null)
            {
                strList.Add(nextLine);
            }
            sr.Close();

            newList.Add(strList[0]);
            newList.Add(strList[1]);
            newList.Add(strList[2]);
            newList.Add(strList[3]);
            newList.Add(strList[4]);
            newList.Add(strList[5]);
            newList.Add(strList[6]);
            newList.Add(strList[7]);

            newList.Add("NICK = \"" + botBox.Text + "\"");
            newList.Add("PASS = \"" + oAuthBox.Text + "\"");
            newList.Add("CHAN = \"#" + streamBox.Text + "\"");
            newList.Add("STREAMER = \"" + streamBox.Text + "\"");
            newList.Add("USERURL = 'https://tmi.twitch.tv/group/user/" + streamBox.Text + "/chatters'");

            newList.Add(strList[13]);

            newList.Add("CURR = \"" + currBox.Text + "\"");
            newList.Add("PANT = " + awardBox.Text);
            newList.Add("WAIT = " + timeBox.Text);

            newList.Add(strList[17]);
            newList.Add(strList[18]);
            newList.Add(strList[19]);
            newList.Add(strList[20]);
            newList.Add(strList[21]);
            newList.Add(strList[22]);

            File.WriteAllText(@".\src\config.py", string.Empty);

            StreamWriter sw = new StreamWriter(@".\src\config.py");
            for (int i = 0; i < newList.Count; i++)
            {
                sw.WriteLine(newList[i]);
            }
            sw.Close();

            updateBut.Enabled = true;
        }

        private void addCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void addModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void ReadConfig()
        {
            StreamReader sr = new StreamReader(@".\src\config.py");

            List<string> strList = new List<string>();

            string nextLine = "";
            while ((nextLine = sr.ReadLine()) != null)
            {
                strList.Add(nextLine);
            }
            sr.Close();

            int endLoc = strList[8].Length - 9;
            string botName = strList[8].Substring(8, endLoc);
            botBox.Text = botName;

            int endLoc2 = strList[9].Length - 9;
            string oAuth = strList[9].Substring(8, endLoc2);
            oAuthBox.Text = oAuth;

            int endLoc3 = strList[11].Length - 13;
            string streamerName = strList[11].Substring(12, endLoc3);
            streamBox.Text = streamerName;

            int endLoc4 = strList[14].Length - 9;
            string currName = strList[14].Substring(8, endLoc4);
            currBox.Text = currName;

            int endLoc5 = strList[15].Length - 7;
            string awName = strList[15].Substring(7, endLoc5);
            awardBox.Text = awName;

            int endLoc6 = strList[16].Length - 7;
            string tName = strList[16].Substring(7, endLoc6);
            timeBox.Text = tName;
        }

        private void OnExit(object sender, EventArgs e)
        {
            python.Kill();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
