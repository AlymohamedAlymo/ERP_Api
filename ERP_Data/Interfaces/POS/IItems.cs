namespace ERP_Data.Interfaces
{
    public interface IItems
    {
        /// <summary>
        /// Items Data
        /// </summary>
        /// <returns></returns>
        object GetItemsData();

        /// <summary>
        /// Delete Item
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        int DeleteItem(int Code);

        /// <summary>
        /// Update Item Data
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        int UpdateItem(Database_Models.Item Item);

        /// <summary>
        /// Add New Item
        /// </summary>
        /// <param name="Item"></param>
        /// <returns></returns>
        int AddNewItem(Database_Models.Item Item);

        /// <summary>
        /// Advances Search
        /// </summary>
        /// <param name="NameItem"></param>
        /// <param name="Match">Name Is Match ?</param>
        /// <param name="Group"></param>
        /// <param name="Type"></param>
        /// <param name="Unit"></param>
        /// <param name="Barcode"></param>
        /// <param name="AddDate"></param>
        /// <param name="NoBarcode"></param>
        /// <param name="DuplicateBarcode"></param>
        /// <param name="WithNote"></param>
        /// <param name="UnPricing"></param>
        /// <param name="DuplicateItems"></param>
        /// <returns></returns>
        object GetItemsAdvancedSearch(string NameItem, bool NoMatch, int Group, int Type, int Unit, int Barcode, int AddDate,
            bool NoBarcode, bool DuplicateBarcode, bool WithNote, bool UnPricing, bool DuplicateItems);


    }
}
