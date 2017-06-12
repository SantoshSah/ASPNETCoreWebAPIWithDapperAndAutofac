using System;
namespace Entities
{
	public class Users
	{
		public int id { get; set; }
		public string email { get; set; }
		public int? step_tracker_providers_id { get; set; }
		public string provider_key { get; set; }
		public string full_name { get; set; }
		public Boolean active { get; set; }
		public Boolean hasPaid { get; set; }
		public string access_token { get; set; }
		public DateTime? issued_token_date { get; set; }
		public DateTime? expire_token_date { get; set; }
	}
}
