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
    public class TvSerieManager : ITvSerieService
    {
        ITvSerieDal _tvSerieDal;

        public TvSerieManager(ITvSerieDal tvSerieDal)
        {
            _tvSerieDal = tvSerieDal;
        }

        public TvSerie GetByID(int id)
        {
            return _tvSerieDal.Get(x => x.Id == id);
        }

        public List<TvSerie> GetList(int id)
        {
            return _tvSerieDal.List(x => x.WriterID == id);
        }

        public List<TvSerie> GetListByWriter(int id)
        {
            throw new NotImplementedException();
        }

        public void TvSerieAdd(TvSerie tvserie)
        {
            _tvSerieDal.Add(tvserie);
        }

        public void TvSerieDelete(TvSerie tvserie)
        {
            _tvSerieDal.Delete(tvserie);
        }

        public void TvSerieUpdate(TvSerie tvserie)
        {
            _tvSerieDal.Update(tvserie);
        }
    }
}
