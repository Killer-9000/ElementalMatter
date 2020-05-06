using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace Assets.Scripts.Database.MySQL
{
    public static class MySQLHandler
    {
        public static MySqlConnection conn { get; private set; }

        public static ConnectionState connectionState
        {
            get 
            {
                if (conn != null)
                    return conn.State;
                else
                    return ConnectionState.Closed;
            } 
        }

        public static void Start(string ipAddress, string username, string password, int port = 3306)
        {
            try
            {
                conn = new MySqlConnection($"Server={ipAddress};Port={port};User={username};Password={password};Connect Timeout=10");
                conn.Open();

                Debug.Log($"MySQL started with state: {connectionState}");
            }
            catch (Exception ex) { { Debug.LogError(ex); } }
        }

        public static void Stop()
        {
            conn.Close();
            conn.Dispose();
        }

        public static List<string> CheckForUpdate()
        {
            if(connectionState == ConnectionState.Open)
            {
                // Settings up result list and query
                List<string> result = new List<string>();
                MySqlCommand cmd = new MySqlCommand(MySQLQueries.RDRUpdate, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                // Comparing update times
                while(reader.Read())
                    result.Add(reader[0].ToString() + "|" + reader[1].ToString());

                // Clean up
                reader.Close();
                cmd.Dispose();

                return result;
            }

            throw new Exception("MySQL: Connection needs to be open to pull data from db.");
        }
    }

    public static class MySQLQueries
    {
        public static readonly string RDRUpdate = "USE `information_schema`;\n" +
            "SELECT TABLE_NAME, UPDATE_TIME FROM TABLES WHERE TABLE_SCHEMA = 'elementalmatter';";
    }
}
