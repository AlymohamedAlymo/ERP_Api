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

        int UpdateSafe(Database_Models.Safes safe);

        int AddNewSafe(Database_Models.Safes safe);

        object GetSafesData();


    }
}
