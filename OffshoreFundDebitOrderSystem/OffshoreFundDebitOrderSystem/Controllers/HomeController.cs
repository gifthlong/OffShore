using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Newtonsoft.Json;
using System.Web;
using OffshoreFundDebitOrderSystem.Infrastructure;
using OffshoreFundDebitOrderSystem.Models;
using OffshoreFundDebitOrderSystem.Models.Infrastructure;
using OffshoreFundDebitOrderSystem.Models.ViewModels;

namespace OffshoreFundDebitOrderSystem.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
           

            //Populate accounts
            //TODO: Find better way to generate the list
            List<OffshoreFund> getfunds = new List<OffshoreFund>()
            {
                new OffshoreFund{
                    Abbreviation="GBP",
                    FullName = "British Pounds"
                },
            
                new OffshoreFund{ Abbreviation="USD",
                        FullName = "US Dollar"
                },

                new OffshoreFund{ Abbreviation="EUR",
                        FullName = "Euro"
                },

                new OffshoreFund{ Abbreviation="ZAR",
                        FullName = "South-African Rand"
                }

            };

            IEnumerable<SelectListItem>  accountsVM = getfunds.Select(n => new SelectListItem
            {
                Value = n.Abbreviation,
                Text = n.FullName
            });

            return View(new HomeViewModel
                {
                    funds = accountsVM,
                    status = new ReturnStatus
                    {
                        isError = false,
                        iSeverity = 1,
                        sMessage = "No error"
                    },
                    currencies = new Currency()
                }
            );
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel model)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<ExchangeRate> currenciesVM = null;

                //Populate currencies
                using (var client = new WebClient())
                {

                    try
                    {
                        //for offline "[{'Name':'ZAR/AUD','Price':9.73},{'Name':'ZAR/BRL','Price':3.48},{'Name':'ZAR/CAD','Price':10.36},{'Name':'ZAR/CHF','Price':14.08},{'Name':'ZAR/DKK','Price':1.81},{'Name':'ZAR/EUR','Price':15.34},{'Name':'ZAR/GBP','Price':20.84},{'Name':'ZAR/HKD','Price':1.78},{'Name':'ZAR/KES','Price':0.13},{'Name':'ZAR/NOK','Price':1.62},{'Name':'ZAR/SEK','Price':1.64},{'Name':'ZAR/SGD','Price':9.65},{'Name':'ZAR/USD','Price':13.76}]";
                        string jsonExchangeRates = "[{'Name':'ZAR/AUD','Price':9.73},{'Name':'ZAR/BRL','Price':3.48},{'Name':'ZAR/CAD','Price':10.36},{'Name':'ZAR/CHF','Price':14.08},{'Name':'ZAR/DKK','Price':1.81},{'Name':'ZAR/EUR','Price':15.34},{'Name':'ZAR/GBP','Price':20.84},{'Name':'ZAR/HKD','Price':1.78},{'Name':'ZAR/KES','Price':0.13},{'Name':'ZAR/NOK','Price':1.62},{'Name':'ZAR/SEK','Price':1.64},{'Name':'ZAR/SGD','Price':9.65},{'Name':'ZAR/USD','Price':13.76}]";
                        //string jsonExchangeRates = client.DownloadString(Configurations.ExchangeUrl);

                        currenciesVM = JsonConvert.DeserializeObject<IEnumerable<ExchangeRate>>(jsonExchangeRates);
                    }
                    catch (System.NullReferenceException) //TODO: Catch the correct exception returned by WebClient object
                    {
                        model.status = new ReturnStatus
                        {
                            isError = true,
                            iSeverity = 5,
                            sMessage = "Unable to connection to the Exchange Rate Portal."
                        };
                    }
                    catch (Exception e)
                    {
                        model.status = new ReturnStatus
                        {
                            isError = true,
                            iSeverity = 5,
                            sMessage = "Error occured while working with the Exchange Rate Portal." + e.Message
                        };
                    }

                    //Calculate return rate
                    // decimal returnValue = currenciesVM.Select(n => n.Name.Split('/')[1])
                }
            }

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Save(HomeViewModel model)
        {
            return View("Index", model);
        }
    }
}
