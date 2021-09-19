using System;
using Bolt.IocScanner.Attributes;
using Bookworm.Xapi.Features.Shared.Ports;

namespace Bookworm.Xapi.Infrastructure.Adapters
{
    [AutoBind]
    internal sealed class UniqueId : IUniqueId
    {
        public Guid New => Guid.NewGuid();
    }
}
