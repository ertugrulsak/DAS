using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBookService
    {
        List<Book> GetList(int id);
        List<Book> GetListByWriter(int id);   
        void BookAdd(Book book);
        Book GetByID(int id);

        void BookDelete(Book book); 
        void BookUpdate(Book book); 
    }
}
