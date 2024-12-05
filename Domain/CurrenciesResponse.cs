using System.Collections.Generic;

namespace CurrencyConverterAPI
{
    public class CurrenciesResponse
    {
        public CurrenciesData Data { get; set; }
    }

    public class CurrenciesData
    {
        public Dictionary<string, string> Rates { get; set; }
    }

}
