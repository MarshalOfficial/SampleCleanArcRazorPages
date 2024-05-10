using AutoMapper;
using Application.Product.Commands.Create;
using Application.Product.Commands.Update;
using Application.Product.Queries.GetAllProducts;
using Application.Product.Queries.GetProductDetails;

namespace Application.Configurations.Mapper.ProductProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductRequest, Domain.Entities.Product>();
            CreateMap<UpdateProductRequest, Domain.Entities.Product>();
            CreateMap<ProductDto, Domain.Entities.Product>().ReverseMap();
            CreateMap<ProductDetailsDto, Domain.Entities.Product>();
        }
    }
}