using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.Data.UnitOfWork;

namespace Hotel.App.Controllers
{
    public class AboutUsController : BaseController
    {
        protected AboutUsController(IHotelData data) : base(data)
        {
        }

        // GET: AboutUs
        public ActionResult Index()
        {
            return View();
        }
    }
}