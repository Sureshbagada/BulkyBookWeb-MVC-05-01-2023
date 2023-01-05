using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        //private readonly int a;

        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            //var objCategoryList = _applicationDbContext.Categories.ToList();

            IEnumerable<Category> objCategoryList = _applicationDbContext.Categories;

            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Display order and Name can be differ");
            }
            if (ModelState.IsValid)
            {
                _applicationDbContext.Categories.Add(obj);
                _applicationDbContext.SaveChanges();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromdDb = _applicationDbContext.Categories.Find(id);

            if (categoryFromdDb == null)
            {
                return NotFound();
            }

            return View(categoryFromdDb);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Display order and Name can be differ");
            }
            if (ModelState.IsValid)
            {
                _applicationDbContext.Categories.Update(obj);
                _applicationDbContext.SaveChanges();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromdDb = _applicationDbContext.Categories.Find(id);

            if (categoryFromdDb == null)
            {
                return NotFound();
            }

            return View(categoryFromdDb);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _applicationDbContext.Categories.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            _applicationDbContext.Categories.Remove(obj);
            _applicationDbContext.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");


        }
    }
}
