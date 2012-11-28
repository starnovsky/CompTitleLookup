using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace NetflixLookup.Common
{
    public static class XElementExpensions
    {
        #region public static string GetNodeValue(this XElement source, string nodeName, string defaultValue)

        public static string GetNodeValue(this XElement source, XName nodeName, string defaultValue = null)
        {
            return source != null ?
                source.With(p => p.Descendants(nodeName)).With(p => p.FirstOrDefault()).Return(p => p.Value, defaultValue) :
                defaultValue;
        }

        public static string GetAttributeValue(this XElement source, XName nodeName, XName attributeName, string defaultValue= null)
        {
            return source != null ?
                source.With(p => p.Descendants(nodeName)).With(p => p.FirstOrDefault()).With(p => p.Attribute(attributeName)).Return(p => p.Value, defaultValue) :
                defaultValue;
        }

        #endregion

        #region public static string GetNodeValue(this IEnumerable<XElement> source, string nodeName, string defaultValue)

        public static string GetNodeValue(this IEnumerable<XElement> source, string nodeName, string defaultValue = null)
        {
            return source != null ?
                source.With(p => p.Descendants(nodeName)).With(p => p.FirstOrDefault()).Return(p => p.Value, defaultValue) :
                defaultValue;
        }

        #endregion
    }
}