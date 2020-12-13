using BookBazar.DataAccess.Data;
using BookBazar.DataAccess.Repository.IRepository;
using BookBazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookBazar.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db):base (db)
        {
            _db = db;
        }

        

      
    }
}
