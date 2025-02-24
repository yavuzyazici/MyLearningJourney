using BookStore.BusinessLayer.Abstract;
using BookStore.DataAccessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLayer.Concrete
{
    public class SubscriberManager : ISubscriberService
    {
        private readonly ISubscribeDal _subscribeDal;

        public SubscriberManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        public void TAdd(Subscriber entity)
        {
            _subscribeDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _subscribeDal.Delete(id);
        }

        public List<Subscriber> TGetAll()
        {
            return _subscribeDal.GetAll();
        }

        public Subscriber TGetById(int id)
        {
            return _subscribeDal.GetById(id);
        }

        public void TUpdate(Subscriber entity)
        {
            _subscribeDal.Update(entity);
        }
    }
}
