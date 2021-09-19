using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookworm.Xapi.Features.Shared.Ports.Repositories
{
    public interface IBooksRepository
    {
        Task<IReadOnlyCollection<BookRecord>> GetAll();
    }

    public record BookRecord
    {
        public string Id { get; init; }
        public string Title { get; init; }
    }
}
