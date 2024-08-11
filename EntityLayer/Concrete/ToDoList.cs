using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Content { get; set; }
        public bool IsRead { get; set; } 
        public int WriterID { get; set; }
        public Writer Writer { get; set; }
        public DateTime? ToDoListDate { get; set; } 
    }
}
