using AutoMapper;
using JWT_Demo.Models;
using JWT_Demo.ViewModels;
using System.Security.Claims;

namespace JWT_Demo.Mapper
{
    public class Mapper : Profile
    {
        public Mapper() {
            CreateMap<LoginVM, Users>().ReverseMap();

            CreateMap<ProductViewModel, Products>().ReverseMap();
        }
    }
}
