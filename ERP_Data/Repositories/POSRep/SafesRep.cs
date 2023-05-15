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
    public class SafesRep : ISafes
    {

        string connectionString = ERP_SettingRep.ConnectionStrings;


        public int DeleteSafe(int Code)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    Safe safe = context.Safes.Where(u => u.id == Code).SingleOrDefault();
                    if (safe == null)
                    {
                        return 2;
                    }
                    context.Safes.Remove(safe);
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


        public int UpdateSafe(Database_Models.Safe safe)
        {

            try
            {
                using (var context = new ERPEntities())
                {
                    Safe Updatesafe = context.Safes.Where(u => u.id == safe.id).FirstOrDefault(); ;

                    Updatesafe.Note = safe.Note;
                    Updatesafe.K_Addr = safe.K_Addr;
                    Updatesafe.K_Keeper = safe.K_Keeper;
                    Updatesafe.K_Name = safe.K_Name;
                    Updatesafe.K_Phone = safe.K_Phone;


                    int result = context.SaveChanges();
                    return result;
                }
            }
            catch
            {
                return 0;
            }


        }



        public int AddNewSafe(Database_Models.Safe safe)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    context.Safes.Add(safe);
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


        public object GetSafesData()
        {
            try
            {
                var db = new ERPEntities();
                return db.Safes.ToList();

            }
            catch
            {

                return null;
            }

        }

    }
}
