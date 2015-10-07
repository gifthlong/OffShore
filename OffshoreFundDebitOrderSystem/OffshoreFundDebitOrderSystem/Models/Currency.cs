using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OffshoreFundDebitOrderSystem.Models;


namespace OffshoreFundDebitOrderSystem.Models
{
    public class Currency
    {
        private decimal _ConvertedAmount;

        public string Name { get; set; }
        public ExchangeRate ExchangeRate;
        public EnumActiveAccounts SelectedCurrency { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal ZARAmount { get; set; }

        public decimal ConvertedAmount
        {
            get { return _ConvertedAmount; }
            set
            {
                _ConvertedAmount = ZARAmount / ExchangeRate.rate;
            }
        }
    }
}