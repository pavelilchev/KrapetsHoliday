namespace Hotel.App.Utils
{
    using System.Web;
    using System.Xml.Linq;

    public static class XmlHelper
    {
        public static string GetNode(string nodeName)
        {
            string path = HttpContext.Current.Server.MapPath("~/SiteInfo.xml");
            var doc = XDocument.Load(path);

            var node = doc.Root.Element(nodeName);
            var nodeValue = node.Value != null ? node.Value : string.Empty;

            return nodeValue;
        }
    }
}