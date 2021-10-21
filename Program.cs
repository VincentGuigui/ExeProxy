using System;
using System.Diagnostics;
using System.IO;

namespace ExeProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentExe = Process.GetCurrentProcess().MainModule.ModuleName;
            string exeToProxy = currentExe.Replace(".exe", ".proxy.exe");
            string log = currentExe.Replace(".exe", ".proxy.log");
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (!File.Exists(path + exeToProxy))
            {
                Console.WriteLine("ExeProxy");
                Console.WriteLine("--------");
                Console.WriteLine("ExeProxy allows you to capture usage of an executable, especially its command line arguments.");
                Console.WriteLine("");
                Console.WriteLine("Instructions:");
                Console.WriteLine("1. Rename the application executable you want to capture:");
                Console.WriteLine("   TheApp.exe => TheApp.proxy.exe");
                Console.WriteLine("2. Rename ExeProxy to match the original name of the application:");
                Console.WriteLine("   ExeProxy.exe => TheApp.exe");
                Console.WriteLine("");
                Console.WriteLine("Output:");
                Console.WriteLine("A log file will be created in the application directory: c:\\PathToApp\\TheApp.proxy.log");
                Console.WriteLine("If the directory is not writeable, the log will be in c:\\temp\\TheApp.proxy.log");
                Console.WriteLine("");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                return;
            }
            try
            {
                File.AppendAllText(path + log, "\n");
                log = path + log;
            }
            catch 
            {
                File.AppendAllText(@"c:\temp\" + log, "\n");
                log = @"c:\temp\" + log;
            }
            File.AppendAllText(log, exeToProxy + ": " + string.Join(' ', args) + "\n");
            Process p = Process.Start(new ProcessStartInfo(path + exeToProxy, string.Join(' ', args)));
            p.WaitForExit();
            File.AppendAllText(log, "Exit code: " + p.ExitCode + "\n");
            Environment.ExitCode = p.ExitCode;
        }
    }
}
