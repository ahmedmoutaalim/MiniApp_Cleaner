using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Cleaner
{
    /// <summary>
    /// Logique d'interaction pour historiquePage.xaml
    /// </summary>
    public partial class historiquePage : Page
    {
        public historiquePage()
        {

            InitializeComponent();
            string path = @"C:\Users\Youcode\source\repos\Cleaner\Text.txt";


            List<string> lines = File.ReadAllLines(path).ToList();
            lines.Reverse();

            string[] entries = lines[0].Split(',');

            firstDate.Text = entries[0];
            firstTime.Text = entries[1];


            string[] entries1 = lines[1].Split(',');

            secondDate.Text = entries1[0];
            secondTime.Text = entries1[1];

        }

        private void Button_Click(object sender, RoutedEventArgs e) {

           
            new MainWindow().Show();
            Application.Current.Windows[0].Close();
            // fermer un application
            // Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            // Application.Current.Shutdown();
        }

    
    }
}
