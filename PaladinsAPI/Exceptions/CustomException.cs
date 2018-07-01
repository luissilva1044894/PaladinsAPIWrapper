namespace PaladinsAPI.Exceptions {
	/// <summary>
	/// Description of CustomException.
	/// </summary>
	public class CustomException : System.Exception {
		public CustomException () : base () { }

	    public CustomException (string message) : base (message) { }
	
	    public CustomException (string format, params object [] args) : base (string.Format (format, args)) { }
	
	    public CustomException (string message, System.Exception innerException) : base (message, innerException) { }
	
	    public CustomException (string format, System.Exception innerException, params object [] args) : base (string.Format (format, args), innerException) { }
	}
}