namespace Hotel.App
{
    using AutoMapper;
    using Hotel.Models;
    using Models.ViewModels;
    using System;
    using System.Linq;

    public static class MapperConfigur
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Review, ReviewVewModel>().ForMember(rvm => rvm.CommentsCount, imce => imce.MapFrom(r => r.Comments.Count(c => c.IsPublished)));
                cfg.CreateMap<EmailViewModel, Email>().ForMember(rvm => rvm.CreationTime, imce => imce.MapFrom(r => DateTime.Now));
                cfg.CreateMap<AppointmentViewModel, Appointment>()
                .ForMember(avm => avm.CreationTime, mce => mce.MapFrom(r => DateTime.Now))
                .ForMember(avm => avm.IsApproved, mce => mce.MapFrom(a => false));
            });
        }
    }
}