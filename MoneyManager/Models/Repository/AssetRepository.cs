using System.Collections.Generic;

namespace MoneyManager.Models
{
    public class AssetRepository : GenericRepository<Asset>
    {
        public AssetRepository(MoneyContext context) : base(context)
        {
        }
    }
}
