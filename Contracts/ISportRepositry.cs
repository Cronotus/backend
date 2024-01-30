
using Entities.Models;

namespace Contracts
{
    public interface ISportRepositry
    {
        Task<Sport?> GetSportAsync(Guid id, bool trackChanges);
    }
}
