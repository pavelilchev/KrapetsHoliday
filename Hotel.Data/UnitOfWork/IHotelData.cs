namespace Hotel.Data.UnitOfWork
{
    using Models;
    using Repositories;

    public interface IHotelData
    {
        IRepository<User> Users { get; }

        IRepository<Review> Reviews { get; }
        
        IRepository<Comment> Comments { get; }

        IRepository<Appointment> Appointments { get; }

        int SaveChanges();
    }
}
