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
    public class BrandManager(IBrandDal _brandDal,IMapper _mapper)  : IBrandService
    {
        public void TCreate(Brand entity)
        {
            _brandDal.Create(entity);
        }
        public void TCreate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Brand>(dto);
            _brandDal.Create(data);
        }
        public void TDelete(int id)
        {
            _brandDal.Delete(id);
        }
        public List<Brand> TGetAll()
        {
            return _brandDal.GetAll();
        }
        public Brand TGetById(int id)
        {
            return _brandDal.GetById(id);
        }

        public Brand TGetFirst()
        {
            return _brandDal.GetFirst();
        }

        public void TUpdate(Brand entity)
        {
            _brandDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Brand>(dto);
            _brandDal.Update(data);
        }
    }
}
