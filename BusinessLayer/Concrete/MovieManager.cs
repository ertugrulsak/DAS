using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MovieManager : IMovieDal
    {

        IMovieDal _movieDal;

        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        public void Add(Movie p)
        {
            _movieDal.Add(p);
        }

        public void Delete(Movie p)
        {
            _movieDal.Delete(p);
        }

        public Movie Get(Expression<Func<Movie, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Movie GetByID(int id)
        {
            return _movieDal.Get(x => x.Id == id);
        }

        public List<Movie> List()
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetList(int id)
        {
            return _movieDal.List(x => x.WriterID == id);
        }

        public List<Movie> List(Expression<Func<Movie, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Movie p)
        {
            _movieDal.Update(p);
        }
    }
}
