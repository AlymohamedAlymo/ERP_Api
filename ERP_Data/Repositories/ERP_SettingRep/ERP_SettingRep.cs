using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Data.Interfaces;
using ERP_Data.Database_Models;
using System.Data;
using System.Data.SqlClient;
using ERP_Data.CustomExceptions;
using System.Runtime.ConstrainedExecution;

namespace ERP_Data.Repositories
{
    public class ERP_SettingRep : IERP_Setting
    {


        public static readonly string ConnectionStrings = "Data Source = 192.168.1.12\\ALYSQL; Initial Catalog = Doctor_ERP; User ID = sa; Password = Aly4807;";











        public static string GetMatchName(string SearchContext)
        {
            string Str = "";
            for (int i = 0; i < SearchContext.Length; i++)
            {
                string Chr = SearchContext.Substring(i, 1);
                if (Chr == "ا" || Chr == "أ" || Chr == "آ" || Chr == "إ") { Str += "[اأآإ]"; }
                else if (Chr == "ه" || Chr == "ة") { Str += "[ةه]"; }
                else if (Chr == "لأ" || Chr == "لا" || Chr == "لآ" || Chr == "لإ") { Str += "[لإلالألآ]"; }
                else if (Chr == "ى" || Chr == "ي" || Chr == "ئ") { Str += "[ىيئ]"; }
                else if (Chr == "ء" || Chr == "ئ") { Str += "[ءئ]"; }
                else if (Chr == "ء" || Chr == "ؤ" || Chr == "و") { Str += "[ءؤو]"; }
                else { Str += Chr; }
            }
            return Str;
        }




        public decimal GetQuantityoftheItem(int IDItem)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                var DataofQuantitySupply = context.Supplies.Where(u => u.ItemID == IDItem)
                                    .Sum(u => u.Amount);

                var DataofQuantityOut = context.OutofStores.Where(u => u.ItemID == IDItem)
                                       .Sum(u => u.Amount);

                var QuantityoftheItem = DataofQuantitySupply - DataofQuantityOut;

                    return QuantityoftheItem;

                }
            }

            catch
            {
                throw new InvalidDataException();
            }

        }



        public object GetStoragePlaceData(int IDItem)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    var DataItemsOfGroup = context.Supplies.Where(u => u.ItemID == IDItem)
                                        .Select(u => new
                                        {
                                            u.limitItem,
                                            u.StoreID,
                                            u.validity,
                                        }).ToList();

                    if (DataItemsOfGroup == null || DataItemsOfGroup.Count == 0)
                    {
                        throw new RecordNotFoundException();
                    }
                    return DataItemsOfGroup;

                }
            }

            catch
            {
                throw new InvalidDataException();
            }
        }



        public PrintSetting GetPrintingSetting(int IDReport)
        {
            try
            {
                using (ERPEntities DB = new ERPEntities())
                {
                    PrintSetting Data = DB.PrintSettings.FirstOrDefault(u => u.ID == IDReport);
                    return Data == null ? throw new RecordNotFoundException() : Data;
                }
            }
            catch { throw new InvalidDataException(); }
        }


        public int UpdatePrintingSetting(PrintSetting PSetting)
        {
            using (ERPEntities DB = new ERPEntities())
            {
                PrintSetting Obj = DB.PrintSettings.FirstOrDefault(u => u.ID == PSetting.ID);

                if (Obj == null) { throw new RecordNotFoundException(); }

                /// Update in PrintSetting
                Utilities.MapProperties.Map(PSetting, Obj, "ID", "ReportName");

                int Result = DB.SaveChanges();
                return Result;

            }
        }



    }

}
