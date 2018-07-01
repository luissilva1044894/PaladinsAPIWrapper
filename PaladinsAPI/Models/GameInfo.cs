namespace PaladinsAPI.Models {
    public class GameInfo : APIResponse {
        public int Leaves { get; set; }
        public int Losses { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int PrevRank { get; set; }
        public int Rank { get; set; }
        public int Season { get; set; }
        public int Tier { get; set; }
        public int Trend { get; set; }
        public int VictoryPoints { get; set; }
        public int Wins { get; set; }
        
		public override string ToString()
		{
			return string.Format("[GameInfo Leaves={0}, Losses={1}, Name={2}, Points={3}, PrevRank={4}, Rank={5}, Season={6}, Tier={7}, Trend={8}, VictoryPoints={9}, Wins={10}]", Leaves, Losses, Name, Points, PrevRank, Rank, Season, Tier, Trend, VictoryPoints, Wins);
		}

    }
}