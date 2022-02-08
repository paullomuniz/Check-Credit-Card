using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Check_Credit_Card
{
    class Func
    {

        public static string CheckValidity(string strCardNumber)
        {
            string strJsonString = (new WebClient()).DownloadString("https://bin-check-dr4g.herokuapp.com/api/" + strCardNumber);

            JObject o = JObject.Parse(strJsonString);

            if ((string)o["message"] == "Search Successful")
            {
                return "true";
            }
            else
            {
                return "false";
            }

        }








    }
}
