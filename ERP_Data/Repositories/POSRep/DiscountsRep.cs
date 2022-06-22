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
    public class DiscountsRep : IDiscounts
    {

        string connectionString = ERP_SettingRep.ConnectionStrings;


        public int DeleteDiscount(int Code)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    Discounts Disc = context.Discounts.Where(u => u.ID == Code).SingleOrDefault();
                    if (Disc == null)
                    {
                        return 2;
                    }
                    context.Discounts.Remove(Disc);
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


        public int UpdateDiscount(Database_Models.Discounts Disc)
        {

            try
            {
                using (var context = new ERPEntities())
                {
                    Discounts UpdateDisc = context.Discounts.Where(u => u.ID == Disc.ID).FirstOrDefault(); ;

                    UpdateDisc.Note = Disc.Note;
                    UpdateDisc.Dis_Name = Disc.Dis_Name;
                    UpdateDisc.Dis_Price = Disc.Dis_Price;

                    int result = context.SaveChanges();
                    return result;
                }
            }
            catch
            {
                return 0;
            }


        }



        public int AddNewDiscount(Database_Models.Discounts Disc)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    context.Discounts.Add(Disc);
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


        public object GetDiscountsData()
        {
            try
            {
                var db = new ERPEntities();
                return db.Discounts.ToList();

            }
            catch
            {

                return null;
            }

        }

    }
}
