namespace PaladinsAPI.Exceptions {
	/// <summary>
	/// Description of KeyOrAuthEmptyException.
	/// </summary>
	public class KeyOrAuthEmptyException : Exceptions.CustomException {
		public KeyOrAuthEmptyException () : base ("Dev Key or Auth Key is Empty!"){ }
		public KeyOrAuthEmptyException (string exception) :
				base (string.Format ("DevKey or AuthKey is Empty: {0}", exception)) { }
	}
}