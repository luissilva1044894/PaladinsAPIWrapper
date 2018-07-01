namespace PaladinsAPI.Models {
    public class Champion : APIResponse {
        public Enums.Champions id { get; set; }
        public string Ability1 { get; set; }
        public string Ability2 { get; set; }
        public string Ability3 { get; set; }
        public string Ability4 { get; set; }
        public string Ability5 { get; set; }
        public int abilityId1 { get; set; }
        public int abilityId2 { get; set; }
        public int abilityId3 { get; set; }
        public int abilityId4 { get; set; }
        public int abilityId5 { get; set; }
        public string ChampionAbility1_URL { get; set; }
        public string ChampionAbility2_URL { get; set; }
        public string ChampionAbility3_URL { get; set; }
        public string ChampionAbility4_URL { get; set; }
        public string ChampionAbility5_URL { get; set; }
        public string ChampionCard_URL { get; set; }
        public string ChampionIcon_URL { get; set; }
        public string Cons { get; set; }
        public int Health { get; set; }
        public string Lore { get; set; }
        public string Name { get; set; }
        public string OnFreeRotation { get; set; }
        public string Pantheon { get; set; }
        public string Pros { get; set; }
        public string Roles { get; set; }
        public int Speed { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string abilityDescription1 { get; set; }
        public string abilityDescription2 { get; set; }
        public string abilityDescription3 { get; set; }
        public string abilityDescription4 { get; set; }
        public string abilityDescription5 { get; set; }
        public string latestChampion { get; set; }
        
		public override string ToString()
		{
			return string.Format("[Champion Id={0}, Ability1={1}, Ability2={2}, Ability3={3}, Ability4={4}, Ability5={5}, AbilityId1={6}, AbilityId2={7}, AbilityId3={8}, AbilityId4={9}, AbilityId5={10}, ChampionAbility1_URL={11}, ChampionAbility2_URL={12}, ChampionAbility3_URL={13}, ChampionAbility4_URL={14}, ChampionAbility5_URL={15}, ChampionCard_URL={16}, ChampionIcon_URL={17}, Cons={18}, Health={19}, Lore={20}, Name={21}, OnFreeRotation={22}, Pantheon={23}, Pros={24}, Roles={25}, Speed={26}, Title={27}, Type={28}, AbilityDescription1={29}, AbilityDescription2={30}, AbilityDescription3={31}, AbilityDescription4={32}, AbilityDescription5={33}, LatestChampion={34}]", id, Ability1, Ability2, Ability3, Ability4, Ability5, abilityId1, abilityId2, abilityId3, abilityId4, abilityId5, ChampionAbility1_URL, ChampionAbility2_URL, ChampionAbility3_URL, ChampionAbility4_URL, ChampionAbility5_URL, ChampionCard_URL, ChampionIcon_URL, Cons, Health, Lore, Name, OnFreeRotation, Pantheon, Pros, Roles, Speed, Title, Type, abilityDescription1, abilityDescription2, abilityDescription3, abilityDescription4, abilityDescription5, latestChampion);
		}

    }
}