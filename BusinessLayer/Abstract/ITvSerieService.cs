using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITvSerieService
    {
        List<TvSerie> GetList(int id);
        List<TvSerie> GetListByWriter(int id); 
        void TvSerieAdd(TvSerie tvserie);
        TvSerie GetByID(int id);

        void TvSerieDelete(TvSerie tvserie);
        void TvSerieUpdate(TvSerie tvserie);
    }
}
