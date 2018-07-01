namespace PaladinsAPI.Enums {
	public enum Platform : int {
		[System.ComponentModel.DescriptionAttribute ("http://api.paladins.com/paladinsapi.svc")]
		PC = 1,
		[System.ComponentModel.DescriptionAttribute ("http://api.xbox.paladins.com/paladinsapi.svc")]
		XBOX = 2,
		[System.ComponentModel.DescriptionAttribute ("http://api.ps4.paladins.com/paladinsapi.svc")]
		PS4 = 3
	}
}