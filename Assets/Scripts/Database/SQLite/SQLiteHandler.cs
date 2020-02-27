using Assets.Scripts.Database.Models;
using Mono.Data.SqliteClient;
using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace Assets.Scripts.Database.SQLite
{
    public static class SQLiteHandler
    {
        private static SqliteConnection conn;

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
            catch (Exception ex) { Debug.LogError(ex); }
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

        public static IEnumerable<Elements> GetElements()
        {
            if (connectionState == ConnectionState.Open)
            {
                List<Elements> elements = new List<Elements>();
                SqliteCommand cmd = new SqliteCommand(SQLiteQueries.RDRUpdate, conn);
                SqliteDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Elements element = new Elements();
                    element.Populate(reader);

                    elements.Add(element);
                }

                return elements;
            }

            throw new Exception("SQLite: Connection needs to be open to pull data from db.");
        }
    }

    public static class SQLiteQueries
    {
        public static readonly string RDRUpdate = "SELECT LastUpdate FROM Meta;";
    }
}
