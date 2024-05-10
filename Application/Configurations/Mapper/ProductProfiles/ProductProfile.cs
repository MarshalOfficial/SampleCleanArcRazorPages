using AutoMapper;
using Application.Product.Commands.Create;
using Application.Product.Commands.Update;

namespace Application.Configurations.Mapper.ProductProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductRequest, Domain.Entities.Product>();
            CreateMap<UpdateProductRequest, Domain.Entities.Product>();
            //CreateMap<MemberDto, Domain.Entities.Product>().ReverseMap();
            //CreateMap<MemberDetailsDto, Domain.Entities.Product>();
        }
    }
}