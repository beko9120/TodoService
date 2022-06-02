using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApiDTO.BLL.DTO;

namespace TodoApiDTO.BLL.Interfaces
{
    public interface ITodoItemLogic
    {
        Task<IEnumerable<TodoItemDTO>> GetTodoItems();
        Task<TodoItemDTO> GetTodoItem(long id);
        Task UpdateTodoItem(long id, TodoItemDTO todoItemDTO);
        Task<TodoItemDTO> CreateTodoItem(TodoItemDTO todoItemDTO);
        Task DeleteTodoItem(long id);
    }
}
