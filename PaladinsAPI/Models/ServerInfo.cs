using System;

namespace PaladinsAPI.Models {
	/// <summary>
	/// Description of ServerInfo.
	/// </summary>
	public class ServerInfo : APIResponse {
		public ServerInfo () : this (string.Empty) { }
		public ServerInfo (string version) {
			this.version = version;
		}
		public string version { get; set; }
	}
}