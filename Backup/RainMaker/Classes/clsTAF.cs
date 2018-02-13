using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace RainMaker.Classes
{
    public class clsTAF
    {
        private static DBEngineType _eDBType;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        clsDBAccess objDBAcess;

        public clsTAF()
        {
            SqlConnection con = new SqlConnection(constr);
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
        }

        //public object CreateTAF(string RevisionNo, DateTime SubmissionDate, string Sites_JobLocation, string AccountManager, string BusinessUnit, string Capacity , string LastMileTopology, string RestorabilityMethod, string AdditionalEquipment, string ServiceParameter, string SLARequirement, int NRFID, int WorkingBy)
        //public object CreateTAF(string TAFFormNo, string RevisionNo, string Sites_JobLocation, string AccountManager, string BusinessUnit, int LastMileTopology, int Capacity, int InterfaceHandoff, int LogicalTopology,string RestorabilityMethod, int AdditionalEquipment,int SLARequirement, string AdditionRequirement, string ServiceParameter, string Comments, string AdditionalEquipmentDesc, int NRFID, int WorkingBy)
        public object CreateTAF(string TAFFormNo, string RevisionNo, string Sites_JobLocation, string AccountManager, string BusinessUnit, int LastMileTopology, int Capacity, int InterfaceHandoff, int LogicalTopology, string RestorabilityMethod, int AdditionalEquipment, int SLARequirement, string AdditionRequirement, int NRFID, int WorkingBy)
        {

            dynamic[,] para = { 
                                { "@TAFFormNo", TAFFormNo },
                                { "@RevisionNo", RevisionNo },
                                { "@Sites_JobLocation", Sites_JobLocation },
                                { "@AccountManager", AccountManager },
                                { "@BusinessUnit", BusinessUnit },
                                { "@LastMileTopology", LastMileTopology },
                                { "@Capacity", Capacity },
                                { "@InterfaceHandoff", InterfaceHandoff},
                                { "@LogicalTopology", LogicalTopology},
                                { "@RestorabilityMethod" , RestorabilityMethod},
                                { "@AdditionalEquipment" , AdditionalEquipment},
                                { "@SLARequirement", SLARequirement},
                                { "@AdditionRequirement", AdditionRequirement},                                
                                //{ "@ServiceParameter", ServiceParameter},
                                //{ "@Comments", Comments},
                                //{ "@AdditionalEquipmentDesc", AdditionalEquipmentDesc},                                
                                { "@NRFID", NRFID},
                                { "@WorkingBy", WorkingBy}

                                

                             };

            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectOpportunityID = objDBAcess.InsertProc_WithOutput("sp_InsertTAF", para, "@TAFID");
            return objectOpportunityID;

        }

        public object UpdateTAF(int TAFID,string TAFFormNo, string RevisionNo, string Sites_JobLocation, string AccountManager, string BusinessUnit, int LastMileTopology, int Capacity, int InterfaceHandoff, int LogicalTopology, string RestorabilityMethod, int AdditionalEquipment, int SLARequirement, string AdditionRequirement)
        {

            dynamic[,] para = { 
                                { "@TAFID", TAFID },
                                { "@TAFFormNo", TAFFormNo },
                                { "@RevisionNo", RevisionNo },
                                { "@Sites_JobLocation", Sites_JobLocation },
                                { "@AccountManager", AccountManager },
                                { "@BusinessUnit", BusinessUnit },
                                { "@LastMileTopology", LastMileTopology },
                                { "@Capacity", Capacity },
                                { "@InterfaceHandoff", InterfaceHandoff},
                                { "@LogicalTopology", LogicalTopology},
                                { "@RestorabilityMethod" , RestorabilityMethod},
                                { "@AdditionalEquipment" , AdditionalEquipment},
                                { "@SLARequirement", SLARequirement},
                                { "@AdditionRequirement", AdditionRequirement},                                
                                //{ "@ServiceParameter", ServiceParameter},
                                //{ "@Comments", Comments},
                                //{ "@AdditionalEquipmentDesc", AdditionalEquipmentDesc},                                
                               

                                

                             };

            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            //object objectOpportunityID = objDBAcess.InsertProc_WithOutput("sp_InsertTAF", para, "@TAFID");
            DataTable dt_UPDTAF = objDBAcess.SP_Datatable("sp_UpdateTAF", para);
            return dt_UPDTAF;

        }


        public DataTable GetTAF(int CustomerCode, DateTime TAFDate)
        {
            dynamic[,] para = {
 
                                 {"@CustomerCode",CustomerCode},
                                 {"@TAFDate",TAFDate}
                             
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GCNM = objDBAcess.SP_Datatable("sp_GetTAF", para);
            return dt_GCNM;
        }


        public DataTable GetTAFData(int TAFID)
        {
            dynamic[,] para = {
 
                                 {"@TAFID",TAFID}                                 
                             
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GCNM = objDBAcess.SP_Datatable("sp_GetTAFData", para);
            return dt_GCNM;
        }


        public string AcceptTAF(int NRFID, int TAFID, string ServiceParameter, string Comments, string AdditionalEquipmentDesc)
        {
            dynamic[,] para = { 
                               { "@NRFID", NRFID},
                               { "@TAFID", TAFID},
                               { "@ServiceParameter", ServiceParameter},
                               { "@Comments", Comments},
                               { "@AdditionalEquipmentDesc", AdditionalEquipmentDesc}
                   
            
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectCustomerID = objDBAcess.executeProc("sp_AcceptTAF", para);
            return "A";
        }


        public string RejectTAF(int NRFID, int TAFID, string ServiceParameter,string Comments,string AdditionalEquipmentDesc )
        {
            dynamic[,] para = { 
                               { "@NRFID", NRFID},
                               { "@TAFID", TAFID},
                               { "@ServiceParameter", ServiceParameter},
                               { "@Comments", Comments},
                               { "@AdditionalEquipmentDesc", AdditionalEquipmentDesc}

            
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectCustomerID = objDBAcess.executeProc("sp_RejectTAF", para);
            return "R";
        }
    }
}