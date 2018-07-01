namespace PaladinsAPI.Exceptions {
    public class SessionLimitException : Exceptions.CustomException {
		public SessionLimitException () { }
		public SessionLimitException (string exception) : base (exception) { }
	}
}