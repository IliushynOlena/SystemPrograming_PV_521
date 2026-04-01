using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _06_AsyncAwait_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // 1 - freeze
            //int value = GenerateValue();
            //list.Items.Add(value);  

            //2 - freeze
            //Task<int> task = Task.Run(GenerateValue);
            //task.Wait(); //freeze
            //list.Items.Add(task.Result);//freeze


            //3 - async await 
            //async - allow method to use await keywords
            //await - wait task without freezing

            // Task<int> task = Task.Run(GenerateValue);
            // int value = await task;
            //// MessageBox.Show("Generated!");
            // list.Items.Add(value);

            //4 
            //int value = await GenerateValueAsync();
            //list.Items.Add(value);
         
            list.Items.Add(await GenerateValueAsync());


          
        }

        int GenerateValue()
        {
            Thread.Sleep(random.Next(5000));
           
            return (int)random.Next(0, 1000);
        }

        Task<int> GenerateValueAsync()
        {
            //return task
            return Task.Run(() =>
            {
                Thread.Sleep(random.Next(5000));
                return (int)random.Next(0, 1000);

            });          
        }
    }
}