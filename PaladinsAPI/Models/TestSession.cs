namespace PaladinsAPI.Models {
    public class TestSession : APIResponse {
		public TestSession () : this (string.Empty) { }
		public TestSession (string session) : base (string.IsNullOrEmpty (session) ? session : session.ToString ().Substring (0, session.ToString ().IndexOf (":"))) {
			if (string.IsNullOrEmpty (session) && session.ToString ().Contains ("successful test")) {
				System.Text.StringBuilder testSession = new System.Text.StringBuilder (session);
	        	this.developer = testSession.ToString ().Substring (testSession.ToString ().IndexOf ("developer: ") + "developer: ".Length);
	        	this.developer = this.developer.Substring (0, this.developer.IndexOf (" "));
	        	
	        	string time = testSession.ToString ().Substring (testSession.ToString ().IndexOf ("time: ") + "time: ".Length);
	        	time = time.Substring (0, time.IndexOf (" signature:"));
	        	
	        	string sessionID = testSession.ToString ().Substring (testSession.ToString ().IndexOf ("session: ") + "session: ".Length);
	        	
	        	this.session = new Models.Session (sessionID, time, "Approved");
	        	
	        	this.signature = testSession.ToString ().Substring (testSession.ToString ().IndexOf ("signature: ") + "signature: ".Length);
	        	this.signature = this.signature.Substring (0, this.signature.IndexOf (" "));
			} else {
				this.session = new Models.Session (string.Empty, string.Empty, string.Empty);
				this.developer = string.Empty;
				this.signature = string.Empty;
			}
		}
		public string developer { get; set; }
        public string signature { get; set; }
        public Models.Session session { get; set; }
        
		public override string ToString () {
        	//This was a successful test with the following parameters added: developer: 1132 time: 5/29/2018 3:37:04 PM signature: ff4b680d5a35fe995eab5b73c12d2f65 session: 6DD997D34B4240339C260D5A8F2A8A00
        	return string.Format ("{0}: developer: {1} time: {2} signature: {3} session: {4}",
        	              this.ret_msg, this.developer, this.session.timestamp, this.signature, this.session.session_id);
		}

    }
}