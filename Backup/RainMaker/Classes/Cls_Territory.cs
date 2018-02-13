using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using RainMaker.Classes;


namespace RainMaker.Classes
{
    public class Cls_Territory
    {
        private static DBEngineType _eDBType;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        clsDBAccess objDBAcess;

        public Cls_Territory()
        {
            SqlConnection con = new SqlConnection(constr);
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
        }


        public object InsertTerritoryQuotas(string PlanName, string TerritoryID, string RegionID, string Domain, string QuotaAmount, string StartDate, string EndDate, string RegionalHead, string RegionalHeadQuota, string ServcieUnitID, string IsActive, string TransactionBy, string TransactionDateTime)
        {
            string[,] para = { 
                                { "@PlanName", PlanName.ToString() },
                                { "@TerritoryID", TerritoryID },
                                
                                { "@RegionID", RegionID },
                                { "@Domain", Domain },
                                { "@QuotaAmount", QuotaAmount},
                                { "@StartDate", StartDate },
                                
                                { "@EndDate", EndDate },
                                { "@RegionalHead", RegionalHead },
                                { "@RegionalHeadQuota", RegionalHeadQuota },
                                { "@ServcieUnitID",ServcieUnitID},
                                { "@IsActive", IsActive },
                                { "@TransactionBy",TransactionBy},
                                { "@TransactionDateTime",TransactionDateTime}
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            bool IsInserted = objDBAcess.executeProc("RM_InsertQuotasTerritory", para);
            return IsInserted;

        }
        
        public object InsertTargets(string QuotaID, string MonthName, string Quater, string StartDate, string EndDate, string FiscalYear, string TargetAmount, string QuotaPercentage, string IsActive, string TransactionBy, string TransactionDateTime)
        {
            string[,] para = { 
                                { "@QuotaID", QuotaID},
                                { "@MonthName", MonthName },
                                { "@Quater", Quater },
                                { "@StartDate", StartDate},
                                { "@EndDate", EndDate },
                                { "@FiscalYear", FiscalYear },
                                { "@TargetAmount", TargetAmount },
                                { "@QuotaPercentage", QuotaPercentage },
                                { "@IsActive", IsActive },
                                { "@TransactionBy",TransactionBy},
                                { "@TransactionDateTime",TransactionDateTime}
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            bool IsInserted = objDBAcess.executeProc("RM_InsertTargets", para);
            return IsInserted;

        }
        
        public DataTable GetTerritoryQuotas()
        {

            string[,] para = {
                     //{"@CustomerCode",QID.ToString()}
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            //DataTable dt = objDBAcess.SP_DatatableWithTwoParameters("sp_GetNullItems", para);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetTerritoryQuota");
            return dt_GNF;

        }

        public DataTable GetLOB()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetLOB");
            return dt_GNF;
        }

        public DataTable GetTerritoryHead()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetTerritoryHead");
            return dt_GNF;
        }

        public DataTable GetRegion()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetRegion");
            return dt_GNF;
        }

        public DataTable GetRegionByTerritory(string FiscalYear,string TerritoryName, string DomainName)
        {
            string[,] para = {
                     {"@RegionName",TerritoryName.ToString()},
                     {"@DomainName",DomainName.ToString()},
                     {"@FiscalYear",FiscalYear.ToString()}
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
             DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetRegionByTerritory",para);
            return dt_GNF;
        }
        public DataTable GetFiscalYear()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetFiscalYear");
            return dt_GNF;
        }
        public DataTable GetTerritoryQuotasOnly()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetTerritoryQuotas");
            return dt_GNF;
        }
        public DataTable GetTerritoryQuotaforTargets(string fiscalyear)
        {
            string[,] para = { 
                                { "@FiscalYear", fiscalyear.ToString() }
                             
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetTerritoryQuota",para);
            return dt_GNF;
        }

        public DataTable GetServiceUnit()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetServiceUnit");
            return dt_GNF;
        }

        public DataTable GetStatus()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("GetStatus");
            return dt_GNF;
        }

        public DataTable GetDomain()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetDomain");
            return dt_GNF;
        }

        //---------------------------------------------------------------------------------------------------------------------
        //System Users
        public object InsertSystemUsers(string txtName, string UserName, string Department, string Designation, string @RoleID, string Email, string password, string LOB, string SubDeptName, string ReportingManager, string Phone, string userStatus, string Region, string Domain, string CreatedBy)
        {
            string[,] para = { 
                                { "@Name", txtName.ToString() },
                                { "@DepartmentID", Department },
                                { "@Username", UserName },
                                { "@Password", password },
                                { "@RoleID", @RoleID},
                                { "@ManagerID", ReportingManager },
                                { "@DesignationID", Designation },
                                { "@Email", Email },
                                { "@Phone",Phone},
                                { "@SubDepID",SubDeptName},
                                { "@LOBID",LOB},
                                { "@DomainID",Domain},
                                { "@RegionID", Region},
                                { "@CreatedBy",CreatedBy},
                                { "@TransactionDateTime",DateTime.Now.ToShortDateString()},
                                { "@IsADAuthenticate","1"},
                                { "@IsActive","1"}
                                
                                
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            bool IsInserted = objDBAcess.executeProc("RM_InsertSystemUsers", para);
            return IsInserted;

        }

        public DataTable GetDesignation()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetDesignation");
            return dt_GNF;
        }
        public DataTable GetDepartment()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetDepartment");
            return dt_GNF;
        }
        public DataTable GetSubDepartment()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetSubDepartment");
            return dt_GNF;
        }

        public DataTable GetServiceUnitSysUser()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetServiceUnit");
            return dt_GNF;
        }

        public DataTable GetLOBForSysUsers()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetLOB");
            return dt_GNF;
        }

        public DataTable Getstatus()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("GetStatus");
            return dt_GNF;
        }

        public DataTable GetResourceRole()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetResourceRole");
            return dt_GNF;
        }
        public DataTable GetReportingManager()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetReportingManager");
            return dt_GNF;
        }
        public DataTable GetReportingManagerByUserID(string UserID)
        {
            string[,] para = { { "@UserID", UserID.ToString() } };
  
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetReportingManagerByUserID",para);
            return dt_GNF;
        }
        public DataTable GetRegionforSysUsers()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetRegion");
            return dt_GNF;
        }

        public DataTable GetSysUsers()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetSysUsers");
            return dt_GNF;
        }
        //-------------------------------------
        //Activity
        public object InsertActivity(string Subject, string CustCode, string Account, string Address, string POC, string SubRefID, String Opportunity, string ActivityDate, string ActivityTime, string ActivityTypeID, string ActivityStatus, string ActivityOwner, string Remarks, String CloserRemarks, string Attachment, string IsActive, string TransactionBy, String TransactionDateTime)
        {
            string[,] para = { 
                                { "@Subject", Subject.ToString() },
                                { "@RefID", CustCode },
                                { "@RefName", Account },
                                { "@Address", Address },
                                { "@POC", POC },
                                { "@SubRefID", SubRefID},
                                { "@SubRefName", Opportunity},
                                { "@ActivityDate", ActivityDate },
                                { "@ActivityTime", ActivityTime },
                                { "@ActivityTypeID", ActivityTypeID },
                                { "@ActivityStatus",ActivityStatus},
                                { "@ActivityOwner",ActivityOwner},
                                { "@Remarks",Remarks},
                                { "@ClosureRemarks",CloserRemarks},
                                { "@Attachment",Attachment},
                                { "@IsActive", IsActive},
                                { "@TransactionBy",TransactionBy},
                                { "@TransactionDateTime",TransactionDateTime}
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            bool IsInserted = objDBAcess.executeProc("RM_InsertActivity", para);
            return IsInserted;

        }

        public object UpdateActivity(string ActivityID,string Subject, string CustCode, string Account, string Address, string POC, string SubRefID, String Opportunity, string ActivityDate, string ActivityTime, string ActivityTypeID, string ActivityStatus, string ActivityOwner, string Remarks, String CloserRemarks)
        {
            string[,] para = { 
                                { "@ActivityID", ActivityID},
                                { "@Subject", Subject.ToString() },
                                { "@RefID", CustCode },
                                { "@RefName", Account },
                                { "@Address", Address },
                                { "@POC", POC },
                                { "@SubRefID", SubRefID},
                                { "@SubRefName", Opportunity},
                                { "@ActivityDate", ActivityDate },
                                { "@ActivityTime", ActivityTime },
                                { "@ActivityTypeID", ActivityTypeID },
                                { "@ActivityStatus",ActivityStatus},
                                { "@ActivityOwner",ActivityOwner},
                                { "@Remarks",Remarks},
                                { "@ClosureRemarks",CloserRemarks}
                             };
           
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            bool IsInserted = objDBAcess.executeProc("MR_UpdateActivity", para);
            return IsInserted;

        }

        public object UpdateQuotas(string QuotasID, string PlanName, string RegionID, string DomainID, string QuotaAmount, String RegionalHead, string RegionalHeadQuota, string IsActive)
        {
            string[,] para = { 
                                { "@QuotaID", QuotasID},
                                { "@PlanName", PlanName},
                                { "@RegionID", RegionID },
                                { "@Domain", DomainID },
                                { "@QuotaAmount", QuotaAmount },
                                { "@RegionalHead", RegionalHead },
                                { "@RegionalHeadQuota", RegionalHeadQuota},
                                { "@IsActive", IsActive },
                             };

            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            bool IsInserted = objDBAcess.executeProc("MR_UpdateQuotas", para);
            return IsInserted;

        }
        public object UpdateUsers(string Name, string UserName, string Department, string Designation, string ResourceRole, string Email, string password, string LOB, string SubDeptName, string ReportingManager, string Phone, string userStatus, string RegionID, string DomainID, string userid )
                                       
        {
            string[,] para = { 
                                { "@UserID", userid },
                                { "@Name", Name.ToString() },
                                { "@DepartmentID", Department },
                                { "@Username", UserName },
                                { "@Password", password },
                                { "@RoleID", ResourceRole},
                                { "@ManagerID", ReportingManager },
                                { "@DesignationID", Designation },
                                { "@Email", Email },
                                { "@Phone",Phone},
                                { "@SubDepID",SubDeptName},
                                { "@LOBID",LOB},
                                { "@DomainID",DomainID},
                                { "@RegionID", RegionID},
                                { "@CreatedBy",userid},
                                { "@TransactionDateTime",DateTime.Now.ToShortDateString()},
                                { "@IsADAuthenticate","1"},
                                { "@IsActive","1"}
                             };

            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            bool IsInserted = objDBAcess.executeProc("MR_UpdateUsers", para);
            return IsInserted;

        }
        public DataTable GetCustomerCode()
        {
            
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetCustomerCode");
            return dt_GNF;
        }

        public DataTable GetActivityType()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetActivityType");
            return dt_GNF;
        }

        public DataTable GetActivityStatus()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetActivityStatus");
            return dt_GNF;
        }
        public DataTable GetCloserRemarks()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetCloserRemarks");
            return dt_GNF;
        }
        public DataTable GetCustomerContact(string RefID)
        {
            string[,] para = {{ "@RefID", RefID.ToString()}};
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetCustomerContact",para);
            return dt_GNF;
        }

        public DataTable GetOpportunity(string RefID)
        {
            string[,] para = { { "@RefID", RefID.ToString() } };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetOpportunityName", para);
            return dt_GNF;
        }

        public DataTable GetActivity(string UserID)
        {
            string[,] para = { { "@UserID", UserID.ToString() } };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("RM_GetActivity", para);
            return dt_GNF;
        }
       //---------------------------------------

        public DataTable GetCompView()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("GetComplaintSD");
            return dt_GNF;
        }
        public DataTable GetTeam()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("OM_GetTeam");
            return dt_GNF;
        }

        public DataTable GetPriority()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GNF = objDBAcess.SP_Datatable("OM_GetPriority");
            return dt_GNF;
        }

        
    }
}