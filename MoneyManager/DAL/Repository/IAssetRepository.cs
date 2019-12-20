using System.Collections.Generic;

namespace MoneyManager.Models
{
    public interface IAssetRepository : IRepository<Asset>
    {
        IEnumerable<Asset> GetByUser(int userId);
    }
}