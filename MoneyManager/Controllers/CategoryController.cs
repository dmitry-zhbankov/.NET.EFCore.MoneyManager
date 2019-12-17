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
        public IActionResult Create(int? parentId)
        {
            var category = new Category();
            if (parentId != null)
            {
                var parent = unitOfWork.CategoryRepository.GetById((int)parentId);
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
                var parent = unitOfWork.CategoryRepository.GetById(category.Parent.CategoryId);
                category.Parent = parent;
                unitOfWork.CategoryRepository.Create(category);
                unitOfWork.Save();
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index",new {categoryId=category.Parent.CategoryId});
        }

        public IActionResult Index(int? categoryId)
        {
            IEnumerable<Category> categories;
            if (categoryId != null)
            {
                ViewBag.ParentId = categoryId;
                categories = unitOfWork.CategoryRepository.Get(x => x.Parent.CategoryId == categoryId);
                return View(categories);
            }
            
            categories = unitOfWork.CategoryRepository.Get(x => x.Parent==null);
            return View(categories);
        }

        public IActionResult Details(int? categoryId)
        {
            if (categoryId == null)
            {
                return BadRequest();
            }
            var category=unitOfWork.CategoryRepository.GetById((int)categoryId);
            return View(category);
        }
    }
}