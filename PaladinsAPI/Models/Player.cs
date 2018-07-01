namespace PaladinsAPI.Models {
    public class Player {
        public string Created_Datetime { get; set; }
        public string Id { get; set; }
        public string Last_Login_Datetime { get; set; }
        public string Leaves { get; set; }
        public string Level { get; set; }
        public string Losses { get; set; }
        public string MasteryLevel { get; set; }
        public string Name { get; set; }
        public string Personal_Status_Message { get; set; }
        public string Region { get; set; }
        public string TeamId { get; set; }
        public string Team_Name { get; set; }
        public Enums.Tier Tier_Conquest { get; set; }
        public string Total_Achievements { get; set; }
        public string Total_Worshippers { get; set; }
        public string Wins { get; set; }
        public string ret_msg { get; set; }
		public override string ToString () {
			return string.Format ("[Player Created_Datetime={0}, Id={1}, Last_Login_Datetime={2}, Leaves={3}, Level={4}, Losses={5}, MasteryLevel={6}, Name={7}, Personal_Status_Message={8}, Region={9}, TeamId={10}, Team_Name={11}, Tier_Conquest={12}, Total_Achievements={13}, Total_Worshippers={14}, Wins={15}, Ret_msg={16}]", Created_Datetime, Id, Last_Login_Datetime, Leaves, Level, Losses, MasteryLevel, Name, Personal_Status_Message, Region, TeamId, Team_Name, Tier_Conquest.GetDescription (), Total_Achievements, Total_Worshippers, Wins, ret_msg);
		}
    }
}