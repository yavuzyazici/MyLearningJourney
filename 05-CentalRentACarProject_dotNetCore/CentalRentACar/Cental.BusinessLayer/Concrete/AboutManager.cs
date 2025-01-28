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
    public class AboutManager(IAboutDal _aboutDal, IMapper _mapper) : IAboutService
    {
        public void TCreate(About entity)
        {
            _aboutDal.Create(entity);
        }
        public void TCreate<TDto>(TDto dto)
        {
            var data = _mapper.Map<About>(dto);
            _aboutDal.Create(data);
        }
        public void TDelete(int id)
        {
            _aboutDal.Delete(id);
        }

        public List<About> TGetAll()
        {
            return _aboutDal.GetAll();
        }
        public About TGetFirst()
        {
            return _aboutDal.GetFirst();
        }

        public About TGetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public void TUpdate(About entity)
        {
            _aboutDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = _mapper.Map<About>(dto);
            _aboutDal.Update(data);
        }
    }
}
