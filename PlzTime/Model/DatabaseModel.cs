#region "Internal Libraries"
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
#endregion
#region "Importet Libraries"
using SQLite;
#endregion

#region "Own Classes"
#endregion

namespace PlauschzeitfahrenTMS
{
	public class DatabaseModel
	{
		#region "### Properties #############################################"
		private static string _dbFilename = "PlzTms.sqlite";

		private string _dbPath;
		private string _dbFile;
		public SQLiteConnection _connection;
		#endregion
		#region "### Constructors #############################################"
		public DatabaseModel ()
		{	
			if (!verifyDatabase()) {
				Console.WriteLine ("DatabaseModel::DatabaseModel(): Database doesn't exist or is corrupt -> initDatabase()");
				this.initDatabase ();
			}
			Console.WriteLine("DatabaseModel::DatabaseModel(): Database ready to use! " );
		}
		#endregion
		#region "### Deconstructors #############################################"
		#endregion
		#region "### UI Methods #############################################"
		#endregion
		#region "### Private Methods #############################################"
		private void initDatabase(){
			try {
				// IOS: ~/Documents > Only for user-created files, is sync with iTunes if supported.
				string presonalFolder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
				// IOS: Applicationfiles are be deposed in ~/Library/<subfolder>/<files>
				// 		This is required by Apple!
				_dbPath = System.IO.Path.Combine(presonalFolder, ".." , "Library/Application Support/" , "Plauschzeitfahren TMS");

				if (!System.IO.Directory.Exists (_dbPath)){
						System.IO.Directory.CreateDirectory (_dbPath);
				}
				
				// Create Database-File...
				_dbFile = System.IO.Path.Combine(_dbPath, _dbFilename);
				Console.WriteLine("DatabaseModel::initDatabase()._dbFile= "+_dbFile);

				// Dreate Database-Structure...
				this.connect();
				var result = _connection.CreateTable<Person>();
				Console.WriteLine("DatabaseModel::initDatabase().CreateTable<Participants>()= "+result);
				this.disconnect();
			} catch (Exception ex) {
				Console.WriteLine("ERROR DatabaseModel::initDatabase(): "+ex.ToString());
			}
		}
		#endregion
		#region "### Public Methods #############################################"
		public bool verifyDatabase(){
			if(File.Exists(_dbFile)) {
				return true;
			} else {
				return false;
			}
		}
		public void connect(){
			try {
				_connection = new SQLiteConnection (_dbFile);
				Console.WriteLine("DatabaseModel::connect()");
			} catch (Exception ex) {
				Console.WriteLine("ERROR DatabaseModel::connect(): "+ex.ToString());
			}
		}
		public void disconnect(){
			try {
				_connection.Close();
				Console.WriteLine("DatabaseModel::disconnect()");
			} catch (Exception ex) {
				Console.WriteLine("ERROR DatabaseModel::disconnect(): "+ex.ToString());
			}
		}
		public void deleteDatabase(){
			try {
				this.disconnect ();
				if (File.Exists (_dbFile)) {
					File.Delete (_dbFile);
				}
			} catch (Exception ex) {
				Console.WriteLine ("ERROR DatabaseModel::deleteDatabase(): " + ex.ToString ());
			}
		}
		public List<Person> getParticipantsOfRace () {
				try {
					this.connect ();
					return this._connection.Table<Person>().ToList(); // Dangerous if list is big!
				} catch (Exception ex) {
					Console.WriteLine("ERROR DatabaseModel::getParticipantsOfRace(): "+ex.ToString());
					return null;
				}					
		}
				
		#endregion
	}
}
