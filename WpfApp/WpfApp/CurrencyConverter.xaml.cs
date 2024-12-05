using CurrencyConverterAPI;
using Domain;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Documents;

namespace WpfApp
{
    public partial class CurrencyConverter : Window
    {
        public CurrencyConverter()
        {
            InitializeComponent();
            LoadCombo();
        }

        private async void LoadCombo()
        {
            HttpHelper HttpHelper = new HttpHelper();
            Response CurrienciesResponse = await HttpHelper.GetCurrenciesAsync();
            List<Currency> CurrenciesJson = JsonConvert.DeserializeObject<List<Currency>>(CurrienciesResponse.ResponseText);
            List<Currency> CurrenciesList = new List<Currency>(CurrenciesJson);
            if (CurrienciesResponse.State == State.Aceptado)
            {
                cmbTo.Items.Clear();
                foreach (Currency Currency in CurrenciesList)
                {
                    if (Currency.Name != "USD")
                    {
                        cmbTo.Items.Add(Currency.Name);
                    }
                }
            }
            else
            {
                MessageBox.Show("Fallo en cargar las monedas para la conversion.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private async void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            decimal Amount = Convert.ToDecimal(txtAmount.Text);
            String SelectedCurrency = cmbTo.SelectedItem.ToString();
            HttpHelper HttpHelper = new();
            ConvertRequest ConvertHelper = new ConvertRequest
            {
                TargetCurrency = SelectedCurrency,
                Value = Amount
            };
                // Realiza el cálculo y trunca a dos decimales.
                decimal Total = await HttpHelper.GetValueCurrenciesAsync(ConvertHelper);
                // Formatea con dos decimales.
                txtTotal.Text = Total.ToString();
        }
    }
}

