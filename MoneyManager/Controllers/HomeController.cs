using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Money_Manager.Models;

namespace Money_Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        UnitOfWork unitOfWork;

        public HomeController(ILogger<HomeController> logger, MoneyContext context)
        {
            this.logger = logger;
            unitOfWork = UnitOfWork.GetInstance(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
