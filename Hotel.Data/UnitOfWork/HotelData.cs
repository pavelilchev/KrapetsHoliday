namespace Hotel.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Models;
    using Repositories;

    public class HotelData : IHotelData
    {
        private readonly DbContext dbContext;

        private readonly IDictionary<Type, object> repositories;

        public HotelData()
            : this(new HotelDbContext())
        {
        }

        public HotelData(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Review> Reviews
        {
            get
            {
                return this.GetRepository<Review>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<Appointment> Appointments
        {
            get
            {
                return this.GetRepository<Appointment>();
            }
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EntityFrameworkRepository<T>);
                this.repositories.Add(
                    typeof(T),
                    Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
