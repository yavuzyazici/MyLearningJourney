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
    public class CarManager(ICarDal _carDal, IMapper _mapper) : ICarService
    {
        public void TCreate(Car entity)
        {
            _carDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Car>(dto);
            _carDal.Create(data);
        }

        public void TDelete(int id)
        {
            _carDal.Delete(id);
        }

        public List<Car> TGetAll()
        {
            return _carDal.GetAll();
        }

        public Car TGetById(int id)
        {
            return _carDal.GetById(id);
        }
        public Car TGetFirst()
        {
            return _carDal.GetFirst();
        }

        public void TUpdate(Car entity)
        {
            _carDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Car>(dto);
            _carDal.Update(data);
        }
    }
}
