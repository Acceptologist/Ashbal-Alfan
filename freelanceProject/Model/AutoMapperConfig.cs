using AutoMapper;
using freelanceProject.DTO;
using freelanceProject.Model;

namespace Final_Project.Models
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get;private set; }

        static AutoMapperConfig() 
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDto>().ReverseMap();
                cfg.CreateMap<Product, Product>().ReverseMap();

            });

            Mapper = config.CreateMapper();
        }
    }
}
