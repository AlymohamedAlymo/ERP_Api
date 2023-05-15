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
    public class BranchsRep : IBranchs
    {

        string connectionString = ERP_SettingRep.ConnectionStrings;


        public int DeleteBranch(int Code)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    Branch BRN = context.Branches.Where(u => u.id == Code).SingleOrDefault();
                    if (BRN == null)
                    {
                        return 2;
                    }
                    context.Branches.Remove(BRN);
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


        public int UpdateBranch(Database_Models.Branch BRN)
        {

            try
            {
                using (var context = new ERPEntities())
                {
                    Branch UpdateBRN = context.Branches.Where(u => u.id == BRN.id).FirstOrDefault(); ;

                    UpdateBRN.Note = BRN.Note;
                    UpdateBRN.B_Addr = BRN.B_Addr;
                    UpdateBRN.B_Maneger = BRN.B_Maneger;
                    UpdateBRN.B_Name = BRN.B_Name;
                    UpdateBRN.B_Phone = BRN.B_Phone;

                    int result = context.SaveChanges();
                    return result;
                }
            }
            catch
            {
                return 0;
            }


        }



        public int AddNewBranch(Database_Models.Branch BRN)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    context.Branches.Add(BRN);
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


        public object GetBranchsData()
        {
            try
            {
                var db = new ERPEntities();
                return db.Branches.ToList();

            }
            catch
            {

                return null;
            }

        }


    }
}
