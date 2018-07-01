namespace PaladinsAPI.Models {
    public class ChampionRank : APIResponse {
        public int Id { get; set; }
        public int Assists { get; set; }
        public int Deaths { get; set; }
        public int Kills { get; set; }
        public int Losses { get; set; }
        public int MinionKills { get; set; }
        public int Rank { get; set; }
        public int Wins { get; set; }
        public int Worshippers { get; set; }
        public string champion { get; set; }
        public string champion_id { get; set; }
        public string player_id { get; set; }
		public override string ToString()
		{
			return string.Format("[ChampionRank Id={0}, Assists={1}, Deaths={2}, Kills={3}, Losses={4}, MinionKills={5}, Rank={6}, Wins={7}, Worshippers={8}, Champion={9}, Champion_id={10}, Player_id={11}]", Id, Assists, Deaths, Kills, Losses, MinionKills, Rank, Wins, Worshippers, champion, champion_id, player_id);
		}

    }
}