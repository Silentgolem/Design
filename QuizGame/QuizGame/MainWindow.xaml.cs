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

namespace QuizGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Player User = new Player();
        public MainWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Login LoginScreen = new Login();
            LoginScreen.Owner = this;
            LoginScreen.ShowDialog();
        }

        private void btnChallenge_Click(object sender, RoutedEventArgs e)
        {
            LaunchGame("Challenge");
        }

        private void btnEndless_Click(object sender, RoutedEventArgs e)
        {
            LaunchGame("Endless");
        }

        private void btnSession_Click(object sender, RoutedEventArgs e)
        {
            LaunchGame("Session");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LaunchGame(string Type)
        {
            Application.Current.Properties["GameType"] = Type;
            GameSession GameScreen = new GameSession();
            GameScreen.Owner = this;
            GameScreen.ShowDialog();
        }
    }
}
