using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Data.Interfaces
{
    public interface IDeliveryAreas
    {

        int DeleteArea(int Code);

        int UpdateArea(Database_Models.DeliveryArea Area);

        int AddNewArea(Database_Models.DeliveryArea Area);

        object GetDeleveryAreasData();

    }
}
