using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _07_CopyFileAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //C:\Users\helen\Desktop\TestFrom\HW.txt
            //C:\Users\helen\Desktop\TestTo
            fromTb.Text = @"C:\Users\helen\Desktop\TestFrom\HW.txt";
            toTb.Text = @"C:\Users\helen\Desktop\TestTo";
            progressBar.Value = 10;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(fromTb.Text);
            MessageBox.Show(toTb.Text);

        }
    }
}