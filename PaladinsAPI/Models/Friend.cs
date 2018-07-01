namespace PaladinsAPI.Models {
    public class Friend : APIResponse {
        public string account_id { get; set; }
        public string name { get; set; }
        public string player_id { get; set; }
        
		public override string ToString()
		{
			return string.Format("[Friend Account_id={0}, Name={1}, Player_id={2}]", account_id, name, player_id);
		}

    }
}