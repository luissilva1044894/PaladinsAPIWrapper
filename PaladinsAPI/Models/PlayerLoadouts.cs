namespace PaladinsAPI.Models {
    public class PlayerLoadouts : APIResponse {
        public int ChampionId { get; set; }
        public string ChampionName { get; set; }
        public int DeckId { get; set; }
        public string DeckName { get; set; }
        public System.Collections.Generic.List <LoadoutItem> LoadoutItems { get; set; }
        public int playerId { get; set; }
        public string playerName { get; set; }
        
		public override string ToString()
		{
			return string.Format("[PlayerLoadouts ChampionId={0}, ChampionName={1}, DeckId={2}, DeckName={3}, LoadoutItems={4}, PlayerId={5}, PlayerName={6}]", ChampionId, ChampionName, DeckId, DeckName, LoadoutItems, playerId, playerName);
		}

    }
}