namespace PaladinsAPI {
	/// <summary>
	/// Description of WebRequest.
	/// </summary>
	public class WebRequest {
		public WebRequest () { }
		#region RequestURL
		/// <summary>
		/// 
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		protected string RequestURL (string url) {
			if (!string.IsNullOrEmpty (url)) {
				var request = System.Net.WebRequest.Create (url);
	        	string str = string.Empty;
	            using (var response = request.GetResponse ()) {
	            	using (var dataStream = response.GetResponseStream ()) {
		            	using (var reader = new System.IO.StreamReader (dataStream)) {
	            			str = reader.ReadToEnd ();
		            	}
		            }
	            }
	        	return str;
			} return url;
        }
		#endregion
		
		#region Deserialize
		/// <summary>
		/// 
		/// </summary>
		/// <param name="input"></param>
		/// <param name="format"></param>
		/// <returns></returns>
		protected T Deserialize <T> (string input, Enums.ResponseFormat format = Enums.ResponseFormat.JSON) {
        	T ret = default (T);
        	if (format.Equals (Enums.ResponseFormat.JSON)) {
        		var jss = new System.Web.Script.Serialization.JavaScriptSerializer ();

        		ret = jss.Deserialize <T> (input);
        	} else {
        		var xmlSerializer = new System.Xml.Serialization.XmlSerializer (typeof (T));
        		using (var reader = new System.IO.StringReader (input)) {
        			ret = (T) xmlSerializer.Deserialize (reader);
        		}
        	}
        	return ret;
        }
		#endregion
	}
}