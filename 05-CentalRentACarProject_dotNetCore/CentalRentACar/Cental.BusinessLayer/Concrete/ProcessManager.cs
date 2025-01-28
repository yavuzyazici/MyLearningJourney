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
    public class ProcessManager(IProcessDal _processDal, IMapper _mapper) : IProcessService
    {
        public void TCreate(Process entity)
        {
            _processDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Process>(dto);
            _processDal.Create(data);
        }

        public void TDelete(int id)
        {
            _processDal.Delete(id);
        }

        public List<Process> TGetAll()
        {
            return _processDal.GetAll();
        }

        public Process TGetById(int id)
        {
            return _processDal.GetById(id);
        }

        public Process TGetFirst()
        {
            return _processDal.GetFirst();
        }

        public void TUpdate(Process entity)
        {
            _processDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Process>(dto);
            _processDal.Update(data);
        }
    }
}
