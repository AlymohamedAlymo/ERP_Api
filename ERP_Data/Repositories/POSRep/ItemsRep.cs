using ERP_Data.CustomExceptions;
using ERP_Data.Database_Models;
using ERP_Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ERP_Data.Repositories
{
    public class ItemsRep : IItems
    {
        public object GetItemsData()
        {
            try
            {
                ERPEntities DB = new ERPEntities();
                return DB.Items.ToList();
            }
            catch { throw new InvalidDataException(); }
        }


        public int DeleteItem(int Code)
        {
            try
            {
                using (ERPEntities DB = new ERPEntities())
                {
                    Item Item = DB.Items.Where(u => u.IDItem == Code).SingleOrDefault();
                    if (Item == null) { throw new RecordNotFoundException(); }
                    DB.Items.Remove(Item);
                    return DB.SaveChanges();
                }
            }
            catch { throw new InvalidDataException(); }
        }

        public int UpdateItem(Item Item)
        {
            try
            {
                using (ERPEntities DB = new ERPEntities())
                {
                    Item UpdateItem = DB.Items.Where(u => u.IDItem == Item.IDItem).FirstOrDefault(); ;
                    UpdateItem.BrcoIt = Item.BrcoIt;
                    UpdateItem.GroupIt = Item.GroupIt;
                    UpdateItem.ItDet = Item.ItDet;
                    UpdateItem.NameIt = Item.NameIt;
                    UpdateItem.TypiT = Item.TypiT;
                    UpdateItem.UnitIt = Item.UnitIt;
                    UpdateItem.Imag = Item.Imag;
                    UpdateItem.IsPricing = Item.IsPricing;
                    return DB.SaveChanges();
                }
            }
            catch { throw new InvalidDataException(); }

        }


        public int AddNewItem(Item Item)
        {
            try
            {
                using (ERPEntities DB = new ERPEntities())
                {
                    DB.Items.Add(Item);
                    return DB.SaveChanges();
                }
            }
            catch { throw new InvalidDataException(); }
        }

        public object GetItemsAdvancedSearch(string NameItem, bool NoMatch, int Group, int Type, int Unit, int Barcode, int AddDate,
            bool NoBarcode, bool DuplicateBarcode, bool WithNote, bool UnPricing, bool DuplicateItems)
        {
            try
            {
                string CNString = ERP_SettingRep.ConnectionStrings;
                SqlConnection CN = new SqlConnection(CNString);
                CN.Open();

                string Query = " SELECT * FROM Items WHERE ";

                bool ANDCase = false;
                if (NameItem != "-1")
                {
                    if (NoMatch)
                    {
                        NameItem = NameItem.Replace(" ", "%");
                        Query += " NameIt like '%" + ERP_SettingRep.GetMatchName(NameItem) + "%' ";
                    }
                    else if (!NoMatch) { Query += " NameIt = '" + NameItem + "' "; }
                    ANDCase = true;
                }
                if (Group != 0)
                {
                    if (ANDCase) { Query += " AND "; }
                    Query += " GroupIt = " + Group;
                    ANDCase = true;
                }
                if (Type != 0)
                {
                    if (ANDCase) { Query += " AND "; }
                    Query += " TypiT = " + Type;
                    ANDCase = true;
                }
                if (Unit != 0)
                {
                    if (ANDCase) { Query += " AND "; }
                    Query += " UnitIt = " + Unit;
                    ANDCase = true;
                }
                if (Barcode != 0)
                {
                    if (ANDCase) { Query += " AND "; }
                    Query += " BrcoIt = " + Barcode;
                    ANDCase = true;
                }
                if (AddDate != 0)
                {
                    if (ANDCase) { Query += " AND "; }
                    Query += " AddDate = " + AddDate;
                    ANDCase = true;
                }
                if (NoBarcode)
                {
                    if (ANDCase) { Query += " AND "; }
                    Query += " BrcoIt IS NULL ";
                    ANDCase = true;
                }
                if (WithNote)
                {
                    if (ANDCase) { Query += " AND "; }
                    Query += " ItDet IS NOT NULL ";
                    ANDCase = true;
                }
                if (UnPricing)
                {
                    if (ANDCase) { Query += " AND "; }
                    Query += " IsPricing = 0 ";
                    ANDCase = true;
                }
                if (DuplicateBarcode)
                {
                    if (ANDCase) { Query += " AND "; }
                    Query += " BrcoIt in(" + GetDublicateBarcode(Query) + ") ";
                    ANDCase = true;
                }
                if (DuplicateItems)
                {
                    if (ANDCase) { Query += " AND "; }
                    Query += " NameIt in(" + GetDublicateItems(Query) + ") ";
                }

                Query += " ORDER BY IDItem ";

                SqlDataAdapter Da = new SqlDataAdapter(Query, CN);
                DataSet Ds = new DataSet();
                Da.Fill(Ds);
                if (CN.State == ConnectionState.Open) { CN.Close(); CN = null; }
                if (Ds.Tables[0] == null || Ds.Tables[0].Rows.Count == 0) { throw new RecordNotFoundException(); }
                return Ds.Tables[0];
            }
            catch { throw new InvalidDataException(); }
        }

        private string GetDublicateBarcode(string Query)
        {
            try
            {
                string CNString = ERP_SettingRep.ConnectionStrings;
                SqlConnection CN = new SqlConnection(CNString);
                CN.Open();

                Query = Query.Substring(Query.IndexOf("FROM"));

                string DuplicateBarcode_Query = " SELECT BrcoIt " + Query + " BrcoIt IS NOT NULL GROUP BY BrcoIt HAVING COUNT(*) > 1 ";

                SqlCommand Cmd = new SqlCommand(DuplicateBarcode_Query, CN);
                SqlDataReader RD = Cmd.ExecuteReader();

                List<string> BarCode = new List<string>();

                if (RD.HasRows) { while (RD.Read()) { BarCode.Add(RD[0].ToString()); } }

                RD.Close(); CN.Close();

                string str = "";

                for (int i = 0; i < BarCode.Count(); i++)
                {
                    str += BarCode[i].ToString();
                    if (BarCode.Count() != i + 1) { str += " , "; }
                }
                return str;
            }
            catch (Exception EX) { return EX.Message; throw new InvalidDataException(); }
        }

        private string GetDublicateItems(string Query)
        {
            try
            {
                string CNString = ERP_SettingRep.ConnectionStrings;
                SqlConnection CN = new SqlConnection(CNString);
                CN.Open();

                Query = Query.Substring(Query.IndexOf("FROM"));

                string DuplicateBarcode_Query = " SELECT NameIt " + Query + " NameIt IS NOT NULL GROUP BY NameIt HAVING COUNT(*) > 1 ";

                SqlCommand Cmd = new SqlCommand(DuplicateBarcode_Query, CN);
                SqlDataReader RD = Cmd.ExecuteReader();

                List<string> Items = new List<string>();

                if (RD.HasRows) { while (RD.Read()) { Items.Add(RD[0].ToString()); } }

                RD.Close(); CN.Close();

                string str = "";

                for (int i = 0; i < Items.Count(); i++)
                {
                    str += "'" + Items[i].ToString() + "'";
                    if (Items.Count() != i + 1) { str += " , "; }
                }
                return str;
            }
            catch (Exception EX) { return EX.Message; throw new InvalidDataException(); }
        }

    }
}
