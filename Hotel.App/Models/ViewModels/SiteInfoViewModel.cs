namespace Hotel.App.Models.ViewModels
{
    using Utils;
    using System.Reflection;

    public class SiteInfoViewModel
    {
        public string LeadsEmail
        {
            get
            {
                return XmlHelper.GetNode(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
            set
            {
                XmlHelper.SetNodeValue(MethodBase.GetCurrentMethod().Name.Substring(4), value);
            }
        }

        public string FacebookUrl
        {
            get
            {
                return XmlHelper.GetNode(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
            set
            {
                XmlHelper.SetNodeValue(MethodBase.GetCurrentMethod().Name.Substring(4), value);
            }
        }

        public string GooglePlusUrl
        {
            get
            {
                return XmlHelper.GetNode(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
            set
            {
                XmlHelper.SetNodeValue(MethodBase.GetCurrentMethod().Name.Substring(4), value);
            }
        }

        public string PhoneNumber
        {
            get
            {
                return XmlHelper.GetNode(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
            set
            {
                XmlHelper.SetNodeValue(MethodBase.GetCurrentMethod().Name.Substring(4), value);
            }
        }

        public string Skype
        {
            get
            {
                return XmlHelper.GetNode(MethodBase.GetCurrentMethod().Name.Substring(4));
            }
            set
            {
                XmlHelper.SetNodeValue(MethodBase.GetCurrentMethod().Name.Substring(4), value);
            }
        }
    }
}