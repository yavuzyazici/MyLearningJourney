using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLayer.Abstract
{
    public interface IDashboardService
    {
        List<T> Where<T>(Expression<Func<T, bool>> exp) where T : class;
        int GetCount<T>() where T : class;
        List<T> GetList<T>() where T : class;
    }
}
