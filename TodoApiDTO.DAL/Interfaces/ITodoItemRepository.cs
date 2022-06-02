using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApiDTO.DAL.Context;

namespace TodoApiDTO.DAL.Interfaces
{
    public interface ITodoItemRepository:IBaseRepository<TodoItem>
    {
        // можно добавить доп. методы
    }
}
