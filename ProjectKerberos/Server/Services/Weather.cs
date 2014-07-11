/************************************************************
 * Authors: Subodh Shakya
 * Organization: University of Alabama in Hunstsville
 * Course: CS670-Computer Network
 * Date: 04.14.2014
 * Description: Weather.cs. Implements weather forecasting service. 
 * However, only a sample weather details is available to demonstrate multiple service availability in service providing 
 * server.
 *************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    public class Weather
    {
        private static Dictionary<string,string> temperatureDictionary;
        public Weather ()
	    {
            temperatureDictionary = new Dictionary<string,string>();
            temperatureDictionary.Add("SUNDAY","10 F");
            temperatureDictionary.Add("MONDAY","13 F");
            temperatureDictionary.Add("TUESDAY","12 F");
            temperatureDictionary.Add("WEDNESDAY","19 F");
            temperatureDictionary.Add("THURSDAY","21 F");
            temperatureDictionary.Add("FRIDAY","18 F");
            temperatureDictionary.Add("SATURDAY","15 F");            
	    }
        public List<string> GetTemperatureToday()
        {
            List<string> temperatureList = new List<string>();
            temperatureList.Add(temperatureDictionary[DateTime.Today.DayOfWeek.ToString().ToUpper()]);
            return temperatureList;
        }

        public List<string> GetTemperatureOfWeek()
        {
            List<string> temperatureList = new List<string>();
            temperatureList.Add(temperatureDictionary["SUNDAY"]);
            temperatureList.Add(temperatureDictionary["MONDAY"]);
            temperatureList.Add(temperatureDictionary["TUESDAY"]);
            temperatureList.Add(temperatureDictionary["WEDNESDAY"]);
            temperatureList.Add(temperatureDictionary["THURSDAY"]);
            temperatureList.Add(temperatureDictionary["FRIDAY"]);
            temperatureList.Add(temperatureDictionary["SATURDAY"]);

            return temperatureList;
        }
    }
}
