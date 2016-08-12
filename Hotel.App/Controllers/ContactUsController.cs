namespace Hotel.App.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;
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
            return this.View();
        }        

        // GET: ContactUs/Create
        public ActionResult Create()
        {
            return this.PartialView("_Email", new EmailViewModel());
        }

        // POST: ContactUs/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmailViewModel email)
        {
            if (this.ModelState.IsValid)
            {
                var dataEmail = Mapper.Map<Email>(email);

                this.Data.Emails.Add(dataEmail);
                this.Data.SaveChanges();
                return this.JavaScript("sendEmailSuccessfully()");
            }

            return this.PartialView("_Email", email);
        }
    }
}
