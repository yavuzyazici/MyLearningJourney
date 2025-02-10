using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class SubscriberManager(ISubscriberDal _subscriberDal, IMapper _mapper) : ISubscriberService
    {
        public void TCreate(Subscriber entity)
        {
            _subscriberDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Subscriber>(dto);
            _subscriberDal.Create(data);
        }

        public void TDelete(int id)
        {
            _subscriberDal.Delete(id);
        }

        public List<Subscriber> TGetAll()
        {
            return _subscriberDal.GetAll();
        }

        public Subscriber TGetById(int id)
        {
            return _subscriberDal.GetById(id);
        }

        public Subscriber TGetFirst()
        {
            return _subscriberDal.GetFirst();
        }

        public void TUpdate(Subscriber entity)
        {
            _subscriberDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Subscriber>(dto);
            _subscriberDal.Update(data);
        }
    }
}
