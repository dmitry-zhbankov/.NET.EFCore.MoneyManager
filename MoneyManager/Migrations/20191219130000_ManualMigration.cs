using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using MoneyManager.Models;

namespace MoneyManager.Migrations
{
    [DbContext(typeof(MoneyContext))]
    [Migration("20191219130000_ManualMigration")]
    public class ManualMigration : Migration
    {
        private IUnitOfWork unitOfWork;

        public ManualMigration()
        {
            unitOfWork = MigrationManager.UnitOfWorkInstance;
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var parents = unitOfWork.CategoryRepository.Get(x => x.Parent == null);
            foreach (var parent in parents)
            {
                UpdateCategoryTransactionsRecursive(parent);
            }
            unitOfWork.Save();
        }

        void UpdateCategoryTransactionsRecursive(Category parent)
        {
            foreach (var item in parent.Children)
            {
                var child = unitOfWork.CategoryRepository.GetById(item.CategoryId);
                var transactions = unitOfWork.TransactionRepository.Get(x => x.Category.CategoryId == child.CategoryId);
                foreach (var transaction in transactions)
                {
                    transaction.Category = parent;
                    unitOfWork.TransactionRepository.Update(transaction);
                }
                UpdateCategoryTransactionsRecursive(item);
                unitOfWork.CategoryRepository.Delete(item.CategoryId);
            }
        }
    }
}
