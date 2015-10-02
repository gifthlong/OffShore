using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffshoreFundDebitOrderSystem.Models.Infrastructure
{
    /// <summary>
    /// Include in all view models to control status for user.
    /// </summary>
    public class ReturnStatus
    {
        public bool isError { get; set; }
        public int iSeverity { get; set; } //1: not too bad - 5: "it's dead Jim"
        public string sMessage { get; set; }
    }
}
