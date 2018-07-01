namespace PaladinsAPI.Exceptions {
    public class DailyLimitException : Exceptions.CustomException {
		public DailyLimitException () { }
		public DailyLimitException (string exception) : base (exception) { }
	}
}