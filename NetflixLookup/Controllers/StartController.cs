using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetflixLookup.Providers;
using NetflixLookup.Parsers;
using NetflixLookup.Models;

namespace NetflixLookup.Controllers
{
    public class StartController : Controller
    {
        //
        // GET: /Start/

        public ActionResult Index()
        {
            return View(new TitleSearch() { MaxResults = SettingsProvider.MaxSearchRecsults.ToString() });
        }

        [HttpPost]
        public ActionResult Index(TitleSearch model)
        {
            return RedirectToAction("Titles", new { term = model.TitleName, maxResults = model.MaxResults });
        }

        public ActionResult Titles(string term, string maxResults)
        {
            NetflixProvider provider = new NetflixProvider();
            var response = provider.SearchTitles(term, maxResults);

            NetflixParser parser = new NetflixParser();
            var model = parser.ParseTitleSearch(response);

            return View(new MovieGridModel() { Movies = model, MaxResults = maxResults });
        }


        public ActionResult Comps(string movieId, string maxResults, string subjectTitle, string subjectReleaseYear)
        {
            NetflixProvider provider = new NetflixProvider();
            var response = provider.GetSimilars(movieId, maxResults);

            NetflixParser parser = new NetflixParser();
            var model = parser.ParseCompSearch(response);

            return View(new MovieGridModel() { Movies = model, MaxResults = maxResults, SubjectTitle = subjectTitle, SubjectReleaseYear = subjectReleaseYear });
        }

        [HttpPost]
        public JsonResult GetTitles(string term, string maxResults)
        {
            NetflixProvider provider = new NetflixProvider();
            var response = provider.SearchTitles(term, maxResults);

            NetflixParser parser = new NetflixParser();
            var model = parser.ParseTitleSearch(response);

            return Json(model);
        }

        [HttpPost]
        public JsonResult GetComps(string movieId, string maxResults)
        {
            NetflixProvider provider = new NetflixProvider();
            var response = provider.GetSimilars(movieId, maxResults);

            NetflixParser parser = new NetflixParser();
            var model = parser.ParseCompSearch(response);

            return Json(model);
        }

    }
}
