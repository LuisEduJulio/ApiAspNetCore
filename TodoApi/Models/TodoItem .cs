using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public double Price { get; set; }
        public bool IsComplete { get; set; }
    }
}
