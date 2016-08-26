namespace Hotel.App.Utils
{
    using System.Web;
    using System.Xml.Linq;

    public static class XmlHelper
    {
        private const string SiteInfoPath = "~/SiteInfo.xml";

        private static XDocument doc = null;

        public static XDocument Document
        {
            get
            {
                if (doc == null)
                {
                    doc = XDocument.Load(HttpContext.Current.Server.MapPath(SiteInfoPath));
                }

                return doc;
            }
        }

        public static string GetNode(string nodeName)
        {
            var node = Document.Root.Element(nodeName);
            var nodeValue = node.Value != null ? node.Value : string.Empty;

            return nodeValue;
        }

        public static void SetNodeValue(string nodeName, string value)
        {
            var node = Document.Root.Element(nodeName);
            node.Value = value;

            doc.Save(HttpContext.Current.Server.MapPath(SiteInfoPath));
        }
    }
}