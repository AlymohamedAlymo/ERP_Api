using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Data.Interfaces
{
    public interface IDelevery
    {

        int DeleteDelevery(int Code);

        int UpdateDelevery(Database_Models.Deleverys Delevery);

        int AddNewDelevery(Database_Models.Deleverys Delevery);

        object GetDeleverysData();


    }
}
