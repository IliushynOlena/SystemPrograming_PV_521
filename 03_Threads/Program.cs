namespace _03_Threads
{
    internal class Program
    {
        static void Method()
        {
            Console.WriteLine($"Id of method thread : {Thread.CurrentThread.GetHashCode()}");
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"\t\t\t{i} - Hello in thread.");
                Thread.Sleep(50);
            }
        }
        static void MethodWithParams(object? a)
        {
            //Tuple<int, int> tuple = new Tuple<int, int>(25, 50);
           
            string name = (string)a!;
            //Console.WriteLine(name);
            //string name2 = a?.ToString()!;
            //Console.WriteLine(name);
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"\t\t\t{i} - {name}.");
                //Thread.Sleep(50);
            }
        }
        static void Main(string[] args)
        {
            #region Example 1
            //int a = 5;
            //MethodWithParams(a);
            ///string name = "Ira";
            //MethodWithParams(name);
            //ParameterizedThreadStart
            //ThreadStart start = new ThreadStart(Method);
            //Thread thread = new Thread(start);
            //Thread thread = new Thread(new ThreadStart(Method));
            //Thread thread = new Thread(Method);
            //thread.Start();
            //Method();
            #endregion



            #region Example 2
            /*
             * Thread Priority
             * Highest
             * AboveNormal
             * Normal
             * BelowNormal
             * Lowest
             
             */
            //Thread thread1 = new Thread(MethodWithParams);
            //thread1.Priority = ThreadPriority.Lowest;
            //thread1.Start("One");

            //Thread thread2 = new Thread(MethodWithParams);
            //thread2.Priority = ThreadPriority.Highest;
            //thread2.Start("\t\tTwo");

            ////Priority (Normal)
            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine($"{i} - Hello in main.");
            //}
            #endregion



            #region Example 3
            //Thread thread = new Thread(Method); 
            //thread.IsBackground = true;
            //thread.Start();

            ////thread.Suspend();
            ////thread.Resume();
            ////thread.Abort();//close thread

            //Console.WriteLine($"Id of main thread : {Thread.CurrentThread.GetHashCode()}");
            //Console.ReadKey();
            //Console.WriteLine("Main thread");

            #endregion


            #region TestThreads
            //ConsoleKeyInfo input;
            //do 
            //{ 
            //    input = Console.ReadKey();
            //    Thread thread = new Thread(InfinityLoop);
            //    thread.Start();
            //    //InfinityLoop();

            //} while (input.Key != ConsoleKey.Escape);


            #endregion

            #region Wait Thread
            Thread thread = new Thread(Method);
            Console.WriteLine("Thread is going start.....");
            thread.Start();

            Thread.Sleep(200);
            Console.WriteLine("Waiting for the end thread");
            thread.Join();  
            Console.WriteLine("Program was ended...");
            #endregion
        }
        static void InfinityLoop()
        {
            Console.WriteLine("Thread has been started.");
            while (true)
            {
                int a = 5;
                int b = 7;
                int c = a + b;
                new Random().Next(100);
            }
        }
    }
   
}
