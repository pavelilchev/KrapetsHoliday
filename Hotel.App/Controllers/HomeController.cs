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
            return this.View();
        }
    }
}