using ERP_Data.CustomExceptions;
using ERP_Data.Database_Models;
using ERP_Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Data.Repositories
{
    public class SupplyRep : ISupply
    {

        public int UpdateSupply(Database_Models.Supply supply)
        {

            try
            {
                using (var context = new ERPEntities())
                {
                    Supply UpdateSupply = context.Supply.Where(u => u.IDMove == supply.IDMove).FirstOrDefault(); ;

                    if (UpdateSupply == null)
                    {
                        context.Supply.Add(UpdateSupply);

                    }

                    else
                    {
                        //if (TypePrice == "جملة") UpdatePricingList.WholesPrice = PricingList.WholesPrice;

                        //else if (TypePrice == "نص جملة") UpdatePricingList.HalfWhoPr = PricingList.HalfWhoPr;
                        //else UpdatePricingList.SellingPr = PricingList.SellingPr;

                        UpdateSupply.Amount  = supply.Amount;
                        UpdateSupply.DateMove  = supply.DateMove;
                        UpdateSupply.DetailsMove  = supply.DetailsMove;
                        UpdateSupply.IDBill  = supply.IDBill;
                        UpdateSupply.IDSupplier  = supply.IDSupplier;
                        UpdateSupply.ItemID  = supply.ItemID;
                        UpdateSupply.limitItem  = supply.limitItem;
                        UpdateSupply.PurPrice  = supply.PurPrice;
                        UpdateSupply.StoreID = supply.StoreID;
                        UpdateSupply.TypMove = supply.TypMove;
                        UpdateSupply.UserID = supply.UserID;
                        UpdateSupply.validity = supply.validity;

                    }


                    int result = context.SaveChanges();
                    return result;
                }
            }
            catch
            {
                return 0;
            }


        }


        public int SupplyItem(Database_Models.Supply supply)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    context.Supply.Add(supply);
                    int res = context.SaveChanges();
                    if (res > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;

                    }
                }

            }

            catch
            {
                throw new InvalidDataException();
            }

        }



        public object GetSupplyList()
        {
            try
            {
                var db = new ERPEntities();
                return db.Supply.ToList();

            }
            catch
            {

                return null;
            }

        }


    }
}
