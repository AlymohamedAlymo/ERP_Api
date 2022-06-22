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
    public class DeleveryAreasRep : IDeliveryAreas
    {

        string connectionString = ERP_SettingRep.ConnectionStrings;


        public int DeleteArea(int Code)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    DeliveryAreas Area = context.DeliveryAreas.Where(u => u.ID == Code).SingleOrDefault();
                    if (Area == null)
                    {
                        return 2;
                    }
                    context.DeliveryAreas.Remove(Area);
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


        public int UpdateArea(Database_Models.DeliveryAreas Area)
        {

            try
            {
                using (var context = new ERPEntities())
                {
                    DeliveryAreas UpdateArea = context.DeliveryAreas.Where(u => u.ID == Area.ID).FirstOrDefault(); ;

                    UpdateArea.Note = Area.Note;
                    UpdateArea.A_Name = Area.A_Name;
                    UpdateArea.A_Price = Area.A_Price;

                    int result = context.SaveChanges();
                    return result;
                }
            }
            catch
            {
                return 0;
            }


        }



        public int AddNewArea(Database_Models.DeliveryAreas Area)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    context.DeliveryAreas.Add(Area);
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


        public object GetDeleveryAreasData()
        {
            try
            {
                var db = new ERPEntities();
                return db.DeliveryAreas.ToList();

            }
            catch
            {

                return null;
            }

        }


    }
}
