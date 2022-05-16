using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SQLite;

namespace PicturePlotDB
{
    class SQLiteDB
    {
        public string myDBFileName;
        public string status = String.Empty;

        private SQLiteConnection myDBConnection = new SQLiteConnection();
        private SQLiteCommand mySQLCommand = new SQLiteCommand();
        //private ConnectionState myConnectionState = new ConnectionState();

        public bool ConnectDB()
        {
            status = String.Empty;
            bool successfulConnection = true;

            //if (myDBConnection.State == ConnectionState.Open) 
            //{
            //    status = "Date base already connected";
            //    successfulConnection = false;
            //    return successfulConnection;
            //}

            if (!File.Exists(myDBFileName))
            {
                status = "File " + myDBFileName + " is not exist";
                successfulConnection = false;
                return successfulConnection;
            }
            try
            {
                myDBConnection = new SQLiteConnection("Data Source=" + myDBFileName + ";Version=3;");
                myDBConnection.Open();
                mySQLCommand.Connection = myDBConnection;
                status = "DB is connected";
                return successfulConnection;
            }
            catch (SQLiteException ex)
            {
                status = status + "\r" + "Error: " + ex.Message;
                successfulConnection = false;
                return successfulConnection;
            }
        }

        public void DisconnectDB()
        {
            status = String.Empty;

            if (!File.Exists(myDBFileName))
            {
                status = "File " + myDBFileName + " is not exist";
                return;
            }

            try
            {
                myDBConnection = new SQLiteConnection("Data Source=" + myDBFileName + ";Version=3;");
                if (myDBConnection.State == ConnectionState.Open)
                {
                    myDBConnection.Close();
                    mySQLCommand.Connection = myDBConnection;

                    status = status + "DB is disconnected";
                }
                else
                    status = status + "DB is already disconnected";
            }
            catch (SQLiteException ex)
            {
                status = status + "\r" + "Error: " + ex.Message;
            }
        }

        public void ExecuteSQLnoQuery(string sqlQuery)
        {
            status = String.Empty;

            //ConnectDB();

            //if (myDBConnection.State != ConnectionState.Open)
            //{
            //    status = "Need to open connection with database";
            //    return;
            //}

            try
            {
                mySQLCommand.CommandText = sqlQuery;
                //SQLiteTransaction myTransaction = myDBConnection.BeginTransaction();
                mySQLCommand.ExecuteNonQuery();
                //myTransaction.Commit();
                status = status + "\r" + "SQLQuery done";
            }
            catch (SQLiteException ex)
            {
                status = "Error: " + ex.Message;
            }
            //DisconnectDB();
        }

        public void ReadTableFromDB(string sqlQuery, DataTable dTable) 
        {
            status = String.Empty;

            if (myDBConnection.State != ConnectionState.Open)
            {
                status = "Need to open connection with database";
                return;
            }

            try
            {
                //sqlQuery = "SELECT * FROM Catalog";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, myDBConnection);
                adapter.Fill(dTable);
            }
            catch (SQLiteException ex)
            {
                status = status + "/r" + "Error: " + ex.Message;
            }           
        }

        public void ReadFromDB(string sqlQuery, ref SQLiteDataReader myReader) 
            //ref SQLiteTransaction myTransaction
        {
            status = String.Empty;

            if (myDBConnection.State != ConnectionState.Open)
            {
                status = "Need to open connection with database";
                return;
            }

            try
            {
                //sqlQuery = "SELECT * FROM Catalog";
                mySQLCommand.CommandText = sqlQuery;
                //myTransaction = myDBConnection.BeginTransaction();
                myReader = mySQLCommand.ExecuteReader();
            }
            catch (SQLiteException ex)
            {
                status = status + "/r" + "Error: " + ex.Message;
            }           
        }

    }
}
