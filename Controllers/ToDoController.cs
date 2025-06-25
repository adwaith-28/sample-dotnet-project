using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Services;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [Route("todos")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoService _service;

        public ToDoController(ToDoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ToDoItem>> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<ToDoItem> Get(int id)
        {
            var item = _service.Get(id);
            return item == null ? NotFound() : item;
        }

        [HttpPost]
        public ActionResult<ToDoItem> Create(ToDoItem item)
        {
            var created = _service.Add(item);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ToDoItem item)
        {
            var updated = _service.Update(id, item);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
