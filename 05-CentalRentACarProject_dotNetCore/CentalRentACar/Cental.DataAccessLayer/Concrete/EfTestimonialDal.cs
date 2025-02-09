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
    public class EfTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
    {
        protected readonly CentalContext _context;
        public EfTestimonialDal(CentalContext context) : base(context)
        {
            _context = context;
        }

        public Testimonial GetByUserName(string userName)
        {
            return _context.Testimonials.FirstOrDefault(x => x.User.UserName == userName);
        }
    }
}
