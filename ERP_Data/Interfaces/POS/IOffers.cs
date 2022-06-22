using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Data.Interfaces
{
    public interface IOffers
    {

        int DeleteOffer(int Code);

        int UpdateOffer(Database_Models.Offers Offer);

        int AddNewOffer(Database_Models.Offers Offer);

        object GetOffersData();

    }
}
