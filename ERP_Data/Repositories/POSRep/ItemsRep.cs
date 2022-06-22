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

                if (Code == 0)
                    Dt = Db.Items.ToList();
                else
                    Dt = Db.Items.Where(u => u.IDItem == Code).ToList();

                return Dt;

            }
            catch
            {

                return null;
            }
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
                }).OrderBy(u => u.IDItem)
                .ToList();



                    if (DataBySearchItems == null)
                    {
                        throw new RecordNotFoundException();
                    }
                    return DataBySearchItems;

                }
            }

            catch
            {
                throw new InvalidDataException();
            }
        }


    }
}
