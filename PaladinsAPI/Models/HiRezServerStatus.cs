namespace PaladinsAPI.Models {
    public class HiRezServerStatus : APIResponse {
        public string entry_dateTime { get; set; }
        public string status { get; set; }
        public string version { get; set; }
        
		public override string ToString() {
			return string.Format("[HiRezServerStatus Entry_dateTime={0}, Status={1}, Version={2}]", entry_dateTime, status, version);
		}

    }
}