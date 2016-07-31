namespace Hotel.App.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Data.UnitOfWork;
    using Hotel.Models;

    public class BaseController : Controller
    {
        private IHotelData data;
        private User userProfile;

        protected BaseController(IHotelData data)
        {
            this.Data = data;
        }

        protected BaseController(IHotelData data, User userProfile)
            : this(data)
        {
            this.UserProfile = userProfile;
        }

        protected IHotelData Data { get; private set; }

        protected User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == username);
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}