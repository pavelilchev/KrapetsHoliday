namespace Hotel.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Hotel.Data.UnitOfWork;

    public class ContactUsController : BaseController
    {
        public ContactUsController(IHotelData data) 
            : base(data)
        {
        }

        // GET: ContactUs
        public ActionResult Index()
        {
            return View();
        }        

        // GET: ContactUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactUs/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
