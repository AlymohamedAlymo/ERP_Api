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

        int UpdateArea(Database_Models.DeliveryAreas Area);

        int AddNewArea(Database_Models.DeliveryAreas Area);

        object GetDeleveryAreasData();

    }
}
