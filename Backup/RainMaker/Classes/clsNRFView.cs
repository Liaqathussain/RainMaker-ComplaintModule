using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace RainMaker.Classes
{
    public class clsNRFView
    {
        private static DBEngineType _eDBType;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        clsDBAccess objDBAcess;
        public clsNRFView()
        {
            SqlConnection con = new SqlConnection(constr);
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
        }


        public DataTable GetNRF(int NRFID)
        {

            string[,] para = {
 
                                 {"@NRFID",NRFID.ToString()}
                                 
                             
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            //DataTable dt = objDBAcess.SP_DatatableWithTwoParameters("sp_GetNullItems", para);
            DataTable dt_GNF = objDBAcess.SP_Datatable("sp_GetCustomerNRF", para);
            return dt_GNF;
            
        }

        public DataTable GetNRFforTAF(int CustomerCode)
        {

            string[,] para = {
 
                                 {"@CustomerCode",CustomerCode.ToString()}                                 
                             
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            //DataTable dt = objDBAcess.SP_DatatableWithTwoParameters("sp_GetNullItems", para);
            DataTable dt_GNF = objDBAcess.SP_Datatable("sp_GetCustomerNRFForTAF", para);
            return dt_GNF;

        }

        public DataTable GetCustomerNRFID(int CustomerCode)
        {

            string[,] para = {
 
                                 {"@CustomerCode",CustomerCode.ToString()}                                 
                             
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);            
            DataTable dt_GNF = objDBAcess.SP_Datatable("sp_GetCustomerNRFID", para);
            return dt_GNF;

        }

        public DataTable GetCustomerNRFMaster(int CustomerCode, int LOBID)
        {
            dynamic[,] para = {
 
                                 {"@CustomerCode",CustomerCode},
                                 {"@LOBID",LOBID} 

                             
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GCNM = objDBAcess.SP_Datatable("sp_GetCustomerNRFMaster", para);
            return dt_GCNM;
        }

        public DataTable GetCustomerNRFMasterForDetail(int CustomerCode)
        {
            dynamic[,] para = {
 
                                 {"@CustomerCode",CustomerCode}                                 
                             
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GCNM = objDBAcess.SP_Datatable("sp_GetCustomerNRFMasterForDetail", para);
            return dt_GCNM;
        }


        public DataTable GetCustomerNRFDetail(int NRFID)
        {
            dynamic[,] para = {
 
                                 {"@NRFID",NRFID}                                 
                             
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GCND = objDBAcess.SP_Datatable("sp_GetCustomerNRFDetail", para);
            return dt_GCND;
        }
    }
}