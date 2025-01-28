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
    public class ReviewManager(IReviewDal _reviewDal, IMapper _mapper) : IReviewService
    {
        public void TCreate(Review entity)
        {
            _reviewDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Review>(dto);
            _reviewDal.Create(data);
        }

        public void TDelete(int id)
        {
            _reviewDal.Delete(id);
        }

        public List<Review> TGetAll()
        {
            return _reviewDal.GetAll();
        }

        public Review TGetById(int id)
        {
            return _reviewDal.GetById(id);
        }

        public Review TGetFirst()
        {
            return _reviewDal.GetFirst();
        }

        public void TUpdate(Review entity)
        {
            _reviewDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Review>(dto);
            _reviewDal.Update(data);
        }
    }
}
