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
                    Id = "6",
                    Title = "The Eye of the World",
                    PhotoUrl = "https://images-na.ssl-images-amazon.com/images/I/51vYL46df+L._AC_SX184_.jpg",
                    Authors = "Robert Jordan",
                    Price = "$13.99",
                    Publisher = "",
                    PublishedOn = ""
                  },
                  new Book
                  {
                    Id = "7",
                    Title = "Beautiful World, Where Are You",
                    PhotoUrl = "https://images-na.ssl-images-amazon.com/images/I/51cidczO3xS._AC_SX184_.jpg",
                    Authors = "Sally Rooney",
                    Price = "$13.99",
                    Publisher = "",
                    PublishedOn = ""
                  },
                  new Book{
                    Id = "8",
                    Title = "Aliens and Other Worlds by Lisa Harvey-Smith",
                    PhotoUrl = "https://d30a6s96kk7rhm.cloudfront.net/original/978/176/076/9781760761165.jpg",
                    Price = "$29.99",
                    Authors = "Lisa Harvey-Smith, Tracie Grimwood",
                    Publisher = "",
                    PublishedOn = ""

                  },
                  new Book{
                    Id = "9",
                    Title = "Exit Through the Gift Shop",
                    PhotoUrl = "https://d30a6s96kk7rhm.cloudfront.net/original/readings/978/176/098/9781760983512.jpg",
                    Price = "$16.99",
                    Authors = "Maryam Master",
                    Publisher = "",
                    PublishedOn = ""

                  },
                  new Book{
                    Id = "10",
                    Title = "Perfect On Paper",
                    PhotoUrl = "https://d30a6s96kk7rhm.cloudfront.net/original/978/144/495/9781444959277.jpg",
                    Price = "$17.99",
                    Authors = "Sophie Gonzales",
                    Publisher = "",
                    PublishedOn = ""

                  },
                  new Book{
                    Id = "11",
                    Title = "The Vanishing Half",
                    PhotoUrl = "https://d30a6s96kk7rhm.cloudfront.net/original/978/034/970/9780349701479.jpg",
                    Price = "$22.99",
                    Authors = "Brit Bennett",
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
