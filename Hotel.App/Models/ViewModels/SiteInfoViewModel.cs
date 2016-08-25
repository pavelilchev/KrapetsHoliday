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
        }

        public string FacebookUrl
        {
            get
            {
                return XmlHelper.GetNode(MethodInfo.GetCurrentMethod().Name.Substring(4));
            }
        }

        public string GooglePlusUrl
        {
            get
            {
                return XmlHelper.GetNode(MethodInfo.GetCurrentMethod().Name.Substring(4));
            }
        }

        public string PhoneNumber
        {
            get
            {
                return XmlHelper.GetNode(MethodInfo.GetCurrentMethod().Name.Substring(4));
            }
        }

        public string Skype
        {
            get
            {
                return XmlHelper.GetNode(MethodInfo.GetCurrentMethod().Name.Substring(4));
            }
        }
    }
}