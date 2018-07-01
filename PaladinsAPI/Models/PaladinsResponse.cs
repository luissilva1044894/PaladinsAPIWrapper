namespace PaladinsAPI.Models {
	/// <summary>
	/// Description of APIResponse.
	/// </summary>
	public class APIResponse {
		public APIResponse () : this (string.Empty) { }
		public APIResponse (string ret_msg) {
			this.ret_msg = ret_msg;
		}
		public string ret_msg { get; set; }
		// public string json { get; set; }
	}
}