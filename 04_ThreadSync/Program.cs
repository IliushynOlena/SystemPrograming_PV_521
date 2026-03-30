using System.Net.Http.Headers;

namespace _04_ThreadSync
{
    class Counter
    {
        public static int count = 0;
    }
    class LockCounter
    {
        int number;//2
        int evenNumber;//2
        public int Number { get { return number; } }
        public int EvenNumbers { get { return evenNumber; } }
        public void UpdateFiels()
        {
            for (int i = 0; i < 1_000_000; i++)
            {
                lock(this)
                    {
                    number++;// 2
                    if (number % 2 == 0)
                        evenNumber++;

                }
              
            }
        }
    }
    static class LockCounterStatic
    {
        static int number;//2
        static int evenNumber;//2
        public static int Number { get { return number; } }
        public static int EvenNumbers { get { return evenNumber; } }
        public static void UpdateFiels()
        {
            for (int i = 0; i < 1_000_000; i++)
            {
                lock (typeof(LockCounterStatic))
                {
                    number++;// 2
                    if (number % 2 == 0)
                        evenNumber++;

                }

            }
        }
    }
    class Statistic
    {
        public static int CountLetters { get; set; }
        public static int CountNumbers { get; set; }

    }
    internal class Program
    {
        static void CountNumber()
        {
            for (int j = 0; j < 1_000_000; j++)
            {
                ++Counter.count;
                Console.WriteLine(Counter.count);
            }
        }
        static void Main(string[] args)
        {
            string root = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Test" ;
            string[] files = Directory.GetFiles(root);
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
            //Files - 5  Threads = 5
            //TextAnalize(string text);




            #region Thread Problem


            //for (int i = 0; i < 5; i++)
            //{
            //    CountNumber();
            //}

            //Thread[] threads = new Thread[5];
            ////void Func()
            ////void Func(object obj)

            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i] = new Thread(
            //        delegate ()
            //        {
            //            for (int j = 0; j < 1_000_000; j++)
            //            {
            //                ++Counter.count;
            //            }
            //        });
            //    threads[i].Start();
            //}

            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i].Join();
            //}
            ////Console.ReadKey();
            //Console.WriteLine($"Counter : {Counter.count}");
            #endregion
            #region Thread Sync
            //Thread[] threads = new Thread[5];
            ////void Func()
            ////void Func(object obj)
            ////Interlocked.Increment - add + 1
            ////Interlocked.Decrement - add - 1
            ////Interlocked.Add - add + value
            ////Interlocked.Exchange - add - value

            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i] = new Thread(
            //        delegate ()
            //        {
            //            for (int j = 0; j < 1_000_000; j++)
            //            {
            //                Interlocked.Increment(ref Counter.count);
            //            }
            //        });
            //    threads[i].Start();
            //}

            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i].Join();
            //}
            ////Console.ReadKey();
            //Console.WriteLine($"Counter : {Counter.count}");
            #endregion
            #region Lock Counter
            LockCounter counter = new LockCounter();
            Thread[] threads = new Thread[5];

            for (int i = 0; i < threads.Length; i++)
            {
       
                threads[i] = new Thread(counter.UpdateFiels);
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }
            //Console.ReadKey();
            Console.WriteLine($"All numbers : {counter.Number}");//5_000_000
            Console.WriteLine($"Even numbers : {counter.EvenNumbers}");//2_500_000
            #endregion

        }
    }
}
