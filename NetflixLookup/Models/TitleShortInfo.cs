using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetflixLookup.Models
{
    public class TitleShortInfo
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string ReleaseYear { get; set; }
        public string ArtSmall { get; set; }
        public string ArtMedium { get; set; }
        public string ArtLarge { get; set; }
        public string Similars { get; set; }
    }
}