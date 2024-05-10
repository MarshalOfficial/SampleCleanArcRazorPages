using AutoMapper.Execution;

namespace Application.Interfaces
{
    public interface IProductRepository : IGenericRepository<Domain.Entities.Product>
    {
        Task<bool> IsMemberUnique(Domain.Entities.Product entiry);
    }
}