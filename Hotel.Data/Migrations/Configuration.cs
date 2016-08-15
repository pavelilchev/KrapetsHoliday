namespace Hotel.Data.Migrations
{
    using System;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<HotelDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(HotelDbContext context)
        {
            this.SeedUsers(context);
            this.SeedReviews(context);
            this.SeedComments(context);
        }

        private void SeedUsers(HotelDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@gmail.com"))
            {
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var userToInsert = new User { UserName = "admin@gmail.com", Email = "admin@gmail.com" };

                userManager.Create(userToInsert, "123456");
                userManager.AddToRole(userToInsert.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "user@gmail.com"))
            {
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var userToInsert = new User { UserName = "user", Email = "user@gmail.com" };

                userManager.Create(userToInsert, "123456");
            }
        }

        private void SeedReviews(HotelDbContext context)
        {
            if (context.Reviews.Any())
            {
                return;
            }

            var author = context.Users.FirstOrDefault(u => u.UserName == "user");
            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                var review = new Review();
                string content = "Това е един страхотен отзив " + i;
                DateTime date = DateTime.Now;
                int rating = 5 - rnd.Next(4);

                review.Content = content;
                review.Author = author;
                review.CreationDate = date;
                review.Rating = rating;
                review.IsPublished = true;
                context.Reviews.Add(review);
            }

            context.SaveChanges();
        }

        private void SeedComments(HotelDbContext context)
        {
            if (context.Comments.Any())
            {
                return;
            }

            var reviews = context.Reviews;
            var author = context.Users.FirstOrDefault(u => u.Email == "user@gmail.com");
            foreach (var review in reviews)
            {
                for (int k = 0; k < 3; k++)
                {
                    var comment = new ReviewComment();
                    comment.Author = author;
                    comment.Content = "Коментарът трябва да бъде смислен " + k;
                    comment.CreationTime = DateTime.Now;
                    comment.Review = review;

                    context.Comments.Add(comment);
                }
            }

            context.SaveChanges();
        }
    }
}
