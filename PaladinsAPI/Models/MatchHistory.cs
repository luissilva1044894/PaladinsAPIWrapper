namespace PaladinsAPI.Models {
    public class MatchHistory : APIResponse {
        public int ActiveId1 { get; set; }
        public int ActiveId2 { get; set; }
        public int ActiveId3 { get; set; }
        public int ActiveId4 { get; set; }
        public string Active_1 { get; set; }
        public string Active_2 { get; set; }
        public string Active_3 { get; set; }
        public string Active_4 { get; set; }
        public int Assists { get; set; }
        public int Creeps { get; set; }
        public int Damage { get; set; }
        public int Damage_Taken { get; set; }
        public int Deaths { get; set; }
        public string God { get; set; }
        public int GodId { get; set; }
        public int Gold { get; set; }
        public int Healing { get; set; }
        public int ItemId1 { get; set; }
        public int ItemId2 { get; set; }
        public int ItemId3 { get; set; }
        public int ItemId4 { get; set; }
        public int ItemId5 { get; set; }
        public int ItemId6 { get; set; }
        public string Item_1 { get; set; }
        public string Item_2 { get; set; }
        public string Item_3 { get; set; }
        public string Item_4 { get; set; }
        public string Item_5 { get; set; }
        public string Item_6 { get; set; }
        public int Killing_Spree { get; set; }
        public int Kills { get; set; }
        public int Level { get; set; }
        public int Match { get; set; }
        public string Match_Time { get; set; }
        public int Minutes { get; set; }
        public int Multi_kill_Max { get; set; }
        public string Queue { get; set; }
        public string Skin { get; set; }
        public int SkinId { get; set; }
        public string Surrendered { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        public string Win_Status { get; set; }
        public string playerName { get; set; }
        
		public override string ToString()
		{
			return string.Format("[MatchHistory ActiveId1={0}, ActiveId2={1}, ActiveId3={2}, ActiveId4={3}, Active_1={4}, Active_2={5}, Active_3={6}, Active_4={7}, Assists={8}, Creeps={9}, Damage={10}, Damage_Taken={11}, Deaths={12}, God={13}, GodId={14}, Gold={15}, Healing={16}, ItemId1={17}, ItemId2={18}, ItemId3={19}, ItemId4={20}, ItemId5={21}, ItemId6={22}, Item_1={23}, Item_2={24}, Item_3={25}, Item_4={26}, Item_5={27}, Item_6={28}, Killing_Spree={29}, Kills={30}, Level={31}, Match={32}, Match_Time={33}, Minutes={34}, Multi_kill_Max={35}, Queue={36}, Skin={37}, SkinId={38}, Surrendered={39}, Team1Score={40}, Team2Score={41}, Win_Status={42}, PlayerName={43}]", ActiveId1, ActiveId2, ActiveId3, ActiveId4, Active_1, Active_2, Active_3, Active_4, Assists, Creeps, Damage, Damage_Taken, Deaths, God, GodId, Gold, Healing, ItemId1, ItemId2, ItemId3, ItemId4, ItemId5, ItemId6, Item_1, Item_2, Item_3, Item_4, Item_5, Item_6, Killing_Spree, Kills, Level, Match, Match_Time, Minutes, Multi_kill_Max, Queue, Skin, SkinId, Surrendered, Team1Score, Team2Score, Win_Status, playerName);
		}

    }
}