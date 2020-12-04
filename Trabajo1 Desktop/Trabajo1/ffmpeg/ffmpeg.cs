using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo1.ffmpeg
{
    class Ffmpeg
    {
        public static void Enviarcmd(string cmd)
        {


            
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c " + cmd);



            
            procStartInfo.CreateNoWindow = true;
            
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            
            procStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo = procStartInfo;
            proc.Start();



        }
    }
}
