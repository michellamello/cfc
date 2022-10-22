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
using System.Windows.Shapes;
using MongoDB.Bson;
using MongoDB.Driver;


namespace cfc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var settings = MongoClientSettings.FromConnectionString("");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("");

            
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            string cabecalhoMsgSaida = "Confirmar saída";
            string textoMsgSaida = "Tem certeza que deseja sair? Todas as informações não salvas serão perdidas!";
            MessageBoxButton btn = MessageBoxButton.YesNo;
            MessageBoxImage messageBoxImage = MessageBoxImage.Warning;
            MessageBoxResult result;

            result = MessageBox.Show(textoMsgSaida, cabecalhoMsgSaida, btn, messageBoxImage);

            if(result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnMaximizar_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                btnMaximizar.ToolTip = "Maximizar";
                WindowState = WindowState.Normal;
            }
            else
            {
                btnMaximizar.ToolTip = "Restaurar";
                WindowState = WindowState.Maximized;
            }
            
        }

        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnConta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
