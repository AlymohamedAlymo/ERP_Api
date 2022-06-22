using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Data.ViewModels;
using System.Data;

namespace ERP_Data.Interfaces
{
    public interface ISales
    {
        int GetNewIDInvoice();
        object GetCustomerLastOrder(int Customer);
        int AddNewItemToInvoice(Database_Models.Sales Sales);

        int AddNewItemToReturns(int Code, Database_Models.Returns Returns);

        DataTable GetInvoiceData(int IDInvoice);
        int AddNewInvoice(Database_Models.Invoice Invoice);

        int AddNewReturnInvoice(int Code, Database_Models.ReturnsInvoice ReturnsInvoice);

        int AddtoWaitInvoice(Database_Models.WaitInvoice WaitInvoice);

        object GetWaitInvoiceData();

        int UpdateItemOfInvoice(int Code,Database_Models.Sales Sales);

        int UpdateWaitInvoice(int Code, Database_Models.WaitInvoice WaitInvoice);

        int DeleteSaleMove(int Code);

        int DeleteSaleInvoice(int Code);

        int DeleteWaitInvoice(int Code);

        int UpdateItemPrice(Database_Models.pricing PricingList);


    }
}
