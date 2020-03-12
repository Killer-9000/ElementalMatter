using Assets.Scripts.Database.Models;
using Assets.Scripts.Database.MySQL;
using Assets.Scripts.Database.SQLite;
using Assets.Scripts.Models;
using Mono.Data.SqliteClient;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Assets.Scripts.Database
{
    public class DatabaseHandler : MonoBehaviour
    {
        public static DatabaseHandler instance;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            // Start up handlers
            SQLiteHandler.Start();
            MySQLHandler.Start("remotemysql.com", "FfN0VA06HT", "6VPphc2QZ7");

            // Check to see if there is an update
            StartCoroutine(CheckForUpdate());

            //LoadAtoms();
        }

        private void OnApplicationQuit()
        {
            // Make sure connections are correctly stopped
            if(SQLiteHandler.connectionState == ConnectionState.Open)
                SQLiteHandler.Stop();

            if (MySQLHandler.connectionState == ConnectionState.Open)
                MySQLHandler.Stop();
        }


        private void LoadAtoms()
        {
            List<Elements> eles = this.GetAllElements().ToList();
            float x = 0;
            float z = 0;
            int k;
            for (k = 10; k < 20; k++)
            {
                Atom.GenerateAtomicModelAysnc(eles[k].Name, new Vector3(10 + x, 10, 5 + z), Quaternion.Euler(0, 0, 0), eles[k].Protons, eles[k].Neutrons, eles[k].Electrons);
                x += 10;
            }
        }

        private IEnumerator CheckForUpdate()
        {
            yield return new AsyncOperation();

            if (MySQLHandler.connectionState == ConnectionState.Open)
            {
                // Get timestamps
                DateTime currentUpdate = SQLiteHandler.GetUpdateTimestamp();
                List<string> tables = MySQLHandler.CheckForUpdate();

                foreach (string table in tables)
                {
                    string[] values = table.Split('|');
                    if (DateTime.TryParse(values[1], out DateTime time))
                    {
                        if (time > currentUpdate)
                        {
                            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM `FfN0VA06HT`.`{values[0]}`", MySQLHandler.conn);
                            MySqlDataReader reader = cmd.ExecuteReader();

                            Type type = Type.GetType("Assets.Scripts.Database.Models." + values[0]);
                            object typeClass = Activator.CreateInstance(type);
                            FieldInfo[] properties = type.GetFields();
                            string insertQuery = $"INSERT INTO `{values[0]}` (";
                            for (int i = 0; i < properties.Length; i++)
                                insertQuery += $"`{properties[i].Name}`, ";
                            insertQuery = insertQuery.Remove(insertQuery.Length - 2);
                            insertQuery += ") VALUES ";

                            while (reader.Read())
                            {
                                type.GetMethod("Populate").Invoke(typeClass, new object[] { reader });
                                insertQuery += $"(";
                                for (int i = 0; i < reader.FieldCount; i++)
                                    insertQuery += $"'{reader[i]}', ";
                                insertQuery = insertQuery.Remove(insertQuery.Length - 2);
                                insertQuery += "),";
                            }
                            insertQuery = insertQuery.Remove(insertQuery.Length - 1);
                            insertQuery += ";";

                            SQLiteHandler.UpdateTable(insertQuery);
                        }
                    }
                }
            }
        }

        public IEnumerable<Elements> GetAllElements() => SQLiteHandler.GetElements();
    }
}
