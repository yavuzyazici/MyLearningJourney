using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repositories;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Concrete
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        protected readonly CentalContext _context;
        public EfBookingDal(CentalContext context) : base(context)
        {
            _context = context;
        }

        public List<Booking> GetByUserName(string userName)
        {
            var user = _context.Users.Where(x=> x.UserName == userName).FirstOrDefault();
            return _context.Bookings.Where(x => user.UserName == userName).ToList();
        }
    }
}
