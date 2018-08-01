﻿using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using System.Data;
//using System.Data.SqlClient;

using System.Data.OracleClient;

namespace OraDB
{
    public class ADO : IDisposable
    {
        OracleTransaction SqlTrans;

        // Development Database
        OracleConnection conn = new OracleConnection("SERVER=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=ServerDB)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));uid=ulp;pwd=ulp;unicode=true;");

        // old Test
        //OracleConnection conn = new OracleConnection("SERVER=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.77)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=BLGDB)));uid=web;pwd=web;unicode=true;");

        // Quality Database
        //OracleConnection conn = new OracleConnection("SERVER=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=172.20.9.171)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=IUTEST)));uid=ulp;pwd=ulp;unicode=true;");

        //// Life Database
        //OracleConnection conn = new OracleConnection("SERVER=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=172.20.8.110)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=IULIVE)));uid=ulp;pwd=ulp;unicode=true;");

        // Local Database
        //OracleConnection conn = new OracleConnection("SERVER=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.8.105)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));uid=ULP;pwd=ULP;unicode=true;");

        // TVIS Database
        //OracleConnection conn = new OracleConnection("SERVER=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.100.13)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=IUDB)));uid=ulp;pwd=ulp;unicode=true;");

        public OracleCommand cmd = new OracleCommand();

        //public OracleParameter parm = new OracleParameter();

        public ADO()
        {
            cmd.Connection = conn;

            if (conn.State != ConnectionState.Open)
            { conn.Open(); }
        }

        public ADO(bool Trans)
        {
            cmd.Connection = conn;
            //cmd.BindByName = true;

            if (conn.State != ConnectionState.Open)
            { conn.Open(); }

            SqlTrans = conn.BeginTransaction();
            cmd.Transaction = SqlTrans;
        }


        //public OracleCommand cmd = new OracleCommand();

        //public ADO()
        //{
        //    cmd.Connection = conn;

        //    try
        //    {
        //        if (conn.State != ConnectionState.Open)
        //        { conn.Open(); }
        //    }
        //    catch (Exception)
        //    {
        //        conn.ConnectionString = "SERVER=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=LocalHost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));uid=web;pwd=web;";
        //        if (conn.State != ConnectionState.Open)
        //        { conn.Open(); }
        //    }
        //}

        public bool SqlCommand(OracleCommand cmd)
        {
            //PopulateNullParameters();

            int Result = cmd.ExecuteNonQuery();

            if (Result > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //public bool SqlCommand()
        //{
        //    //PopulateNullParameters();
        //    //OracleCommand cmd

        //    int Result = cmd.ExecuteNonQuery();

        //    if (Result > -1)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        //public bool SqlCommandT(OracleCommand cmd)
        //{
        //    int Result = cmd.ExecuteNonQuery();

        //    if (Result > -1)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public bool SqlCommiteT(bool Commite)
        {
            try
            {
                if (Commite)
                {
                    SqlTrans.Commit();
                    return true;
                }
                else
                {
                    SqlTrans.Rollback();
                    return false;
                }
            }
            catch (Exception)
            {
                SqlTrans.Rollback();
                return false;
            }
        }



        //public long SqlCommandGetID(OracleCommand cmd, string cmdGetID)
        //{
        //    //cmd.Connection = conn;

        //    SqlTrans = conn.BeginTransaction();

        //    try
        //    {
        //        cmd.Transaction = SqlTrans;
        //        //cmd.Parameters.AddRange(pramts);

        //        int cmdResult = cmd.ExecuteNonQuery();

        //        if (cmdResult > -1)
        //        {
        //            cmd.CommandText = cmdGetID;
        //            object Result = cmd.ExecuteScalar();

        //            if (Convert.ToString(Result) != "")
        //            {
        //                SqlTrans.Commit();
        //                return Convert.ToInt32(Result);
        //            }
        //            else
        //            {
        //                SqlTrans.Rollback();
        //                return -1;
        //            }
        //        }
        //        else
        //        {
        //            SqlTrans.Rollback();
        //            return -1;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        try { SqlTrans.Rollback(); }
        //        catch (Exception) { }

        //        return -1;
        //    }
        //}

        public DataTable SqlSelect(OracleCommand cmd)
        {
            DataTable dt = new DataTable();

            dt.Load(cmd.ExecuteReader());

            return dt;
        }

        public DataRow SqlSelectOneRow(OracleCommand cmd)
        {
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;
            }
        }

        public object SqlSelectOneValue(OracleCommand cmd)
        {
            return cmd.ExecuteScalar();
        }

        private void PopulateNullParameters()
        {
            foreach (OracleParameter p in cmd.Parameters)
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
            }
        }

        public object Nullable(object value)
        {
            return value ?? DBNull.Value;
        }


        //SqlTransaction SqlTrans;
        //SqlConnection conn = new SqlConnection("Data Source=SQL5016.Smarterasp.net;Initial Catalog=DB_9BC4B1_BaljDataBase;Persist Security Info=True;User ID=DB_9BC4B1_BaljDataBase_admin;Password=mohm05428");
        //public SqlCommand cmd = new SqlCommand();

        //public ADO()
        //{
        //    cmd.Connection = conn;
        //    if (conn.State != ConnectionState.Open)
        //    { conn.Open(); }
        //}

        ////public ADO(bool WithTransaction)
        ////{
        ////    cmd.Connection = conn;
        ////    //cmd.Transaction = SqlTrans;
        ////    if (conn.State != ConnectionState.Open)
        ////    {
        ////        conn.Open();
        ////    }
        ////}

        //public bool SqlCommand(SqlCommand cmd)
        //{
        //    int Result = cmd.ExecuteNonQuery();

        //    if (Result > -1)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public long SqlCommandGetID(SqlCommand cmd, string cmdGetID)
        //{
        //    //cmd.Connection = conn;

        //    SqlTrans = conn.BeginTransaction("NetTransaction");

        //    try
        //    {
        //        cmd.Transaction = SqlTrans;
        //        //cmd.Parameters.AddRange(pramts);

        //        int cmdResult = cmd.ExecuteNonQuery();

        //        if (cmdResult > -1)
        //        {
        //            cmd.CommandText = cmdGetID;
        //            object Result = cmd.ExecuteScalar();

        //            if (Convert.ToString(Result) != "")
        //            {
        //                SqlTrans.Commit();
        //                return Convert.ToInt32(Result);
        //            }
        //            else
        //            {
        //                SqlTrans.Rollback();
        //                return -1;
        //            }
        //        }
        //        else
        //        {
        //            SqlTrans.Rollback();
        //            return -1;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        try { SqlTrans.Rollback(); }
        //        catch (Exception) { }

        //        return -1;
        //    }
        //}

        //public DataTable SqlSelect(SqlCommand cmd)
        //{
        //    DataTable dt = new DataTable();
        //    dt.Load(cmd.ExecuteReader());

        //    return dt;
        //}

        //public DataRow SqlSelectOneRow(SqlCommand cmd)
        //{
        //    DataTable dt = new DataTable();
        //    dt.Load(cmd.ExecuteReader());

        //    if (dt.Rows.Count > 0)
        //    {
        //        return dt.Rows[0];
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public object SqlSelectOneValue(SqlCommand cmd)
        //{
        //    return cmd.ExecuteScalar();
        //}

        ////private static void ExecuteSqlTransaction(string connectionString)
        ////{
        ////    using (SqlConnection connection = new SqlConnection(connectionString))
        ////    {
        ////        connection.Open();

        ////        SqlCommand command = connection.CreateCommand();
        ////        SqlTransaction transaction;

        ////        // Start a local transaction.
        ////        transaction = connection.BeginTransaction("SampleTransaction");

        ////        // Must assign both transaction object and connection 
        ////        // to Command object for a pending local transaction
        ////        command.Connection = connection;
        ////        command.Transaction = transaction;

        ////        try
        ////        {
        ////            command.CommandText =
        ////                "Insert into Region (RegionID, RegionDescription) VALUES (100, 'Description')";
        ////            command.ExecuteNonQuery();
        ////            command.CommandText =
        ////                "Insert into Region (RegionID, RegionDescription) VALUES (101, 'Description')";
        ////            command.ExecuteNonQuery();

        ////            // Attempt to commit the transaction.
        ////            transaction.Commit();
        ////            //Console.WriteLine("Both records are written to database.");
        ////        }
        ////        catch (Exception ex)
        ////        {
        ////            //Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
        ////            //Console.WriteLine("  Message: {0}", ex.Message);

        ////            // Attempt to roll back the transaction. 
        ////            try
        ////            {
        ////                transaction.Rollback();
        ////            }
        ////            catch (Exception ex2)
        ////            {
        ////                // This catch block will handle any errors that may have occurred 
        ////                // on the server that would cause the rollback to fail, such as 
        ////                // a closed connection.
        ////                //Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
        ////                //Console.WriteLine("  Message: {0}", ex2.Message);
        ////            }
        ////        }
        ////    }
        ////}

        public void Dispose()
        {
            try
            {
                conn.Dispose();
                cmd.Dispose();
                if (SqlTrans != null) { SqlTrans.Dispose(); }
            }
            catch (Exception)
            { }
        }
    }
}