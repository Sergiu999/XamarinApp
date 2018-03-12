using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using XamarinApp.Droid.Persistance;
using XamarinApp.Persistance;

[assembly: Dependency(typeof(SQLiteDb))]

namespace XamarinApp.Droid.Persistance
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}