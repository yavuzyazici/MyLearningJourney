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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly BookStoreContext _context;
        public EfProductDal(BookStoreContext context) : base(context)
        {
            _context = context;
        }

        public int GetProductCount()
        {
            return _context.Products.Count();
        }
        public List<Product> GetProductsWithCategories()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }
    }
}
