using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace RainMaker.Classes
{
    public class clsCreateAccount
    {
        private static DBEngineType _eDBType;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        clsDBAccess objDBAcess;


        public clsCreateAccount()
        {
            SqlConnection con = new SqlConnection(constr);
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
        }

        public object CreateAccount( string Customer, string Logo, string Country,string State,string City, string EmailAddress, string Phone, string Remarks, int IsActive, int TransactionBy, string CustomerType, string Domain)
	    {
            string[,] para = { 
                                { "@Customer", Customer },
                                { "@Logo", Logo },
                                { "@Country", Country },
                                { "@State", State },
                                { "@City", City },
                                { "@EmailAddress", EmailAddress },       
                                { "@Phone", Phone },
                                { "@Remarks" , Remarks},
                                { "@IsActive", IsActive.ToString()},
                                { "@TransactionBy",TransactionBy.ToString()},
                                { "@CustomerType", CustomerType},
                                { "@Domain", Domain}
            
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectCustomerID = objDBAcess.InsertProc_WithOutput("sp_CPM_InsertCustomer", para, "@CustomerCode");
            return objectCustomerID;
        }


        public object CreateTransactionLog(int RefrenceID, string Refrence, int StatusID, string Remarks, int TransactionBy, DateTime TransactionDateTime)
        {
            dynamic[,] para = { 
                                { "@RefrenceID", RefrenceID },
                                { "@Refrence", Refrence },
                                { "@StatusID", StatusID },
                                { "@Remarks", Remarks },
                                { "@TransactionBy", TransactionBy },
                                { "@TransactionDateTime", TransactionDateTime }    
                                
            
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectCustomerID = objDBAcess.executeProc("sp_InsertTransaction", para);
            return objectCustomerID;
        }

        public object UpdateAccount(int CustomerCode,string Customer, string Logo, string Country, string State, string City, string EmailAddress, string Phone, string Remarks, int IsActive, int TransactionBy, string CustomerType, string Domain)
        {
            dynamic[,] para = { 
                                { "@CustomerCode", CustomerCode },
                                { "@Customer", Customer },
                                { "@Logo", Logo },
                                { "@Country", Country },
                                { "@State", State },
                                { "@City", City },
                                { "@EmailAddress", EmailAddress },       
                                { "@Phone", Phone },
                                { "@Remarks" , Remarks},
                                { "@IsActive", IsActive.ToString()},
                                { "@TransactionBy",TransactionBy},
                                { "@CustomerType", CustomerType},
                                { "@Domain", Domain}
            
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectCustomerID = objDBAcess.executeProc("sp_CPM_UpdateCustomer", para);
            return objectCustomerID;
        }




        public DataTable GetAccount()
        {            
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);            
            DataTable dt_GA = objDBAcess.SP_Datatable("GetCustomerIdentification");
            return dt_GA;
        }

        public DataTable GetAccountByCustomerCode(int CustomerCode, string CustomerName, int IsActive)
        {
            dynamic[,] para = { 
                                { "@CustomerCode", CustomerCode },
                                { "@CustomerName", CustomerName },
                                { "@IsActive", IsActive }             
            
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GA = objDBAcess.SP_Datatable("sp_CPM_SearchMasterCustomer",para);
            return dt_GA;
        }
    }
}