using AutoMapper;
using Application.Product.Commands.Create;

namespace Application.Configurations.Mapper.ProductProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductRequest, Domain.Entities.Product>();
            //CreateMap<UpdateProductCommand, Domain.Entities.Product>();
            //CreateMap<MemberDto, Domain.Entities.Product>().ReverseMap();
            //CreateMap<MemberDetailsDto, Domain.Entities.Product>();
        }
    }
}