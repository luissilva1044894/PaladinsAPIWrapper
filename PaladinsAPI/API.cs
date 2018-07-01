

namespace PaladinsAPI {
	/// <summary>
	/// Description of API.
	/// </summary>
	public class BaseAPI : WebRequest {
		#region Variables
		public Models.Session currentSession;
		protected System.DateTime lastSession;
		private Enums.eLanguageCode language;
		
		protected readonly string devKey = string.Empty, authKey = string.Empty, endpointBaseURL = string.Empty;
		protected readonly Enums.ResponseFormat responseFormat;
		#endregion
		
		#region Constructors
		protected BaseAPI () { }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="devKey">Your API developer ID from your application request</param>
		/// <param name="authKey"></param>
		public BaseAPI (int devKey, string authKey) : this (devKey.ToString (), authKey) { }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="devKey">Your API developer ID from your application request</param>
		/// <param name="authKey"></param>
		public BaseAPI (string devKey, string authKey) : this (devKey, authKey, 1) { }
		public BaseAPI (int devKey, string authKey, int platform = 1, int responseFormat = 1) : this (devKey.ToString (), authKey, platform, responseFormat) { }
		/// <summary>
        /// 
        /// </summary>
        /// <param name="devKey">Your API developer ID from your application request</param>
        /// <param name="authKey"></param>
        /// <param name="platform"></param>
        /// <param name="responseFormat"></param>
		public BaseAPI (string devKey, string authKey, int platform = 1, int responseFormat = 1) : this (devKey, authKey,
                                                    (platform.Equals (3) ? Enums.Platform.PS4 : platform.Equals (2) ? Enums.Platform.XBOX: Enums.Platform.PC),
                                                    responseFormat.Equals (2) ? Enums.ResponseFormat.XML : Enums.ResponseFormat.JSON, Enums.eLanguageCode.English) { }
		public BaseAPI (int devKey, string authKey, Enums.Platform platform = Enums.Platform.PC, Enums.ResponseFormat responseFormat = Enums.ResponseFormat.JSON,
                    Enums.eLanguageCode language = Enums.eLanguageCode.English) : this (devKey.ToString (), authKey, platform, responseFormat, language) { }
        /// <summary>
		/// 
		/// </summary>
		/// <param name="devKey">Your API developer ID from your application request</param>
		/// <param name="authKey"></param>
		/// <param name="platform"></param>
		/// <param name="responseFormat"></param>
		/// <param name="language"></param>
        public BaseAPI (string devKey, string authKey, Enums.Platform platform = Enums.Platform.PC,
		            								Enums.ResponseFormat responseFormat = Enums.ResponseFormat.JSON, Enums.eLanguageCode language = Enums.eLanguageCode.English) {
			if (string.IsNullOrEmpty (devKey) || string.IsNullOrEmpty (authKey)) {
				throw new Exceptions.KeyOrAuthEmptyException ();
			} else {
				this.devKey = devKey;
	        	this.authKey = authKey;
	        	this.endpointBaseURL = platform.GetDescription ();
	        	this.responseFormat = responseFormat;
	        	this.Language = language;
	        	this.CreateSession ();
			}
		}

		#endregion
		
		#region Signature
		protected string CreateSignature (string apiMethod) {
			return Utils.Security.GetMD5Hash (this.devKey + apiMethod + this.authKey + Utils.UtcNow ());
        }
        #endregion
		
        #region SessionExpired
        protected bool IsSessionExpired {
        	get {
        		return (this.currentSession == null ||
        		        string.IsNullOrEmpty (this.currentSession.session_id) ||
        		        System.DateTime.UtcNow.Subtract (this.lastSession).TotalMinutes >= 15);
        	}
        }
		#endregion
        
		#region CreateSession
		protected virtual void CreateSession () {
			if (string.IsNullOrEmpty (this.currentSession.session_id))
            	throw new System.Exception ("Session could not be created!");
		}
		#endregion
		
		#region Request
		protected T Request <T> (string apiMethod, params dynamic [] parameters) {
			var url = this.BuildUrlRequest (apiMethod, parameters);
            
			var rs = this.RequestURL (url);
			
            var result = this.Deserialize <T> (rs);
            
            return result;
        }
		#endregion
		
		#region UrlBuilder
		protected string BuildUrlRequest (string apiMethod, params dynamic [] parameters) {
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder ();
			
			stringBuilder.Append (this.endpointBaseURL);
			stringBuilder.Append ("/").Append (apiMethod).Append (this.responseFormat.GetDescription ());
			if (!apiMethod.ToLower ().Equals ("ping")) {
				stringBuilder.Append ("/").Append (this.devKey);
				stringBuilder.Append ("/").Append (this.CreateSignature (apiMethod));
				if (!apiMethod.ToLower ().Equals ("createsession") && !string.IsNullOrEmpty (this.currentSession.session_id)) {
					stringBuilder.Append ("/").Append (this.currentSession.session_id);
				}
				stringBuilder.Append ("/").Append (Utils.UtcNow ());
				foreach (var param in parameters) {
					if ((param is System.DateTime)) {
						stringBuilder.Append ("/").Append (param.ToString ("yyyyMMdd"));
					} else if ((param is Enums.QueueType || param is Enums.eLanguageCode)) {
						stringBuilder.Append ("/").Append (((int) param).ToString ());
					} else {
						stringBuilder.Append ("/").Append (param.ToString ());
					}
	            }
			}
			
			return stringBuilder.ToString ();
        }
		#endregion
		
		public Enums.eLanguageCode Language {
			get {
				return this.language;
			} private set {
				this.language = value;
			}
		}
	}
}