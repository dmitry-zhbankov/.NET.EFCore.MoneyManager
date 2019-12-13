﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Models;

namespace MoneyManager.Controllers
{
    public class UserController : Controller
    {
        IUnitOfWork unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var users = unitOfWork.UserRepository.Get((user) => true);
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (user==null)
            {
                return new BadRequestResult();
            }
            try
            {
                unitOfWork.UserRepository.Create(user);
                unitOfWork.Save();
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }
        
        public IActionResult Details(int? userId)
        {
            if (userId==null)
            {
                return new BadRequestResult();
            }
            User user = unitOfWork.UserRepository.GetById((int)userId);
            return View(user);
        }

        public IActionResult Delete(int? userId)
        {
            if (userId == null)
            {
                return new BadRequestResult();
            }
            try
            {
                unitOfWork.UserRepository.Delete((int)userId);
                unitOfWork.Save();
            }
            catch
            {
                ViewBag.Message = "Delete error";
                return View();
            }
            ViewBag.Message = "Successfully deleted";
            return View();
        }

        public IActionResult Edit(int? userId)
        {
            if (userId == null)
            {
                return new BadRequestResult();
            }
            var user = unitOfWork.UserRepository.GetById((int)userId);
            return View(user);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<ActionResult> EditPost(int? userId)
        {
            if (userId==null)
            {
                return new BadRequestResult();
            }
            var user = unitOfWork.UserRepository.GetById((int)userId);
            if (await TryUpdateModelAsync(user))
            {
                try
                {
                    unitOfWork.UserRepository.Update(user);
                    unitOfWork.Save();
                }
                catch
                {
                    return View(user);
                }
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}