using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using OffshoreFundDebitOrderSystem.Controllers;


using System.Web.Mvc;
using System.Net;
using Newtonsoft.Json;
using System.Web;
using OffshoreFundDebitOrderSystem.Infrastructure;
using OffshoreFundDebitOrderSystem.Models;
using OffshoreFundDebitOrderSystem.Models.Infrastructure;
using OffshoreFundDebitOrderSystem.Models.ViewModels;

namespace OffshoreFundDebitOrderSystem.Models
{
    public class ExportToTextFile
    {
        public bool WriteToFile( Currency order)
        {

            string line = order.Name + "\t" +
                          order.SelectedCurrency.ToString() + "\t" +
                          order.ZARAmount.ToString() + "\t" +
                          order.ConvertedAmount.ToString() + "\t" +
                          order.OrderDate.ToString("D") + "\t" +
                          order.submitDate.ToString("D") + "\n";


            using (StreamWriter file = new StreamWriter(ConfigurationManager.AppSettings["TextFilePath"].ToString(),true))
            {
                file.WriteLine(line);
            }

                
                

            return true;
        }
    }
}