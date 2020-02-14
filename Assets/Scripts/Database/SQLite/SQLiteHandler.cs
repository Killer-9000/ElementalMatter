using Assets.Scripts.Database.Models;
using Assets.Scripts.Exceptions;
using Mono.Data.SqliteClient;
using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace Assets.Scripts.Database.SQLite
{
    public static class SQLiteHandler
    {
        public static SqliteConnection conn;

        public static ConnectionState connectionState 
        {
            get 
            {
                try { return conn.State; }
                catch (Exception) { return ConnectionState.Closed; }
            }
        }
        
        public static void Start()
        {
            try
            {
                conn = new SqliteConnection($"URI=file:{Application.streamingAssetsPath}/Database.db");
                conn.Open();

                Debug.Log($"SQLite started with state: {conn.State}");
            }
            catch (Exception ex) { ExceptionWriting.WriteException(ex); }
        }

        public static void Stop()
        {
            conn.Close();
            conn.Dispose();
        }

        public static DateTime GetUpdateTimestamp()
        {
            if(connectionState == ConnectionState.Open)
            {
                SqliteCommand cmd = new SqliteCommand(SQLiteQueries.RDRUpdate, conn);
                SqliteDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                    return DateTime.Parse(reader[0].ToString());

                return DateTime.MinValue;
            }

            throw new Exception("SQLite: Connection needs to be open to pull data from db.");
        }

        public static List<elements> GetElements()
        {
            if (connectionState == ConnectionState.Open)
            {
                List<elements> result = new List<elements>();

                SqliteCommand cmd = new SqliteCommand(SQLiteQueries.GetElements, conn);
                SqliteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    elements row = new elements();
                    row.Populate(reader);

                    result.Add(row);
                }

                return result;
            }

            throw new Exception("SQLite: Connection needs to be open to pull data from db.");
        }
    }

    public static class SQLiteQueries
    {
        public static readonly string RDRUpdate = "SELECT LastUpdate FROM Meta;";
        public static readonly string GetElements = "SELECT * FROM Elements;";
    }
}
