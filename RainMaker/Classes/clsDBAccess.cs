using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data.Odbc;


namespace RainMaker.Classes
{
    public enum DBEngineType
    {
        ODBC,
        OLEDB,
        SQL
    }

    public class clsDBAccess
    {
        int chkQry;
        private string conStr = string.Empty;
        private static string _sServerName;
        private static int _iPort;
        private static bool _isMADS;
        private DBEngineType _eDBType;
        private object m_sEngineType;
        private DataTable objDT;
        private DataSet objDS;
        private DbConnection objCon;
        private SqlConnection objSqlCon;
        private SqlCommand objSqlCmd;
        private DbCommand objCmd;
        private DbDataAdapter objAdp;
        private DbDataReader objRD;
        private string _connectString;

        public clsDBAccess(string sConnectionString, DBEngineType DBEngine)
        {
            DBType = DBEngine;
            objCon = GetConnection(sConnectionString, DBEngine);
            conStr = sConnectionString;
            objSqlCon = new SqlConnection(conStr);

        }

        public DbConnection Connection
        {
            get { return objCon; }
        }

        public static string ServerName
        {
            get { return _sServerName; }
            set { _sServerName = value; }
        }

        public static int Port
        {
            get { return _iPort; }
            set { _iPort = value; }
        }

        public static bool MADSON
        {
            get { return _isMADS; }
            set { _isMADS = value; }
        }

        public string ConnectString
        {
            get { return conStr; }
            set { conStr = value; }
        }

        public DBEngineType DBType
        {
            get { return _eDBType; }
            set { _eDBType = value; }
        }

        public DbConnection GetConnection(string sConnectionString, DBEngineType DBEngine)
        {
            try
            {
                switch (DBEngine)
                {
                    case DBEngineType.OLEDB:
                        //objCon = new OleDb.OleDbConnection(sConnectionString);
                        objCon = new OleDbConnection(sConnectionString);
                        break;
                    case DBEngineType.ODBC:
                        //objCon = new Odbc.OdbcConnection(sConnectionString);
                        objCon = new OdbcConnection(sConnectionString);
                        break;
                    case DBEngineType.SQL:
                        //objCon = new SqlClient.SqlConnection(sConnectionString);
                        objCon = new SqlConnection(sConnectionString);
                        break;
                }

                // objCon.Open()
            }
            catch (Exception ex)
            {
                //objLog.PersistException("DataAccess", "GetConnection()", ex)
                // Logger.logException("DataAccess", "GetConnection", "CS:" & sConnectionString & ", Message:" & ex.Message)
            }
            return objCon;
        }

        public DataTable getDataTable(string qry)
        {

            try
            {
                try
                {
                    //Logger.logActivity("DataAccess", "GetDT", "Query : " & qry)

                    objDT = new DataTable();
                    objCon.Open();

                    objCmd = getCommandObject(qry);
                    objCmd.Connection = objCon;
                    // Logger.logActivity("DataAccess", "getDataTable", "Connection : " & objCon.ConnectionString)
                    objAdp = getAdapterObject();
                    objAdp.SelectCommand = objCmd;

                    objAdp.Fill(objDT);
                    // Logger.logActivity("DataAccess", "GetDT", "Count : " & objDT.Rows.Count)
                }
                catch (Exception ex)
                {
                    // Logger.logException("DataAccess", "GetDT", "CS:" & objCon.ConnectionString & ", Message: " & ex.Message)
                }
                finally
                {
                    objCon.Close();
                }
                return objDT;
            }
            catch (Exception ex)
            {
                // Logger.logException("DataAccess", "GetDT", ex.Message)

            }
            finally
            {
            }
            return objDT;
        }

        public DataSet getDataSet(string qry)
        {
            try
            {
                objCmd = getCommandObject(qry);
                objDS = new DataSet();
                objCon.Open();
                objCmd.Connection = objCon;
                objAdp = getAdapterObject();
                objAdp.SelectCommand = objCmd;
                objAdp.Fill(objDS);
            }
            catch (Exception ex)
            {
                // Logger.logException("DataAccess", "GetDataSet", "CS:" & objCon.ConnectionString & ", Message:" & ex.Message)
            }
            finally
            {
                objCon.Close();
            }
            return objDS;
        }

        public DbDataReader getDataReader(string qry)
        {
            try
            {
                objCon.Open();
                objCmd = getCommandObject(qry);
                objCmd.Connection = objCon;
                objRD = objCmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                // Logger.logException("DataAccess", "GetDataReader", "CS:" & objCon.ConnectionString & ", Message:" & ex.Message)
            }
            finally
            {
                objCon.Close();
            }
            return objRD;
        }

        public void close()
        {
            objCon.Close();
        }

        public bool executeProc(string ProcName)
        {
            try
            {
                objCon.Open();
                objCmd = new System.Data.SqlClient.SqlCommand();
                objCmd.Connection = objCon;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = ProcName;
                chkQry = objCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                chkQry = 0;
            }
            finally
            {
                objCon.Close();
            }
            if (chkQry == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool executeProc(string ProcName, dynamic[,] Par)
        {
            try
            {
                //objCon.Open();
                objSqlCon.Open();


                objSqlCmd = new SqlCommand(ProcName, objSqlCon);

                objSqlCmd.CommandType = CommandType.StoredProcedure;
                objSqlCmd.CommandTimeout = 45;
                int int_LoopterminationValue = Par.Length / 2;

                for (Int16 i = 0; i < int_LoopterminationValue; i++)
                {
                    objSqlCmd.Parameters.AddWithValue(Par[i, 0], Par[i, 1]);
                }


                chkQry = objSqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                chkQry = 0;
            }
            finally
            {
                objSqlCon.Close();
            }
            if (chkQry == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public object InsertProc_WithOutput(string ProcName, string[,] Par, string flag)
        {


            try
            {
                objSqlCon.Open();
                objSqlCmd = new SqlCommand(ProcName, objSqlCon);
                objSqlCmd.CommandType = CommandType.StoredProcedure;
                objSqlCmd.CommandTimeout = 45;
                int int_LoopterminationValue = Par.Length / 2;
                for (Int16 i = 0; i < int_LoopterminationValue; i++)
                {
                    if (i == 0)
                    {
                        objSqlCmd.Parameters.Add(new SqlParameter(flag, SqlDbType.BigInt));
                        objSqlCmd.Parameters[flag].Direction = ParameterDirection.Output;
                        objSqlCmd.Parameters.AddWithValue(Par[i, 0], Par[i, 1]);

                    }
                    else
                    {
                        objSqlCmd.Parameters.AddWithValue(Par[i, 0], Par[i, 1]);

                    }

                }


                objSqlCmd.ExecuteNonQuery();
                dynamic InsertedID = objSqlCmd.Parameters[flag].Value.ToString();
                return InsertedID;

            }
            catch (Exception ex)
            {
                chkQry = 0;
                return chkQry;
            }
            finally
            {
                objSqlCon.Close();
            }

        }


        public object InsertProc_WithOutput(string ProcName, dynamic[,] Par, string flag)
        {


            try
            {
                objSqlCon.Open();
                objSqlCmd = new SqlCommand(ProcName, objSqlCon);
                objSqlCmd.CommandType = CommandType.StoredProcedure;
                objSqlCmd.CommandTimeout = 45;
                int int_LoopterminationValue = Par.Length / 2;
                for (Int16 i = 0; i < int_LoopterminationValue; i++)
                {
                    if (i == 0)
                    {
                        objSqlCmd.Parameters.Add(new SqlParameter(flag, SqlDbType.BigInt));
                        objSqlCmd.Parameters[flag].Direction = ParameterDirection.Output;
                        objSqlCmd.Parameters.AddWithValue(Par[i, 0], Par[i, 1]);

                    }
                    else
                    {
                        objSqlCmd.Parameters.AddWithValue(Par[i, 0], Par[i, 1]);

                    }

                }


                objSqlCmd.ExecuteNonQuery();
                dynamic InsertedID = objSqlCmd.Parameters[flag].Value.ToString();
                return InsertedID;

            }
            catch (Exception ex)
            {
                chkQry = 0;
                return chkQry;
            }
            finally
            {
                objSqlCon.Close();
            }

        }

        

        public DataTable SP_Datatable(string SP_Name, string[,] Par)
        {


            try
            {
                objSqlCon.Open();
                objSqlCmd = new SqlCommand(SP_Name, objSqlCon);

                objSqlCmd.CommandType = CommandType.StoredProcedure;
                objSqlCmd.CommandTimeout = 45;
                int int_LoopTerminationPoint = Par.Length / 2;
                for (Int16 i = 0; i < int_LoopTerminationPoint; i++)
                {
                    objSqlCmd.Parameters.AddWithValue(Par[i, 0], Par[i, 1]);
                }

                objDT = new DataTable();
                objAdp = getAdapterObject();
                objAdp.SelectCommand = objSqlCmd;
                objAdp.Fill(objDT);

                return objDT;


            }
            catch (Exception ex)
            {
                objDT = null;
                return objDT;

            }
            finally
            {
                objSqlCon.Close();
            }

        }

        
        public DataTable SP_Datatable(string SP_Name, dynamic[,] Par)
        {


            try
            {
                objSqlCon.Open();
                objSqlCmd = new SqlCommand(SP_Name, objSqlCon);

                objSqlCmd.CommandType = CommandType.StoredProcedure;
                objSqlCmd.CommandTimeout = 45;
                int int_LoopTerminationPoint = Par.Length / 2;
                for (Int16 i = 0; i < int_LoopTerminationPoint; i++)
                {
                    objSqlCmd.Parameters.AddWithValue(Par[i, 0],Par[i, 1]);
                }

                objDT = new DataTable();
                objAdp = getAdapterObject();
                objAdp.SelectCommand = objSqlCmd;
                objAdp.Fill(objDT);

                return objDT;


            }
            catch (Exception ex)
            {
                objDT = null;
                return objDT;

            }
            finally
            {
                objSqlCon.Close();
            }

        }


        public DataTable SP_DatatableWithTwoParameters(string SP_Name, string[,] Par)
        {


            try
            {
                objSqlCon.Open();
                objSqlCmd = new SqlCommand(SP_Name, objSqlCon);

                objSqlCmd.CommandType = CommandType.StoredProcedure;
                objSqlCmd.CommandTimeout = 45;
                int j = Par.Length / 2;

                for (Int16 i = 0; i < j; i++)
                {
                    objSqlCmd.Parameters.AddWithValue(Par[i, 0], Par[i, 1]);
                }

                objDT = new DataTable();
                objAdp = getAdapterObject();
                objAdp.SelectCommand = objSqlCmd;
                objAdp.Fill(objDT);

                return objDT;


            }
            catch (Exception ex)
            {
                objDT = null;
                return objDT;

            }
            finally
            {
                objSqlCon.Close();
            }

        }

        public DataTable SP_Datatable(string SP_Name)
        {

            try
            {
                objSqlCon.Open();
                objSqlCmd = new SqlCommand(SP_Name, objSqlCon);
                objSqlCmd.CommandType = CommandType.StoredProcedure;
                objSqlCmd.CommandTimeout = 45;
                objDT = new DataTable();
                objAdp = getAdapterObject();
                objAdp.SelectCommand = objSqlCmd;
                objAdp.Fill(objDT);

                return objDT;


            }
            catch (Exception ex)
            {
                objDT = null;
                return objDT;

            }
            finally
            {
                objSqlCon.Close();
            }

        }

        public bool executeQry(string qry)
        {

            try
            {
                try
                {
                    objCon.Open();
                    objCmd = getCommandObject(qry);
                    objCmd.Connection = objCon;
                    chkQry = objCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    chkQry = 0;
                }
                finally
                {
                    objCon.Close();
                }


            }
            catch (Exception ex)
            {
                //objLog.PersistException("DataAccess", "executeQry()", ex)

            }
            finally
            {
            }
            if (chkQry == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public DbCommand getCommandObject(string qry)
        {
            DbCommand objTmpCmd = null;
            switch (DBType)
            {
                case DBEngineType.OLEDB:
                    //objTmpCmd = new OleDb.OleDbCommand(qry);
                    objTmpCmd = new OleDbCommand(qry);
                    break;
                case DBEngineType.ODBC:
                    //objTmpCmd = new Odbc.OdbcCommand(qry);
                    objTmpCmd = new OdbcCommand(qry);
                    break;
                case DBEngineType.SQL:
                    //objTmpCmd = new SqlClient.SqlCommand(qry);
                    objTmpCmd = new SqlCommand(qry);
                    break;
            }

            return objTmpCmd;
        }

        public DbDataAdapter getAdapterObject()
        {
            DbDataAdapter objTmpAdp = null;
            switch (DBType)
            {
                case DBEngineType.OLEDB:
                    //objTmpAdp = new OleDb.OleDbDataAdapter();                    
                    objTmpAdp = new OleDbDataAdapter();
                    break;
                case DBEngineType.SQL:
                    //objTmpAdp = new SqlClient.SqlDataAdapter();
                    objTmpAdp = new SqlDataAdapter();
                    break;
                case DBEngineType.ODBC:
                    //objTmpAdp = new Odbc.OdbcDataAdapter();
                    //objTmpAdp = new OdbcDataAdapter();
                    objTmpAdp = new SqlDataAdapter();
                    break;
            }
            return objTmpAdp;
        }

        public void DisposeConnection()
        {
            objSqlCon.Dispose();
        }

    }
}