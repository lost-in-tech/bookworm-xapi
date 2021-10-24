using Microsoft.AspNetCore.Mvc;

namespace Bookworm.Xapi.Controllers
{
    [Route("books")]
    public class BooksController : ControllerBase
    {

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(new
            {
                Items = new Book[]
                {
                  new Book
                  {
                    Id = "1",
                    Title = "Code Complete"
                  },
                  new Book
                  {
                    Id = "2",
                    Title = "Pragmatic Programmer"
                  }
                }
            });
        }
    }

    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }
}
