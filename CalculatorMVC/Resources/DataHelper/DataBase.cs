using System;
using SQLite;
using CalculatorMVC.Resources.Models;
using System.Collections.Generic;

namespace CalculatorMVC.Resources.DataHelper
{
    class DataBase
    {
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public bool CreateDataBase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "")))
                {
                    connection.CreateTable<History>();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool InsertIntoTableHistory(History history)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "")))
                {
                    connection.Insert(history);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateTableHistory(History history)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "")))
                {
                    connection.Query<History>($"Update History SET Equation={history.Equation} Result={history.Result} WHERE ID={history.ID}");
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteTableHistory(History history)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "")))
                {
                    connection.Delete(history);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public List<History> History()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "")))
                {
                    return connection.Table<History>().ToList();
                }
            }
            catch
            {
                return null;
            }
        }
    }
}