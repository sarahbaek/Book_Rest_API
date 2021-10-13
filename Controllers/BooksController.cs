using Book_Library;
using Book_Rest_API.Managers;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Book_Rest_API.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("AllowOnlyGet")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksManager _manager = new BooksManager();

        #region Method: GetAll()
        // GET: api/<BooksController>
        [ProducesResponseType(StatusCodes.Status200OK)]//Ok
        [ProducesResponseType(StatusCodes.Status204NoContent)]//nothing 
        [HttpGet]
        //public Book Get()
        //{
        //    return _manager.GetAll();
        //}
        public ActionResult<IEnumerable<Book>> GetAll([FromQuery] string inContains)
        {
            IEnumerable<Book> books = _manager.GetAll(inContains);
            if (books.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(books);
            }

        }
        #endregion

        #region Method: Get()

        // GET api/<BooksController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]//Ok
        [ProducesResponseType(StatusCodes.Status404NotFound)] //error
        [HttpGet("{inISBN13}")]
        //public Book Get(string inISBN13)
        //{
        //    return _manager.GetById(inISBN13);
        //}
        public ActionResult<Book> Get(string inISBN13)
        {
            Book item = _manager.GetById((inISBN13));
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }

        }

        #endregion

        #region Method: Post()
        // POST api/<BooksController>
        [ProducesResponseType(StatusCodes.Status200OK)]//Ok
        //[EnableCors("AllowOnlyGet")]
        [HttpPost]
        //public Book Post([FromBody] Book value)
        //{
        //    return _manager.Add(value);
        //}
        public ActionResult<Book> Post([FromBody] Book incomingBook)
        {
            return Ok(_manager.Add(incomingBook));
        }
        #endregion

        #region Method: Put()
        // PUT api/<BooksController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]//Ok
        [ProducesResponseType(StatusCodes.Status404NotFound)] //error
        //[DisableCors]
        [HttpPut("{inISBN13}")]
        //public Book Put(string inISBN13, [FromBody] Book value)
        //{
        //    return _manager.Update(inISBN13, value);
        //}

        public ActionResult<Book> Put(string inISBN13, [FromBody] Book incomingBook)
        {
            Book updateBook = _manager.Update(inISBN13, incomingBook);
            if (updateBook == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(updateBook);
            }
        }
        #endregion

        #region Method: Delete()
        // DELETE api/<BooksController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]//Ok
        [ProducesResponseType(StatusCodes.Status404NotFound)] //error
        [HttpDelete("{inISBN13}")]
        //public Book Delete(string inISBN13)
        //{
        //    return _manager.Delete(inISBN13);
        //}


        public ActionResult<Book> Delete(string inISBN13)
        {
            Book deleteBook = _manager.Delete(inISBN13);
            if (deleteBook == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(deleteBook);
            }

        }
        #endregion

    }


}
