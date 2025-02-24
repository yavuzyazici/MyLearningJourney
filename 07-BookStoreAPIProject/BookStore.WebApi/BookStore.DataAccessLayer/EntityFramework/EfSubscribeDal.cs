using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using BookStore.DataAccessLayer.Repositories;
using BookStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.EntityFramework
{
    public class EfSubscribeDal : GenericRepository<Subscriber>, ISubscribeDal
    {
        public EfSubscribeDal(BookStoreContext context) : base(context)
        {
        }
    }
}
