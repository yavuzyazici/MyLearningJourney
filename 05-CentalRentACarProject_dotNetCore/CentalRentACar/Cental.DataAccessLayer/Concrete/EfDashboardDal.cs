using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repositories;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Concrete
{
    public class EfDashboardDal : IDashboardDal
    {
        protected readonly CentalContext _context;

        public EfDashboardDal(CentalContext context)
        {
            _context = context;
        }
        public int GetCount<T>() where T : BaseEntity
        {
            return _context.Set<T>().Count();
        }
        public List<T> Where<T>(Expression<Func<T, bool>> exp) where T : BaseEntity
        {
            return _context.Set<T>().Where(exp).ToList();
        }
    }
}
