using System.Net;
using System.Threading.Tasks;
using Bookworm.Xapi.Features.Books.List;
using Bookworm.Xapi.Features.Shared.Ports.Repositories;
using Bookworm.Xapi.Tests.Infra;
using Bookworm.Xapi.Tests.Infra.Fixtures;
using NSubstitute;
using Shouldly;
using Xunit;

namespace Bookworm.Xapi.Tests.Features.Books
{
    public class BooksEndpointTests : Infra.TestWithWebServer
    {
        [Fact]
        public async Task Should_return_ok()
        {
            // Arrange
            // Given books respository provide following books
            var givenAvailableBooksInRepository = new[]
            {
                new BookRecord
                {
                    Id = "fake-1",
                    Title = "fake-title-1"
                },
                new BookRecord
                {
                    Id = "fake-2",
                    Title = "fake-title-2"
                }
            };

            var fakeRepo = this.GetFakeService<IBooksRepository>();
            fakeRepo.GetAll().Returns(givenAvailableBooksInRepository);

            // Act
            // When I call get all books endpoint
            var rsp = await Server.GetAsync("/books/");

            // And I read the content as expected viewmodel
            var content = await rsp.ReadContentAs<BooksListViewModel>(); 

            // Assert
            // Then I should get status code okay
            rsp.StatusCode.ShouldBe(HttpStatusCode.OK);

            // And content should match as expected
            content.ShouldMatchApprovedEx();
        }

        public BooksEndpointTests(WebServerFixture fixture) : base(fixture)
        {
        }
    }
}
