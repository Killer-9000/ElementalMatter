using Assets.Scripts.Database.Models;
using Assets.Scripts.Database.MySQL;
using Assets.Scripts.Database.SQLite;
using Assets.Scripts.Models;
using Mono.Data.SqliteClient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Database
{
    public class DatabaseHandler : MonoBehaviour
    {
        public static DatabaseHandler instance;

        public string MysqlAddress;
        public string MysqlUsername;
        public string MysqlPassword;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            // Start up handlers
            SQLiteHandler.Start();
            MySQLHandler.Start(MysqlAddress, MysqlUsername, MysqlPassword);

            // Check to see if there is an update
            CheckForUpdate();

            LoadAtoms();
        }

        private async Task LoadAtoms()
        {
            List<elements> eles = SQLiteHandler.GetElements();
            float x = 0;
            float z = 0;
            int k = 0;
            await Atom.GenerateAtomicModelAysnc(eles[k].Name, new Vector3(10 + x, 10, 5 + z), Quaternion.Euler(0, 0, 0), eles[k].Protons, eles[k].Neutrons, eles[k].Electrons);
        }

        private void OnApplicationQuit()
        {
            // Make sure connections are correctly stopped
            if(SQLiteHandler.connectionState == ConnectionState.Open)
                SQLiteHandler.Stop();

            if (MySQLHandler.connectionState == ConnectionState.Open)
                MySQLHandler.Stop();
        }

        public void CheckForUpdate()
        {
            // Get timestamps
            DateTime currentUpdate = SQLiteHandler.GetUpdateTimestamp();
            List<string> tables = MySQLHandler.CheckForUpdate();

            foreach(string table in tables)
            {
                string[] values = table.Split('|');
                DateTime update;
                if (DateTime.TryParse(values[1], out update))
                {
                    if (update < currentUpdate)
                        return;

                    UpdateTable(values);
                }
                else
                    UpdateTable(values);
            }
        }

        private void UpdateTable(string[] values)
        {
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM `ElementalMatter`.`{values[0]}`", MySQLHandler.conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            Type type = Type.GetType("Assets.Scripts.Database.Models." + values[0]);
            FieldInfo[] fields = type.GetFields();
            if (fields.Length > 0 && reader.HasRows)
            {
                string insertQuery = $"INSERT INTO `{values[0]}` (";
                for (int i = 0; i < fields.Length; i++)
                    insertQuery += $"`{fields[i].Name}`, ";
                insertQuery = insertQuery.Remove(insertQuery.Length - 2);
                insertQuery += ") VALUES\n";

                while (reader.Read())
                {
                    var generatedClass = Activator.CreateInstance(type);
                    type.GetMethod("Populate").Invoke(generatedClass, new object[] { reader });

                    insertQuery += $"(";
                    for (int i = 0; i < reader.FieldCount; i++)
                        insertQuery += $"'{reader[i]}', ";
                    insertQuery = insertQuery.Remove(insertQuery.Length - 2);
                    insertQuery += "),\n";
                }
                insertQuery = insertQuery.Remove(insertQuery.Length - 2);
                insertQuery += ";";

                SqliteCommand sqliteCmd = new SqliteCommand(insertQuery, SQLiteHandler.conn);
                int rowsAffected = sqliteCmd.ExecuteNonQuery();
                sqliteCmd.Dispose();
            }

            reader.Close();
            cmd.Dispose();
        }
    }
}
