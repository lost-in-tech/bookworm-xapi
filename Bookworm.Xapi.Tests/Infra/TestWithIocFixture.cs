using System;
using Bookworm.Xapi.Tests.Infra.Fixtures;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Bookworm.Xapi.Tests.Infra
{
    [Trait("Category", "Fast")]
    [Collection(nameof(IocFixtureCollection))]
    public abstract class TestWithIocFixture : IDisposable, IHaveServiceProvider
    {
        private readonly IServiceScope _scope;

        public TestWithIocFixture(IocFixture fixture)
        {
            _scope = fixture.CreateScope();
        }

        public void Dispose()
        {
            _scope?.Dispose();
        }

        IServiceProvider IHaveServiceProvider.ServiceProvider => _scope.ServiceProvider;
    }
}
