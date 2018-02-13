using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RainMaker.Classes
{
    public class clsNRFWithOpportunity
    {
        private static DBEngineType _eDBType;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        clsDBAccess objDBAcess;

        public clsNRFWithOpportunity()
        {
            SqlConnection con = new SqlConnection(constr);
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
        }

        public DataTable GetOpportunityForNRF()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GON = objDBAcess.SP_Datatable("sp_Get_OpportunityForNRF");
            return dt_GON;
        }
    }
}