namespace PaladinsAPI {
	public static class Utils {
		public static string Substring (string input, string indexOf, string lastOf = "") {
			string ret = string.Empty;
			if (!string.IsNullOrEmpty (indexOf)) input.Substring (input.IndexOf (indexOf) + indexOf.Length);
			if (!string.IsNullOrEmpty (lastOf)) ret = ret.Substring (0, ret.IndexOf (lastOf));
			return ret;
		}
		public static string UtcNow () { return Utils.UtcNow ("yyyyMMddHHmmss"); }
		public static string UtcNow (string format) {
			return System.DateTime.UtcNow.ToString (format); 
		}
		
		/// <summary>
		/// Description of Security.
		/// </summary>
		public class Security {
			private Security () { }
			public static string GetMD5Hash (string input) {
	            using (var md5 = System.Security.Cryptography.MD5.Create ()) {
	                var bytes = md5.ComputeHash (System.Text.Encoding.UTF8.GetBytes (input));
	                var sb = new System.Text.StringBuilder ();
	                foreach (byte @byte in bytes)
	                	sb.Append (@byte.ToString ("x2").ToLower ());
	                
	                return sb.ToString();
	            }
	        }
		}
	}
}