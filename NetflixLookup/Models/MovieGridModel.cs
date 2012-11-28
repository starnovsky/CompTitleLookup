using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetflixLookup.Models
{
    public class MovieGridModel
    {
        public List<TitleShortInfo> Movies { get; set; }
        public string MaxResults { get; set; }
        public string SubjectTitle { get; set; }
        public string SubjectReleaseYear { get; set; }
        public string SubjectID { get; set; }
    }
}