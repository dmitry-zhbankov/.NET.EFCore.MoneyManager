using System;
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
            var users= unitOfWork.UserRepository.Get((user) => true);
            return View(users);
        }
    }
}