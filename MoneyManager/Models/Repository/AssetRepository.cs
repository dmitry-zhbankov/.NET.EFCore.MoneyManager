using System.Collections.Generic;

namespace Money_Manager.Models
{
    public class AssetRepository : GenericRepository<Asset>
    {
        public AssetRepository(MoneyContext context) : base(context)
        {
        }
    }
}
