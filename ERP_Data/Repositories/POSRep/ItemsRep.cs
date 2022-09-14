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


        public object GetItemsOfGroupData(int ItemsGroupID)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    var DataItemsOfGroup = context.Items.Where(u => u.GroupIt == ItemsGroupID)
                                        .Select(u => new
                                        {
                                            u.IDItem,
                                            u.ItDet,
                                            u.NameIt,
                                            u.TypiT,
                                            u.UnitIt,
                                            u.Imag
                                        }).OrderBy(u => u.IDItem)
                                        .ToList();
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

        public object GetItemsData(int Code)
        {
            try
            {
                object Dt = null;
                var Db = new ERPEntities();
                if (Code == 0) Dt = Db.Items.ToList();
                else Dt = Db.Items.Where(u => u.IDItem == Code).ToList();
                return Dt;
            }
            catch { return null; }
        }

        public object GetItemsSearchData(string SearchContext)
        {
            try
            {
                using (var Db = new ERPEntities())
                {
                    var DataBySearchItems = Db.Items.Where(u => u.NameIt.Contains(SearchContext) || u.BrcoIt == SearchContext)
                        .Select(u => new
                        {
                            u.BrcoIt,
                            u.GroupIt,
                            u.IDItem,
                            u.ItDet,
                            u.NameIt,
                            u.TypiT,
                            u.UnitIt,
                            u.Imag
                        }).OrderBy(u => u.IDItem).ToList();

                    if (DataBySearchItems == null) { throw new RecordNotFoundException(); }

                    return DataBySearchItems;

                }
            }

            catch { throw new InvalidDataException(); }

        }

        public int DeleteItem(int Code)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    Items Item = context.Items.Where(u => u.IDItem == Code).SingleOrDefault();

                    if (Item == null) return 2;

                    context.Items.Remove(Item);
                    int res = context.SaveChanges();

                    if (res > 0) return 1;
                    else return 0;

                }
            }
            catch { return 0; }

        }

        public int UpdateItem(Database_Models.Items Item)
        {

            try
            {
                using (var context = new ERPEntities())
                {
                    Items UpdateItem = context.Items.Where(u => u.IDItem == Item.IDItem).FirstOrDefault(); ;
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


        public int AddNewItem(Database_Models.Items Item)
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


        public object GetItemsAdvancedSearch(string SearchContext)
        {
            try
            {
                string Fields = " * ";
                string connectionString = ERP_SettingRep.ConnectionStrings;
                SqlConnection CN = new SqlConnection(connectionString);
                CN.Open();
                string Query = "";
                SearchContext = SearchContext.Replace(" ", "%");
                Query = " SELECT " + Fields + " FROM Items WHERE NameIt like '%" + ERP_SettingRep.GetMatchName(SearchContext) + "%' order by IDItem ";
                SqlDataAdapter Da = new SqlDataAdapter(Query, CN);
                DataSet Ds = new DataSet();
                Da.Fill(Ds);
                if (CN.State == System.Data.ConnectionState.Open) { CN.Close(); CN = null; }
                if (Ds.Tables[0] == null || Ds.Tables[0].Rows.Count == 0) { throw new RecordNotFoundException(); }
                return Ds.Tables[0];

            }
            catch { throw new InvalidDataException(); }

        }

    }
}
