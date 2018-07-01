namespace PaladinsAPI.Models {
    public class ChampionSkin : APIResponse {
        public int champion_id { get; set; }
        public string champion_name { get; set; }
        public string rarity { get; set; }
        public int skin_id1 { get; set; }
        public int skin_id2 { get; set; }
        public string skin_name { get; set; }
        public string skin_name_english { get; set; }
        
		public override string ToString()
		{
			return string.Format("[ChampionSkin Champion_id={0}, Champion_name={1}, Rarity={2}, Skin_id1={3}, Skin_id2={4}, Skin_name={5}, Skin_name_english={6}]", champion_id, champion_name, rarity, skin_id1, skin_id2, skin_name, skin_name_english);
		}

    }
}