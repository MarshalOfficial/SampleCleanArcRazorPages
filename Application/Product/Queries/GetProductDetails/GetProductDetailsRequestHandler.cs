using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Product.Queries.GetProductDetails
{
    public class GetProductDetailsRequestHandler : IRequestHandler<GetProductDetailsRequest, ProductDetailsDto>
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;

        public GetProductDetailsRequestHandler(IProductRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ProductDetailsDto> Handle(GetProductDetailsRequest request, CancellationToken cancellationToken)
        {
            // Query the database
            var member = await repository.GetByIdAsync(request.Id);

            // convert to DTO objects
            var result = mapper.Map<ProductDetailsDto>(member);

            // return value
            return result;
        }
    }
}