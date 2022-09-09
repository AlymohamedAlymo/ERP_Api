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
    public class CustomerRep : ICustomer
    {


        public int DeleteCustomer(int Code)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    Customer customer = context.Customer.Where(u => u.IDCust == Code).SingleOrDefault();
                    if (customer == null)
                    {
                        return 2;
                    }
                    context.Customer.Remove(customer);
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


        public int UpdateCustomer(Database_Models.Customer customer)
        {

            try
            {
                using (var context = new ERPEntities())
                {
                    Customer UpdateCustomer = context.Customer.Where(u => u.IDCust == customer.IDCust).FirstOrDefault(); ;

                    UpdateCustomer.AddrCust = customer.AddrCust;
                    UpdateCustomer.apartCuat = customer.apartCuat;
                    UpdateCustomer.DateFi = customer.DateFi;
                    UpdateCustomer.DetailsCust = customer.DetailsCust;
                    UpdateCustomer.FloorCust = customer.FloorCust;
                    UpdateCustomer.MobileCust = customer.MobileCust;
                    UpdateCustomer.MobilePlus = customer.MobilePlus;
                    UpdateCustomer.NameCust = customer.NameCust;
                    UpdateCustomer.PhoneCust = customer.PhoneCust;
                    UpdateCustomer.TypeCust = customer.TypeCust;

                    int result = context.SaveChanges();
                    return result;
                }
            }
            catch
            {
                return 0;
            }


        }



        public int AddNewCustomer(Database_Models.Customer customer)
        {
            try
            {
                using (var context = new ERPEntities())
                {
                    context.Customer.Add(customer);
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


        public object GetCustomerSearchData(string SearchContext)
        {
            try
            {
                string Fields = " * ";
                string connectionString = ERP_SettingRep.ConnectionStrings;

                SqlConnection CN = new SqlConnection(connectionString);
                CN.Open();
                string SQL = "";

                SearchContext = SearchContext.Replace(" ", "%");

                SQL = "select " + Fields + " from Customer where NameCust like '%" + ERP_SettingRep.GetMatchName(SearchContext) + "%' or MobileCust like '%" + SearchContext + "%' " +
                "or PhoneCust like '%" + SearchContext + "%'" + " or MobilePlus like '%" + SearchContext + "%' or AddrCust like '%" + SearchContext + "%' order by IDCust ";


                SqlDataAdapter Da = new SqlDataAdapter(SQL, CN);
                DataSet Ds = new DataSet();

                Da.Fill(Ds, "table");

                if (CN.State == System.Data.ConnectionState.Open)
                    CN.Close();
                CN = null;
                if (Ds.Tables["table"] == null || Ds.Tables["table"].Rows.Count == 0)
                {
                    throw new RecordNotFoundException();
                }

                return Ds.Tables["table"];

            }
            catch
            {
                throw new InvalidDataException();
            }


        }


        public object GetCustomerData(int Code)
        {
            try
            {
                object Dt = null;
                var Db = new ERPEntities();

                if (Code == 0)
                    Dt = Db.Customer.ToList();
                else
                    Dt = Db.Customer.Where(u => u.IDCust == Code).ToList();

                return Dt;
            }
            catch
            {

                return null;
            }
        }


    }
}
