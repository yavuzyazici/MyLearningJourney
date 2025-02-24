using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.EntityFramework
{
    public class EfDashboardDal : IDashboardDal
    {
        protected readonly BookStoreContext _context;

        public EfDashboardDal(BookStoreContext context)
        {
            _context = context;
        }
        public int GetCount<T>() where T : class
        {
            return _context.Set<T>().Count();
        }

        public List<T> GetList<T>() where T : class
        {
            return _context.Set<T>().ToList();
        }

        public List<T> Where<T>(Expression<Func<T, bool>> exp) where T : class
        {
            return _context.Set<T>().Where(exp).ToList();
        }
    }
}
