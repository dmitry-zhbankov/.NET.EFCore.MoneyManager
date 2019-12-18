using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MoneyManager.Models
{
    public class AssetRepository : GenericRepository<Asset>
    {
        public AssetRepository(MoneyContext context) : base(context)
        {
        }
        
        public IEnumerable<Asset> GetByUser(int userId)
        {
            return Get(x => x.User.UserId == userId).OrderBy(x=>x.Name);
        }
    }
}
