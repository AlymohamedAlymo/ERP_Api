using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP_Data.Interfaces;
using ERP_Data.Database_Models;

namespace ERP_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class POSController : ControllerBase
    {
        private readonly ISales Sales;

        private readonly IStores Stores;
        private readonly ISafes Safes;
        private readonly IBranchs Branchs;
        private readonly IKeepers Keepers;
        private readonly IDelevery Delevery;
        private readonly IDeliveryAreas DeleveryAreas;
        private readonly IDiscounts Discounts;
        private readonly IOffers Offers;
        private readonly ITaxs Taxs;
        private readonly IItems Items;
        private readonly ICustomer Customer;
        private readonly IPricing  Pricing;
        private readonly ISupply Supply;
        private readonly IItemsGroups ItemsGroups;
        private readonly ITypeItems TypeItems;
        private readonly IUnitItems UnitItems;

        public POSController(ISales _Sales, IStores _Stores, ISafes _Safes, IBranchs _Branchs, IKeepers _Keepers,
            IDelevery _Delevery, IDeliveryAreas _DeleveryAreas, IDiscounts _Discounts, IOffers _Offers,
            ITaxs _Taxs, IItems _Items, ICustomer _Customer, IPricing _Pricing, ISupply _Supply,
            IItemsGroups _ItemsGroups, ITypeItems _TypeItems, IUnitItems _UnitItems)
        {
            this.Sales = _Sales;
            this.Stores = _Stores;
            this.Safes = _Safes;
            this.Branchs = _Branchs;
            this.Keepers = _Keepers;
            this.Delevery = _Delevery;
            this.DeleveryAreas = _DeleveryAreas;
            this.Discounts = _Discounts;
            this.Offers = _Offers;
            this.Taxs = _Taxs;
            this.Items = _Items;
            this.Customer = _Customer;
            this.Pricing = _Pricing;
            this.Supply = _Supply;
            this.ItemsGroups = _ItemsGroups;
            this.TypeItems = _TypeItems;
            this.UnitItems = _UnitItems;


        }



        [HttpGet]
        [Route("GetWaitInvoiceData")]
        public ActionResult<string> GetWaitInvoiceData()
        {
            try
            {
                object dt = Sales.GetWaitInvoiceData();

                return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            catch
            {
                return null;
            }

        }

        [HttpPost]
        [Route("AddtoWaitInvoice")]
        public ActionResult<string> AddtoWaitInvoice([FromBody] ERP_Data.Database_Models.WaitInvoice WaitInvoice)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Sales.AddtoWaitInvoice(WaitInvoice));
            }
            catch
            {
                return "حدث خطأ";
            }
        }


        [HttpPost]
        [Route("AddNewInvoice")]
        public ActionResult<string> AddNewInvoice([FromBody] ERP_Data.Database_Models.Invoice Invoice)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Sales.AddNewInvoice(Invoice));
            }
            catch
            {
                return "حدث خطأ";
            }
        }

        [HttpPost]
        [Route("AddNewReturnInvoice/{Code}")]
        public ActionResult<string> AddNewReturnInvoice(int Code, [FromBody] ERP_Data.Database_Models.ReturnsInvoice ReturnsInvoice)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Sales.AddNewReturnInvoice(Code, ReturnsInvoice));
            }
            catch
            {
                return "حدث خطأ";
            }
        }


        [HttpGet]
        [Route("GetInvoiceData/{IDInvoice}")]
        public ActionResult<object> GetInvoiceData(int IDInvoice)
        {
            try
            {
               var dt = Sales.GetInvoiceData(IDInvoice);

                return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            catch
            {
                return null;
            }

        }


        [HttpPost]
        [Route("AddNewItemToInvoice")]
        public ActionResult<string> AddNewItemToInvoice([FromBody] ERP_Data.Database_Models.Sale SalesData)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Sales.AddNewItemToInvoice(SalesData));
            }
            catch
            {
                return "حدث خطأ";
            }
        }

        [HttpPost]
        [Route("AddNewItemToReturns/{Code}")]
        public ActionResult<string> AddNewItemToReturns(int Code, [FromBody] ERP_Data.Database_Models.Return ReturnsData)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Sales.AddNewItemToReturns(Code, ReturnsData));
            }
            catch
            {
                return "حدث خطأ";
            }
        }


        [HttpPost]
        [Route("UpdateItemOfInvoice/{Code}")]
        public ActionResult<string> UpdateItemOfInvoice(int Code,[FromBody] ERP_Data.Database_Models.Sale SalesData)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Sales.UpdateItemOfInvoice(Code, SalesData));
            }
            catch
            {
                return "حدث خطأ";
            }
        }

        [HttpPost]
        [Route("UpdateWaitInvoice/{Code}")]
        public ActionResult<string> UpdateWaitInvoice(int Code, [FromBody] ERP_Data.Database_Models.WaitInvoice WaitInvoice)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Sales.UpdateWaitInvoice(Code, WaitInvoice));
            }
            catch
            {
                return "حدث خطأ";
            }
        }


        [HttpDelete]
        [Route("DeleteSaleMove/{Code}")]
        public ActionResult<string> DeleteSaleMove(int Code)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Sales.DeleteSaleMove(Code));
            }
            catch
            {

                return "حدث خطأ";
            }
        }

        [HttpDelete]
        [Route("DeleteSaleInvoice/{Code}")]
        public ActionResult<string> DeleteSaleInvoice(int Code)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Sales.DeleteSaleInvoice(Code));
            }
            catch
            {

                return "حدث خطأ";
            }
        }


        [HttpDelete]
        [Route("DeleteWaitInvoice/{Code}")]
        public ActionResult<string> DeleteWaitInvoice(int Code)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Sales.DeleteWaitInvoice(Code));
            }
            catch
            {

                return "حدث خطأ";
            }
        }


        [HttpGet]
        [Route("GetCustomerLastOrder/{Customer}")]
        public ActionResult<string> GetCustomerLastOrder(int Customer)
        {
            try
            {
                object dt = Sales.GetCustomerLastOrder(Customer);

                return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            catch
            {
                return null;
            }

        }


        [HttpGet]
        [Route("GetNewIDInvoice")]
        public ActionResult<int> GetNewIDInvoice()
        {
            try
            {
                int dt;
                dt = Sales.GetNewIDInvoice();

                return dt;
            }
            catch
            {
                return 1;
            }

        }







        /// <summary>
        /// Stores Control
        /// </summary>
        /// <param name="SearchContext"></param>
        /// <returns></returns>



        [HttpGet]
        [Route("GetStoresData")]
        public ActionResult<string> GetStoresData()
        {
            try
            {
                object dt = Stores.GetStoresData();

                return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            catch 
            {
                return null;
            }

        }

        [HttpPost]
        [Route("AddNewStore")]
        public ActionResult<string> AddNewStore([FromBody] ERP_Data.Database_Models.Store Store)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Stores.AddNewStore(Store));
            }
            catch 
            {
                return "حدث خطأ";
            }
        }


        [HttpPost]
        [Route("UpdateStore")]
        public ActionResult<string> UpdateStore([FromBody] ERP_Data.Database_Models.Store Store)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Stores.UpdateStore(Store));
            }
            catch
            {
                return "حدث خطأ";
            }
        }

        [HttpDelete]
        [Route("DeleteStore/{Code}")]
        public ActionResult<string> DeleteStore(int Code)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Stores.DeleteStore(Code));
            }
            catch
            {

                return "حدث خطأ";
            }
        }


        /// <summary>
        /// Safes Control
        /// </summary>
        /// <param name="SearchContext"></param>
        /// <returns></returns>


        [HttpGet]
        [Route("GetSafesData")]
        public ActionResult<string> GetSafesData()
        {
            try
            {
                object dt = Safes.GetSafesData();

                return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            catch
            {
                return null;
            }

        }

        [HttpPost]
        [Route("AddNewSafe")]
        public ActionResult<string> AddNewSafe([FromBody] ERP_Data.Database_Models.Safe safe)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Safes.AddNewSafe(safe));
            }
            catch
            {
                return "حدث خطأ";
            }
        }


        [HttpPost]
        [Route("UpdateSafe")]
        public ActionResult<string> UpdateSafe([FromBody] ERP_Data.Database_Models.Safe safe)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Safes.UpdateSafe(safe));
            }
            catch
            {
                return "حدث خطأ";
            }
        }

        [HttpDelete]
        [Route("DeleteSafe/{Code}")]
        public ActionResult<string> DeleteSafe(int Code)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Safes.DeleteSafe(Code));
            }
            catch
            {

                return "حدث خطأ";
            }
        }







        /// <summary>
        /// Branchs Control
        /// </summary>
        /// <param name="SearchContext"></param>
        /// <returns></returns>


        [HttpGet]
        [Route("GetBranchsData")]
        public ActionResult<string> GetBranchsData()
        {
            try
            {
                object dt = Branchs.GetBranchsData();

                return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            catch
            {
                return null;
            }

        }

        [HttpPost]
        [Route("AddNewBranch")]
        public ActionResult<string> AddNewBranch([FromBody] ERP_Data.Database_Models.Branch BNR)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Branchs.AddNewBranch(BNR));
            }
            catch
            {
                return "حدث خطأ";
            }
        }


        [HttpPost]
        [Route("UpdateBranch")]
        public ActionResult<string> UpdateBranch([FromBody] ERP_Data.Database_Models.Branch BNR)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Branchs.UpdateBranch(BNR));
            }
            catch
            {
                return "حدث خطأ";
            }
        }

        [HttpDelete]
        [Route("DeleteBranch/{Code}")]
        public ActionResult<string> DeleteBranch(int Code)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Branchs.DeleteBranch(Code));
            }
            catch
            {

                return "حدث خطأ";
            }
        }






        /// <summary>
        /// Keepers Control
        /// </summary>
        /// <param name="SearchContext"></param>
        /// <returns></returns>




        [HttpGet]
        [Route("GetKeepersData")]
        public ActionResult<string> GetKeepersData()
        {
            try
            {
                object dt = Keepers.GetKeepersData();

                return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            catch
            {
                return null;
            }

        }

        [HttpPost]
        [Route("AddNewKeeper")]
        public ActionResult<string> AddNewKeeper([FromBody] ERP_Data.Database_Models.Keeper Kp)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Keepers.AddNewKeeper(Kp));
            }
            catch
            {
                return "حدث خطأ";
            }
        }


        [HttpPost]
        [Route("UpdateKeeper")]
        public ActionResult<string> UpdateKeeper([FromBody] ERP_Data.Database_Models.Keeper Kp)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Keepers.UpdateKeeper(Kp));
            }
            catch
            {
                return "حدث خطأ";
            }
        }

        [HttpDelete]
        [Route("DeleteKeeper/{Code}")]
        public ActionResult<string> DeleteKeeper(int Code)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Keepers.DeleteKeeper(Code));
            }
            catch
            {

                return "حدث خطأ";
            }
        }



        /// <summary>
        /// Deleverys Control
        /// </summary>
        /// <param name="SearchContext"></param>
        /// <returns></returns>



        [HttpGet]
        [Route("GetDeleverysData")]
        public ActionResult<string> GetDeleverysData()
        {
            try
            {
                object dt = Delevery.GetDeleverysData();

                return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            catch
            {
                return null;
            }

        }

        [HttpPost]
        [Route("AddNewDelevery")]
        public ActionResult<string> AddNewDelevery([FromBody] ERP_Data.Database_Models.Delevery Delv)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Delevery.AddNewDelevery(Delv));
            }
            catch
            {
                return "حدث خطأ";
            }
        }


        [HttpPost]
        [Route("UpdateDelevery")]
        public ActionResult<string> UpdateDelevery([FromBody] ERP_Data.Database_Models.Delevery Delv)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Delevery.UpdateDelevery(Delv));
            }
            catch
            {
                return "حدث خطأ";
            }
        }

        [HttpDelete]
        [Route("DeleteDelevery/{Code}")]
        public ActionResult<string> DeleteDelevery(int Code)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Delevery.DeleteDelevery(Code));
            }
            catch
            {

                return "حدث خطأ";
            }
        }





        /// <summary>
        /// DeleveryAreas Control
        /// </summary>
        /// <param name="SearchContext"></param>
        /// <returns></returns>




        [HttpGet]
        [Route("GetDeleveryAreasData")]
        public ActionResult<string> GetDeleveryAreasData()
        {
            try
            {
                object dt = DeleveryAreas.GetDeleveryAreasData();

                return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            catch
            {
                return null;
            }

        }

        [HttpPost]
        [Route("AddNewArea")]
        public ActionResult<string> AddNewArea([FromBody] ERP_Data.Database_Models.DeliveryArea Area)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(DeleveryAreas.AddNewArea(Area));
            }
            catch
            {
                return "حدث خطأ";
            }
        }


        [HttpPost]
        [Route("UpdateArea")]
        public ActionResult<string> UpdateArea([FromBody] ERP_Data.Database_Models.DeliveryArea Area)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(DeleveryAreas.UpdateArea(Area));
            }
            catch
            {
                return "حدث خطأ";
            }
        }

        [HttpDelete]
        [Route("DeleteArea/{Code}")]
        public ActionResult<string> DeleteArea(int Code)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(DeleveryAreas.DeleteArea(Code));
            }
            catch
            {

                return "حدث خطأ";
            }
        }





        /// <summary>
        /// Discounts Control
        /// </summary>
        /// <param name="SearchContext"></param>
        /// <returns></returns>






        [HttpGet]
        [Route("GetDiscountsData")]
        public ActionResult<string> GetDiscountsData()
        {
            try
            {
                object dt = Discounts.GetDiscountsData();

                return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            catch
            {
                return null;
            }

        }

        [HttpPost]
        [Route("AddNewDiscount")]
        public ActionResult<string> AddNewDiscount([FromBody] ERP_Data.Database_Models.Discount Disc)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Discounts.AddNewDiscount(Disc));
            }
            catch
            {
                return "حدث خطأ";
            }
        }


        [HttpPost]
        [Route("UpdateDiscount")]
        public ActionResult<string> UpdateDiscount([FromBody] ERP_Data.Database_Models.Discount Disc)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Discounts.UpdateDiscount(Disc));
            }
            catch
            {
                return "حدث خطأ";
            }
        }

        [HttpDelete]
        [Route("DeleteDiscount/{Code}")]
        public ActionResult<string> DeleteDiscount(int Code)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Discounts.DeleteDiscount(Code));
            }
            catch
            {

                return "حدث خطأ";
            }
        }





        /// <summary>
        /// Offers Control
        /// </summary>
        /// <param name="SearchContext"></param>
        /// <returns></returns>



        [HttpGet]
        [Route("GetOffersData")]
        public ActionResult<string> GetOffersData()
        {
            try
            {
                object dt = Offers.GetOffersData();

                return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            catch
            {
                return null;
            }

        }

        [HttpPost]
        [Route("AddNewOffer")]
        public ActionResult<string> AddNewOffer([FromBody] ERP_Data.Database_Models.Offer Offer)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Offers.AddNewOffer(Offer));
            }
            catch
            {
                return "حدث خطأ";
            }
        }


        [HttpPost]
        [Route("UpdateOffer")]
        public ActionResult<string> UpdateOffer([FromBody] ERP_Data.Database_Models.Offer Offer)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Offers.UpdateOffer(Offer));
            }
            catch
            {
                return "حدث خطأ";
            }
        }

        [HttpDelete]
        [Route("DeleteOffer/{Code}")]
        public ActionResult<string> DeleteOffer(int Code)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Offers.DeleteOffer(Code));
            }
            catch
            {

                return "حدث خطأ";
            }
        }
































        /// <summary>
        /// Taxs Control
        /// </summary>
        /// <param name="SearchContext"></param>
        /// <returns></returns>





        [HttpGet]
        [Route("GetTaxsData")]
        public ActionResult<string> GetTaxsData()
        {
            try
            {
                object dt = Taxs.GetTaxsData();

                return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            catch
            {
                return null;
            }

        }

        [HttpPost]
        [Route("AddNewTax")]
        public ActionResult<string> AddNewTax([FromBody] ERP_Data.Database_Models.Tax Tax)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Taxs.AddNewTax(Tax));
            }
            catch
            {
                return "حدث خطأ";
            }
        }


        [HttpPost]
        [Route("UpdateTax")]
        public ActionResult<string> UpdateTax([FromBody] ERP_Data.Database_Models.Tax Tax)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Taxs.UpdateTax(Tax));
            }
            catch
            {
                return "حدث خطأ";
            }
        }

        [HttpDelete]
        [Route("DeleteTax/{Code}")]
        public ActionResult<string> DeleteTax(int Code)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Taxs.DeleteTax(Code));
            }
            catch
            {

                return "حدث خطأ";
            }
        }










        /// <summary>
        /// Items Control
        /// </summary>
        /// <param name="SearchContext"></param>
        /// <returns></returns>






        //[HttpGet]
        //[Route("GetItemsOfGroupData/{ItemsGroupID}")]
        //public ActionResult<string> GetItemsOfGroupData(int ItemsGroupID)
        //{
        //    try
        //    {
        //        object dt = new();
        //        dt = Items.GetItemsOfGroupData(ItemsGroupID);

        //        return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
        //    }
        //    catch
        //    {
        //        return null;
        //    }

        //}


        //[HttpGet]
        //[Route("GetItemsSearchData/{SearchContext}")]
        //public ActionResult<string> GetItemsData(string SearchContext)
        //{
        //    try
        //    {
        //        object dt = new();
        //        dt = Items.GetItemsSearchData(SearchContext);

        //        return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
        //    }
        //    catch
        //    {
        //        return null;
        //    }

        //}

        [HttpGet]
        [Route("GetItemsAdvancedSearch/{NameItem}/{Match}/{Group}/{Type}/{Unit}/{Barcode}/{AddDate}/{NoBarcode}/{DuplicateBarcode}/{WithNote}")]
        public ActionResult<string> GetItemsAdvancedSearch(string NameItem, bool Match, int Group, int Type, int Unit, int Barcode, int AddDate, bool NoBarcode, bool DuplicateBarcode, bool WithNote)
        {
            try
            {
               var Dt = Items.GetItemsAdvancedSearch(NameItem, Match, Group, Type, Unit, Barcode, AddDate, NoBarcode, DuplicateBarcode, WithNote);
               return Newtonsoft.Json.JsonConvert.SerializeObject(Dt);

            }
            catch { return null; }

        }

        [HttpGet]
        [Route("GetItemsData/{Code}/{RowIndex}")]
        public ActionResult<string> GetItemsData(int Code, int RowIndex)
        {
            try
            {
                object Dt = Items.GetItemsData(Code, RowIndex);
                return Newtonsoft.Json.JsonConvert.SerializeObject(Dt);
            }
            catch { return null; }

        }
        [HttpGet]
        [Route("GetCountItemsData")]
        public ActionResult<int> GetCountItemsData()
        {
            try { return Items.GetCountItemsData(); }
            catch { return 0; }
        }


        [HttpPost]
        [Route("AddNewItem")]
        public ActionResult<string> AddNewItem([FromBody] ERP_Data.Database_Models.Item Item)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Items.AddNewItem(Item));
            }
            catch
            {
                return "حدث خطأ";
            }
        }


        [HttpPost]
        [Route("UpdateItem")]
        public ActionResult<string> UpdateItem([FromBody] ERP_Data.Database_Models.Item Item)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Items.UpdateItem(Item));
            }
            catch
            {
                return "حدث خطأ";
            }
        }

        [HttpDelete]
        [Route("DeleteItem/{Code}")]
        public ActionResult<string> DeleteItem(int Code)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Items.DeleteItem(Code));
            }
            catch
            {

                return "حدث خطأ";
            }
        }






        /// <summary>
        /// Customer Control
        /// </summary>
        /// <param name="SearchContext"></param>
        /// <returns></returns>







        [HttpGet]
        [Route("GetCustomerSearchData/{SearchContext}")]
        public ActionResult<string> GetCustomerSearchData(string SearchContext)
        {
            try
            {
                object dt = Customer.GetCustomerSearchData(SearchContext);

                return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            catch
            {
                return null;
            }

        }


        [HttpGet]
        [Route("GetCustomerData/{Code}")]
        public ActionResult<string> GetCustomerData(int Code)
        {
            try
            {
                object dt = Customer.GetCustomerData(Code);
                return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            catch
            {
                return null;
            }

        }


        [HttpPost]
        [Route("AddNewCustomer")]
        public ActionResult<string> AddNewCustomer([FromBody] ERP_Data.Database_Models.Customer customer)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Customer.AddNewCustomer(customer));
            }
            catch
            {
                return "حدث خطأ";
            }
        }


        [HttpPost]
        [Route("UpdateCustomer")]
        public ActionResult<string> UpdateCustomer([FromBody] ERP_Data.Database_Models.Customer customer)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Customer.UpdateCustomer(customer));
            }
            catch
            {
                return "حدث خطأ";
            }
        }

        [HttpDelete]
        [Route("DeleteCustomer/{Code}")]
        public ActionResult<string> DeleteCustomer(int Code)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Customer.DeleteCustomer(Code));
            }
            catch
            {

                return "حدث خطأ";
            }
        }




        [HttpPost]
        [Route("PricingItem")]
        public ActionResult<string> PricingItem([FromBody] ERP_Data.Database_Models.pricing PricingList)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Pricing.PricingItem(PricingList));
            }
            catch
            {
                return "حدث خطأ";
            }
        }

        [HttpDelete]
        [Route("ClearPricing/{Code}")]
        public ActionResult<string> ClearPricing(int Code)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Pricing.ClearPricing(Code));
            }
            catch
            {

                return "حدث خطأ";
            }
        }

        [HttpPost]
        [Route("UpdateItemPrice")]
        public ActionResult<string> UpdateItemPrice([FromBody] ERP_Data.Database_Models.pricing PricingList)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Pricing.UpdateItemPrice(PricingList));
            }
            catch
            {
                return "حدث خطأ";
            }
        }



        [HttpGet]
        [Route("GetPricingList")]
        public ActionResult<object> GetPricingList()
        {
            try
            {
                return Pricing.GetPricingList();

            }
            catch
            {
                return null;
            }

        }




        [HttpPost]
        [Route("SupplyItem")]
        public ActionResult<string> SupplyItem([FromBody] ERP_Data.Database_Models.Supply SupplyList)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Supply.SupplyItem(SupplyList));
            }
            catch
            {
                return "حدث خطأ";
            }
        }


        [HttpPost]
        [Route("UpdateSupply")]
        public ActionResult<string> UpdateSupply([FromBody] ERP_Data.Database_Models.Supply SupplyList)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(Supply.UpdateSupply(SupplyList));
            }
            catch
            {
                return "حدث خطأ";
            }
        }



        [HttpGet]
        [Route("GetSupplyList")]
        public ActionResult<object> GetSupplyList()
        {
            try
            {
                return Supply.GetSupplyList();

            }
            catch
            {
                return null;
            }

        }






        /// <summary>
        /// Items Group Control
        /// </summary>
        /// <param name="SearchContext"></param>
        /// <returns></returns>






        [HttpGet]
        [Route("GetItemsGroups")]
        public ActionResult<string> GetItemsGroups()
        {
            try
            {
                object dt = ItemsGroups.GetItemsGroups();

                return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            catch
            {
                return null;
            }

        }


        [HttpGet]
        [Route("GetItemsUnits")]
        public ActionResult<string> GetItemsUnits()
        {
            try
            {
                object  dt = UnitItems.GetItemsUnits();

                return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            catch { return null; }

        }





        [HttpGet]
        [Route("GetItemsTypes")]
        public ActionResult<string> GetItemsTypes()
        {
            try
            {
                object dt = TypeItems.GetItemsTypes();

                return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            }
            catch { return null; }

        }



        [HttpGet]
        [Route("GetUnpricedItems")]
        public ActionResult<int> GetUnpricedItems()
        {
            try { return Items.GetUnpricedItems(); }
            catch { return -1; }

        }



    }

}
