using System;
using SQLite;

namespace PlauschzeitfahrenTMS
{
	[Table("Participant")]
	public class Participant
	{
		[PrimaryKey, AutoIncrement, Column("ID")]
		private int ID { get; set; }
		[Column("creatmin_ts")]
		private DateTime creation { get; set; }
		[Column("modification_ts")]
		private DateTime modification { get; set; }
		[Indexed, NotNull]
		public int plz_ID { get; set; }
		public string gender { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		//[Ignore] // = is not stored in Database
		public string name { get; }
		public string birthday { get; set; }
		public string street { get; set; }
		public string number { get; set; }
		public string zip { get; set; }
		public string city { get; set; }
		public string region { get; set; }
		public string country { get; set; }
		public string telephone { get; set; }
		public string mobile { get; set; }
		public string mail { get; set; }

		public Participant(){
			this.creation = DateTime.UtcNow;
			this.modification = DateTime.UtcNow;
		}

		public Participant(bool p_test){
			if (p_test)
			{
				this.creation = DateTime.UtcNow;
				this.modification = DateTime.UtcNow;
				this.plz_ID = 98001;
				this.gender = "male";
				this.firstName = "Loïc";
				this.lastName = "Mérat";
				this.name = this.firstName + " " + this.lastName;
				this.birthday = "03-09-1918";
				this.street = "Mont de Drôts";
				this.number = "9s";
				this.zip = "1450";
				this.city = "Ste-Croix";
				this.region = "VD";
				this.country = "Schweiz";
				this.telephone = "+41999999999";
				this.mobile = "+41799999999";
				this.mail = "toto@mac.com";
			}
		}
	}
}

