using BookBazar.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookBazar.Models;

namespace BookBazar.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Catagory : Controller
    {
        private readonly IUnitOfWork _iUnitOfWork;

        public Catagory(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            BookBazar.Models.Catagory catagory = new BookBazar.Models.Catagory();
            if (id == null)
            {
                return View(catagory);
            }
            catagory = _iUnitOfWork.Catagory.Get(id.GetValueOrDefault());
            if (catagory == null)
            {
                return NotFound();
            }
            return View(catagory);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BookBazar.Models.Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                if (catagory.CatagoryId == 0)
                {
                    _iUnitOfWork.Catagory.Add(catagory);
                }
                else
                {
                    _iUnitOfWork.Catagory.Update(catagory);
                }
                _iUnitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(catagory);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _iUnitOfWork.Catagory.GetAll();

            return Json(new { data = allObj });

        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var catFromDb = _iUnitOfWork.Catagory.Get(id);
            if (catFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _iUnitOfWork.Catagory.Remove(catFromDb);
            _iUnitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
