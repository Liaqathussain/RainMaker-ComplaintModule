using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace RainMaker.Classes
{
    public class clsGeneralFunction
    {
        private static DBEngineType _eDBType;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        clsDBAccess objDBAcess;

        public clsGeneralFunction()
        {
            SqlConnection con = new SqlConnection(constr);
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
        }

        public DataTable GetALLServices()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GAS = objDBAcess.SP_Datatable("GetServiceUnits");
            return dt_GAS;
        }

        public DataTable GetOpportunityDetails(int OppID)

        {
            dynamic[,] para = {
                              {"@OppID",OppID }
                              };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GD = objDBAcess.SP_Datatable("Get_Opportunity",para);
            return dt_GD;
        }

        public DataTable GetOpportunityBudgetary()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GD = objDBAcess.SP_Datatable("Get_BudgetaryOpportunity");
            return dt_GD;
        }

        public DataTable GetOpportunityRequirementEBU()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GD = objDBAcess.SP_Datatable("Get_Requirement_EBU");
            return dt_GD;
        }

        public DataTable GetOpportunitySurveyEBU()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GD = objDBAcess.SP_Datatable("Get_Survey_EBU");
            return dt_GD;
        }

        public DataTable GetOpportunityBusinessCaseEBU()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GD = objDBAcess.SP_Datatable("Get_BusinessCase_EBU");
            return dt_GD;
        }



        public DataTable GetOpportunityProposal()
        {            
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GD = objDBAcess.SP_Datatable("Get_Proposal");
            return dt_GD;
        }

        public DataTable GetOpportunityProposal(int OppID)
        {
            dynamic[,] para = { { "@OppID", OppID } };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GD = objDBAcess.SP_Datatable("Get_Proposal", para);
            return dt_GD;
        }


        public DataTable GetALLBandWidth()
        {

            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt = objDBAcess.SP_Datatable("GetBandwidthEnterprise");
            return dt;
        }


        public DataTable GetALLBusinessType()
        {

            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt = objDBAcess.SP_Datatable("GetBusinessType");
            return dt;
        }

        public DataTable GetBuildingByCityName(string CityName)
        {
            string[,] para = { { "@CityName", Convert.ToString(CityName) } };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GBBCN = objDBAcess.SP_Datatable("sp_GetBuildingChargesByCityName", para);
            return dt_GBBCN;
        }

        public DataTable GetBuildingByCityID(string CityName)
        {
            string[,] para = { { "@CityName", Convert.ToString(CityName) } };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GBBCN = objDBAcess.SP_Datatable("sp_GetBuildingChargesByCityID", para);
            return dt_GBBCN;
        }

        public DataTable GetArea(int City)
        {
            dynamic[,] para = { { "@City", City } };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            //DataTable dt = objDBAcess.SP_DatatableWithTwoParameters("sp_GetNullItems", para);
            DataTable dt_GA = objDBAcess.SP_Datatable("sp_GetArea", para);
            return dt_GA;
        }


        public DataTable GetRegionByCityID(int City)
        {
            dynamic[,] para = { { "@City", City } };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            //DataTable dt = objDBAcess.SP_DatatableWithTwoParameters("sp_GetNullItems", para);
            DataTable dt_GRBCI = objDBAcess.SP_Datatable("sp_GetRegionByCity", para);
            return dt_GRBCI;
        }

        public DataTable GetAreabyAreaID(int AreaID)
        {
            dynamic[,] para = { { "@AreaID", AreaID } };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            //DataTable dt = objDBAcess.SP_DatatableWithTwoParameters("sp_GetNullItems", para);
            DataTable dt_GABAI = objDBAcess.SP_Datatable("Get_AreabyAreaID", para);
            return dt_GABAI;
        }

        public DataTable GetAllItems()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt = objDBAcess.SP_Datatable("sp_GetAllItems");
            return dt;
        }

        public DataTable GetAllLOB()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt = objDBAcess.SP_Datatable("Get_LOB");
            return dt;
        }

        public DataTable GetAllInfra()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt = objDBAcess.SP_Datatable("Get_LOB");
            return dt;
        }

        public DataTable GetAllCustomer()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt = objDBAcess.SP_Datatable("GetCustomerIdentification");
            return dt;
        }


        public DataTable GetAllAccounts()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt = objDBAcess.SP_Datatable("sp_CPM_GetMasterCustomer");
            return dt;
        }

        public DataTable GetAllCurrencies()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt = objDBAcess.SP_Datatable("sp_Get_Currency");
            return dt;
        }

        public DataTable GetAllOppStatus()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt = objDBAcess.SP_Datatable("sp_OppStatus");
            return dt;
        }

        public DataTable GetDomain()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GD = objDBAcess.SP_Datatable("sp_SelDomain");
            return dt_GD;
        }

        public DataTable GetAllContacts(int ContactID, string CustomerName, int IsActive)
        {

            dynamic[,] para = { 
                                { "@ContactID", ContactID },
                                { "@CustomerName", CustomerName },
                                { "@IsActive", IsActive }                              
                              
                              };

            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GAC = objDBAcess.SP_Datatable("sp_SelCustomerContact",para);
            return dt_GAC;
        }


        public DataTable GetOppStages(int LOBID)
        {
            dynamic[,] para = { 
                                
                                { "@LOB_ID", LOBID }                              
                              
                              };

            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GOS = objDBAcess.SP_Datatable("sp_GetOppStages", para);
            return dt_GOS;
        }


        public DataTable GetOppStagesEBU(int LOBID)
        {
            dynamic[,] para = { 
                                
                                { "@LOB_ID", LOBID }                              
                              
                              };

            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GOS = objDBAcess.SP_Datatable("sp_GetOppStagesEBU", para);
            return dt_GOS;
        }

        public DataTable GetOppStatus()
        {           
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GOS = objDBAcess.SP_Datatable("sp_GetOppStatus");
            return dt_GOS;
        }

        public DataTable GetCurrency()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GOS = objDBAcess.SP_Datatable("sp_GetCurrency");
            return dt_GOS;
        }

        #region "Create Customer Contact"

        public DataTable GetContactTitle()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_CT = objDBAcess.SP_Datatable("sp_Sales_GetContactTitle");
            return dt_CT;
        }


        public DataTable GetContactType()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_CCT = objDBAcess.SP_Datatable("sp_Sales_GetContactType");
            return dt_CCT;
        }

        public DataTable GetContactReligion()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_CR = objDBAcess.SP_Datatable("sp_Sales_GetContactReligion");
            return dt_CR;
        }

        #endregion


    }
}