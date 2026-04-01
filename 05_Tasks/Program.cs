namespace _05_Tasks
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public override string ToString()
        {
            return $"{Title}. {Author}";
        }
    }
    internal class Program
    {
        static void Display()
        {
            Console.WriteLine("Start method Display");
            Console.WriteLine("Task 1: ");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            /// some code
            Console.WriteLine("End method Display");
        }
        static void Method1()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(i);
            }
        }
        //static void Method2()
        //{
        //    for (int i = 51; i < 100; i++)
        //    {
        //        Console.WriteLine(i);
        //    }
        //}
        //static void Method3()
        //{
        //    for (int i = 101; i < 150; i++)
        //    {
        //        Console.WriteLine(i);
        //    }
        //}
        static void Main(string[] args)
        {

            //ThreadStart
            //Thread thread1 = new Thread(Method1);//void ()
            //Thread thread2 = new Thread(delegate ()
            //{
            //    for (int i = 51; i < 100; i++)
            //    {
            //        Console.WriteLine(i);
            //    }

            //});//void (object obj)
            //Thread thread3 = new Thread(() =>
            //{
            //    for (int i = 101; i < 150; i++)
            //    {
            //        Console.WriteLine(i);
            //    }
            //});

            //thread1.Start();
            //thread2.Start();
            //thread3.Start();




            #region Task            
            /*
            Task task1 = new Task(Display); //Task (Thread t = new Thread())
            task1.Start();

            //start automatically

            Task task2 = Task.Factory.StartNew(() => Console.WriteLine($"Task 2 : Id " +
                $"{Thread.CurrentThread.ManagedThreadId}"));

            Task task3 = Task.Run(() => Console.WriteLine($"Task 3 . From thread : " +
                $"{Thread.CurrentThread.ManagedThreadId}"));


            Console.WriteLine("End Method Main ");
            Console.ReadKey();
            */
            #endregion
            #region Task Methods
            //Task task1 = new Task(Display); //Task (Thread t = new Thread())
            //task1.Start();
            //task1.Wait();// waiting ...... (freeze )
            //Console.WriteLine("Task end work");
            #endregion
            #region Array Tasks
            /*
            Random random = new Random();   
            Task[] tasks = new Task[3]
            {
                new Task(()=> Console.WriteLine("First Taks")),
                new Task(()=> Console.WriteLine("Second Taks")),
                new Task(()=> Console.WriteLine("Third Taks"))
            };
            foreach (var task in tasks)
                task.Start();
            Task.WaitAll(tasks);//freeze
            Console.WriteLine("All task have done!");

            Task[] task2 = new Task[3];
            int j = 0;
            for (int i = 0; i < task2.Length; i++)
            {
                task2[i] = Task.Run(() =>
                {
                    Thread.Sleep(random.Next(5000));
                    Console.WriteLine($"Task {++j} work");
                });
            }

            Task.WaitAny(task2);
            Console.WriteLine("Any task have done!");
            Console.ReadKey();
            
            */
            #endregion
            #region ContinueWith
            /*
            Task task = new Task(() =>
            {
                Console.WriteLine($"Task Id : {Task.CurrentId}");
                Thread.Sleep(1000);
            });

            Task continueTask = task.ContinueWith(Display2)
                .ContinueWith(Display2)
                .ContinueWith(Display2);

            task.Start();

            continueTask.Wait();
            Console.WriteLine("Main is working.....");
            Console.ReadLine();
            */
            #endregion
            #region Task Return
        
            Task<int> task = new Task<int>(() => Factorial(5, 88, 9, "Hello "));

            Task<int> sumTask = task.ContinueWith(Summa);

            task.Start();
         
            Console.WriteLine(task.Result);
            Console.WriteLine("------------------------------------");
            Console.WriteLine(sumTask.Result);

            Task<Book> task3 = new Task<Book>(() =>
            {
                Thread.Sleep(3000);
                return new Book { Title = "Harry Potter", Author = "Diana Rouling" };
            });

            task3.Start();

            task3.Wait();//freeze//

            Book b = task3.Result;//freeze
            Console.WriteLine($"{b.Title} . {b.Author}");

            Console.ReadLine();
            
            #endregion
        }
        static int Summa(Task<int> prev_task)
        {
            int sum = prev_task.Result + prev_task.Result;
            return sum;
        }
        static int Factorial(int x, int a, int b, string text)//5! = 1*2*3*4*5
        {
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(text);
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            return result;
        }
        static void Display2(Task prev)
        {
            Console.WriteLine("Start method Display");
            Console.WriteLine($"Task id : {Task.CurrentId}");
            Console.WriteLine($"Previus Task id : {prev.Id}");

            /// some code
            Console.WriteLine("End method Display");
        }
    }
}
