namespace Hotel.App
{
    using AutoMapper;
    using Hotel.Models;
    using Models.ViewModels;

    public static class MapperConfigur
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Review, ReviewVewModel>().ForMember(rvm => rvm.CommentsCount, imce => imce.MapFrom(r => r.Comments.Count));
            });
        }
    }
}