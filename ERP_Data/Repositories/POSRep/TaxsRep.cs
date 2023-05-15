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
    public class TaxsRep : ITaxs
    {


        string connectionString = ERP_SettingRep.ConnectionStrings;


        public int DeleteTax(int Code)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    Tax Tax = context.Taxs.Where(u => u.ID == Code).SingleOrDefault();
                    if (Tax == null)
                    {
                        return 2;
                    }
                    context.Taxs.Remove(Tax);
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


        public int UpdateTax(Database_Models.Tax Tax)
        {

            try
            {
                using (var context = new ERPEntities())
                {
                    Tax UpdateTax = context.Taxs.Where(u => u.ID == Tax.ID).FirstOrDefault(); ;

                    UpdateTax.Note = Tax.Note;
                    UpdateTax.T_Name = Tax.T_Name;
                    UpdateTax.T_Price = Tax.T_Price;

                    int result = context.SaveChanges();
                    return result;
                }
            }
            catch
            {
                return 0;
            }


        }



        public int AddNewTax(Database_Models.Tax Tax)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    context.Taxs.Add(Tax);
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


        public object GetTaxsData()
        {
            try
            {
                var db = new ERPEntities();
                return db.Taxs.ToList();

            }
            catch
            {

                return null;
            }

        }

    }
}
