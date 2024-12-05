using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ConvertRequest
    {
        public string TargetCurrency { get; set; }
        public decimal Value { get; set; }
    }
}
