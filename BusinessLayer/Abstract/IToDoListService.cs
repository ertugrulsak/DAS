using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IToDoListService
    {
        List<ToDoList> GetList(int id);
        List<ToDoList> GetListByWriter(int id);
        void ToDoListAdd(ToDoList toDoList); 
        ToDoList GetByID(int id);

        void ToDoListDelete(ToDoList toDoList); 
        void ToDoListUpdate(ToDoList toDoList);
    }
}
