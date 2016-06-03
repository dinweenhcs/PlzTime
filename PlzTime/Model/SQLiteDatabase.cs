using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using SQLite;

namespace PlzTime
{
	public class SQLiteDatabase
	{
		#region "### Properties #############################################"
		private string _databaseName;
		private string _applicationSupportFolder;

		private string _dbPath;
		private string _dbFile;
		public SQLiteConnection _connection;
		#endregion
		#region "### Constructors #############################################"
		public SQLiteDatabase(string databaseName, string applicationSupportFolder)
		{
			this._databaseName = databaseName;
			this._applicationSupportFolder = applicationSupportFolder;

			if (!verifySQLiteDatabase())
			{
				Console.WriteLine("SQLiteDatabase::SQLiteDatabase(): SQLiteDatabase doesn't exist or is corrupt -> initSQLiteDatabase()");
				this.initSQLiteDatabase();
			}
			Console.WriteLine("SQLiteDatabase::SQLiteDatabase(): SQLiteDatabase ready to use! ");
		}
		#endregion
		#region "### Deconstructors #############################################"
		#endregion

		#region "### UI Methods #############################################"
		#endregion
		#region "### Private Methods #############################################"
		private void initSQLiteDatabase()
		{
			try
			{
				// IOS: ~/Documents > Only for user-created files, is sync with iTunes if supported.
				string presonalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				// IOS: Applicationfiles are be deposed in ~/Library/<subfolder>/<files>
				// 		This is required by Apple!
				_dbPath = System.IO.Path.Combine(presonalFolder, "..", "Library/Application Support/", this._applicationSupportFolder);

				if (!System.IO.Directory.Exists(_dbPath))
				{
					System.IO.Directory.CreateDirectory(_dbPath);
				}

				// Create SQLiteDatabase-File...
				_dbFile = System.IO.Path.Combine(_dbPath, this._databaseName);
				Console.WriteLine("SQLiteDatabase::initSQLiteDatabase()._dbFile= " + _dbFile);
			}
			catch (Exception ex)
			{
				Console.WriteLine("ERROR SQLiteDatabase::initSQLiteDatabase(): " + ex.ToString());
			}
		}
		#endregion
		#region "### Public Methods #############################################"
		public bool verifySQLiteDatabase()
		{
			if (File.Exists(_dbFile))
			{
				return true;
			}
			else {
				return false;
			}
		}
		public void connect()
		{
			try
			{
				_connection = new SQLiteConnection(_dbFile);
				Console.WriteLine("SQLiteDatabase::connect()");
			}
			catch (Exception ex)
			{
				Console.WriteLine("ERROR SQLiteDatabase::connect(): " + ex.ToString());
			}
		}
		public void disconnect()
		{
			try
			{
				_connection.Close();
				Console.WriteLine("SQLiteDatabase::disconnect()");
			}
			catch (Exception ex)
			{
				Console.WriteLine("ERROR SQLiteDatabase::disconnect(): " + ex.ToString());
			}
		}
		public void deleteSQLiteDatabase()
		{
			try
			{
				this.disconnect();
				if (File.Exists(_dbFile))
				{
					File.Delete(_dbFile);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("ERROR SQLiteDatabase::deleteSQLiteDatabase(): " + ex.ToString());
			}
		}
		#endregion
	}
}
