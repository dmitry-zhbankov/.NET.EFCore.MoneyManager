using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Models;

namespace MoneyManager.Controllers
{
    public class TransactionController : Controller
    {
        IUnitOfWork unitOfWork;

        public TransactionController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index(int? userId)
        {
            IEnumerable<Transaction> transactions;
            if (userId != null)
            {
                transactions = unitOfWork.TransactionRepository.GetUserTransactions((int) userId);
                ViewBag.UserId = userId;
                return View(transactions);
            }

            transactions = unitOfWork.TransactionRepository.Get(x => true);
            return View(transactions);
        }

        public IActionResult Create(int? userId)
        {
            if (userId == null)
            {
                return BadRequest();
            }

            var transaction = new Transaction();
            transaction.User = unitOfWork.UserRepository.GetById((int) userId);
            return View(transaction);
        }

        [HttpPost]
        public ActionResult Create(Transaction transaction)
        {
            if (transaction == null)
            {
                return BadRequest();
            }

            try
            {
                var category = unitOfWork.CategoryRepository.GetById(transaction.Category.CategoryId);
                var asset = unitOfWork.AssetRepository.GetById(transaction.Asset.AssetId);
                var user = unitOfWork.UserRepository.GetById(transaction.User.UserId);
                transaction.Category = category;
                transaction.Asset = asset;
                transaction.User = user;
                transaction.Date = DateTime.Now;

                if (category.Type == CategoryType.Income)
                {
                    asset.Balance += transaction.Amount;
                }

                if (category.Type == CategoryType.Expense)
                {
                    if (asset.Balance >= transaction.Amount)
                    {
                        asset.Balance -= transaction.Amount;
                    }
                    else
                    {
                        ViewBag.Message =
                            $@"Insufficient funds ! Asset '{asset.Name}' Balance = {asset.Balance} < {transaction.Amount}";
                        return View(transaction);
                    }
                }

                unitOfWork.AssetRepository.Update(asset);
                unitOfWork.TransactionRepository.Create(transaction);
                unitOfWork.Save();
            }
            catch
            {
                return View(transaction);
            }

            return RedirectToAction("Index", new {userId = transaction.User.UserId});
        }

        public IActionResult DeleteMonthTransactions(int? userId)
        {
            if (userId == null)
            {
                return RedirectToAction("Index");
            }

            try
            {
                unitOfWork.TransactionRepository.DeleteAllUserMonthTransactions((int) userId);
                TempData["Message"] = $"Successfully deleted {unitOfWork.Save()} records";
                return RedirectToAction("Index", new {userId = userId});
            }
            catch
            {
                throw;
            }
        }
    }
}