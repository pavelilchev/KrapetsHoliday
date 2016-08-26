namespace Hotel.App.Models.ViewModels
{
    using Hotel.App.Utils;
    using System.Reflection;

    public class SiteInfoViewModel
    {
        public string LeadsEmail
        {
            get
            {
                return XmlHelper.GetNode(MethodInfo.GetCurrentMethod().Name.Substring(4));
            }
            set
            {
                XmlHelper.SetNodeValue(MethodInfo.GetCurrentMethod().Name.Substring(4), value);
            }
        }

        public string FacebookUrl
        {
            get
            {
                return XmlHelper.GetNode(MethodInfo.GetCurrentMethod().Name.Substring(4));
            }
            set
            {
                XmlHelper.SetNodeValue(MethodInfo.GetCurrentMethod().Name.Substring(4), value);
            }
        }

        public string GooglePlusUrl
        {
            get
            {
                return XmlHelper.GetNode(MethodInfo.GetCurrentMethod().Name.Substring(4));
            }
            set
            {
                XmlHelper.SetNodeValue(MethodInfo.GetCurrentMethod().Name.Substring(4), value);
            }
        }

        public string PhoneNumber
        {
            get
            {
                return XmlHelper.GetNode(MethodInfo.GetCurrentMethod().Name.Substring(4));
            }
            set
            {
                XmlHelper.SetNodeValue(MethodInfo.GetCurrentMethod().Name.Substring(4), value);
            }
        }

        public string Skype
        {
            get
            {
                return XmlHelper.GetNode(MethodInfo.GetCurrentMethod().Name.Substring(4));
            }
            set
            {
                XmlHelper.SetNodeValue(MethodInfo.GetCurrentMethod().Name.Substring(4), value);
            }
        }
    }
}