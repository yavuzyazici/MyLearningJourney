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
    public class GenericManager<T>(IGenericDal<T> _genericDal, IMapper _mapper) : IGenericService<T> where T : BaseEntity
    {
        public void TCreate(T entity)
        {
            _genericDal.Create(entity);
        }
        public void TCreate<TDto>(TDto dto)
        {
            var data = _mapper.Map<T>(dto);
            _genericDal.Create(data);
        }
        public void TDelete(int id)
        {
            _genericDal.Delete(id);
        }

        public List<T> TGetAll()
        {
           return _genericDal.GetAll();
        }
        public T TGetFirst()
        {
            return _genericDal.GetFirst();
        }

        public T TGetById(int id)
        {
            return _genericDal.GetById(id);
        }

        public void TUpdate(T entity)
        {
            _genericDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = _mapper.Map<T>(dto);
            _genericDal.Update(data);
        }
    }
}
