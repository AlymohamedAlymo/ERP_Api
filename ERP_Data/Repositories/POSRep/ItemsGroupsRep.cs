using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Data.Database_Models;
using ERP_Data.Interfaces;

namespace ERP_Data.Repositories
{
    public class ItemsGroupsRep : IItemsGroups
    {


        public List<ItemGroup> GetItemsGroups()
        {
            try
            {
                var DB = new ERPEntities();
                return DB.ItemGroups.ToList();

            }
            catch { return null; }

        }

    }
}
