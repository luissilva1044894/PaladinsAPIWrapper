namespace PaladinsAPI.Models {
    public class QueueChampionStat : APIResponse {
        public int Assists { get; set; }
        public string Champion { get; set; }
        public int ChampionId { get; set; }
        public int Deaths { get; set; }
        public int Gold { get; set; }
        public int Kills { get; set; }
        public string LastPlayed { get; set; }
        public int Losses { get; set; }
        public int Matches { get; set; }
        public int Minutes { get; set; }
        public string Queue { get; set; }
        public int Wins { get; set; }
        public string player_id { get; set; }
        
		public override string ToString()
		{
			return string.Format("[QueueChampionStat Assists={0}, Champion={1}, ChampionId={2}, Deaths={3}, Gold={4}, Kills={5}, LastPlayed={6}, Losses={7}, Matches={8}, Minutes={9}, Queue={10}, Wins={11}, Player_id={12}]", Assists, Champion, ChampionId, Deaths, Gold, Kills, LastPlayed, Losses, Matches, Minutes, Queue, Wins, player_id);
		}

    }
}