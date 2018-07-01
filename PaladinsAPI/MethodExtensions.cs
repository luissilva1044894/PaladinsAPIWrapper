namespace PaladinsAPI {
	/// <summary>
	/// Description of MethodExtensions.
	/// </summary>
	public static class MethodExtensions {
		public static string GetDescription (this System.Enum value) {
			System.ComponentModel.DescriptionAttribute [] attributes = (System.ComponentModel.DescriptionAttribute [])value.GetType ().GetField (value.ToString ()).GetCustomAttributes (typeof (System.ComponentModel.DescriptionAttribute), false);
			return attributes != null && attributes.Length > 0 ? attributes [0].Description : value.ToString ();
		}
	}
}