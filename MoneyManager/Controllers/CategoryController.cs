using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Models;

namespace MoneyManager.Controllers
{
    public class CategoryController : Controller
    {
        IUnitOfWork unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Create(int? categoryId)
        {
            var category = new Category();
            if (categoryId != null)
            {
                var parent = unitOfWork.CategoryRepository.GetById((int)categoryId);
                category.Parent = parent;
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            try
            {
                
                unitOfWork.CategoryRepository.Create(category);
                unitOfWork.Save();
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Index(int? categoryId)
        {
            IEnumerable<Category> categories;
            if (categoryId != null)
            {
                ViewBag.ParentId = categoryId;
                categories = unitOfWork.CategoryRepository.GetById((int) categoryId).Children;
                return View(categories);
            }
            
            categories = unitOfWork.CategoryRepository.Get(x => true);
            return View(categories);
        }

        public IActionResult Details(int? categoryId)
        {
            if (categoryId==null)
            {
                return BadRequest();
            }
            var category=unitOfWork.CategoryRepository.GetById((int)categoryId);
            return View(category);
        }
    }
}