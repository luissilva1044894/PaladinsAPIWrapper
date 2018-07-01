namespace PaladinsAPI.Models {
    public class MatchId : APIResponse {
        public string Active_Flag { get; set; }
        public int Match { get; set; }
        
		public override string ToString()
		{
			return string.Format("[MatchId Active_Flag={0}, Match={1}]", Active_Flag, Match);
		}

    }
}