using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SQLite;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CalculatorMVC.Resources.Models;

namespace CalculatorMVC.Assets
{
    class Database
    {
        private string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbHistory.db3");
        private SQLiteConnection db;
        public Database()
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<History>();
        }

        public bool IsCreate
        {
            get
            {
                if(db == null)
                {
                    db = new SQLiteConnection(dbPath);
                }
                return true;
            }
        }

        public void Insert(History history)
        {
            if(IsCreate)
            db.Insert(history);
        }
        public List<History> Select()
        {
            if(IsCreate)
            return db.Table<History>().ToList();
            return null;
        }

    }
}