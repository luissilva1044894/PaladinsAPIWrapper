namespace PaladinsAPI.Models {
    public class Item : APIResponse {
        public string Description { get; set; }
        public string DeviceName { get; set; }
        public int IconId { get; set; }
        public int ItemId { get; set; }
        public int Price { get; set; }
        public string ShortDesc { get; set; }
        public int champion_id { get; set; }
        public string itemIcon_URL { get; set; }
        public string item_type { get; set; }
        public int talent_reward_level { get; set; }
        
		public override string ToString()
		{
			return string.Format("[Item Description={0}, DeviceName={1}, IconId={2},\r\nItemId={3}, Price={4}, ShortDesc={5},\r\nChampion_id={6}, ItemIcon_URL={7}, Item_type={8}, Talent_reward_level={9}]", Description, DeviceName, IconId, ItemId, Price, ShortDesc, champion_id, itemIcon_URL, item_type, talent_reward_level);
		}

    }
}