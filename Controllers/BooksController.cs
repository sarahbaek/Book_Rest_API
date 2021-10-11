using Book_Library;
using Book_Rest_API.Managers;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Book_Rest_API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOnlyGet")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly BooksManager _manager = new BooksManager();

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _manager.GetAll();
        }

        // GET api/<BooksController>/5
        [HttpGet("{inISBN13}")]
        public Book Get(string inISBN13)
        {
            return _manager.GetById(inISBN13);
        }

        // POST api/<BooksController>
        [EnableCors("AllowOnlyGet")]
        [HttpPost]
        public Book Post([FromBody] Book value)
        {
            return _manager.Add(value);
        }

        // PUT api/<BooksController>/5
        [DisableCors]
        [HttpPut("{inISBN13}")]
        public Book Put(string inISBN13, [FromBody] Book value)
        {
            return _manager.Update(inISBN13, value);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{inISBN13}")]
        public Book Delete(string inISBN13)
        {
            return _manager.Delete(inISBN13);
        }
    }

    //    // GET: api/<BooksController>
    //    [HttpGet]
    //    public IEnumerable<string> Get()
    //    {
    //        return new string[] { "value1", "value2" };
    //    }

    //    // GET api/<BooksController>/5
    //    [HttpGet("{id}")]
    //    public string Get(int id)
    //    {
    //        return "value";
    //    }

    //    // POST api/<BooksController>
    //    [HttpPost]
    //    public void Post([FromBody] string value)
    //    {
    //    }

    //    // PUT api/<BooksController>/5
    //    [HttpPut("{id}")]
    //    public void Put(int id, [FromBody] string value)
    //    {
    //    }

    //    // DELETE api/<BooksController>/5
    //    [HttpDelete("{id}")]
    //    public void Delete(int id)
    //    {
    //    }
}
