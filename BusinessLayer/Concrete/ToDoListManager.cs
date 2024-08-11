using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ToDoListManager : IToDoListService
    {
        IToDoListDal _toDoListDal;

        public ToDoListManager(IToDoListDal toDoListDal)
        {
            _toDoListDal = toDoListDal;
        }

        public ToDoList GetByID(int id)
        {
            return _toDoListDal.Get(x => x.Id == id);
        }

        public List<ToDoList> GetList(int id)
        {
            return _toDoListDal.List(x => x.WriterID == id);
        }

        public List<ToDoList> GetListByWriter(int id)
        {
            throw new NotImplementedException();
        }

        public void ToDoListAdd(ToDoList toDoList)
        {
            _toDoListDal.Add(toDoList);
        }

        public void ToDoListDelete(ToDoList toDoList)
        {
            _toDoListDal.Delete(toDoList);
        }

        public void ToDoListUpdate(ToDoList toDoList)
        {
            _toDoListDal.Update(toDoList);
        }
    }
}
