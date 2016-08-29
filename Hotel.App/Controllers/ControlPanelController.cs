namespace Hotel.App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Models.ViewModels;
    using System.Data.Entity;
    using System.Resources;

    [Authorize(Roles ="Admin")]
    public class ControlPanelController : BaseController
    {
        public ControlPanelController(IHotelData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult ReviewsOption(ControlPanelViewModel model)
        {
            var type = model.ReviewsType;
            var order = model.ReviewsSortOrder;
            var content = model.ReviewContent;

            var reviews = this.Data.Reviews.All().Include(r => r.Comments).Include(r => r.Author);
            if (type == "published")
            {
                reviews = reviews.Where(r => r.IsPublished == true);
            }
            else if (type == "unpublished")
            {
                reviews = reviews.Where(r => r.IsPublished == false);
            }

            if (!string.IsNullOrEmpty(content))
            {
                reviews = reviews.Where(r => r.Content.Contains(content));
            }


            if (order == "ascending")
            {
                reviews = reviews.OrderBy(r => r.CreationDate);
            }
            else
            {
                reviews = reviews.OrderByDescending(r => r.CreationDate);
            }

            return this.View("Reviews", reviews.ToList());
        }

        [HttpPost]
        public ActionResult AppointmentsOption(ControlPanelViewModel model)
        {
            var type = model.AppointmentType;
            var order = model.AppointmentSortOrder;

            var appointments = this.Data.Appointments.All();
            if (type == "approved")
            {
                appointments = appointments.Where(r => r.IsApproved == true);
            }
            else if (type == "unapproved")
            {
                appointments = appointments.Where(r => r.IsApproved == false);
            }

            if (order == "ascending")
            {
                appointments = appointments.OrderBy(r => r.StartDtae);
            }
            else
            {
                appointments = appointments.OrderByDescending(r => r.StartDtae);
            }

            return this.View("Appointments", appointments.ToList());
        }

        [HttpPost]
        public ActionResult EditAppointment(string id, string isPublished)
        {
            int intId;
            bool isInt = int.TryParse(id, out intId);
            if (!isInt)
            {
                return this.HttpNotFound();
            }

            var appointment = this.Data.Appointments.Find(intId);
            appointment.IsApproved = isPublished != null;

            this.Data.SaveChanges();

            return this.PartialView("_Appointment", appointment);
        }


        [HttpPost]
        public ActionResult EditReview(string id, string isPublished)
        {
            int intId;
            bool isInt = int.TryParse(id, out intId);
            if (!isInt)
            {
                return this.HttpNotFound();
            }

            var review = this.Data.Reviews.Find(intId);
            review.IsPublished = isPublished != null;

            this.Data.SaveChanges();

            return this.PartialView("_Review", review);
        }

        [HttpPost]
        public ActionResult EditComment(string reviewId, string commentId, string isPublished)
        {
            int intReviewId;
            bool isInt = int.TryParse(reviewId, out intReviewId);
            if (!isInt)
            {
                return this.HttpNotFound();
            }

            var review = this.Data.Reviews.All().Include(r => r.Author).FirstOrDefault(r => r.Id == intReviewId);

            if (review == null)
            {
                return this.HttpNotFound();
            }

            var comment = review.Comments.FirstOrDefault(c => c.Id == int.Parse(commentId));

            if (comment == null)
            {
                return this.HttpNotFound();
            }

            comment.IsPublished = isPublished != null;

            this.Data.SaveChanges();

            return this.PartialView("_ReviewComment", comment);
        }

        public ActionResult EditSiteInfo()
        {
            var info = new SiteInfoViewModel();

            return this.View(info);
        }

        [HttpPost]
        public ActionResult EditSiteInfo(SiteInfoViewModel model)
        {
            return this.PartialView();
        }
    }
}
