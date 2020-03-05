using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.TodoItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TodoItems.Add(new TodoItem { Name = "Laranja", Descricao = "O interior da laranja é formado por gomos, cujo sabor varia do doce ao levemente ácido. É uma fruta rica em vitamina C, sais minerais como ferro, potássio, cálcio.", Price = 7.99 });
                _context.SaveChanges();
                _context.TodoItems.Add(new TodoItem { Name = "Limão", Descricao = "O limão possui um suco com sabor fortemente cítrico e azedo, pois apresenta uma grande quantidade de ácido cítrico. É uma fruta rica em vitamina C, complexo B e sais minerais (fósforo, cálcio e ferro).", Price = 1.95 });
                _context.SaveChanges();
                _context.TodoItems.Add(new TodoItem { Name = "Manga", Descricao = "A manga é o fruto da mangueira (Mangifera indica L.), árvore frutífera da família Anacardiaceae, nativa do sul e do sudeste asiático desde o leste da Índia até as Filipinas, e introduzida com sucesso no Brasil, em Angola, em Moçambique e em outros países tropicais.", Price = 5.15 });
                _context.SaveChanges();
                _context.TodoItems.Add(new TodoItem { Name = "Uva", Descricao = "É uma fruta rica em sais minerais, tais como: cálcio, ferro, fósforo, magnésio, sódio e potássio. Possui também, em quantidade razoável, vitaminas (complexo B e vitamina C). Não é muito calórica, pois 100 gramas de uva possui, aproximadamente, 50 calorias.", Price = 8.56 });
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound("Produto não existe!");
            }

            return todoItem;
        }
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item)
        {
            
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem item)
        {
            if (id != item.Id)
            {
                return BadRequest("Não cadastrado");
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if(todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
   
}