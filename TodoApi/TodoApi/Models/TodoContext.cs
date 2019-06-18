using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        /* Classe Context per collegamento a DB */

        // Costruttore standard per l'istanziamento dei DbSet

        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

        // Dichiarazione DbSet:

        public DbSet<TodoItem> todoitems { get; set; }

        // Registare il servizio nello startup:
        // using Microsoft.EntityFrameworkCore;
        // using TodoApi.Models;
        //
        // Nel ConfigureService:
        // services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));

    }
}
