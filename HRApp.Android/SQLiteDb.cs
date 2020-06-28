using System;
using System.IO;
using HRApp.Droid;
using SQLite;

using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]

namespace HRApp.Droid
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

