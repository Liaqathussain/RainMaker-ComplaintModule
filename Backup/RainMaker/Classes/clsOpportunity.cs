using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace RainMaker.Classes
{
    public class clsOpportunity
    {
        private static DBEngineType _eDBType;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        clsDBAccess objDBAcess;


        public clsOpportunity()
        {
            SqlConnection con = new SqlConnection(constr);
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
        }

        /*public object CreateOpportunity(string OppName, string PartnerID, string CustCode, string ContactID, string KAMID, string WinProbability, string CurrencyID, string StageID, int StatusID
            , int IsActive, string IsBudgetaryQuote, string BudgetaryQuoteDate, string BudgetaryQuoteAmount
            , string QuoteProposalDate, string NegotiatedMMR, string NegotiatedAmount, string NegotiatedRevenue)*/

        //    public object CreateOpportunity(string OppName, string PartnerID, string CustCode, string ContactID, string KAMID, string WinProbability, string CurrencyID, string StageID, int StatusID
        //    , int IsActive)
        //{
        //    //dynamic[,] para = { 
        //    //                    { "@OppName", OppName },
        //    //                    { "@PartnerID", PartnerID },
        //    //                    { "@CustCode", CustCode },
        //    //                    { "@ContactID", ContactID },
        //    //                    { "@KAMID", KAMID },
        //    //                    { "@WinProbability", WinProbability },       
        //    //                    { "@CurrencyID", CurrencyID },
        //    //                    { "@StageID" , StageID},
        //    //                    { "@StatusID", StatusID},
        //    //                    { "@IsActive", IsActive},
        //    //                    { "@IsBudgetaryQuote", IsBudgetaryQuote},
        //    //                    { "@BudgetaryQuoteDate", BudgetaryQuoteDate},
        //    //                    { "@BudgetaryQuoteAmount", BudgetaryQuoteAmount},
        //    //                    { "@QuoteProposalDate", QuoteProposalDate},
        //    //                    { "@NegotiatedMMR", NegotiatedMMR},
        //    //                    { "@NegotiatedAmount", NegotiatedAmount},
        //    //                    { "@NegotiatedRevenue", NegotiatedRevenue},
        //    //                    { "@NegotiatedMMR", NegotiatedMMR},
        //    //                    { "@NegotiatedMMR", NegotiatedMMR},

        //    //                 };

        //    dynamic[,] para = { 
        //                        { "@OppName", OppName },
        //                        { "@PartnerID", PartnerID },
        //                        { "@CustCode", CustCode },
        //                        { "@ContactID", ContactID },
        //                        { "@KAMID", KAMID },
        //                        { "@WinProbability", WinProbability },       
        //                        { "@CurrencyID", CurrencyID },
        //                        { "@StageID" , StageID},
        //                        { "@StatusID", StatusID},
        //                        { "@IsActive", IsActive},                             

        //                     };

        //    clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
        //    object objectCustomerID = objDBAcess.executeProc("sp_InsertOpportunity", para);
        //    return objectCustomerID;
        //}

        public object CreateOpportunity(string OppName, string OppType, int StageID,int PartnerID,int CustCode,int CurrencyID,int StatusID, string WinProbability,int KAMID, int WorkingBy, string Attachment1,int LastUpdateBy  )
        {

            dynamic[,] para = { 
                                { "@OppName", OppName },
                                { "@OppType", OppType },
                                { "@StageID", StageID },
                                { "@PartnerID", PartnerID },
                                { "@CustCode", CustCode },
                                { "@CurrencyID", CurrencyID },
                                { "@StatusID", StatusID },
                                { "@WinProbability", WinProbability },                                
                                { "@KAMID" , KAMID},
                                { "@WorkingBy" , WorkingBy},
                                { "@Attachment1", Attachment1},                                
                                { "@LastUpdateBy", LastUpdateBy}

                                

                             };

            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectOpportunityID = objDBAcess.InsertProc_WithOutput("sp_InsertOpportunityMaster_New", para, "@OppId");
            return objectOpportunityID;

        }

        public object UpdateOpportunity(int OppId, string OppName, int StageID, int PartnerID, int CustCode, int CurrencyID, int StatusID, string WinProbability, int KAMID, int WorkingBy, string Attachment1, int LastUpdateBy, int IsBudgetaryQuote, DateTime BudgetaryQuoteDate, DateTime QuoteProposalDate)
        {

            dynamic[,] para = { 
                                { "@OppId", OppId },
                                { "@OppName", OppName },
                                { "@StageID", StageID },                                
                                { "@PartnerID", PartnerID },
                                { "@CustCode", CustCode },
                                { "@CurrencyID", CurrencyID },
                                { "@StatusID", StatusID },
                                { "@WinProbability", WinProbability },                                
                                { "@KAMID" , KAMID},
                                { "@WorkingBy" , WorkingBy},
                                { "@Attachment1", Attachment1},                                
                                { "@LastUpdateBy", LastUpdateBy},                                
                                { "@IsBudgetaryQuote", IsBudgetaryQuote},
                                { "@BudgetaryQuoteDate", BudgetaryQuoteDate},
                                { "@QuoteProposalDate", QuoteProposalDate}

                                

                             };

            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectOpportunityID = objDBAcess.executeProc("sp_UpdateOpportunityMaster_New", para);
            return objectOpportunityID;

        }

        //public object CreateOpportunityDetails(string SID_A_Address, string SID_A_Area, string SID_A_Building, string SID_A_City)
        //{

        //    dynamic[,] para = { 
        //                        { "@SID_A_Address", SID_A_Address },
        //                        { "@SID_A_Area", SID_A_Area },
        //                        { "@SID_A_Building", SID_A_Building },
        //                        { "@SID_A_City", SID_A_City }                               

        //                     };

        //    clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
        //    object objectCustomerID = objDBAcess.executeProc("sp_InsertOpportunityDetails", para);
        //    return objectCustomerID;
        //}

        public object CreateOpportunityDetails(string Site_A_Address, int Site_A_Country, int Site_A_City, string Site_B_Address, int Site_B_Country, int Site_B_City, int Name, int QuantityUOM, int Interface, string Last_Mile_Protection, string Wet_Portion_Restorability, string SLA, DateTime RFS_Date_Duration, string Contract_Term, string Win_Loss, int Currency, int OppID)
        {
            dynamic[,] para = { 
                                { "@Site_A_Address", Site_A_Address },
                                { "@Site_A_Country", Site_A_Country },
                                { "@Site_A_City", Site_A_City },
                                { "@Site_B_Address", Site_B_Address },
                                { "@Site_B_Country", Site_B_Country },
                                { "@Site_B_City", Site_B_City },
                                { "@Name", Name },
                                { "@QuantityUOM" , QuantityUOM},                                
                                { "@Interface",Interface},
                                { "@Last_Mile_Protection",Last_Mile_Protection},
                                { "@Wet_Portion_Restorability", Wet_Portion_Restorability},
                                { "@SLA", SLA},
                                { "@RFS_Date_Duration", RFS_Date_Duration},
                                { "@Contract_Term", Contract_Term},
                                { "@Win_Loss", Win_Loss},
                                { "@Currency", Currency},
                                { "@OppID", OppID}
            
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectCustomerID = objDBAcess.executeProc("sp_Ins_OpportunityDetails_New", para);
            return objectCustomerID;
        }

        public object UpdateOpportunityDetails(int OppID,string Site_A_Address, int Site_A_Country, int Site_A_City, string Site_B_Address, int Site_B_Country, int Site_B_City, int Name, int QuantityUOM, int Interface, string Last_Mile_Protection, string Wet_Portion_Restorability, string SLA, DateTime RFS_Date_Duration, string Contract_Term, string Win_Loss, int Currency,decimal NRC_Budget,decimal MRC_Budget,decimal NRC_Cost_On_Net,decimal MRC_Cost_On_Net, decimal NRC_Cost_Off_Net, decimal MRC_Cost_Off_Net,decimal NRC_Cost_OOP,decimal MRC_Cost_OOP,string Name_of_3P,decimal NRC_Actual,decimal MRC_Actual,decimal NRR,decimal MRR,decimal ROI ,decimal Term_Profit ,decimal Term_Revenue,decimal Recurring_Margin_Percentage,decimal Non_Recurring_Margin_Percentage)
        {
            dynamic[,] para = { 
                                { "@OppID",OppID},
                                { "@Site_A_Address", Site_A_Address },
                                { "@Site_A_Country", Site_A_Country },
                                { "@Site_A_City", Site_A_City },
                                { "@Site_B_Address", Site_B_Address },
                                { "@Site_B_Country", Site_B_Country },
                                { "@Site_B_City", Site_B_City },
                                { "@Name", Name },
                                { "@QuantityUOM" , QuantityUOM},                                
                                { "@Interface",Interface},
                                { "@Last_Mile_Protection",Last_Mile_Protection},
                                { "@Wet_Portion_Restorability", Wet_Portion_Restorability},
                                { "@SLA", SLA},
                                { "@RFS_Date_Duration", RFS_Date_Duration},
                                { "@Contract_Term", Contract_Term},
                                { "@Win_Loss", Win_Loss},
                                { "@Currency", Currency},
                                { "@NRC_Budget", NRC_Budget},
                                { "@MRC_Budget", MRC_Budget},
                                { "@NRC_Cost_On_Net", NRC_Cost_On_Net},
                                { "@MRC_Cost_On_Net", MRC_Cost_On_Net},
                                { "@NRC_Cost_Off_Net", NRC_Cost_Off_Net},
                                { "@MRC_Cost_Off_Net", MRC_Cost_Off_Net},
                                { "@NRC_Cost_OOP", NRC_Cost_OOP},
                                { "@MRC_Cost_OOP", MRC_Cost_OOP},
                                { "@Name_of_3P", Name_of_3P},
                                { "@NRC_Actual", NRC_Actual},
                                { "@MRC_Actual", MRC_Actual},
                                { "@NRR", NRR},
                                { "@MRR", MRR},
                                { "@ROI", ROI},
                                { "@Term_Profit", Term_Profit},
                                { "@Term_Revenue", Term_Revenue},
                                { "@Recurring_Margin_Percentage", Recurring_Margin_Percentage},
                                { "@Non_Recurring_Margin_Percentage", Non_Recurring_Margin_Percentage}

                                
            
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectCustomerID = objDBAcess.executeProc("sp_Update_OpportunityDetails_New", para);
            return objectCustomerID;
        }

        public object InsertRevenueLines(int OppID, string Site_A_Address,int Site_A_Country, int Site_A_City, string Site_B_Address, int Site_B_Country, int Site_B_City, int Name, int QuantityUOM, int Interface, string Last_Mile_Protection, string Wet_Portion_Restorability, string SLA, DateTime RFS_Date_Duration, string Contract_Term, string Win_Loss, int Currency, decimal NRC_Budget, decimal MRC_Budget, decimal NRC_Cost_On_Net, decimal MRC_Cost_On_Net, decimal NRC_Cost_Off_Net, decimal MRC_Cost_Off_Net, decimal NRC_Cost_OOP, decimal MRC_Cost_OOP, string Name_of_3P, decimal NRC_Actual, decimal MRC_Actual, decimal NRR, decimal MRR, decimal ROI, decimal Term_Profit, decimal Term_Revenue, decimal Recurring_Margin_Percentage, decimal Non_Recurring_Margin_Percentage)
        {
            dynamic[,] para = { 
                                { "@OppID",OppID},
                                { "@Site_A_Address", Site_A_Address },
                                { "@Site_A_Country", Site_A_Country },
                                { "@Site_A_City", Site_A_City },
                                { "@Site_B_Address", Site_B_Address },
                                { "@Site_B_Country", Site_B_Country },
                                { "@Site_B_City", Site_B_City },
                                { "@Name", Name },
                                { "@QuantityUOM" , QuantityUOM},                                
                                { "@Interface",Interface},
                                { "@Last_Mile_Protection",Last_Mile_Protection},
                                { "@Wet_Portion_Restorability", Wet_Portion_Restorability},
                                { "@SLA", SLA},
                                { "@RFS_Date_Duration", RFS_Date_Duration},
                                { "@Contract_Term", Contract_Term},
                                { "@Win_Loss", Win_Loss},
                                { "@Currency", Currency},
                                { "@NRC_Budget", NRC_Budget},
                                { "@MRC_Budget", MRC_Budget},
                                { "@NRC_Cost_On_Net", NRC_Cost_On_Net},
                                { "@MRC_Cost_On_Net", MRC_Cost_On_Net},
                                { "@NRC_Cost_Off_Net", NRC_Cost_Off_Net},
                                { "@MRC_Cost_Off_Net", MRC_Cost_Off_Net},
                                { "@NRC_Cost_OOP", NRC_Cost_OOP},
                                { "@MRC_Cost_OOP", MRC_Cost_OOP},
                                { "@Name_of_3P", Name_of_3P},
                                { "@NRC_Actual", NRC_Actual},
                                { "@MRC_Actual", MRC_Actual},
                                { "@NRR", NRR},
                                { "@MRR", MRR},
                                { "@ROI", ROI},
                                { "@Term_Profit", Term_Profit},
                                { "@Term_Revenue", Term_Revenue},
                                { "@Recurring_Margin_Percentage", Recurring_Margin_Percentage},
                                { "@Non_Recurring_Margin_Percentage", Non_Recurring_Margin_Percentage}

                                
            
                             };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            object objectCustomerID = objDBAcess.executeProc("sp_Insert_Revenue_Lines", para);
            return objectCustomerID;
        }


        public DataTable GetAllOpportunity()
        {
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GAO = objDBAcess.SP_Datatable("sp_Get_Opportunity");
            return dt_GAO;
        }

        public DataTable GetOpportunityByID(int OppID)
        {
            dynamic[,] para = { 
                              {"OppID", @OppID} 
                              };
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GAO = objDBAcess.SP_Datatable("sp_Get_OpportunityById",para);
            return dt_GAO;
        }
    }
}