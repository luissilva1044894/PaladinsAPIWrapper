namespace PaladinsAPI.Models {
    public class Ping {
		public Ping (string ping) {
			try {
            	this.patch = ping.Substring (ping.IndexOf ("PATCH - ") + "PATCH - ".Length);
            	this.patch = this.patch.Substring (0, this.patch.IndexOf ("]"));
	            this.successfull = ping.ToLower ().Contains ("ping successful");
	            this.version = ping.Substring (ping.IndexOf ("(ver ") + "(ver ".Length);
	            this.version = this.version.Substring (0, this.version.IndexOf (")"));
	            this.timestamp = ping.Substring (ping.IndexOf ("Server Date:") + "Server Date:".Length).Replace (@"\/", "/");
            } catch { }
		}
        public string timestamp { get; set; }
        public bool successfull { get; set; }
        public string patch { get; set; }
        public string version { get; set; }
		public override string ToString() {
			return string.Format("[Ping Timestamp={0}, Successfull={1}, Patch={2}, Version={3}]", timestamp, successfull, patch, version);
		}

    }
}