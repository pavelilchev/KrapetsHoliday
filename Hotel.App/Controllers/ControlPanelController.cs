namespace Hotel.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.UnitOfWork;
    using Hotel.Models;
    using Models.ViewModels;
    using System.Data.Entity;
    using System.Threading.Tasks;

    [Authorize]
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
            else
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
            return null;
        }

        [HttpPost]
        public Task<ActionResult> EditReview(Review reviewModel)
        {
           
            return null;
        }
    }
}
