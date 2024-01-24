using Entities.Models;

namespace Contracts
{
    public interface IProfileRepository
    {
        Task<User?> GetProfileAsync(Guid id, bool trackChanges);
    }
}
