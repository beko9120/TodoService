using TodoApiDTO.DAL.Context;
using TodoApiDTO.DAL.Interfaces;

namespace TodoApiDTO.DAL.Repositories
{
    public class TodoItemRepository: BaseRepository<TodoItem>, ITodoItemRepository
    {
        public TodoItemRepository(TodoContext context) : base(context)
        {
        }

        // добавить доп. методы
    }
}
