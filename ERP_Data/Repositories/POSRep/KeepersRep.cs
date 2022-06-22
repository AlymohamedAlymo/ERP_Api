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
    public class KeepersRep : IKeepers
    {

        string connectionString = ERP_SettingRep.ConnectionStrings;


        public int DeleteKeeper(int Code)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    Keepers Kp = context.Keepers.Where(u => u.id == Code).SingleOrDefault();
                    if (Kp == null)
                    {
                        return 2;
                    }
                    context.Keepers.Remove(Kp);
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


        public int UpdateKeeper(Database_Models.Keepers Kp)
        {

            try
            {
                using (var context = new ERPEntities())
                {
                    Keepers UpdateKp = context.Keepers.Where(u => u.id == Kp.id).FirstOrDefault(); ;

                    UpdateKp.Note = Kp.Note;
                    UpdateKp.Kp_Addr = Kp.Kp_Addr;
                    UpdateKp.Kp_NaID = Kp.Kp_NaID;
                    UpdateKp.Kp_Name = Kp.Kp_Name;
                    UpdateKp.Kp_Phone = Kp.Kp_Phone;

                    int result = context.SaveChanges();
                    return result;
                }
            }
            catch
            {
                return 0;
            }


        }



        public int AddNewKeeper(Database_Models.Keepers Kp)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    context.Keepers.Add(Kp);
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


        public object GetKeepersData()
        {
            try
            {
                var db = new ERPEntities();
                return db.Keepers.ToList();

            }
            catch
            {

                return null;
            }

        }



    }
}
