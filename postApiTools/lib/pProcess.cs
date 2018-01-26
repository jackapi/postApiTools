using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postApiTools.lib
{
    public class pProcess
    {

        /// <summary>
        /// cmd执行
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static string ExeCommand(string commandText)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            string strOutput = null;
            try
            {
                p.Start();
                p.StandardInput.WriteLine(commandText);
                p.StandardInput.WriteLine("exit");
                strOutput = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                p.Close();
            }
            catch (Exception e)
            {
                strOutput = e.Message;
            }
            return strOutput;
        }

    }
}
