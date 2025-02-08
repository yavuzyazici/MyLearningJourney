using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IDashboardService
    {
        List<T> Where<T>(Expression<Func<T, bool>> exp) where T : BaseEntity;
        int GetCount<T>() where T : BaseEntity;
    }
}
