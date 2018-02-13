using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace RainMaker.Classes
{
    public class clsInfraCosting
    {
        private static DBEngineType _eDBType;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        clsDBAccess objDBAcess;

        public clsInfraCosting()
        {
            SqlConnection con = new SqlConnection(constr);
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
        }

        public DataTable GetDefaultItems(float Distance, int InfraType, int BuildID, int City, int AreaID)
        {
            //string[,] para = { { "@Distance", Distance.ToString() }, { "@InfraType", InfraType.ToString() }, { "@BuildID", BuildID.ToString() } };
            dynamic[,] para = { { "@Distance", Distance }, { "@InfraType", InfraType }, { "@BuildID", BuildID }, { "@City", City }, { "@AreaID", AreaID } };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            //DataTable dt = objDBAcess.SP_DatatableWithTwoParameters("sp_GetNullItems", para);
            DataTable dt_GDI = objDBAcess.SP_Datatable("sp_InfraBasedItems", para);
            return dt_GDI;
        }

        //public DataTable GetDefaultItems(float Distance, int InfraType, int BuildID, int City)
        //{
        //    //string[,] para = { { "@Distance", Distance.ToString() }, { "@InfraType", InfraType.ToString() }, { "@BuildID", BuildID.ToString() } };
        //    dynamic[,] para = { { "@Distance", Distance }, { "@InfraType", InfraType }, { "@BuildID", BuildID }, { "@City", City }};
        //    clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
        //    //DataTable dt = objDBAcess.SP_DatatableWithTwoParameters("sp_GetNullItems", para);
        //    DataTable dt_GDI = objDBAcess.SP_Datatable("sp_GetNullItems", para);
        //    return dt_GDI;
        //}

        
        


        public DataTable GetAllItemsWithItemNumber(string ItemNumber)
        {
            string[,] para = { { "@ItemNumber", Convert.ToString(ItemNumber) } };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt = objDBAcess.SP_Datatable("sp_GetAllItemsWithItemNumber", para);
            return dt;
        }

        public object CreateNRF(int str_CustomerCode, string str_Addres, string str_City, string str_Industry, string str_BranchName, string str_NRFService,  string str_Capacity, string str_InfraType, int int_LOB, int int_Distance, string str_POCName, string str_POCCOntact, string str_POCEmail, int int_MRC, int int_OTC,int int_ROI, int int_Building, int int_Area, int int_Infra,string str_Region,string str_TransactionBy)
        {
            string[,] para = { 
                                { "@CustomerCode", str_CustomerCode.ToString() },
                                { "@SiteAddress", str_Addres },
                                { "@City", str_City },
                                { "@Industry", str_Industry },
                                { "@BranchName", str_BranchName },
                                { "@NRFService", str_NRFService },                                
                                { "@Capacity", str_Capacity },
                                { "@InfraType", str_InfraType },
                                { "@LOB", int_LOB.ToString() },
                                { "@Distance", Convert.ToString(int_Distance) },
                                { "@POCName", str_POCName },
                                { "@POCContact", str_POCCOntact },
                                { "@POCEmail", str_POCEmail },
                                { "@MRC", int_MRC.ToString() },
                                { "@OTC", int_OTC.ToString() },
                                { "@ROI", int_ROI.ToString() },
                                { "@Building", int_Building.ToString() },
                                { "@Area", int_Area.ToString() },
                                { "@Infra", int_Area.ToString() },
                                { "@Region", str_Region },
                                { "@TransactionBy", str_TransactionBy }

                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectnrfid = objDBAcess.InsertProc_WithOutput("sp_InsertNRFNew", para, "@NRFID");
            return objectnrfid;

        }

        public object UpdateNRFKey(string str_NRFID)
        {
            string[,] para = {                                 
                                { "@NRFID", str_NRFID }
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectnrfid = objDBAcess.executeProc("sp_UpdateNRFNEW", para);
            return objectnrfid;

        }

        public DataTable GetNRFKeyForPDF(int NRFID)
        {
            dynamic[,] para = { { "@NRFID", NRFID } };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNKFP = objDBAcess.SP_Datatable("sp_GetNRFKeyForPDF", para);
            return dt_GNKFP;
        }


        public object InsertItems(int int_NRFID, string str_ItemNumber, int int_Quantity, Decimal dec_Cost)
        {
            string[,] para = { 
                                { "@NRFID",  int_NRFID.ToString() },
                                { "@ITEMNMBR", str_ItemNumber },
                                { "@Quantity", int_Quantity.ToString() },
                                { "@Cost", dec_Cost.ToString() },
                               
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            bool IsInserted = objDBAcess.executeProc("sp_InsertNRFLine", para);
            return IsInserted;

        }




    }
}