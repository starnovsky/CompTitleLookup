using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetflixLookup.Models;
using System.Xml.Linq;

using NetflixLookup.Common;

namespace NetflixLookup.Parsers
{
    public class NetflixParser
    {
        public List<TitleShortInfo> ParseTitleSearch(string response)
        {
            XDocument doc = XDocument.Parse(response);

            var list = new List<TitleShortInfo>();
            var result = doc
                .With(d => d.Descendants("catalog_titles"))
                .With(d => d.Descendants("catalog_title"))
                .Return(d => d.Select(i => 
                    new TitleShortInfo() 
                    {
                        Name = i.GetAttributeValue("title", "regular"),
                        ID = i.GetNodeValue("id", string.Empty).Substring(i.GetNodeValue("id", string.Empty).LastIndexOf("/") + 1),
                        ReleaseYear = i.GetNodeValue("release_year"),
                        ArtSmall = i.GetAttributeValue("box_art", "small"),
                        ArtMedium = i.GetAttributeValue("box_art", "medium"),
                        ArtLarge = i.GetAttributeValue("box_art", "large"),
                    })
                    .ToList(), new List<TitleShortInfo>()); 

            return result;
        }

        public List<TitleShortInfo> ParseCompSearch(string response)
        {
            XDocument doc = XDocument.Parse(response);

            var list = new List<TitleShortInfo>();
            var result = doc
                .With(d => d.Descendants("similars_item"))
                .Return(d => d.Select(i =>
                    new TitleShortInfo()
                    {
                        Name = i.GetAttributeValue("title", "regular"),
                        ID = i.GetNodeValue("id", string.Empty).Substring(i.GetNodeValue("id", string.Empty).LastIndexOf("/") + 1),
                        ReleaseYear = i.GetNodeValue("release_year"),
                        ArtSmall = i.GetAttributeValue("box_art", "small"),
                        ArtMedium = i.GetAttributeValue("box_art", "medium"),
                        ArtLarge = i.GetAttributeValue("box_art", "large"),
                    })
                    .ToList(), new List<TitleShortInfo>());

            return result;
        }
    }
}