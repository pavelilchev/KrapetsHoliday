namespace Hotel.App.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Hotel.Data.UnitOfWork;
    using Hotel.Models;

    public class AppointmentController : BaseController
    {
        protected AppointmentController(IHotelData data) : base(data)
        {
        }

        // GET: Appointments
        public ActionResult Index()
        {
            return this.View(this.Data.Appointments.All().ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = this.Data.Appointments.Find(id);
            if (appointment == null)
            {
                return this.HttpNotFound();
            }
            return this.View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] Appointment appointment)
        {
            if (this.ModelState.IsValid)
            {
                this.Data.Appointments.Add(appointment);
                this.Data.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = this.Data.Appointments.Find(id);
            if (appointment == null)
            {
                return this.HttpNotFound();
            }
            return this.View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] Appointment appointment)
        {
            if (this.ModelState.IsValid)
            {
                this.Data.Appointments.Update(appointment);
                this.Data.SaveChanges();
                return this.RedirectToAction("Index");
            }
            return this.View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = this.Data.Appointments.Find(id);
            if (appointment == null)
            {
                return this.HttpNotFound();
            }
            return this.View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = this.Data.Appointments.Find(id);
            this.Data.Appointments.Remove(appointment);
            this.Data.SaveChanges();
            return this.RedirectToAction("Index");
        }
    }
}
