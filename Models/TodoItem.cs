using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Producent { get; set; }
        public double Price { get; set; }

        public int PlayTime { get; set; }

    }
}
