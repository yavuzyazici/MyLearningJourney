using BookStore.BusinessLayer.Abstract;
using BookStore.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLayer.Concrete
{
    public class DashboardManager : IDashboardService
    {
        private readonly IDashboardDal _dashboardDal;

        public DashboardManager(IDashboardDal dashboardDal)
        {
            _dashboardDal = dashboardDal;
        }

        public int GetCount<T>() where T : class
        {
            return _dashboardDal.GetCount<T>();
        }

        public List<T> GetList<T>() where T : class
        {
            return _dashboardDal.GetList<T>();
        }

        public List<T> Where<T>(Expression<Func<T, bool>> exp) where T : class
        {
            return _dashboardDal.Where(exp);
        }
    }
}
