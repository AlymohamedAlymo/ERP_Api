using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Data.Interfaces
{
    public interface IPricing
    {

        object GetPricingList();

        int UpdateItemPrice(Database_Models.pricing PricingList);

        int PricingItem(Database_Models.pricing PricingList);

        int ClearPricing(int Code);


    }
}
