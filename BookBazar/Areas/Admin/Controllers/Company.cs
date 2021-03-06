﻿using BookBazar.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookBazar.Models;

namespace BookBazar.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Company : Controller
    {
        private readonly IUnitOfWork _iUnitOfWork;

        public Company(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            BookBazar.Models.Company company = new BookBazar.Models.Company();
            if (id == null)
            {
                return View(company);
            }
            company = _iUnitOfWork.Company.Get(id.GetValueOrDefault());
            if (company == null)
            {
                return NotFound();
            }
            return View(company);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BookBazar.Models.Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.Id == 0)
                {
                    _iUnitOfWork.Company.Add(company);
                }
                else
                {
                    _iUnitOfWork.Company.Update(company);
                }
                _iUnitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _iUnitOfWork.Company.GetAll();

            return Json(new { data = allObj });

        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var catFromDb = _iUnitOfWork.Company.Get(id);
            if (catFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _iUnitOfWork.Company.Remove(catFromDb);
            _iUnitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
