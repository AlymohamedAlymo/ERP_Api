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

        int UpdateTax(Database_Models.Taxs Tax);

        int AddNewTax(Database_Models.Taxs Tax);

        object GetTaxsData();


    }
}
