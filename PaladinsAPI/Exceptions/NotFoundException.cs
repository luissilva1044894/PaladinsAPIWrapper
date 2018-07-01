namespace PaladinsAPI.Exceptions {
    public class NotFoundException : Exceptions.CustomException {
		public NotFoundException () { }
		public NotFoundException (string exception) : base (exception) { }
    }
}