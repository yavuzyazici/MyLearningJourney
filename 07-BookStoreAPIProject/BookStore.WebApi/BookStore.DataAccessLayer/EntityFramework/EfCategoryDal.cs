using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using BookStore.DataAccessLayer.Repositories;
using BookStore.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly BookStoreContext _context;
        public EfCategoryDal(BookStoreContext context) : base(context)
        {
            _context = context;
        }

        public List<Category> GetCategoriesWithProducts()
        {
            return _context.Categories.Include(c => c.Products).ToList();
        }
    }
}
