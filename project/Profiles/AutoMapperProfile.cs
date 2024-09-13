using AutoMapper;
using project.Models;
using project.ViewModel;

namespace project.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserRegister, User>();

            CreateMap<CategoryVM, Category>().ReverseMap();

            CreateMap<Product, ProductVM>().ForMember(s => s.Category, d =>
            d.MapFrom(e => e.Category!.Name ?? "NA"));

            CreateMap<ProductVM, Product>();

            CreateMap<User, UserDetailsVM>();

        }
    }
}
