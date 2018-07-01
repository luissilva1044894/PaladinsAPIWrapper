namespace PaladinsAPI.Enums {
	public enum ResponseFormat : int {
        [System.ComponentModel.DescriptionAttribute ("json")]
		JSON = 1,
        [System.ComponentModel.DescriptionAttribute ("xml")]
		XML = 2,
		[System.ComponentModel.DescriptionAttribute ("plain text")]
		PLAIN_TEXT = 3
    }
}