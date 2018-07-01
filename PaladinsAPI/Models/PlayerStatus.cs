namespace PaladinsAPI.Models {
    public class PlayerStatus : APIResponse {
        public int Match { get; set; }
        public string personal_status_message { get; set; }
        public Enums.PlayerStatus status { get; set; } // public int status { get; set; }
        public string status_string { get; set; }
        public int playerId { get; set; }
        
		public override string ToString()
		{
			return string.Format("[PlayerStatus Match={0}, Personal_status_message={1}, Status={2}, Status_string={3}, PlayerId={4}]", Match, personal_status_message, status, status_string, playerId);
		}

    }
}