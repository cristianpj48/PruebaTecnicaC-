using CurrencyConverterAPI;
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

namespace WpfApp
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
        public async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            HttpHelper HttpHelper = new HttpHelper();
            User User = new()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Password
            };

            Response Response = await HttpHelper.LoginAsync(User);

            if (Response.State == State.Aceptado)
            {
                MessageBox.Show(Response.MessageText);
                //Abrimos la nueva ventana
                CurrencyConverter ConverterWindow = new();
                ConverterWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(Response.MessageText);
            }
        }
    }
}
