using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Data.Interfaces
{
    public interface IStores
    {

        int DeleteStore(int Code);

        int UpdateStore(Database_Models.Store store);

        int AddNewStore(Database_Models.Store store);

        object GetStoresData();


    }
}
