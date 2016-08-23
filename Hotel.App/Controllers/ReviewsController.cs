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
        public ActionResult Index(int page = 1, int count = 5)
        {
            var allReviews = this.Data.Reviews.All().Where(r => r.IsPublished).Include(r => r.Comments).Include(r => r.Author);
            var reviews = allReviews
                .OrderByDescending(r => r.CreationDate)
                .Skip((page - 1) * count)
                .Take(count)
                .ToList();

            int reviewsCount = allReviews.Count();
            this.ViewBag.TotalPages = (reviewsCount + count - 1) / count;
            this.ViewBag.CurrentPage = page;

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
        public ActionResult Create([Bind(Include = "Id,Content,Rating")] Review review)
        {
            if (this.ModelState.IsValid)
            {
                review.Author = this.UserProfile;
                review.CreationDate = DateTime.Now;
                review.IsPublished = false;

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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
            review.IsPublished = false;
            this.Data.Reviews.Update(review);
            this.Data.SaveChanges();

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment([Bind(Include = "Content, ReviewId")] ReviewCommentViewModel comment)
        {
            var review = this.Data.Reviews.Find(comment.ReviewId);
            var reviewComment = new ReviewComment();

            if (this.ModelState.IsValid)
            {
                reviewComment.Content = comment.Content;
                reviewComment.Author = this.UserProfile;
                reviewComment.CreationTime = DateTime.Now;
                reviewComment.Review = review;
                reviewComment.IsPublished = false;

                this.Data.Comments.Add(reviewComment);
                this.Data.SaveChanges();

                return this.RedirectToAction("/Details/" + comment.ReviewId);
            }

            return this.View("Details", review);
        }
    }
}
