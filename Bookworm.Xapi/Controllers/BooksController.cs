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
                    Title = "Fluent Python: Clear, Concise, and Effective Programming",
                    PhotoUrl = "https://images-na.ssl-images-amazon.com/images/I/41R+fNX-akL._SX379_BO1,204,203,200_.jpg",
                    Authors = "Luciano Ramalho",
                    Price = "$45.72",
                    Publisher = "O'Reilly Media",
                    PublishedOn = "September 1, 2015"
                  },
                  new Book
                  {
                    Id = "2",
                    Title = "Apples Never Fall",
                    PhotoUrl = "https://images-na.ssl-images-amazon.com/images/I/41OFl6AFT6L._AC_SX184_.jpg",
                    Authors = "Liane Moriarty",
                    Price = "$14.99",
                    Publisher = "",
                    PublishedOn = ""
                  },
                  new Book
                  {
                    Id = "3",
                    Title = "The Judge's List",
                    PhotoUrl = "https://images-na.ssl-images-amazon.com/images/I/41E3EKUlXGS._AC_SX184_.jpg",
                    Authors = "John Grisham",
                    Price = "$14.99",
                    Publisher = "",
                    PublishedOn = ""
                  },
                  new Book
                  {
                    Id = "4",
                    Title = "The Wish",
                    PhotoUrl = "https://images-na.ssl-images-amazon.com/images/I/51NUTi4a5YL._AC_SX184_.jpg",
                    Authors = "Nicholas Sparks",
                    Price = "$15.99",
                    Publisher = "",
                    PublishedOn = ""
                  },
                  new Book
                  {
                    Id = "5",
                    Title = "Harlem Shuffle: A Novel",
                    PhotoUrl = "https://images-na.ssl-images-amazon.com/images/I/51NUTi4a5YL._AC_SX184_.jpg",
                    Authors = "Colson Whitehead",
                    Price = "$12.89",
                    Publisher = "",
                    PublishedOn = ""
                  },
                  new Book
                  {
                    Id = "5",
                    Title = "The Eye of the World",
                    PhotoUrl = "https://images-na.ssl-images-amazon.com/images/I/51vYL46df+L._AC_SX184_.jpg",
                    Authors = "Robert Jordan",
                    Price = "$13.99",
                    Publisher = "",
                    PublishedOn = ""
                  }
                }
            });
        }
    }

    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public string PublishedOn { get; set; }
        public string PhotoUrl { get; set; }
        public string Price { get; set; }
        public string Publisher { get; set; }
    }
}
