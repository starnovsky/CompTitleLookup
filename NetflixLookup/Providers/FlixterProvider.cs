using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

namespace NetflixLookup.Providers
{
    public class FlixterProvider
    {
        private const string ApiBase = "http://api.rottentomatoes.com/api/public/v1.0/";

        public string SearchTitles(string titleName, string maxResults)
        {

            // construct request
            var request = string.Format("{0}movies.json?apikey={1}&q={2}&page_limit={3}", ApiBase, SettingsProvider.FlixterApiKey, titleName, maxResults);

            return ReadResult(request);
        }

        public string GetSimilars(string id, string maxResults)
        {
            // construct request
            var request = string.Format("{0}movies/{1}/similar.json?apikey={2}&page_limit={3}", ApiBase, id, SettingsProvider.FlixterApiKey, maxResults);
            return ReadResult(request);
        }

        private string ReadResult(string request)
        {
            // make request
            string results = "";

            WebRequest req = WebRequest.Create(request);
            using (WebResponse rsp = req.GetResponse())
            {
                using (StreamReader sr = new StreamReader(rsp.GetResponseStream()))
                {
                    results = sr.ReadToEnd();
                }
            }

            return results;
        }
    }
}