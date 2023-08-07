using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IModelRepository : IRepository<Model>,IAsyncRepository<Model>
    {
    }
}
