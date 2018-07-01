namespace PaladinsAPI.Models {
    public class Session : APIResponse {
		public Session () : this (string.Empty, string.Empty, string.Empty) { }
		public Session (string session_id, string timestamp, string ret_msg) : base (ret_msg) {
			this.session_id = session_id;
			this.timestamp = timestamp;
		}
        public string session_id { get; set; }
        public string timestamp { get; set; }
        
		public override string ToString () {
			return string.Format ("[Session_id={0}, Timestamp={1}, RetMsg={2}]", session_id, timestamp, this.ret_msg);
		}
    }
}