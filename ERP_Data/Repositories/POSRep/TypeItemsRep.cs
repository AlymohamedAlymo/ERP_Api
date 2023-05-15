using ERP_Data.Database_Models;
using ERP_Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Data.Repositories
{
    public class TypeItemsRep : ITypeItems
    {

        public List<ItemsType> GetItemsTypes()
        {
            try
            {
                var DB = new ERPEntities();
                return DB.ItemsTypes.ToList();

            }
            catch { return null; }

        }


    }
}
