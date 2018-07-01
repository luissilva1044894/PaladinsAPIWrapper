namespace PaladinsAPI.Models {
    public class RankedConquest : APIResponse {
		public int Leaves { get; set; }
		public int Losses { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public string PrevRank { get; set; }
        public int Rank { get; set; }
        public string Rank_Stat_Conquest { get; set; }
        public string Rank_Stat_Duel { get; set; }
        public string Rank_Stat_Joust { get; set; }
        public int Season { get; set; }
        public int Tier { get; set; }
        public int Trend { get; set; }
        public int Wins { get; set; }
        public int player_id { get; set; }
        
		public override string ToString()
		{
			return string.Format("[RankedConquest Leaves={0}, Losses={1}, Name={2}, Points={3}, PrevRank={4}, Rank={5}, Rank_Stat_Conquest={6}, Rank_Stat_Duel={7}, Rank_Stat_Joust={8}, Season={9}, Tier={10}, Trend={11}, Wins={12}, Player_id={13}]", Leaves, Losses, Name, Points, PrevRank, Rank, Rank_Stat_Conquest, Rank_Stat_Duel, Rank_Stat_Joust, Season, Tier, Trend, Wins, player_id);
		}

    }
}