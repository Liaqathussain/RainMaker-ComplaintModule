using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace RainMaker.Classes
{
    public class clsCreateContact
    {
        private static DBEngineType _eDBType;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        clsDBAccess objDBAcess;



        public clsCreateContact()
        {
            SqlConnection con = new SqlConnection(constr);
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
        }


        public object CreateContact(int CustCode, 
                                    int CityID,                                   
                                    string CC_Title,
                                    string CC_Name, 
                                    string CC_Contact, 
                                    string CC_Email, 
                                    string CC_Mobile, 
                                    string CC_Address, 
                                    int ContactTypeID, 
                                    string Religion,
                                    string Gender,
                                    int TransactionBy
                                    )
        {
            dynamic[,] para = { 
                                { "@CustCode", CustCode },
                                { "@CityID", CityID },
                                { "@CC_Title", CC_Title },
                                { "@CC_Name", CC_Name },
                                { "@CC_Contact", CC_Contact },
                                { "@CC_Email", CC_Email  },
                                { "@CC_Mobile", CC_Mobile },
                                { "@CC_Address", CC_Address },
                                { "@ContactTypeID", ContactTypeID },
                                { "@Religion" , Religion},
                                { "@Gender", Gender},
                                { "@TransactionBy",TransactionBy}         
                             };
           
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectCustomerID = objDBAcess.executeProc("sp_Sales_InsertCustomerContact", para);
            return objectCustomerID;
        }

        public void UpdateContact(int ContactID, int CustomerCode, string FirstName, string LastName, string Prefix , string Department,  string CNIC , string JobTitle, string MobilePhone, string WorkPhone, string Email, string Address, string City, string State, string Country, string PinCode, string Gender, string Religion, string ContactType, int IsFav, int IsActive)
        {
            dynamic[,] para = { 
                                { "@ContactID", ContactID },
                                { "@CustomerCode", CustomerCode },                                
                                { "@FirstName", FirstName },
                                { "@LastName", LastName },
                                { "@Prefix", Prefix },
                                { "@Department", Department },
                                { "@CNIC", CNIC },
                                { "@JobTitle", JobTitle },
                                { "@MobilePhone", MobilePhone },
                                { "@WorkPhone", WorkPhone },       
                                { "@Email", Email },
                                { "@Address" , Address},
                                { "@City", City},
                                { "@State",State},
                                { "@Country", Country},
                                { "@PinCode", PinCode},
                                { "@Gender", Gender},
                                { "@Religion", Religion},
                                { "@ContactType", ContactType},
                                { "@IsFav", IsFav},
                                { "@IsActive", IsActive}
            
                             };

            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectContactID = objDBAcess.executeProc("sp_UpdateCustomerContacts", para);
            
        }


    }





}