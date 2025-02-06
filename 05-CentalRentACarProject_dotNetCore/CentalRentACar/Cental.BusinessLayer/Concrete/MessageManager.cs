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
    public class MessageManager(IMessageDal _messageDal, IMapper _mapper) : IMessageService
    {
        public void TCreate(Message entity)
        {
            _messageDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Message>(dto);
            _messageDal.Create(data);
        }

        public void TDelete(int id)
        {
            _messageDal.Delete(id);
        }

        public List<Message> TGetAll()
        {
            return _messageDal.GetAll();
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public Message TGetFirst()
        {
            return _messageDal.GetFirst();
        }

        public void TUpdate(Message entity)
        {
            _messageDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Message>(dto);
            _messageDal.Update(data);
        }
    }
}
