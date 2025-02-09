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
    public class ContactManager(IContactDal _contactDal, IMapper _mapper) : IContactService
    {
        public void TCreate(Contact entity)
        {
            _contactDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Contact>(dto);
            _contactDal.Create(data);
        }

        public void TDelete(int id)
        {
            _contactDal.Delete(id);
        }

        public List<Contact> TGetAll()
        {
            return _contactDal.GetAll();
        }

        public Contact TGetById(int id)
        {
            return _contactDal.GetById(id);
        }

        public Contact TGetFirst()
        {
            return _contactDal.GetFirst();
        }

        public void TUpdate(Contact entity)
        {
            _contactDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Contact>(dto);
            _contactDal.Update(data);
        }
    }
}
