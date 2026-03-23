using System.Diagnostics;

namespace _01_IntroToProcesses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Process process = new Process();    

            /*Process current = Process.GetCurrentProcess();
            current.PriorityClass = ProcessPriorityClass.High;
            Console.WriteLine("------Current process info");
            Console.WriteLine($"Priority Class : {current.PriorityClass}");
            Console.WriteLine($"Name : {current.ProcessName}");
            Console.WriteLine($"Id : {current.Id}");
            Console.WriteLine($"Machine Name : {current.MachineName}");
            Console.WriteLine($"Private memoory size : {current.PrivateMemorySize64/1024}");
            Console.WriteLine($"Start time : {current.StartTime}");
            Console.WriteLine($"TotalProcessorTime : {current.TotalProcessorTime}");
            Console.WriteLine($"UserProcessorTime : {current.UserProcessorTime}");
            */

            /*
            Process[] processes = Process.GetProcesses();
            Console.WriteLine("Name\t\t\tPID\t\t\tPriority\t\t\tMachine name");
            foreach (var p in processes)
            {
                try
                {
                    Console.WriteLine($"{p.ProcessName}\t" +
                    $"{p.Id}\t{p.PriorityClass}\t{p.MachineName}\t" +
                    $"{p.StartTime}");

                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine(p.ProcessName);
                    Console.ResetColor();
                }
                
            }
            */

            //Process.Start("MicrosoftEdge.exe", "google.com stackoverflow.com");
            //Process.Start("Calc.exe");
            //Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe","google.com stackoverflow.com");


            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = @"notepad",
                Arguments = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\TestProcess.txt",
                WindowStyle = ProcessWindowStyle.Maximized
            };

            Process pr = Process.Start(info);
            Console.ReadKey();
            //pr.Kill();//End TAsk
            //pr.CloseMainWindow();//Alt+F4
            //pr.Close();//clear reference

            Console.WriteLine("Wait for exit....");

            pr.WaitForExit();
            Console.WriteLine($"Exit code : {pr.ExitCode}");
            Console.WriteLine($"Exit time : {pr.ExitTime}");

            Console.ReadKey();
        }
    }
}
