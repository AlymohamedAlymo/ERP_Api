using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Data.CustomExceptions;
using ERP_Data.Database_Models;
using ERP_Data.Interfaces;
using ERP_Data.ViewModels;

namespace ERP_Data.Repositories
{
    public class StoresRep : IStores
    {
        //readonly string connectionString = ERP_SettingRep.ConnectionStrings;


        public int DeleteStore(int Code)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    Store store = context.Stores.Where(u => u.id == Code).SingleOrDefault();
                    if (store == null)
                    {
                        return 2;
                    }
                    context.Stores.Remove(store);
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


        public int UpdateStore(Database_Models.Store store)
        {

            try
            {
                using (var context = new ERPEntities())
                {
                    Store Updatestore = context.Stores.Where(u => u.id == store.id).FirstOrDefault(); ;

                    Updatestore.Note = store.Note;
                    Updatestore.S_Addr = store.S_Addr;
                    Updatestore.S_Keeper = store.S_Keeper;
                    Updatestore.S_Name = store.S_Name;
                    Updatestore.S_Phone = store.S_Phone;


                    int result = context.SaveChanges();
                    return result;
                }
            }
            catch
            {
                return 0;
            }


        }



        public int AddNewStore(Database_Models.Store store)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    context.Stores.Add(store);
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


        public object GetStoresData()
        {
            try
            {
                var db = new ERPEntities();
                return db.Stores.ToList();

            }
            catch
            {

                return null;
            }

        }


    }
}
