using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class DashboardManager(IDashboardDal _dashboardDal) : IDashboardService
    {
        public int GetCount<T>() where T : BaseEntity
        {
            return _dashboardDal.GetCount<T>();
        }

        public List<T> Where<T>(Expression<Func<T, bool>> exp) where T : BaseEntity
        {
            return _dashboardDal.Where(exp);
        }
    }
}
