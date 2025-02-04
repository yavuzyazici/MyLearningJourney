using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : BaseEntity
    {
        List<T> TGetAll();
        T TGetById(int id);
        T TGetFirst();
        void TDelete(int id);
        void TCreate(T entity);
        void TCreate<TDto>(TDto dto);
        void TUpdate(T entity);
        void TUpdate<TDto>(TDto dto);
    }
}