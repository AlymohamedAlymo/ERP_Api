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
    public class OffersRep : IOffers
    {


        string connectionString = ERP_SettingRep.ConnectionStrings;


        public int DeleteOffer(int Code)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    Offers Offer = context.Offers.Where(u => u.ID == Code).SingleOrDefault();
                    if (Offer == null)
                    {
                        return 2;
                    }
                    context.Offers.Remove(Offer);
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


        public int UpdateOffer(Database_Models.Offers Offer)
        {

            try
            {
                using (var context = new ERPEntities())
                {
                    Offers UpdateOffer = context.Offers.Where(u => u.ID == Offer.ID).FirstOrDefault(); ;

                    UpdateOffer.Note = Offer.Note;
                    UpdateOffer.CashBack = Offer.CashBack;
                    UpdateOffer.F_Quantity = Offer.F_Quantity;
                    UpdateOffer.IsActive = Offer.IsActive;
                    UpdateOffer.IsFree = Offer.IsFree;
                    UpdateOffer.O_Name = Offer.O_Name;
                    UpdateOffer.P_Quantity = Offer.P_Quantity;

                    int result = context.SaveChanges();
                    return result;
                }
            }
            catch
            {
                return 0;
            }


        }



        public int AddNewOffer(Database_Models.Offers Offer)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    context.Offers.Add(Offer);
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


        public object GetOffersData()
        {
            try
            {
                var db = new ERPEntities();
                return db.Offers.ToList();

            }
            catch
            {

                return null;
            }

        }


    }
}
