using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace _08_FileManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      

        ViewModel model = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = model;
            fromTextBox.Text = model.Source = @"C:\Users\helen\Desktop\asP_NET\01_ASP.NET Core-20240115_181348-Meeting Recording.mp4";
            toTextBox.Text = model.Destination = @"C:\Users\helen\Desktop\Test";
            model.Progress = 0;

        }

        private void Source_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
               model.Source = dialog.FileName;
            }
        }

        private void Dest_Button_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();  
            dialog.IsFolderPicker = true;//work with folders
            if( dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                model.Destination = dialog.FileName;
            }          
        }

        private async void Copy_Button_Click(object sender, RoutedEventArgs e)
        {
            //source
            //destination
            //Copy file async
            string fileName = System.IO.Path.GetFileName(model.Source);

            //  C: \Users\helen\Desktop\Test/ + NameFile.txt
            string destFullPath = System.IO.Path.Combine(model.Destination, fileName);
            CopyProcessecInfo info = new CopyProcessecInfo()
            {
                Filename = fileName,
                Percentage = 0
            };
            model.AddProcess(info);
            await FileCopyAsync(model.Source, destFullPath, info);
            MessageBox.Show("File copied!!!");
        }

        private Task FileCopyAsync(string source , string dest, CopyProcessecInfo info)
        {
            return Task.Run(() =>
            {
                //1 - copy async
                //File.Copy(Source, dest, true);

                //2
                using FileStream srcStream = new FileStream(source, FileMode.Open, FileAccess.Read);
                using FileStream desStream = new FileStream(dest, FileMode.Create, FileAccess.Write);
                byte[] buffer = new byte[1024 * 8];//8Kb
                int bytes = 0;
                do
                {
                    bytes = srcStream.Read(buffer, 0, buffer.Length);
                    desStream.Write(buffer, 0, bytes);

                    float percentage = desStream.Length / (srcStream.Length / 100);
                    //progress.Value = percentage;    
                    model.Progress = percentage;
                    info.Percentage = percentage;


                } while (bytes > 0);


                //srcStream.Dispose
                //destStream.Dispose

            });
        }

        [AddINotifyPropertyChangedInterface]
        class CopyProcessecInfo
        {
            public string Filename { get; set; }
            public float Percentage { get; set; }
        }
        [AddINotifyPropertyChangedInterface]
        class ViewModel
        {
            private ObservableCollection<CopyProcessecInfo> processes;
            public string Source { get; set; }
            public string Destination { get; set; }
            public float Progress { get; set; }
            public bool IsWaiting => Progress == 0;
            public IEnumerable<CopyProcessecInfo> Processes => processes;//get - readonly
            public ViewModel()
            {
                processes = [];
            }
            public void AddProcess(CopyProcessecInfo info)
            {
                processes.Add(info);
            }
        }
    }
}