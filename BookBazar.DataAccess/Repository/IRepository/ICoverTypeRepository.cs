using BookBazar.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookBazar.DataAccess.Repository.IRepository
{
   public interface ICoverTypeRepository :IRepository<CoverType>
    {
        public void Update(CoverType coverType);
    }
}
