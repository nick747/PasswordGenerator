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

namespace PasswordGe_Ster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int length = int.Parse(lunghezza.Text);
            string preferredWord = parola.Text;

            password.Text = GeneraPassword(length, preferredWord);
        }

        public string GeneraPassword(int lunghezza, string preferredWord)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            const string validSymbols = "!@#$%^&*_-+=|;:\",.?";
            Random random = new Random();
            string randomChars = new string(Enumerable.Repeat(validChars, lunghezza - preferredWord.Length - 1).Select(s => s[random.Next(s.Length)]).ToArray());

            string randomSymbol = new string(Enumerable.Repeat(validSymbols, 1).Select(s => s[random.Next(s.Length)]).ToArray());

            if (preferredWord.Length == 0)
            {
                return randomChars + randomSymbol;
            } else
            {
                return randomChars + "+" + preferredWord + randomSymbol;
            }
        }
    }

}


