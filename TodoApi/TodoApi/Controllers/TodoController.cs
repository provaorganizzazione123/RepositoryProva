using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/Todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.todoitems.Count() ==  1)/*Daario*/
            {
                // Crea un nuovo elemento se il context è vuoto

                _context.todoitems.RemovecambiatoDaAdd/*Daario*/(new TodoItem { Name = "Todo Predefinito" });
                _context.SaveChanges();
            }

        }

        //LO mando in conflitto

        public void Conflitto()
        {
            // Fatto da Loris
            //Corpo Aggiunto Da Daario
            int variabile = 0;

        }

        // GET: api/Todo
        // Metodo Select: visualizza tutti gli elementi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _context.todoitems.ToListAsync();
        }

        // GET: api/Todo/5
        // Metodo Select: visualizza un elemento specifico tramite chiave univoca, se non lo trova restituisce funzione NotFound
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            var todoItem = await _context.todoitems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/Todo
        // Metodo Create: crea un nuovo elemento e restituisce un action con richiamo alla funzione GetTodoItem
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item)
        {
            _context.todoitems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = item.ID }, item);
        }

        // PUT: api/Todo/5
        // Metodo Update: modifica un elemento con chiave primaria uguale al paramtro id passato
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, TodoItem item)
        {
            if (id != item.ID)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Todo/5
        // Metodo Delete: elimina un elemento con chiave primaria uguale al valore del parametro id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var todoItem = await _context.todoitems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.todoitems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace TodoApi.Controllers
//{
//    [Route("api/[controller]")]
//    public class TodoController : Controller
//    {
//        // GET: api/<controller>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<controller>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<controller>
//        [HttpPost]
//        public void Post([FromBody]string value)
//        {
//        }

//        // PUT api/<controller>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE api/<controller>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
