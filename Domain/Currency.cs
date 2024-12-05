using System;

namespace CurrencyConverterAPI
{
    public class Currency
    {
        public String Name { get; set; }
        public decimal Rate { get; set; }
        public DateTime CurrentDate { get; set; }

        public decimal Convert(String targetCurrency, decimal value)
        {
            return value * Rate;
        }
    }
}
