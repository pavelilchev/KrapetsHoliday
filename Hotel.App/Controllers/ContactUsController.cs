namespace Hotel.App.Controllers
{
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Models.ViewModels;
    using AutoMapper;
    using Hotel.Models;
    using Utils;

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
            string currentUserUsername = null;
            string currentUserEmail = null;
            
            if (this.UserProfile != null)
            {
                currentUserEmail = this.UserProfile.Email;
                currentUserUsername = this.UserProfile.UserName;
            }

            return this.PartialView("_Email", new EmailViewModel {Name = currentUserUsername, EmailAddress = currentUserEmail});
        }

        // POST: ContactUs/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmailViewModel email)
        {
            if (this.ModelState.IsValid)
            {
                var dataEmail = Mapper.Map<Email>(email);

                this.Data.Emails.Add(dataEmail);
                this.Data.SaveChanges();

                var message = new MailMessage();
                var toEmail = XmlHelper.GetNode("LeadsEmail");
                message.To.Add(new MailAddress(toEmail));
                message.Subject = "Имейл изпратен от контактната форма на Крапетц Холидей";
                message.Body = email.Content;
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                }

                return this.JavaScript("sendEmailSuccessfully()");
            }

            return this.PartialView("_Email", email);
        }
    }
}
