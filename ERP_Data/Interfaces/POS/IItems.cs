namespace ERP_Data.Interfaces
{
    public interface IItems
    {
        object GetItemsData();
        int DeleteItem(int Code);
        int UpdateItem(Database_Models.Item Item);
        int AddNewItem(Database_Models.Item Item);
        object GetItemsAdvancedSearch(string NameItem, bool Match, int Group, int Type, int Unit, int Barcode, int AddDate, bool NoBarcode, bool DuplicateBarcode, bool WithNote);
        int GetCountOfUnpricedItems();

    }
}
