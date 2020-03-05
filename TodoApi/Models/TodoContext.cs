using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

/*
 * O contexto de banco de dados é a classe principal que coordena a funcionalidade
 * do Entity Framework para um modelo de dados. Essa classe é criada derivando-a da 
 * classe Microsoft.EntityFrameworkCore.DbContext.
 */
namespace TodoApi.Models
{
    public class TodoContext : DbContext 
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
