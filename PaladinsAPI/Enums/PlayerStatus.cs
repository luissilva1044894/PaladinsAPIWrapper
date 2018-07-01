namespace PaladinsAPI.Enums {
	public enum PlayerStatus : int {
        [System.ComponentModel.DescriptionAttribute ("Player is not online")]
		Offline = 0,
        [System.ComponentModel.DescriptionAttribute ("Basically anywhere except god selection or in game")]
		InLobby = 1,
        [System.ComponentModel.DescriptionAttribute ("Player has accepted match and is selecting god before start of game")]
		ChampionSelection = 2,
        [System.ComponentModel.DescriptionAttribute ("Match has started")]
		InGame = 3,
        [System.ComponentModel.DescriptionAttribute ("Player is logged in, but may be blocking broadcast of player state")]
		Online = 4,
        [System.ComponentModel.DescriptionAttribute ("Player not found")]
        Unknown = 5
    }
}