namespace PaladinsAPI.Models {
    public class TopMatch : APIResponse {
        public string Ban1 { get; set; }
        public int Ban1Id { get; set; }
        public string Ban2 { get; set; }
        public int Ban2Id { get; set; }
        public string Entry_Datetime { get; set; }
        public int LiveSpectators { get; set; }
        public int Match { get; set; }
        public int Match_Time { get; set; }
        public int OfflineSpectators { get; set; }
        public string Queue { get; set; }
        public string RecordingFinished { get; set; }
        public string RecordingStarted { get; set; }
        public int Team1_AvgLevel { get; set; }
        public int Team1_Gold { get; set; }
        public int Team1_Kills { get; set; }
        public int Team1_Score { get; set; }
        public int Team2_AvgLevel { get; set; }
        public int Team2_Gold { get; set; }
        public int Team2_Kills { get; set; }
        public int Team2_Score { get; set; }
        public int WinningTeam { get; set; }
        
		public override string ToString()
		{
			return string.Format("[TopMatch Ban1={0}, Ban1Id={1}, Ban2={2}, Ban2Id={3}, Entry_Datetime={4}, LiveSpectators={5}, Match={6}, Match_Time={7}, OfflineSpectators={8}, Queue={9}, RecordingFinished={10}, RecordingStarted={11}, Team1_AvgLevel={12}, Team1_Gold={13}, Team1_Kills={14}, Team1_Score={15}, Team2_AvgLevel={16}, Team2_Gold={17}, Team2_Kills={18}, Team2_Score={19}, WinningTeam={20}]", Ban1, Ban1Id, Ban2, Ban2Id, Entry_Datetime, LiveSpectators, Match, Match_Time, OfflineSpectators, Queue, RecordingFinished, RecordingStarted, Team1_AvgLevel, Team1_Gold, Team1_Kills, Team1_Score, Team2_AvgLevel, Team2_Gold, Team2_Kills, Team2_Score, WinningTeam);
		}

    }
}