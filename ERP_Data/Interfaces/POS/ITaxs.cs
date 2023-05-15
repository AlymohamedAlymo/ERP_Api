using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Data.Interfaces
{
    public interface ITaxs
    {

        int DeleteTax(int Code);

        int UpdateTax(Database_Models.Tax Tax);

        int AddNewTax(Database_Models.Tax Tax);

        object GetTaxsData();


    }
}
