using AutoMapper;
using Core.DTOs;

using Entity.DTOs;
using Entity.Model;
using NLayer.Core.DTOs;

namespace Service.Mapping
{
    // Entity leri DTO ya ya da DTO ları Entity e çevirecek
    // Mapleme işlemini burada belirteceğiz
    public class MapProfile : Profile
    {
        // tüm hepsini buraya yazmaya gerek yok parçalı bir şekilde de yazılabilir bu fazla olduğu zamanda
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap(); // ReverseMap diyerek ProductDto yu Product ya da çevire bilme özelliğini keledik
            // yani hem Product -> ProductDto ya hem de ProductDto -> Product çevire biliyoruz
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>(); // Reverse gerekyok çünkü her hangi bir update de  Product dan ProductUpdateDto ya dönüştürmeme gerekyok bu senaryoda ondan dolayı ReverseMap yazmana gerek yok
            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<Category, CategoryWithProductsDto>();
            CreateMap<ProductCreateDto, Product>().ReverseMap();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<Favorites, FavoritesDto>().ReverseMap();
            CreateMap<FavoritesDto, Favorites>().ReverseMap();
            CreateMap<User, BaseDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap(); 
            CreateMap<UserCreateDto, User>().ReverseMap(); 
            CreateMap<UserUpdateDto, User>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap(); 


        }
    }
}
