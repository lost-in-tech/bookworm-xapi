using System;

namespace Bookworm.Xapi.Tests.Infra
{
    public interface IHaveServiceProvider
    {
        IServiceProvider ServiceProvider { get; }
    }
}
