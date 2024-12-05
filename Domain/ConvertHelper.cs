using CurrencyConverterAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ConvertHelper
    {
        public Response Process(string targetCurrency, decimal value)
        {
            try
            {
                GetCurrencies GetCurrencies = new GetCurrencies();
                Response CurrencyResponse = GetCurrencies.Process();

                if (CurrencyResponse.State != State.Aceptado)
                {
                    return new Response
                    {
                        State = State.Rechazado,
                        MessageText = "No se pudieron obtener las tasas de cambio.",
                        ResponseText = CurrencyResponse.ResponseText
                    };
                }

                List<Currency> Currencies = JsonConvert.DeserializeObject<List<Currency>>(CurrencyResponse.ResponseText);

                var TargetCurrencyData = Currencies.FirstOrDefault(c => c.Name == targetCurrency);
                if (TargetCurrencyData == null)
                {
                    return new Response
                    {
                        State = State.Rechazado,
                        MessageText = $"La moneda {targetCurrency} no fue encontrada.",
                        ResponseText = String.Empty
                    };
                }

                // Realizar la conversión
                decimal ConvertedValue = TargetCurrencyData.Convert(targetCurrency, value);

                return new Response
                {
                    State = State.Aceptado,
                    MessageText = "Conversión realizada exitosamente.",
                    ResponseText = ConvertedValue.ToString()
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    State = State.Rechazado,
                    MessageText = "Error durante el procesamiento de la conversión.",
                    ResponseText = ex.Message
                };
            }
        }
    }
}

