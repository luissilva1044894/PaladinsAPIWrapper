namespace PaladinsAPI.Models {
    public class MatchPlayer : APIResponse {
        public int Account_Level { get; set; }
        public int GodId { get; set; }
        public string GodName { get; set; }
        public int Mastery_Level { get; set; }
        public int Match { get; set; }
        public string Queue { get; set; }
        public int SkinId { get; set; }
        public int Tier { get; set; }
        public string playerCreated { get; set; }
        public string playerId { get; set; }
        public string playerName { get; set; }
        public int taskForce { get; set; }
        public int tierLosses { get; set; }
        public int tierWins { get; set; }
        
		public override string ToString()
		{
			return string.Format("[MatchPlayer Account_Level={0}, GodId={1}, GodName={2}, Mastery_Level={3}, Match={4}, Queue={5}, SkinId={6}, Tier={7}, PlayerCreated={8}, PlayerId={9}, PlayerName={10}, TaskForce={11}, TierLosses={12}, TierWins={13}]", Account_Level, GodId, GodName, Mastery_Level, Match, Queue, SkinId, Tier, playerCreated, playerId, playerName, taskForce, tierLosses, tierWins);
		}

    }
}