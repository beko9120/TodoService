using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApiDTO.BLL.DTO;
using TodoApiDTO.BLL.Interfaces;
using TodoApiDTO.DAL.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoApiDTO.DAL.Context;

namespace TodoApiDTO.BLL.Logics
{
    public class TodoItemLogic: ITodoItemLogic
    {

        private readonly ITodoItemRepository _repository;
        public TodoItemLogic(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TodoItemDTO>> GetTodoItems()
        {
            return await _repository.GetQueryable(x => true).Select(x => ItemToDTO(x)).ToListAsync();
        }

        public async Task<TodoItemDTO> GetTodoItem(long id)
        {
            var todoItem = await _repository.GetById(id);
            if (todoItem == null)
                throw new ArgumentException("Not found");

            return ItemToDTO(todoItem);
        }

        public async Task UpdateTodoItem(long id, TodoItemDTO todoItemDTO)
        {

            var todoItem = await _repository.GetById(id);
            if (todoItem == null)
            {
                throw new ArgumentException("Not found");
            }

            todoItem.Name = todoItemDTO.Name;
            todoItem.IsComplete = todoItemDTO.IsComplete;

            try
            {
                await _repository.Update(todoItem);
            }
            catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
            {
                throw new ArgumentException("Not found");
            }

        }

        public async Task<TodoItemDTO> CreateTodoItem(TodoItemDTO todoItemDTO)
        {
            var todoItem = new TodoItem
            {
                IsComplete = todoItemDTO.IsComplete,
                Name = todoItemDTO.Name
            };

            todoItem.Id = await _repository.Add(todoItem);
            return ItemToDTO(todoItem);
        }

        public async Task DeleteTodoItem(long id)
        {
            var todoItem = await _repository.GetById(id);
            if (todoItem == null)
            {
                throw new ArgumentException("Not found");
            }
            await _repository.Delete(todoItem);
        }

        #region private
        private bool TodoItemExists(long id) => _repository.GetQueryable(x => true).Any(e => e.Id == id);

        private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
            new TodoItemDTO
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
        #endregion
    }
}
