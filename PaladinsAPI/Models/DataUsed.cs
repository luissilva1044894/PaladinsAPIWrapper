namespace PaladinsAPI.Models {
    public class DataUsed : APIResponse {
        public int Active_Sessions { get; set; }
        public int Concurrent_Sessions { get; set; }
        public int Request_Limit_Daily { get; set; }
        public int Session_Cap { get; set; }
        public int Session_Time_Limit { get; set; }
        public int Total_Requests_Today { get; set; }
        public int Total_Sessions_Today { get; set; }
        
		public override string ToString()
		{
			return string.Format("[DataUsed Active_Sessions={0}, Concurrent_Sessions={1}, Request_Limit_Daily={2}, Session_Cap={3}, Session_Time_Limit={4}, Total_Requests_Today={5}, Total_Sessions_Today={6}]", Active_Sessions, Concurrent_Sessions, Request_Limit_Daily, Session_Cap, Session_Time_Limit, Total_Requests_Today, Total_Sessions_Today);
		}

    }
}