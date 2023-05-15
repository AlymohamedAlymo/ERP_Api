using ERP_Data.CustomExceptions;
using ERP_Data.Database_Models;
using ERP_Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Data.Repositories
{
    public class ItemsRep : IItems
    {


        //public object GetItemsOfGroupData(int ItemsGroupID)
        //{
        //    try
        //    {
        //        using (var context = new ERPEntities())
        //        {
        //            var DataItemsOfGroup = context.Items.Where(u => u.GroupIt == ItemsGroupID)
        //                                .Select(u => new
        //                                {
        //                                    u.IDItem,
        //                                    u.ItDet,
        //                                    u.NameIt,
        //                                    u.TypiT,
        //                                    u.UnitIt,
        //                                    u.Imag
        //                                }).OrderBy(u => u.IDItem)
        //                                .ToList();
        //            if (DataItemsOfGroup == null || DataItemsOfGroup.Count == 0)
        //            {
        //                throw new RecordNotFoundException();
        //            }
        //            return DataItemsOfGroup;

        //        }
        //    }

        //    catch
        //    {
        //        throw new InvalidDataException();
        //    }
        //}

        public object GetItemsData(int Code)
        {
            //try
            //{
                object Dt = null;
                var Db = new ERPEntities();
                if (Code == 0) Dt = Db.Items.ToList();
                else Dt = Db.Items.Where(u => u.IDItem == Code).ToList();
                return Dt;
            //}
            //catch { return null; }
        }

        //public object GetItemsSearchData(string SearchContext)
        //{
        //    try
        //    {
        //        using (var Db = new ERPEntities())
        //        {
        //            var DataBySearchItems = Db.Items.Where(u => u.NameIt.Contains(SearchContext) || u.BrcoIt == int.Parse(SearchContext))
        //                .Select(u => new
        //                {
        //                    u.BrcoIt,
        //                    u.GroupIt,
        //                    u.IDItem,
        //                    u.ItDet,
        //                    u.NameIt,
        //                    u.TypiT,
        //                    u.UnitIt,
        //                    u.Imag
        //                }).OrderBy(u => u.IDItem).ToList();

        //            if (DataBySearchItems == null) { throw new RecordNotFoundException(); }

        //            return DataBySearchItems;

        //        }
        //    }

        //    catch { throw new InvalidDataException(); }

        //}

        public int DeleteItem(int Code)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    Item Item = context.Items.Where(u => u.IDItem == Code).SingleOrDefault();

                    if (Item == null) return 2;

                    context.Items.Remove(Item);
                    int res = context.SaveChanges();

                    if (res > 0) return 1;
                    else return 0;

                }
            }
            catch { return 0; }

        }

        public int UpdateItem(Item Item)
        {

            try
            {
                using (var context = new ERPEntities())
                {
                    Item UpdateItem = context.Items.Where(u => u.IDItem == Item.IDItem).FirstOrDefault(); ;
                    UpdateItem.BrcoIt = Item.BrcoIt;
                    UpdateItem.GroupIt = Item.GroupIt;
                    UpdateItem.ItDet = Item.ItDet;
                    UpdateItem.NameIt = Item.NameIt;
                    UpdateItem.TypiT = Item.TypiT;
                    UpdateItem.UnitIt = Item.UnitIt;
                    UpdateItem.Imag = Item.Imag;

                    int result = context.SaveChanges();
                    return result;
                }
            }
            catch { return 0; }

        }


        public int AddNewItem(Item Item)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    context.Items.Add(Item);
                    int res = context.SaveChanges();
                    if (res > 0) return 1;
                    else return 0;
                }

            }
            catch { throw new InvalidDataException(); }

        }


        public object GetItemsAdvancedSearch(string NameItem, bool Match, int Group, int Type, int Unit, int Barcode, int AddDate, bool NoBarcode, bool DuplicateBarcode, bool WithNote)
        {
            try
            {
                string Fields = " * ";
                string connectionString = ERP_SettingRep.ConnectionStrings;
                SqlConnection CN = new SqlConnection(connectionString);
                CN.Open();
                string Query = " SELECT " + Fields + " FROM Items WHERE ";

                bool ANDCase = false;
                if (NameItem != "-1")
                {
                    
                    if (!Match) 
                    {
                        NameItem = NameItem.Replace(" ", "%");
                        Query += " NameIt like '%" + ERP_SettingRep.GetMatchName(NameItem) + "%' ";
                    } 
                    else if (Match) Query += " NameIt = '" + NameItem + "' ";

                    ANDCase = true;
                }
                if (Group != 0) 
                {

                    if (ANDCase) Query += " AND ";

                    Query += " GroupIt = " + Group;

                    ANDCase = true;

                }
                if (Type != 0)
                {
                    if (ANDCase) Query += " AND ";

                    Query += " TypiT = " + Type;

                    ANDCase = true;

                }
                if (Unit != 0)
                {
                    if (ANDCase) Query += " AND ";

                    Query += " UnitIt = " + Unit;

                    ANDCase = true;

                }
                if (Barcode != 0)
                {
                    if (ANDCase) Query += " AND ";

                    Query += " BrcoIt = " + Barcode;

                    ANDCase = true;

                }
                if (AddDate != 0)
                {
                    if (ANDCase) Query += " AND ";

                    Query += " AddDate = " + AddDate;

                    ANDCase = true;

                }
                if (NoBarcode)
                {
                    if (ANDCase) Query += " AND ";

                    Query += " BrcoIt IS NULL ";

                    ANDCase = true;

                }
                if (WithNote)
                {
                    if (ANDCase) Query += " AND ";

                    Query += " ItDet IS NOT NULL ";

                }
                if (DuplicateBarcode)
                {
                    if (ANDCase) Query += " AND ";

                    Query += " BrcoIt in(" + GetDublicateBarcode(Query) + ") ";

                }

                Query += " ORDER BY IDItem ";

                SqlDataAdapter Da = new SqlDataAdapter(Query, CN);
                DataSet Ds = new DataSet();
                Da.Fill(Ds);
                if (CN.State == System.Data.ConnectionState.Open) { CN.Close(); CN = null; }
                if (Ds.Tables[0] == null || Ds.Tables[0].Rows.Count == 0) { throw new RecordNotFoundException(); }
                return Ds.Tables[0];

            }
            catch { throw new InvalidDataException(); }

        }


        string GetDublicateBarcode(string Query)
        {

            string connectionString = ERP_SettingRep.ConnectionStrings;
            SqlConnection CN = new SqlConnection(connectionString);
            CN.Open();

            Query = Query.Substring(Query.IndexOf("FROM"));

           string DuplicateBarcode_Query = " SELECT BrcoIt " + Query + " BrcoIt IS NOT NULL GROUP BY BrcoIt HAVING COUNT(*) > 1 ";

            List<string> BarCode = new List<string>();
            SqlCommand cmd = new SqlCommand(DuplicateBarcode_Query, CN);
            SqlDataReader RD = cmd.ExecuteReader();
            if (RD.HasRows)
            {
                while (RD.Read())
                {
                    BarCode.Add(RD[0].ToString());
                }
            }

            RD.Close();
            CN.Close();

            string str = "";

            for (int a = 0; a < BarCode.Count(); a++)
            {
                str += BarCode[a].ToString();

                if (BarCode.Count() != a + 1)
                    str += " , ";
            }

            return str;

        }

        public int GetUnpricedItems()
        {
            string connectionString = ERP_SettingRep.ConnectionStrings;
            SqlConnection CN = new SqlConnection(connectionString);
            CN.Open();
            int ItemsCount = 0;
            string Query = " SELECT COUNT(IDItem) FROM Items WHERE NOT EXISTS (SELECT IDItem FROM pricing WHERE Items.IDItem = pricing.IDItem) ";
            SqlCommand cmd = new SqlCommand(Query, CN);
            SqlDataReader RD = cmd.ExecuteReader();
            RD.Read();
            ItemsCount = int.Parse(RD[0].ToString());
            RD.Close();
            CN.Close();
            return ItemsCount;
        }

    }
}
