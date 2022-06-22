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
    public class DeleverysRep : IDelevery
    {

        string connectionString = ERP_SettingRep.ConnectionStrings;


        public int DeleteDelevery(int Code)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    Deleverys Delevery = context.Deleverys.Where(u => u.id == Code).SingleOrDefault();
                    if (Delevery == null)
                    {
                        return 2;
                    }
                    context.Deleverys.Remove(Delevery);
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


        public int UpdateDelevery(Database_Models.Deleverys Delevery)
        {

            try
            {
                using (var context = new ERPEntities())
                {
                    Deleverys UpdateDelevery = context.Deleverys.Where(u => u.id == Delevery.id).FirstOrDefault(); ;

                    UpdateDelevery.Note = Delevery.Note;
                    UpdateDelevery.D_Addr = Delevery.D_Addr;
                    UpdateDelevery.D_NaID = Delevery.D_NaID;
                    UpdateDelevery.D_Name = Delevery.D_Name;
                    UpdateDelevery.D_Phone = Delevery.D_Phone;

                    int result = context.SaveChanges();
                    return result;
                }
            }
            catch
            {
                return 0;
            }


        }



        public int AddNewDelevery(Database_Models.Deleverys Delevery)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    context.Deleverys.Add(Delevery);
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


        public object GetDeleverysData()
        {
            try
            {
                var db = new ERPEntities();
                return db.Deleverys.ToList();

            }
            catch
            {

                return null;
            }

        }



    }
}
