﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Data.Interfaces;
using ERP_Data.Database_Models;
using System.Data;
using System.Data.SqlClient;
using ERP_Data.CustomExceptions;

namespace ERP_Data.Repositories
{
    public class ERP_SettingRep : IERP_Setting
    {


        public static readonly string ConnectionStrings = "Data Source = 192.168.1.12;Initial Catalog = Doctor_ERP;User ID=sa;Password= Aly4807;";











        public static string getMatchName(string SearchContext)
        {
            string chr = "";
            string cstname = "";
            for (int a = 0; a < SearchContext.Length; a++)
            {
                chr = SearchContext.Substring(a, 1);
                if (chr == "ا" || chr == "أ" || chr == "آ" || chr == "إ")
                    cstname = cstname + "[اأآإ]";
                else if (chr == "ه" || chr == "ة")
                    cstname = cstname + "[ةه]";
                else if (chr == "لأ" || chr == "لا" || chr == "لآ" || chr == "لإ")
                    cstname = cstname + "[لإلالألآ]";
                else if (chr == "ى" || chr == "ي" || chr == "ئ")
                    cstname = cstname + "[ىيئ]";
                else if (chr == "ء" || chr == "ئ")
                    cstname = cstname + "[ءئ]";
                else if (chr == "ء" || chr == "ؤ" || chr == "و")
                    cstname = cstname + "[ءؤو]";
                else
                    cstname = cstname + chr;

            }

            return cstname;
        }




        public decimal GetQuantityoftheItem(int IDItem)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                var DataofQuantitySupply = context.Supply.Where(u => u.ItemID == IDItem)
                                    .Sum(u => u.Amount);

                var DataofQuantityOut = context.OutofStore.Where(u => u.ItemID == IDItem)
                                       .Sum(u => u.Amount);

                var QuantityoftheItem = DataofQuantitySupply - DataofQuantityOut;

                    return QuantityoftheItem;

                }
            }

            catch (Exception c)
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
                    var DataItemsOfGroup = context.Supply.Where(u => u.ItemID == IDItem)
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

            catch (Exception c)
            {
                throw new InvalidDataException();
            }
        }


    }

}
