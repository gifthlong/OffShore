using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OffshoreFundDebitOrderSystem.Models.Infrastructure;
using System.Web.Mvc;

namespace OffshoreFundDebitOrderSystem.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Currency> currencies { get; set; }
        public IEnumerable<SelectListItem> funds { get; set; }
        public ReturnStatus status { get; set; }
    }
}
