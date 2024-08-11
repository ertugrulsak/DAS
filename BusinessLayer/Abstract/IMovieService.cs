using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMovieService
    {
        List<Movie> GetList(int id);
        List<Movie> GetListByWriter(int id);
        void MovieAdd(Movie movie); 
        Movie GetByID(int id);

        void MovieDelete(Movie movie);
        void MovieUpdate(Movie movie); 
    }
}

