using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CurrencyConverterAPI
{
    public class GetCurrencies
    {
        private static readonly List<Currency> Currencies = new List<Currency>();
        public Response Process()
        {
            try
            {
                HttpClient Client = new HttpClient();
                String Response = Client.GetStringAsync("https://api.coinbase.com/v2/exchange-rates?currency=USD").Result;
                CurrenciesResponse CurrenciesResponse = JsonConvert.DeserializeObject<CurrenciesResponse>(Response);

                Currencies.Clear();

                foreach (var rate in CurrenciesResponse.Data.Rates)
                {
                    if (rate.Key != "USD")
                    {
                        Currency currency = new Currency
                        {
                            Name = rate.Key,
                            Rate = decimal.Parse(rate.Value),
                            CurrentDate = DateTime.Now
                        };
                        Currencies.Add(currency);
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
