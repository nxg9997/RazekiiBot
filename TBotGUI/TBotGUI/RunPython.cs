using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace TBotGUI
{
    class RunPython
    {
        ProcessStartInfo pythonInfo = new ProcessStartInfo();
        Process python;

        public RunPython()
        {
            try
            {
                pythonInfo.FileName = @"C:\Users\Nate\AppData\Local\Programs\Python\Python36-32\python.exe";
                pythonInfo.Arguments = @"\TBot2.py";
                pythonInfo.CreateNoWindow = false;
                pythonInfo.UseShellExecute = true;
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
        }

        public void StartPython()
        {
            try
            {
                Console.WriteLine("Python Starting");
                python = Process.Start(pythonInfo);

                StreamWriter sw = python.StandardInput;
                StreamReader sr = python.StandardOutput;
                StreamReader er = python.StandardError;
                
                python.WaitForExit();
                python.Close();
            }
            catch(Exception exc)
            {
                Console.WriteLine("Error starting python script! " + exc.StackTrace);
            }
            
        }

        public void StopPython()
        {
            try
            {
                python.Kill();
            }
            catch
            {
                Console.WriteLine("Error stopping python");
            }
        }



    }
}
