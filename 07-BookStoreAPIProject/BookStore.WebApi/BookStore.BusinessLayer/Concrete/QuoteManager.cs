using BookStore.BusinessLayer.Abstract;
using BookStore.DataAccessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLayer.Concrete
{
    public class QuoteManager : IQuoteService
    {
        private readonly IQuoteDal _quoteDal;

        public QuoteManager(IQuoteDal quoteDal)
        {
            _quoteDal = quoteDal;
        }

        public void TAdd(Quote entity)
        {
            _quoteDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _quoteDal.Delete(id);
        }

        public List<Quote> TGetAll()
        {
            return _quoteDal.GetAll();
        }

        public Quote TGetById(int id)
        {
            return _quoteDal.GetById(id);
        }

        public void TUpdate(Quote entity)
        {
            _quoteDal.Update(entity);
        }
    }
}
