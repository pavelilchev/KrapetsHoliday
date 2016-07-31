namespace Hotel.App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.UnitOfWork;

    public class HomeController : BaseController
    {
        public HomeController(IHotelData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            var  reviews = this.Data.Reviews.All();
            int reviewsCount = reviews.Count();
            double averageRating = reviews.Sum(r => r.Rating)/ (double)reviewsCount;
            this.Session["ReviewsCount"] = reviewsCount;
            this.Session["AverageRating"] = averageRating;

            return this.View();
        }
    }
}