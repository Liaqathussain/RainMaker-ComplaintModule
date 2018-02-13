using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace RainMaker.Classes
{
    public class clsMap
    {
        private static DBEngineType _eDBType;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        clsDBAccess objDBAcess;
        public clsMap()
        {
            SqlConnection con = new SqlConnection(constr);
            clsDBAccess objDBAcess = new clsDBAccess(constr, _eDBType);
            
        }

        public DataTable GetFiveNearestPlaceOFCurrentLocation(double CurLat, double CurLng, int InfraType)
        {
            string[,] para = {
                           {"@cur_lat",CurLat.ToString()}
                          ,{"@cur_lng",CurLng.ToString()}
                          ,{"@InfraType",InfraType.ToString()}                          
                             };
            objDBAcess  = new clsDBAccess(constr, _eDBType);
            DataTable dt_GFNPOCL =  objDBAcess.SP_Datatable("sp_GetNearestPlacemark", para);
            return dt_GFNPOCL;
           
        }

        public DataTable GetTopNearestPlaceOFCurrentLocation(double CurLat, double CurLng)
        {
            string[,] para = {
                           {"@cur_lat",CurLat.ToString()}
                          ,{"@cur_lng",CurLng.ToString()}
                          };
            objDBAcess = new clsDBAccess(constr, _eDBType);
            DataTable dt_GFNPOCL = objDBAcess.SP_Datatable("sp_GetTopNearestPlacemark", para);
            return dt_GFNPOCL;

        }
    }
}