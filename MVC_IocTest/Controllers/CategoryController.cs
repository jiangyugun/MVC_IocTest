﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MVC_IocTest.Models;
using MVC_IocTest.Models.Interface;
using MVC_IocTest.Models.Repositiry;

namespace Mvc_Repository.Controllers
{
    public class CategoryController : Controller
    {
        private IRepository<Categories> categoryRepository;
        public CategoryController()
        {
            this.categoryRepository = new GenericRepository<Categories>();
        }

        public ActionResult Index()
        {
            var categories = this.categoryRepository.GetAll()
                .OrderByDescending(x => x.CategoryID)
                .ToList();

            return View(categories);
        }

        //=========================================================================================

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                var category = this.categoryRepository.Get(x => x.CategoryID == id.Value);
                return View(category);

            }
        }

        //=========================================================================================

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categories category)
        {
            if (category != null && ModelState.IsValid)
            {
                this.categoryRepository.Create(category);
                return RedirectToAction("index");
            }
            else
            {
                return View(category);
            }
        }

        //=========================================================================================

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                var category = this.categoryRepository.Get(x => x.CategoryID == id.Value);
                return View(category);
            }
        }

        [HttpPost]
        public ActionResult Edit(Categories category)
        {
            if (category != null && ModelState.IsValid)
            {
                this.categoryRepository.Update(category);
                return View(category);
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        //=========================================================================================

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                var category = this.categoryRepository.Get(x => x.CategoryID == id.Value);
                return View(category);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var category = this.categoryRepository.Get(x => x.CategoryID == id);
                this.categoryRepository.Delete(category);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id });
            }
            return RedirectToAction("index");
        }

    }
}