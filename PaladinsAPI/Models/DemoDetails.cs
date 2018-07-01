namespace PaladinsAPI.Models {
    public class DemoDetails : APIResponse {
        public int BanID1 { get; set; }
        public int BanID2 { get; set; }
        public int BanID3 { get; set; }
        public int BanID4 { get; set; }
        public string entry_dateTime { get; set; }
        public string match { get; set; }
        public int matchTime { get; set; }
        public int offlineSpectators { get; set; }
        public int queueType { get; set; }
        public int realtimeSpectators { get; set; }
        public string recordingEnded { get; set; }
        public string recordingStarted { get; set; }
        public int team1_AvgLevel { get; set; }
        public int team1_gold { get; set; }
        public int team1_kills { get; set; }
        public int team1_Score { get; set; }
        public int team2_AvgLevel { get; set; }
        public int team2_gold { get; set; }
        public int team2_kills { get; set; }
        public int team2_Score { get; set; }
        public int WinningTeam { get; set; }
        
		public override string ToString()
		{
			return string.Format("[DemoDetails BanID1={0}, BanID2={1}, BanID3={2}, BanID4={3}, Entry_dateTime={4}, Match={5}, MatchTime={6}, OfflineSpectators={7}, QueueType={8}, RealtimeSpectators={9}, RecordingEnded={10}, RecordingStarted={11}, Team1_AvgLevel={12}, Team1_gold={13}, Team1_kills={14}, Team1_Score={15}, Team2_AvgLevel={16}, Team2_gold={17}, Team2_kills={18}, Team2_Score={19}, WinningTeam={20}]", BanID1, BanID2, BanID3, BanID4, entry_dateTime, match, matchTime, offlineSpectators, queueType, realtimeSpectators, recordingEnded, recordingStarted, team1_AvgLevel, team1_gold, team1_kills, team1_Score, team2_AvgLevel, team2_gold, team2_kills, team2_Score, WinningTeam);
		}

    }
}