using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetflixLookup.Models;
using NetflixLookup.Providers;

namespace NetflixLookup.Controllers
{
    public class FlixterController : Controller
    {
        //
        // GET: /Flixter/

        public ActionResult Index()
        {
            return View(new TitleSearch() { MaxResults = SettingsProvider.MaxSearchRecsults.ToString() });
        }

        public ActionResult Comps(string movieId, string maxResults, string subjectTitle, string subjectReleaseYear)
        {
            return View(new MovieGridModel() { SubjectID = movieId, MaxResults = maxResults, SubjectTitle = subjectTitle, SubjectReleaseYear = subjectReleaseYear });
        }

    }
}
