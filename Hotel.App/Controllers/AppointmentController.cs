namespace Hotel.App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Hotel.Data.UnitOfWork;
    using Hotel.Models;
    using Models.ViewModels;
    using AutoMapper;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using Utils;

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
        public async Task<ActionResult> Index(AppointmentViewModel appointmentModel)
        {
            if (this.ModelState.IsValid)
            {
                this.ViewBag.IsDisabled = "disabled";

                var appointment = Mapper.Map<Appointment>(appointmentModel);

                this.Data.Appointments.Add(appointment);
                this.Data.SaveChanges();


                var message = new MailMessage();
                var toEmail = XmlHelper.GetNode("LeadsEmail");
                message.To.Add(new MailAddress(toEmail));
                message.Subject = "Имейл за резервация от Крапец Холидей";
                message.Body = this.FillClientInfo(appointmentModel);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                }

                return this.View();
            }

            return this.View(appointmentModel);
        }

        private string FillClientInfo(AppointmentViewModel model)
        {
            var template = System.IO.File.ReadAllText(Server.MapPath("~/Files/Templates/AppointmentEmailTemplate.html"));
            template = template.Replace("[TEMPLATE_NAME]", model.FirstName).
            Replace("[TEMPLATE_LAST_NAME]", model.LastName).
            Replace("[TEMPLATE_EMAIL]", model.Email).
            Replace("[TEMPLATE_PHONE]", model.Phone).
            Replace("[TEMPLATE_START_DATE]", model.StartDtae.ToString("dd.MM.yyyy")).
            Replace("[TEMPLATE_END_DATE]", model.EndDate.ToString("dd.MM.yyyy")).
            Replace("[TEMPLATE_COUNT]", model.HosesCount.ToString());

            return template;
        }
    }
}
