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

        int UpdateDiscount(Database_Models.Discounts Dis);

        int AddNewDiscount(Database_Models.Discounts Dis);

        object GetDiscountsData();

    }
}
