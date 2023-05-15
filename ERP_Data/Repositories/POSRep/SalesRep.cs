using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ERP_Data.CustomExceptions;
using ERP_Data.Database_Models;
using ERP_Data.Interfaces;
using ERP_Data.ViewModels;


namespace ERP_Data.Repositories
{
    public class SalesRep : ISales
    {

        readonly string connectionString = ERP_SettingRep.ConnectionStrings;


        public int AddtoWaitInvoice(Database_Models.WaitInvoice WaitInvoice)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    context.WaitInvoices.Add(WaitInvoice);
                    int res = context.SaveChanges();
                    if (res > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;

                    }
                }

            }

            catch
            {
                throw new InvalidDataException();
            }

        }


        public int AddNewInvoice(Database_Models.Invoice Invoice)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    context.Invoices.Add(Invoice);
                    int res = context.SaveChanges();
                    if (res > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;

                    }
                }

            }

            catch
            {
                throw new InvalidDataException();
            }

        }

        public int AddNewReturnInvoice(int Code, Database_Models.ReturnsInvoice ReturnsInvoice)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    Invoice invoice = context.Invoices.Where(u => u.IDInvoice == Code).FirstOrDefault();

                    context.ReturnsInvoices.Add(ReturnsInvoice);
                    int result = context.SaveChanges();

                    if (invoice == null)
                    {
                        return 5;
                    }

                    invoice.Return = true;

                    result = context.SaveChanges();

                    if (result > 0)
                    {
                        return result;
                    }
                    else
                    {
                        return result;
                    }

                }

            }

            catch
            {
                throw new InvalidDataException();
            }

        }

        public int GetNewIDInvoice()
        {

            try
            {
                var db = new ERPEntities();
                return db.Invoices.Count() + 1;

            }

            catch
            {

                return 1;
            }
        }

        public object GetWaitInvoiceData()
        {
            try
            {
                var db = new ERPEntities();
                return db.WaitInvoices.ToList();

            }
            catch
            {

                return null;
            }

        }


        public object GetCustomerLastOrder(int Customer)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    var DataLastOrder = context.Sales.Where(u => u.CustID == Customer)
                                        .Select(u => new
                                        {
                                            u.DaINT,
                                            u.ItemID,
                                            u.Quant,
                                            u.UnitPrice,
                                            u.DetiMove,
                                        }).OrderByDescending(u => u.DaINT)
                                          .Skip(0)
                                          .Take(10)
                                          .ToList();
                    if (DataLastOrder == null || DataLastOrder.Count == 0)
                    {
                        throw new RecordNotFoundException();
                    }
                    return DataLastOrder;
                }
            }

            catch
            {
                throw new InvalidDataException();
            }
        }

        public int AddNewItemToInvoice(Database_Models.Sale Addmby3t)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    context.Sales.Add(Addmby3t);
                    int res = context.SaveChanges();
                    if (res > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;

                    }
                }

            }

            catch
            {
                throw new InvalidDataException();
            }

        }

        public int AddNewItemToReturns(int Code, Database_Models.Return AddReturn)
        {
            try
            {

                using (var context = new ERPEntities())
                {
                    Sale sells = context.Sales.Where(u => u.IDMove == Code).FirstOrDefault();

                    context.Returns.Add(AddReturn);
                    int result = context.SaveChanges();


                    if (sells == null)
                    {
                        return 5;
                    }

                    sells.Return = true;

                    result = context.SaveChanges();

                    if (result > 0)
                    {
                        return result;
                    }
                    else
                    {
                        return result;
                    }


                }



            }

            catch
            {
                throw new InvalidDataException();
            }


        }


        public DataTable GetInvoiceData(int IDInvoice)
        {
            try
            {
                //List<InvoiceData> results = new List<InvoiceData>();
                SqlConnection CN = new SqlConnection(connectionString);
                CN.Open();
                string SQL = "";
                string Fields = " IDMove, ItemID, Quant, UnitItem, Price, Total, [Return] ";
                string DbName = "Sales";
                string Query = " where InvoiceID =";
                SQL = "select " + Fields + " from " + DbName + Query + IDInvoice;
                string Ord = " Order By IDMove ";
                SQL += Ord;
                //SqlCommand cmd = new SqlCommand(SQL, CN);
                SqlDataAdapter Ra = new SqlDataAdapter(SQL, CN);

                DataTable Dt = new DataTable();

                Dt.Columns.Add("الكود");
                Dt.Columns.Add("الصنف");
                Dt.Columns.Add("الكمية");
                Dt.Columns.Add("الوحدة");
                Dt.Columns.Add("السعر");
                Dt.Columns.Add("الاجمالي");
                Dt.Columns.Add("مرتجع");

                DataSet Ds = new DataSet();
                Ra.Fill(Ds, "table");


                InvoiceData InvoiceDataRow = new InvoiceData();

                for (int i = 0; i < Ds.Tables["table"].Rows.Count; i++)
                {


                    string[] Row = new string[5];

                    Row = new string[] { Ds.Tables["table"].Rows[i]["IDMove"].ToString(), Ds.Tables["table"].Rows[i]["ItemID"].ToString(), Ds.Tables["table"].Rows[i]["Quant"].ToString(), Ds.Tables["table"].Rows[i]["UnitItem"].ToString(), Ds.Tables["table"].Rows[i]["Price"].ToString(), Ds.Tables["table"].Rows[i]["Total"].ToString(), Ds.Tables["table"].Rows[i]["Return"].ToString() };
                    Dt.Rows.Add(Row);


                }

                CN.Close();


                return Dt;


            }

            catch
            {
                throw new InvalidDataException();
            }

        }

        public int UpdateItemOfInvoice(int Code, Database_Models.Sale Updatemby3t)
        {

            try
            {
                using (var context = new ERPEntities())
                {

                    Sale sell = context.Sales.Where(u => u.IDMove == Code).FirstOrDefault();
                    if (sell == null)
                    {
                        return 5;
                    }

                    sell.Quant = Updatemby3t.Quant;
                    sell.CustID = Updatemby3t.CustID;
                    sell.DaINT = Updatemby3t.DaINT;
                    sell.DateMove = Updatemby3t.DateMove;
                    sell.DetiMove = Updatemby3t.DetiMove;
                    //sell.IDMove = Updatemby3t.IDMove;
                    sell.InvoiceID = Updatemby3t.InvoiceID;
                    sell.ItemID = Updatemby3t.ItemID;
                    sell.OrderID = Updatemby3t.OrderID;
                    sell.Price = Updatemby3t.Price;
                    sell.Total = Updatemby3t.Total;
                    sell.UnitItem = Updatemby3t.UnitItem;
                    sell.UnitPrice = Updatemby3t.UnitPrice;
                    sell.UserID = Updatemby3t.UserID;
                    sell.WaitID = Updatemby3t.WaitID;

                    int result = context.SaveChanges();
                    if (result > 0)
                    {
                        return result;
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            catch
            {
                return 0;
            }

        }

        public int UpdateWaitInvoice(int Code, Database_Models.WaitInvoice UpdateWait)
        {

            try
            {
                using (var context = new ERPEntities())
                {

                    WaitInvoice wait = context.WaitInvoices.Where(u => u.InvoiceID == Code).FirstOrDefault();
                    if (wait == null)
                    {
                        return 5;
                    }

                    wait.additional = UpdateWait.additional;
                    wait.CustID = UpdateWait.CustID;
                    wait.DateInv = UpdateWait.DateInv;
                    wait.DelvID = UpdateWait.DelvID;
                    wait.DetailsBill = UpdateWait.DetailsBill;
                    wait.Discount = UpdateWait.Discount;
                    //wait.IDWait = UpdateWait.ItemID;
                    wait.InvoiceID = UpdateWait.InvoiceID;
                    wait.NetBill = UpdateWait.NetBill;
                    wait.Paid = UpdateWait.Paid;
                    wait.ShipPrice = UpdateWait.ShipPrice;
                    wait.TherRest = UpdateWait.TherRest;
                    wait.TotalInvo = UpdateWait.TotalInvo;
                    wait.TypInv = UpdateWait.TypInv;
                    wait.UserID = UpdateWait.UserID;

                    int result = context.SaveChanges();
                    if (result > 0)
                    {
                        return result;
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            catch
            {
                return 0;
            }

        }

        public int DeleteSaleMove(int Code)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    Sale sell = context.Sales.Where(u => u.IDMove == Code).FirstOrDefault();
                    if (sell == null)
                    {
                        return 2;
                    }
                    context.Sales.Remove(sell);
                    int res = context.SaveChanges();
                    if (res > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteSaleInvoice(int Code)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    Sale sell = context.Sales.Where(u => u.InvoiceID == Code).SingleOrDefault();
                    if (sell == null)
                    {
                        return 2;
                    }
                    context.Sales.Remove(sell);
                    int res = context.SaveChanges();
                    if (res > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch
            {
                return 0;
            }

        }



        public int DeleteWaitInvoice(int Code)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    WaitInvoice wait = context.WaitInvoices.Where(u => u.InvoiceID == Code).SingleOrDefault();
                    if (wait == null)
                    {
                        return 2;
                    }
                    context.WaitInvoices.Remove(wait);
                    int res = context.SaveChanges();
                    if (res > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch
            {
                return 0;
            }

        }



    }
}
