using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApiDTO.DAL.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext()
        {
        }
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        protected TodoContext(DbContextOptions options)
          : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
