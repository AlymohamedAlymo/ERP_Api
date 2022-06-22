using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Data.Interfaces
{
    public interface IKeepers
    {

        int DeleteKeeper(int Code);

        int UpdateKeeper(Database_Models.Keepers Kp);

        int AddNewKeeper(Database_Models.Keepers Kp);

        object GetKeepersData();

    }
}
