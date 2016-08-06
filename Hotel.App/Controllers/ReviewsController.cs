namespace Hotel.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.UnitOfWork;
    using Hotel.Models;
    using Models.ViewModels;

    public class ReviewsController : BaseController
    {
        public ReviewsController(IHotelData data)
            : base(data)
        {
        }

        // GET: Reviews
        public ActionResult Index()
        {
            var reviews = this.Data.Reviews.All().Include(r => r.Comments).Include(r => r.Author).ToList();

            var vmReviews = Mapper.Map<IEnumerable<Review>, IEnumerable<ReviewVewModel>>(reviews);
           
            return this.View(vmReviews);
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Review review = this.Data.Reviews.Find(id);
            if (review == null)
            {
                return this.HttpNotFound();
            }

            return this.View(review);
        }

        // GET: Reviews/Create
        [Authorize]
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content")] Review review)
        {
            if (this.ModelState.IsValid)
            {
                review.Author = this.UserProfile;
                review.CreationDate = DateTime.Now;
                review.Rating = 5;

                this.Data.Reviews.Add(review);
                this.Data.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(review);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = this.Data.Reviews.Find(id);
            if (review == null)
            {
                return this.HttpNotFound();
            }
            return this.View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,CreationDate")] Review review)
        {
            if (this.ModelState.IsValid)
            {
                this.Data.Reviews.Update(review);
                this.Data.SaveChanges();
                return this.RedirectToAction("Index");
            }
            return this.View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Review review = this.Data.Reviews.Find(id);
            if (review == null)
            {
                return this.HttpNotFound();
            }

            return this.View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = this.Data.Reviews.Find(id);
            this.Data.Reviews.Remove(review);
            this.Data.SaveChanges();

            return this.RedirectToAction("Index");
        }
    }
}
