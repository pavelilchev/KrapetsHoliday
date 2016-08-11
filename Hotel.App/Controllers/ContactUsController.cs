namespace Hotel.App.Controllers
{
    using System.Web.Mvc;
    using Hotel.Data.UnitOfWork;
    using Models.ViewModels;
    using AutoMapper;
    using Hotel.Models;

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
            return PartialView("_Email", new EmailViewModel());
        }

        // POST: ContactUs/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmailViewModel email)
        {
            if (this.ModelState.IsValid)
            {
                this.TempData["message"] = "Вашето писмо беше изпратено успешно!";
                var dataEmail = Mapper.Map<Email>(email);

                this.Data.Emails.Add(dataEmail);
                this.Data.SaveChanges();

                return View("Index");
            }

            return View("_Email", email);
        }
    }
}
