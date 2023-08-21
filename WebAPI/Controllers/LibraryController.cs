using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : Controller
    {
        public static List<Books> books = new List<Books>();
        private readonly ICustomer _customers;
        public LibraryController(ICustomer customer)
        {
            _customers = customer;
        }
        [HttpPost]

        public IActionResult Add(Books book)
        {
            if (ModelState.IsValid)
            {
                books.Add(book);
                _customers.AddBooks(book);
                return CreatedAtAction("AddBooks", new { book.BookID }, book);

            }
            return BadRequest();
        }

        [HttpGet]

        public IActionResult GetDetails()
        {
            try {
                var Books = _customers.GetBooks();

                if (Books != null)
                    return Ok(Books);
            }

            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
             
        }
        [HttpDelete]
        public IActionResult Remove(int BookID)
        {
            bool k = _customers.Delete(BookID);
            if (k)
            {
                return Ok(k);
            }
            return NoContent();
        }





    }


    }

