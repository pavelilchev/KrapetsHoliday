namespace Hotel.App.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Hotel.Data.UnitOfWork;
    using Hotel.Models;
    using Models.ViewModels;
    using AutoMapper;

    public class AppointmentController : BaseController
    {
        public AppointmentController(IHotelData data) 
            : base(data)
        {
        }

      
        public ActionResult Index()
        {
            var appointments = this.Data.Appointments.All().ToList();

            return this.View();
        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AppointmentViewModel appointmentModel)
        {
            if (this.ModelState.IsValid)
            {
                var appointment = Mapper.Map<Appointment>(appointmentModel);

                this.Data.Appointments.Add(appointment);
                this.Data.SaveChanges();
                return this.View();
            }

            return this.View(appointmentModel);
        }
    }
}
