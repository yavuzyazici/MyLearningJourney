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
    public class BookingManager(IBookingDal _bookingDal, IMapper _mapper) : IBookingService
    {
        public List<Booking> GetByUserName(string userName)
        {
            return _bookingDal.GetByUserName(userName);
        }

        public void TCreate(Booking entity)
        {
            _bookingDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Booking>(dto);
            _bookingDal.Create(data);
        }

        public void TDelete(int id)
        {
            _bookingDal.Delete(id);
        }

        public List<Booking> TGetAll()
        {
            return _bookingDal.GetAll();
        }

        public Booking TGetById(int id)
        {
            return _bookingDal.GetById(id);
        }

        public Booking TGetFirst()
        {
            return _bookingDal.GetFirst();
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Booking>(dto);
            _bookingDal.Update(data);
        }
    }
}
