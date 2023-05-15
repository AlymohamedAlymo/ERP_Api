using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Data.Interfaces
{
    public interface IBranchs
    {

        int DeleteBranch(int Code);

        int UpdateBranch(Database_Models.Branch BRN);

        int AddNewBranch(Database_Models.Branch BRN);

        object GetBranchsData();

    }
}
