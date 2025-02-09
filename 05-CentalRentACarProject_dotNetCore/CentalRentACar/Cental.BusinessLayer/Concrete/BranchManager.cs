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
    public class BranchManager(IBranchDal _branchDal, IMapper _mapper) : IBranchService
    {
        public void TCreate(Branch entity)
        {
            _branchDal.Create(entity);
        }

        public void TCreate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Branch>(dto);
            _branchDal.Create(data);
        }

        public void TDelete(int id)
        {
            _branchDal.Delete(id);
        }

        public List<Branch> TGetAll()
        {
            return _branchDal.GetAll();
        }

        public Branch TGetById(int id)
        {
            return _branchDal.GetById(id);
        }

        public Branch TGetFirst()
        {
            return _branchDal.GetFirst();
        }

        public void TUpdate(Branch entity)
        {
            _branchDal.Update(entity);
        }

        public void TUpdate<TDto>(TDto dto)
        {
            var data = _mapper.Map<Branch>(dto);
            _branchDal.Update(data);
        }
    }
}
