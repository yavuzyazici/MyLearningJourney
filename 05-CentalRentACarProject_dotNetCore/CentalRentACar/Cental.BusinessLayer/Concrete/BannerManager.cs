using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DtoLayer.BannerDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class BannerManager(IBannerDal _bannerDal, IMapper _mapper) : IBannerService
    {
        public void TCreate(Banner entity)
        {
            _bannerDal.Create(entity);
        }
        public void TCreate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Banner>(dto);
            _bannerDal.Create(data);
        }
        public void TDelete(int id)
        {
            _bannerDal.Delete(id);
        }

        public List<Banner> TGetAll()
        {
            return _bannerDal.GetAll();
        }

        public Banner TGetById(int id)
        {
            return _bannerDal.GetById(id);
        }

        public Banner TGetFirst()
        {
            return _bannerDal.GetFirst();
        }

        public void TUpdate(Banner entity)
        {
            _bannerDal.Update(entity);
        }
        public void TUpdate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Banner>(dto);
            _bannerDal.Update(data);
        }
    }
}
