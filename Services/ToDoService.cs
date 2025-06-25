using ToDoApi.Models;

namespace ToDoApi.Services
{
    public class ToDoService
    {
        private readonly List<ToDoItem> _items = new();
        private int _nextId = 1;

        public List<ToDoItem> GetAll() => _items;

        public ToDoItem? Get(int id) => _items.FirstOrDefault(i => i.Id == id);

        public ToDoItem Add(ToDoItem item)
        {
            item.Id = _nextId++;
            _items.Add(item);
            return item;
        }

        public bool Update(int id, ToDoItem updatedItem)
        {
            var existing = Get(id);
            if (existing == null) return false;

            existing.Title = updatedItem.Title;
            existing.IsComplete = updatedItem.IsComplete;
            return true;
        }

        public bool Delete(int id)
        {
            var existing = Get(id);
            if (existing == null) return false;

            _items.Remove(existing);
            return true;
        }
    }
}