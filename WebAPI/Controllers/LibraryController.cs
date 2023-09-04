using AutoMapper;
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
        private readonly IMapper _mapper;
        public LibraryController(ICustomer customer,IMapper mapper)
        {
            _customers = customer;
            _mapper = mapper;
        }
        [HttpPost]

        public IActionResult Add(Books book)
        {
            if (ModelState.IsValid)
            {
                books.Add(book);
                _customers.AddBooks(book);
                // return CreatedAtAction("GetDetailsbyId", new { book.BookID }, book);
                return Ok(book);

            }
            return BadRequest();
        }
        [HttpGet("id")]

        public IActionResult GetDetailsbyId(int id)
        {
            try
            {
                var Books = _customers.GetBookbyId(id);

                if (Books != null)
                {
                    var BookViewModel = _mapper.Map<List<BookViewModel>>(Books);

                    return Ok(Books);
                }
            }

            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();

        }

        [HttpGet]

        public IActionResult GetDetails()
        {
            try
            {
                var Books = _customers.GetBooks();

                if (Books != null)
                {

                    var BookViewModel = _mapper.Map<List<BookViewModel>>(Books);

                    return Ok(BookViewModel);
                }
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

