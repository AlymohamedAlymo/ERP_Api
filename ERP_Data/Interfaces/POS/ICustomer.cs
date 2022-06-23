using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Data.Interfaces
{
    public interface ICustomer
    {




        int DeleteCustomer(int Code);

        int UpdateCustomer(Database_Models.Customer Customer);

        int AddNewCustomer(Database_Models.Customer Customer);


        object GetCustomerData(int Code);

        object GetCustomerSearchData(string SearchContext);

    }
}
