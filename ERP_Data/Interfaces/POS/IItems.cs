using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Data.Interfaces
{
    public interface IItems
    {

        object GetItemsData(int Code);

        object GetItemsSearchData(string SearchContext);

        object GetItemsOfGroupData(int ItemsGroupID);

        int DeleteItem(int Code);

        int UpdateItem(Database_Models.Items Item);

        int AddNewItem(Database_Models.Items Item);


    }
}
