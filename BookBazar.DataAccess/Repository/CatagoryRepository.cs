using BookBazar.DataAccess.Data;
using BookBazar.DataAccess.Repository.IRepository;
using BookBazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookBazar.DataAccess.Repository
{
    public class CatagoryRepository : Repository<Catagory>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CatagoryRepository(ApplicationDbContext db):base (db)
        {
            _db = db;
        }

        

        public void Update(Catagory catagory)
        {
            var objFromDb = _db.Catagoires.FirstOrDefault(s => s.CatagoryId == catagory.CatagoryId);
            if (objFromDb != null)
            {
                objFromDb.Name = catagory.Name;

            }
        }
    }
}
