using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Concrete;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class TestimonialManager(ITestimonialDal _testimonialDal, IMapper _mapper) : ITestimonialService
    {
        public void TCreate(Testimonial entity)
        {
            _testimonialDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Testimonial>(dto);
            _testimonialDal.Create(data);
        }

        public void TDelete(int id)
        {
            _testimonialDal.Delete(id);
        }

        public List<Testimonial> TGetAll()
        {
            return _testimonialDal.GetAll();
        }

        public Testimonial TGetById(int id)
        {
            return _testimonialDal.GetById(id);
        }

        public Testimonial TGetFirst()
        {
            return _testimonialDal.GetFirst();
        }

        public void TUpdate(Testimonial entity)
        {
            _testimonialDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Testimonial>(dto);
            _testimonialDal.Update(data);
        }
    }
}
