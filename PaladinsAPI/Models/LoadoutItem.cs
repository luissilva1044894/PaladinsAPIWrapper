namespace PaladinsAPI.Models {
    public class LoadoutItem {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Points { get; set; }
        
		public override string ToString()
		{
			return string.Format("[LoadoutItem ItemId={0}, ItemName={1}, Points={2}]", ItemId, ItemName, Points);
		}

    }
}