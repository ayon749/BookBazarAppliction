using BookBazar.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookBazar.DataAccess.Repository.IRepository
{
   public interface ICompanyRepository : IRepository<Company>
    {
        public void Update(Company company);
    }
}
