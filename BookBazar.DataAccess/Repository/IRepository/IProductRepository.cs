using BookBazar.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookBazar.DataAccess.Repository.IRepository
{
   public interface IProductRepository :IRepository<Product>
    {
        public void Update(Product product);
    }
}
