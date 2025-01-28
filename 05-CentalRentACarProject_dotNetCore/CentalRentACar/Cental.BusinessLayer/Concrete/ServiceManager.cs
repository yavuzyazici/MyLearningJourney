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
    public class ServiceManager(IServiceDal _serviceDal, IMapper _mapper) : IServiceService
    {
        public void TCreate(Service entity)
        {
            _serviceDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Service>(dto);
            _serviceDal.Create(data);
        }

        public void TDelete(int id)
        {
            _serviceDal.Delete(id);
        }

        public List<Service> TGetAll()
        {
            return _serviceDal.GetAll();
        }

        public Service TGetById(int id)
        {
            return _serviceDal.GetById(id);
        }

        public Service TGetFirst()
        {
            return _serviceDal.GetFirst();
        }

        public void TUpdate(Service entity)
        {
            _serviceDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Service>(dto);
            _serviceDal.Update(data);
        }
    }
}
