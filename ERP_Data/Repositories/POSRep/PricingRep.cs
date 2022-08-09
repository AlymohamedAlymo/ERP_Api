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
    public  class PricingRep : IPricing
    {

        public int UpdateItemPrice(Database_Models.pricing PricingList)
        {

            try
            {
                using (var context = new ERPEntities())
                {
                    pricing UpdatePricingList = context.pricing.Where(u => u.IDItem == PricingList.IDItem).FirstOrDefault(); ;

                    if (UpdatePricingList == null)
                    {
                        context.pricing.Add(PricingList);

                    }

                    else
                    {
                        //if (TypePrice == "جملة") UpdatePricingList.WholesPrice = PricingList.WholesPrice;

                        //else if (TypePrice == "نص جملة") UpdatePricingList.HalfWhoPr = PricingList.HalfWhoPr;
                        //else UpdatePricingList.SellingPr = PricingList.SellingPr;

                        UpdatePricingList.DateMove = PricingList.DateMove;
                        UpdatePricingList.DetMove = PricingList.DetMove;
                        UpdatePricingList.HalfWhoPr = PricingList.HalfWhoPr;
                        UpdatePricingList.IDItem = PricingList.IDItem;
                        UpdatePricingList.SellingPr = PricingList.SellingPr;
                        UpdatePricingList.SupplyPrice = PricingList.SupplyPrice;
                        UpdatePricingList.WholesPrice = PricingList.WholesPrice;

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


        public int PricingItem(Database_Models.pricing PricingList)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    context.pricing.Add(PricingList);
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


        public int ClearPricing(int Code)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    pricing pricing = context.pricing.Where(u => u.IDMove == Code).SingleOrDefault();
                    if (pricing == null)
                    {
                        return 2;
                    }
                    context.pricing.Remove(pricing);
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
                return 0;
            }

        }

        public object GetPricingList()
        {
            try
            {
                var db = new ERPEntities();
                return db.pricing.ToList();

            }
            catch
            {

                return null;
            }

        }


    }
}
