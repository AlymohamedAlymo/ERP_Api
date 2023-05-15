using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Data.Interfaces
{
    public interface IDiscounts
    {

        int DeleteDiscount(int Code);

        int UpdateDiscount(Database_Models.Discount Dis);

        int AddNewDiscount(Database_Models.Discount Dis);

        object GetDiscountsData();

    }
}
