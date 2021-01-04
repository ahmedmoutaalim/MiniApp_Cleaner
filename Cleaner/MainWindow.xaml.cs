using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using Microsoft.Win32;
using System.ComponentModel;
using System.Windows.Threading;
using System.Text.RegularExpressions;
using System.Windows.Media.Animation;
using System.Net;
using System.Diagnostics;
using System.IO.Compression;

namespace Cleaner
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double clientVersion = 1.0;




        public MainWindow()
        {
            InitializeComponent();
           
            ShowDate();
            string path = @"C:\Users\Youcode\source\repos\Cleaner\maj.txt";



            List<string> line = File.ReadAllLines(path).ToList();

            line.Reverse();

            string R = line[0];
            majDate.Text = R;
        }

      

        private void checkUpdate()
        {
            double strNewVersion = 1.1;

            //double newVersion = double.Parse(strNewVersion);

            if(clientVersion < strNewVersion)
            {
                WebClient client = new WebClient();
                client.DownloadFile("https://download944.mediafire.com/ka2ofp3obqyg/kpmyqm0mm7e349k/Cleaner.exe", @"C:\Users\Youcode\source\repos\Cleaner\Cleaner\bin\Release\Cleaner.exe");


                            ProcessStartInfo startInfo = new ProcessStartInfo();
                            startInfo.FileName = @"C:\Users\Youcode\source\repos\Cleaner\Cleaner\bin\Release\Cleaner.exe";

                            Process.Start(startInfo);
                            this.Close();

            }
            else
            {
                msg.Text = "c'est la derniére version !!";
            }

        // msg.Show();
        }

      /* private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Process.Start("https://www.dropbox.com/s/yv59diyfxq3w2fn/WindowUbdaterVersion.xaml?dl=0");
            Application.Current.Shutdown();
        }*/




        public void ShowDate()
        {

            string path = @"C:\Users\Youcode\source\repos\Cleaner\analyse.txt";

            List<string> line = File.ReadAllLines(path).ToList();

            line.Reverse();

            string R = line[0];
            Date_Analyse.Text = R;
        }



        private void BTN_Analyser(object sender, RoutedEventArgs e)
        {

            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Temp");

            long[] values = DirSize(dir);

            long size = values[0];
            long file = values[1];

            Analyse_text.Text = file.ToString() + " files  " + String.Format("{0:0.0}", (size / 1024)) + "  KB";
            textMsg.Text = "";



            string path = @"C:\Users\Youcode\source\repos\Cleaner\analyse.txt";


            if (!File.Exists(path))
            {
                using (var i = new StreamWriter(path, true))
                {

                    i.WriteLine(getdate() + "," + gettime());

                }
            }
            else
            {

                List<string> lines = File.ReadAllLines(path).ToList();

                lines.Add(getdate() + "," + gettime());

                File.WriteAllLines(path, lines);

            }

            ShowDate();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }




  
        private void progBar()
        {


            progress.Visibility = Visibility.Visible;
            Duration duration = new Duration(TimeSpan.FromSeconds(3));
            DoubleAnimation doubleAnimation = new DoubleAnimation(progress.Value + 100, duration);
            progress.BeginAnimation(ProgressBar.ValueProperty,doubleAnimation);

           

        }

       

        private void nettoyer_button(object sender,EventArgs e)
        {


            progBar();
          


            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Temp");

         

            //delete file and app
            foreach (FileInfo file in dir.EnumerateFiles())
            {

                
                try
                {
                    file.Delete();
                 
                   
                      
                 
                }
                catch
                {
                    continue;
               
                }
            }

            //delete folder
            foreach (DirectoryInfo di in dir.EnumerateDirectories())
            {

           
             
                try
                {
                  
                    di.Delete(true);
                }
                catch
                {
                  
                    continue;
                }



            }


            long[] values = DirSize(dir);
            long size = values[0];
            long fil = values[1];





            


                if (fil < 30)
                {


                    Analyse_text.Text = "0 files 0 KB";
                    textMsg.Text = "nettoyage est succès..." + progress.Value ;


                }
                else
                {


                    Analyse_text.Text = fil.ToString() + " files  " + String.Format("{0:0.0}", (size / 1024)) + "  KB";
                    textMsg.Text = "nettoyage est succès...";

                }
           
            
          
                string path = @"C:\Users\Youcode\source\repos\Cleaner\Text.txt";



            if (!File.Exists(path))
            {
                using (var i = new StreamWriter(path, true))
                {

                    i.WriteLine(getdate() + "," + gettime());

                }
            }
            else
            {

                List<string> lines = File.ReadAllLines(path).ToList();

                lines.Add(getdate() + "," + gettime());

                File.WriteAllLines(path, lines);

            }




        }

    




        public string getdate()
        {
            DateTime date = DateTime.Today;
            return date.ToString("d");
        }


        public string gettime()
        {
            DateTime date = DateTime.Now;
            return date.ToString("HH:mm");
        }


        private void Historique_Btn(object sender, RoutedEventArgs e)
        {

            historiquePage pg = new historiquePage();


            this.Content = pg;



        }


        private void Analyse2(object sender, RoutedEventArgs e)
        {



            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Temp");

            long[] values = DirSize(dir);

            long size = values[0];
            long file = values[1];

            Analyse_text.Text = file.ToString() + " files  " + String.Format("{0:0.0}", (size / 1024)) + "  KB";
            textMsg.Text = "";
        }



        public long[] DirSize(DirectoryInfo d)
        {
            long size = 0;
            long files = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();


            foreach (FileInfo fi in fis)

            {

                try
                {

                    size += fi.Length;
                    files += 1;




                }
                catch
                {
                    continue;
                }


            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di)[0];
                files += DirSize(di)[1];
            }
            long[] values = { size, files };
            return values;

        }

        private void progress_ValueChanged(object sender, ProgressChangedEventArgs e)
        {

            

        }

        private void maj(object sender, RoutedEventArgs e)
        {


           checkUpdate();

            string path = @"C:\Users\Youcode\source\repos\Cleaner\maj.txt";





            if (!File.Exists(path))
            {
                using (var i = new StreamWriter(path, true))
                {

                    i.WriteLine(getdate() + "," + gettime());

                }
            }
            else
            {

                List<string> lines = File.ReadAllLines(path).ToList();

                lines.Add(getdate() + "," + gettime());

                File.WriteAllLines(path, lines);

            }



        }
    }
  
}

