using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Data.Interfaces
{
    public interface ISupply
    {

        object GetSupplyList();

        int UpdateSupply(Database_Models.Supply supply);

        int SupplyItem(Database_Models.Supply supply);



    }
}
