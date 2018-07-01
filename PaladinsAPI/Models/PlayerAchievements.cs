namespace PaladinsAPI.Models {
    public class PlayerAchievements : APIResponse {
        public int AssistedKills { get; set; }
        public int CampsCleared { get; set; }
        public int DivineSpree { get; set; }
        public int DoubleKills { get; set; }
        public int FireGiantKills { get; set; }
        public int FirstBloods { get; set; }
        public int GodLikeSpree { get; set; }
        public int GoldFuryKills { get; set; }
        public int Id { get; set; }
        public int ImmortalSpree { get; set; }
        public int KillingSpree { get; set; }
        public int MinionKills { get; set; }
        public string Name { get; set; }
        public int PentaKills { get; set; }
        public int PhoenixKills { get; set; }
        public int PlayerKills { get; set; }
        public int QuadraKills { get; set; }
        public int RampageSpree { get; set; }
        public int ShutdownSpree { get; set; }
        public int SiegeJuggernautKills { get; set; }
        public int TowerKills { get; set; }
        public int TripleKills { get; set; }
        public int UnstoppableSpree { get; set; }
        public int WildJuggernautKills { get; set; }
        
		public override string ToString()
		{
			return string.Format("[PlayerAchievements AssistedKills={0}, CampsCleared={1}, DivineSpree={2}, DoubleKills={3}, FireGiantKills={4}, FirstBloods={5}, GodLikeSpree={6}, GoldFuryKills={7}, Id={8}, ImmortalSpree={9}, KillingSpree={10}, MinionKills={11}, Name={12}, PentaKills={13}, PhoenixKills={14}, PlayerKills={15}, QuadraKills={16}, RampageSpree={17}, ShutdownSpree={18}, SiegeJuggernautKills={19}, TowerKills={20}, TripleKills={21}, UnstoppableSpree={22}, WildJuggernautKills={23}]", AssistedKills, CampsCleared, DivineSpree, DoubleKills, FireGiantKills, FirstBloods, GodLikeSpree, GoldFuryKills, Id, ImmortalSpree, KillingSpree, MinionKills, Name, PentaKills, PhoenixKills, PlayerKills, QuadraKills, RampageSpree, ShutdownSpree, SiegeJuggernautKills, TowerKills, TripleKills, UnstoppableSpree, WildJuggernautKills);
		}

    }
}