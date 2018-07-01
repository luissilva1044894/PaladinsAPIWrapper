namespace PaladinsAPI.Exceptions {
    public class WrongCredentialsException : Exceptions.CustomException {
		public WrongCredentialsException () { }
		public WrongCredentialsException (string exception) : base (exception) { }
    }
}