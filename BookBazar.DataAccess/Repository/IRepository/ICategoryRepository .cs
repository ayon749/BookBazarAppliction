using BookBazar.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookBazar.DataAccess.Repository.IRepository
{
   public interface ICategoryRepository : IRepository<Catagory>
    {
        public void Update(Catagory catagory);
    }
}
