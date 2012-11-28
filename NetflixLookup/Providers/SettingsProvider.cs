using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetflixLookup.Providers
{
    public abstract class SettingsProvider
    {
        public static string ConsumerKey { get { return "vs7ga4dcgtssn4rjcbkane7w"; } }
        public static string SharedSecret { get { return "Stme8eGKa5"; } }
        public static int MaxSearchRecsults { get { return 25; } }

        public static string FlixterApiKey = "ghkd29w7224s7f467ehgqju9";
    }
}