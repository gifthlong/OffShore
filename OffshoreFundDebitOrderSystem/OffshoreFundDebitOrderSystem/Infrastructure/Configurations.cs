using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OffshoreFundDebitOrderSystem.Infrastructure
{
    public class Configurations
    {
        public static string ExchangeUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["ExchangeRateUrl"];
            }
        }
    }
}
