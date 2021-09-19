using System.Collections.Generic;
using System.Threading.Tasks;
using Bolt.Common.Extensions;
using Bolt.IocScanner.Attributes;
using Bookworm.Xapi.Features.Shared.Ports.Repositories;

namespace Bookworm.Xapi.Infrastructure.Adapters.Repositories
{
    [AutoBind]
    internal sealed class BooksRepository : IBooksRepository
    {
        public async Task<IReadOnlyCollection<BookRecord>> GetAll()
        {
            return new[]
            {
                new BookRecord
                {
                    Id = "1001",
                    Title = "xapi-bookworm"
                }
            };
        }
    }
}
