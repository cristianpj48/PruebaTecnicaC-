using System.Net.Http;
using System.Text.Json;
using System.Text;
using CurrencyConverterAPI;
using Newtonsoft.Json;
using Domain;

namespace WpfApp
{
    public class HttpHelper
    {
        private readonly HttpClient Client;

        public HttpHelper()
        {
            this.Client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5191/api/")
            };
        }

        public async Task<Response> LoginAsync(User user)
        {
            String Json = JsonConvert.SerializeObject(user);
            StringContent Content = new (Json, Encoding.UTF8, "application/json");
            HttpResponseMessage Response = await Client.PostAsync("Currency/Login", Content);
            String ResponseContent = await Response.Content.ReadAsStringAsync();
            Response DeserializedResponse = JsonConvert.DeserializeObject<Response>(ResponseContent);
            if (DeserializedResponse == null)
            {
                throw new InvalidOperationException("La respuesta no se pudo deserializar en un objeto válido de tipo Response.");
            }
            return DeserializedResponse;
        }

        public async Task<Response> GetCurrenciesAsync()
        {
            HttpResponseMessage Response = await Client.GetAsync("Currency/Currencies");
            String ResponseContent = await Response.Content.ReadAsStringAsync();
            Response DeserializedResponse = JsonConvert.DeserializeObject<Response>(ResponseContent);
            if (DeserializedResponse == null)
            {
                throw new InvalidOperationException("La respuesta no se pudo deserializar en un objeto válido de tipo Response.");
            }
            return DeserializedResponse;
        }

        public async Task<decimal> GetValueCurrenciesAsync(ConvertRequest request)
        {
            String Json = JsonConvert.SerializeObject(request);
            StringContent Content = new(Json, Encoding.UTF8, "application/json");
            HttpResponseMessage Response = await Client.PostAsync("Currency/Convert",Content);
            String ResponseContent = await Response.Content.ReadAsStringAsync();
            String DeserializedResponse = JsonConvert.DeserializeObject<Response>(ResponseContent).ResponseText;
            if (DeserializedResponse == null)
            {
                throw new InvalidOperationException("La respuesta no se pudo deserializar en un objeto válido de tipo Response.");
            }
            decimal Total = Convert.ToDecimal(DeserializedResponse);

            return Total;
        }
    }
}
