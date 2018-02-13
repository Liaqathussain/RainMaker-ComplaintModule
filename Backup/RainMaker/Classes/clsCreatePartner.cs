using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace RainMaker.Classes
{
    public class clsCreatePartner
    {

        private static DBEngineType _eDBType;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        clsDBAccess objDBAcess;

        public clsCreatePartner()
        {
            SqlConnection con = new SqlConnection(constr);
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
        }


        public object CreatePartner(int CustomerCode, int PartnerCode)
        {
            dynamic[,] para = { 
                                { "@CustomerCode", CustomerCode },
                                { "@PartnerCode", PartnerCode }     
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectPartnerID = objDBAcess.executeProc("sp_CPM_InsertCustPartner", para);
            return objectPartnerID;
        }
    }
}