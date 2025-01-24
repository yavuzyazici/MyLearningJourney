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
    public class ProcessManager : IProcessService
    {
        private readonly IProcessDal _processDal;

        public ProcessManager(IProcessDal processDal)
        {
            _processDal = processDal;
        }

        public void TCreate(Process entity)
        {
            _processDal.Create(entity);
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
    }
}
