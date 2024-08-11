using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BookManager : IBookService
    {

        IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public Book GetByID(int id)
        {
            return _bookDal.Get(x => x.Id == id);
        }

        public List<Book> GetList(int id)
        {
          return _bookDal.List(x=>x.WriterID == id);
        }

        public List<Book> GetListByWriter(int id)
        {
            throw new NotImplementedException();
        }

        public void BookAdd(Book book)
        {
            _bookDal.Add(book);
        }

        public void BookDelete(Book book)
        {
           _bookDal.Delete(book);
        }

        public void BookUpdate(Book book) 
        {
          _bookDal.Update(book);
        }
    }
}
