/************************************************************
 * Authors: Subodh Shakya
 * Organization: University of Alabama in Hunstsville
 * Course: CS670-Computer Network
 * Date: 04.13.2014
 * Description: Currency.cs. Implements currency conversion service. 
 * However, only a sample conversion feature is provided so as to demonstrate multiple service availability 
 * in service providing server.
 *************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    public class Currency
    {
        public List<string> GetUSDEUR()
        {
            List<string> currencyExchangeList = new List<string>();
            currencyExchangeList.Add("1 USD = 0.72 EUR");
            return currencyExchangeList;
        }
    }
}
