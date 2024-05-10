using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Product.Queries.GetAllProducts
{
    public class GetAllProductRequestHandler : IRequestHandler<GetAllProductsRequest, IEnumerable<ProductDto>>
    {
        private readonly IMapper mapper;
        private readonly IProductRepository repository;

        public GetAllProductRequestHandler(IMapper mapper, IProductRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            // Query the database
            var members = await repository.GetAllAsync();

            // convert to DTO objects
            var result = mapper.Map<List<ProductDto>>(members);

            // return value
            return result;
        }
    }
}