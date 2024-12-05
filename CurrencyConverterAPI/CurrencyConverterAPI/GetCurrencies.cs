using Newtonsoft.Json;

namespace CurrencyConverterAPI
{
    public class GetCurrencies
    {
        private static readonly List<Currency> Currencies = [];
        public Response Process()
        {
            try
            {
                HttpClient Client = new();
                String Response = Client.GetStringAsync("https://api.coinbase.com/v2/exchange-rates?currency=USD").Result;
                CurrenciesResponse CurrenciesResponse = JsonConvert.DeserializeObject<CurrenciesResponse>(Response);

                Currencies.Clear();

                foreach (KeyValuePair<String,String> Rate in CurrenciesResponse.Data.Rates)
                {
                    if (Rate.Key != "USD")
                    {
                        Currency Currency = new()
                        {
                            Name = Rate.Key,
                            Rate = decimal.Parse(Rate.Value),
                            CurrentDate = DateTime.Now
                        };
                        Currencies.Add(Currency);
                    }
                }
                return new Response
                {
                    State = State.Aceptado,
                    MessageText = "Tasas de cambio obtenidas exitosamente",
                    ResponseText = JsonConvert.SerializeObject(Currencies)
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    State = State.Rechazado,
                    MessageText = "Error al obtener tasas de cambio",
                    ResponseText = ex.Message
                };
            }
        }
    }

}
