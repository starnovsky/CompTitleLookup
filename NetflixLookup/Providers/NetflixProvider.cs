using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

namespace NetflixLookup.Providers
{
    public class NetflixProvider
    {
        public string SearchTitles(string titleName, string maxResults)
        {
            OAuth.OAuthBase oauth = new OAuth.OAuthBase();

            // add inputs
            Uri requestUrl = new Uri("http://api-public.netflix.com/catalog/titles/");
            oauth.AddQueryParameter("term", titleName);
            oauth.AddQueryParameter("max_results", maxResults);

            // prepare outputs
            string normalizedUrl;
            string normalizedRequestParameters;

            // generate request signature
            string sig = oauth.GenerateSignature(requestUrl,
                                                 SettingsProvider.ConsumerKey, 
                                                 SettingsProvider.SharedSecret,
                                                 null, 
                                                 null,		// token , tokenSecret (not needed)
                                                 "GET", 
                                                 oauth.GenerateTimeStamp(), 
                                                 oauth.GenerateNonce(),
                                                 out normalizedUrl, 
                                                 out normalizedRequestParameters);
            // construct request
            var request = requestUrl + "?" +
                            normalizedRequestParameters +
                            "&oauth_signature=" + oauth.UrlEncode(sig);
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

        public string GetSimilars(string id, string maxResults)
        {
            OAuth.OAuthBase oauth = new OAuth.OAuthBase();

            // add inputs
            Uri requestUrl = new Uri("http://api-public.netflix.com/catalog/titles/movies/" + id + "/similars");
            oauth.AddQueryParameter("max_results", maxResults);

            // prepare outputs
            string normalizedUrl;
            string normalizedRequestParameters;

            // generate request signature
            string sig = oauth.GenerateSignature(requestUrl,
                                                 SettingsProvider.ConsumerKey,
                                                 SettingsProvider.SharedSecret,
                                                 null,
                                                 null,		// token , tokenSecret (not needed)
                                                 "GET",
                                                 oauth.GenerateTimeStamp(),
                                                 oauth.GenerateNonce(),
                                                 out normalizedUrl,
                                                 out normalizedRequestParameters);
            // construct request
            var request = requestUrl + "?" +
                            normalizedRequestParameters +
                            "&oauth_signature=" + oauth.UrlEncode(sig);
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