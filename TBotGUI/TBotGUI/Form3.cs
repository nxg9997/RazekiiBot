using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TBotGUI
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            newList.Add(strList[8]);
            newList.Add(strList[9]);
            newList.Add(strList[10]);
            newList.Add(strList[11]);
            newList.Add(strList[12]);
            newList.Add(strList[13]);
            newList.Add(strList[14]);
            newList.Add(strList[15]);
            newList.Add(strList[16]);
            newList.Add(strList[17]);

            string modStr = strList[18];
            int modLength = modStr.Length;
            modStr = modStr.Substring(0, modLength - 1);
            modStr += ", '" + textBox1.Text + "']";

            newList.Add(modStr);

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

            this.Close();
        }
    }
}
