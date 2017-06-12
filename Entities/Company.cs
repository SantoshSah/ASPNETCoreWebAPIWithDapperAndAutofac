namespace Entities
{
	public class Company
	{
		public int id { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public string email { get; set; }
		public int person_no { get; set; }
		public string address { get; set; }
		public string zipcode { get; set; }
		public int? city_id { get; set; }
		public int? state_id { get; set; }
		public string phone_no { get; set; }
		public bool is_active { get; set; }
	}
}
