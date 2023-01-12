using AutoMapper;
using BasicCrud.Entities.Concrete;
using BasicCrud.Entities.Dtos;

namespace BasicCrud.Business.AutoMapper.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductAddDto, Product>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.UtcNow))
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.UtcNow));

            CreateMap<ProductUpdateDto, Product>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.UtcNow)).ReverseMap();

            CreateMap<ProductListDto, Product>().ReverseMap();

            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}