namespace Hotel.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.UnitOfWork;
    using Hotel.Models;
    using Models.ViewModels;

    [Authorize]
    public class ControlPanelController : BaseController
    {
        public ControlPanelController(IHotelData data) 
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var model = new ControlPanelViewModel();
            model.ReviewsTypes = new[]
            {
                new SelectListItem { Value = "published", Text = "Публикувани" },
                new SelectListItem { Value = "unpublished", Text = "Непубликувани" },
                new SelectListItem { Value = "all", Text = "Всички" },
            };

            model.ReviewsSortOrder = new[]
           {
                new SelectListItem { Value = "ascending", Text = "Възходящо" },
                new SelectListItem { Value = "descending", Text = "Низходящо" }
            };

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Reviews([Bind(Include = "Type,Order")] ControlPanelViewModel model)
        {
            var reviews = this.Data.Reviews.All().ToList();
            var vmReviews = Mapper.Map<IEnumerable<Review>, IEnumerable<ReviewVewModel>>(reviews);

            return this.View(vmReviews);
        }

        [HttpPost]
        public ActionResult Appointments()
        {
            return null;
        }
    }
}
