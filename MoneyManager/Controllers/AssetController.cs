using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Models;

namespace MoneyManager.Controllers
{
    public class AssetController : Controller
    {

        IUnitOfWork unitOfWork;

        public AssetController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Create(int? userId)
        {
            if (userId == null)
            {
                return BadRequest();
            }
            var user = unitOfWork.UserRepository.GetById((int)userId);
            var asset=new Asset();
            asset.User = user;
            return View(asset);
        }

        [HttpPost]
        public ActionResult Create(Asset asset)
        {
            if (asset == null)
            {
                return BadRequest();
            }
            try
            {
                var user = unitOfWork.UserRepository.GetById(asset.User.UserId);
                asset.User = user;
                unitOfWork.AssetRepository.Create(asset);
                unitOfWork.Save();
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index",new {userId=asset.User.UserId});
        }


        public IActionResult Index(int? userId)
        {
            if (userId == null)
            {
                return BadRequest();
            }
            var assets = unitOfWork.AssetRepository.GetByUser((int)userId);
            ViewBag.User = unitOfWork.UserRepository.GetById((int)userId);
            return View(assets);
        }
    }
}