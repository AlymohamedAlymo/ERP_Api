using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Data.Interfaces
{
    public interface ISafes
    {

        int DeleteSafe(int Code);

        int UpdateSafe(Database_Models.Safe safe);

        int AddNewSafe(Database_Models.Safe safe);

        object GetSafesData();


    }
}
