namespace Hotel.App.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;

    public class GalleryController : BaseController
    {
        public GalleryController(IHotelData data) : base(data)
        {
        }

        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }

    }
}