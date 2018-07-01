using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Collections;

using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace PaladinsAPI {
	/// <summary>
	/// 
	/// </summary>
	public class PaladinsAPI : BaseAPI {
		#region Constructors
		protected PaladinsAPI () { }
		/// <summary>
		/// PaladinsAPI is a Class Library built in C# which can provide you the main endpoints from the paladins api.
		/// Get your devId and authkey from https://fs12.formsite.com/HiRez/form48/secure_index.html
		/// </summary>
		/// <param name="devKey">Your Paladins API developer ID from your application request</param>
		/// <param name="authKey"></param>
		public PaladinsAPI (int devKey, string authKey) : this (devKey.ToString (), authKey) { }
        /// <summary>
		/// PaladinsAPI is a Class Library built in C# which can provide you the main endpoints from the paladins api.
		/// Get your devId and authkey from https://fs12.formsite.com/HiRez/form48/secure_index.html
		/// </summary>
		/// <param name="devKey">Your Paladins API developer ID from your application request</param>
		/// <param name="authKey"></param>
        public PaladinsAPI (string devKey, string authKey) : this (devKey, authKey, 1) { }
        /// <summary>
        /// PaladinsAPI is a Class Library built in C# which can provide you the main endpoints from the paladins api.
		/// Get your devId and authkey from https://fs12.formsite.com/HiRez/form48/secure_index.html
        /// </summary>
        /// <param name="devKey">Your Paladins API developer ID from your application request</param>
        /// <param name="authKey"></param>
        /// <param name="platform"></param>
        /// <param name="responseFormat"></param>
        public PaladinsAPI (int devKey, string authKey, int platform = 1, int responseFormat = 1) : this (devKey.ToString (), authKey, platform, responseFormat) { }
        /// <summary>
        /// PaladinsAPI is a Class Library built in C# which can provide you the main endpoints from the paladins api.
		/// Get your devId and authkey from https://fs12.formsite.com/HiRez/form48/secure_index.html
        /// </summary>
        /// <param name="devKey">Your Paladins API developer ID from your application request</param>
        /// <param name="authKey"></param>
        /// <param name="platform"></param>
        /// <param name="responseFormat"></param>
        public PaladinsAPI (string devKey, string authKey, int platform = 1, int responseFormat = 1) : this (devKey, authKey,
                                                           (platform.Equals (3) ? Enums.Platform.PS4 : platform.Equals (2) ? Enums.Platform.XBOX: Enums.Platform.PC),
                                                           responseFormat.Equals (2) ? Enums.ResponseFormat.XML : Enums.ResponseFormat.JSON, Enums.eLanguageCode.English) { }
        public PaladinsAPI (int devKey, string authKey, Enums.Platform platform = Enums.Platform.PC,
                            								Enums.ResponseFormat responseFormat = Enums.ResponseFormat.JSON,
                            								Enums.eLanguageCode language = Enums.eLanguageCode.English) : this (devKey.ToString (), authKey, platform, responseFormat, language) { }
        /// <summary>
        /// PaladinsAPI is a Class Library built in C# which can provide you the main endpoints from the paladins api.
		/// Get your devId and authkey from https://fs12.formsite.com/HiRez/form48/secure_index.html
        /// </summary>
        /// <param name="devKey">Your Paladins API developer ID from your application request</param>
        /// <param name="authKey"></param>
        /// <param name="platform"></param>
        /// <param name="responseFormat"></param>
        /// <param name="language"></param>
        public PaladinsAPI (string devKey, string authKey, Enums.Platform platform = Enums.Platform.PC,
                            								Enums.ResponseFormat responseFormat = Enums.ResponseFormat.JSON,
                            								Enums.eLanguageCode language = Enums.eLanguageCode.English) : base (devKey, authKey, platform, responseFormat, language) { }
        #endregion
        [System.Obsolete ("This is deprecated", true)]
        public void Obsoleto () { }
        
        #region CheckRequest
        protected T CheckRequest <T> (string apiMethod, params dynamic [] parameters) {
        	if (!apiMethod.ToLower ().Equals ("createsession") && this.IsSessionExpired) this.CreateSession ();
        	
        	var result = this.Request <T> (apiMethod, parameters);
            
            /* Variables to hold the exception if any */
            var foundProblem = false;
            var errorMessage = string.Empty;

            /* Player Achievements and Patch Info is the only one that does not contain list,
             * so there is no generictypedefinition and we will get an exception */
            if (result is Models.PlayerAchievements || result is Models.PatchInfo) {
                var basic = result as Models.APIResponse;
                if (basic.ret_msg != null) {
                    foundProblem = !foundProblem;
                    errorMessage = basic.ret_msg;
                }
            } /*else if (typeof (T).GetGenericTypeDefinition () == typeof (System.Collections.Generic.List <>)) {
            	///var list = (System.Collections.Generic.List<T>) result;
            	var list = result as System.Collections.Generic.iList<T>;
                if (list != null && list.Count > 0) {
                    var mine = list[0] as Models.PaladinsResponse;
                    if (mine.ret_msg != null) foundProblem = !foundProblem;
                }
            } */else {
            	var basic = result as Models.APIResponse;
            	if (basic != null && !string.IsNullOrEmpty (basic.ret_msg) &&
            	    	!basic.ret_msg.ToLower ().Equals ("approved")) {
						foundProblem = !foundProblem;
                		errorMessage = basic.ret_msg;
            	}
            }

            /* If there is no problem in the response, return the values */
            if (!foundProblem) return result;

            /* If there is a problem in the response, try again.
             * It is only check for dead session the recursion. */
            if (errorMessage.Contains ("dailylimit")) {
                throw new Exceptions.DailyLimitException (errorMessage);
            } else if (errorMessage.Contains ("Maximum number of active sessions reached")) {
                throw new Exceptions.SessionLimitException (errorMessage);
            } else if (errorMessage.Contains ("Exception while validating developer access")) {
                throw new Exceptions.WrongCredentialsException (errorMessage);
            } else if (errorMessage.Contains ("404")) { throw new Exceptions.NotFoundException (errorMessage); }

            this.CreateSession ();
            return this.CheckRequest <T> (apiMethod, parameters);
        }
        #endregion

        #region Connectivity
        
        #region CreateSession
        /// <summary>
        /// /createsession[ResponseFormat]/{developerId}/{signature}/{timestamp}
        /// </summary>
        /// <returns>A required step to Authenticate the developerId/signature for further API use.</returns>
        protected override void CreateSession () {
            this.lastSession = System.DateTime.UtcNow;
            
            this.currentSession = this.CheckRequest <Models.Session> ("createsession");
			
            base.CreateSession ();
        }
        #endregion
        
        #region Ping
        /// <summary>
        /// /ping[ResponseFormat]
        /// </summary>
        /// <returns>A quick way of validating access to the Hi-Rez API.</returns>
        public Models.Ping Ping () {
            return new Models.Ping (this.CheckRequest <string> ("ping"));
        }
        #endregion
        
        #region TestSession
        /// <summary>
        /// /testsession[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}
        /// </summary>
        /// <returns>A means of validating that a session is established.</returns>
        public Models.TestSession TestSession () {
        	return new Models.TestSession (this.CheckRequest <string> ("testsession"));
        }
        #endregion
        
        #region GetHiRezServerStatus
		/// <summary>
		/// /gethirezserverstatus[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}
		/// </summary>
		/// <returns>Function returns UP/DOWN status for the primary game/platform environments.  Data is cached once a minute.</returns>
        public Models.HiRezServerStatus GetHiRezServerStatus () {
			return this.CheckRequest <System.Collections.Generic.List <Models.HiRezServerStatus>> ("gethirezserverstatus") [0];
        }
        #endregion
        
        #endregion
        
        #region API
        
        #region GetChampions
        /// <summary>
        /// /getchampions[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{languageCode}
        /// </summary>
        /// <param name="languageCode"></param>
        /// <returns>Returns all Champions and their various attributes.</returns>
        public System.Collections.Generic.List<Models.Champion> GetChampions (int languageCode) { return this.GetChampions ((Enums.eLanguageCode) languageCode); }
        /// <summary>
        /// /getchampions[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{languageCode} 
        /// </summary>
        /// <param name="languageCode"></param>
        /// <returns>Returns all Champions and their various attributes.</returns>
        public System.Collections.Generic.List<Models.Champion> GetChampions(Enums.eLanguageCode languageCode = Enums.eLanguageCode.English) {
        	return this.CheckRequest <System.Collections.Generic.List<Models.Champion>> ("getchampions", languageCode);
        }
        #endregion
        
        #region GetChampionRanks
        /// <summary>
        /// /getchampionranks[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{player}
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns>Returns the Rank and Worshippers value for each Champion a player has played.</returns>
        public List<Models.ChampionRank> GetChampionRanks (string playerName) {
        	return this.CheckRequest <List<Models.ChampionRank>> ("getchampionranks", playerName);
        }
        /// <summary>
        /// /getchampionranks[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{player}
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns>Returns the Rank and Worshippers value for each Champion a player has played.</returns>
        public List<Models.ChampionRank> GetChampionRanks (int playerId) {
        	return this.CheckRequest <List<Models.ChampionRank>> ("getchampionranks", playerId);
        }
        #endregion
        
        #region GetChampionsSkins
        /// <summary>
        /// /getchampionskins[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{godId}/{languageCode}
        /// </summary>
        /// <param name="championId"></param>
        /// <param name="languageCode"></param>
        /// <returns>Returns all available skins for a particular Champion.</returns>
        public List<Models.ChampionSkin> GetChampionSkins (int championId, int languageCode) { return this.GetChampionSkins (championId, (Enums.eLanguageCode) languageCode); }
        /// <summary>
        /// /getchampionskins[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{godId}/{languageCode}
        /// </summary>
        /// <param name="championId"></param>
        /// <param name="languageCode"></param>
        /// <returns>Returns all available skins for a particular Champion.</returns>
        public List<Models.ChampionSkin> GetChampionSkins (int championId, Enums.eLanguageCode languageCode = Enums.eLanguageCode.English) {
        	return this.CheckRequest <List<Models.ChampionSkin>> ("getchampionskins", championId, languageCode);
        }
        #endregion
        
        #region GetDataUsed
        /// <summary>
        /// /getdataused[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}
        /// </summary>
        /// <returns>Returns API Developer daily usage limits and the current status against those limits.</returns>
        public Models.DataUsed GetDataUsed () {
        	return this.CheckRequest <System.Collections.Generic.List<Models.DataUsed>> ("getdataused") [0];
        }
        #endregion
        
        #region GetFriends
        /// <summary>
        /// /getfriends[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{player}
        /// </summary>
        /// <param name="playerName">String ID of a specify player</param>
        /// <returns>Returns the Smite User names of each of the player’s friends.</returns>
        public System.Collections.Generic.List <Models.Friend> GetFriends (string playerName) {
        	return this.CheckRequest <System.Collections.Generic.List<Models.Friend>> ("getfriends", playerName);
        }
        
        /// <summary>
        /// /getfriends[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{player}
        /// </summary>
        /// <param name="playerId">Integer ID of a specify player</param>
        /// <returns>Returns the Smite User names of each of the player’s friends.</returns>
        public System.Collections.Generic.List <Models.Friend> GetFriends (int playerId) {
        	return this.CheckRequest <System.Collections.Generic.List<Models.Friend>> ("getfriends", playerId);
        }
        #endregion
        
        #region GetItems
        /// <summary>
        /// /getitems[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{languagecode}
        /// </summary>
        /// <returns>Returns all Items and their various attributes.</returns>
        public List<Models.Item> GetItems () { return this.GetItems (this.Language); }
        /// <summary>
        /// /getitems[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{languagecode}
        /// </summary>
        /// <param name="languageCode"></param>
        /// <returns>Returns all Items and their various attributes.</returns>
        public List<Models.Item> GetItems (int languageCode) { return this.GetItems ((Enums.eLanguageCode) languageCode); }
        /// <summary>
        /// /getitems[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{languagecode}
        /// </summary>
        /// <param name="languageCode"></param>
        /// <returns>Returns all Items and their various attributes.</returns>
        public List<Models.Item> GetItems(Enums.eLanguageCode languageCode) {
        	return this.CheckRequest <List<Models.Item>> ("getitems", languageCode);
        }
        #endregion
        
        #region GetMatchDetails
        /// <summary>
        /// /getmatchdetails[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{match_id}
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns>Returns the statistics for a particular completed match.</returns>
        public List<Models.MatchDetails> GetMatchDetails (int matchId) {
        	return this.CheckRequest <List<Models.MatchDetails>> ("getmatchdetails", matchId);
        }
        #endregion
        
        #region GetMatchHistory
        /// <summary>
        /// /getmatchhistory[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{player}
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns>Gets recent matches and high level match statistics for a particular player.</returns>
        public List<Models.MatchHistory> GetMatchHistory (string playerName) {
        	return this.CheckRequest <List<Models.MatchHistory>> ("getmatchhistory", playerName);
        }
        /// <summary>
        /// /getmatchhistory[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{player}
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns>Gets recent matches and high level match statistics for a particular player.</returns>
        public List<Models.MatchHistory> GetMatchHistory (int playerId) {
        	 return this.CheckRequest <List<Models.MatchHistory>> ("getmatchhistory", playerId);
        }
        #endregion
        
        #region GetMatchIdsByQueue
        /// <summary>
        /// /getmatchidsbyqueue[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{queue}/{date}/{hour}
        /// NOTE - To avoid HTTP timeouts in the GetMatchIdsByQueue() method, you can now specify a 10-minute window within the specified {hour} field to lessen the size of data returned by appending a “,mm” value to the end of {hour}. For example, to get the match Ids for the first 10 minutes of hour 3, you would specify {hour} as “3,00”.  This would only return the Ids between the time 3:00 to 3:09.  Rules below:
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="date"></param>
        /// <param name="hour">Only valid values for mm are “00”, “10”, “20”, “30”, “40”, “50”. To get the entire third hour worth of Match Ids, call GetMatchIdsByQueue() 6 times, specifying the following values for {hour}: “3,00”, “3,10”, “3,20”, “3,30”, “3,40”, “3,50”. The standard, full hour format of {hour} = “hh” is still supported.</param>
        /// <returns>Lists all Match IDs for a particular Match Queue; useful for API developers interested in constructing data by Queue.  To limit the data returned, an {hour} parameter was added (valid values: 0 - 23).  An {hour} parameter of -1 represents the entire day, but be warned that this may be more data than we can return for certain queues.  Also, a returned “active_flag” means that there is no match information/stats for the corresponding match.  Usually due to a match being in-progress, though there could be other reasons.</returns>
        public List<Models.MatchId> GetMatchIdsByQueue (Enums.QueueType queue, string date, string hour) {
        	return this.CheckRequest <List<Models.MatchId>> ("getmatchidsbyqueue", queue, date, hour);
        }
        /// <summary>
        /// /getmatchidsbyqueue[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{queue}/{date}/{hour}
        /// NOTE - To avoid HTTP timeouts in the GetMatchIdsByQueue() method, you can now specify a 10-minute window within the specified {hour} field to lessen the size of data returned by appending a “,mm” value to the end of {hour}. For example, to get the match Ids for the first 10 minutes of hour 3, you would specify {hour} as “3,00”.  This would only return the Ids between the time 3:00 to 3:09.  Rules below:
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="date"></param>
        /// <param name="hour">>Only valid values for mm are “00”, “10”, “20”, “30”, “40”, “50”. To get the entire third hour worth of Match Ids, call GetMatchIdsByQueue() 6 times, specifying the following values for {hour}: “3,00”, “3,10”, “3,20”, “3,30”, “3,40”, “3,50”. The standard, full hour format of {hour} = “hh” is still supported.</param>
        /// <returns>Lists all Match IDs for a particular Match Queue; useful for API developers interested in constructing data by Queue.  To limit the data returned, an {hour} parameter was added (valid values: 0 - 23).  An {hour} parameter of -1 represents the entire day, but be warned that this may be more data than we can return for certain queues.  Also, a returned “active_flag” means that there is no match information/stats for the corresponding match.  Usually due to a match being in-progress, though there could be other reasons.</returns>
        public List<Models.MatchId> GetMatchIdsByQueue (Enums.QueueType queue, System.DateTime date, string hour) {
        	return this.GetMatchIdsByQueue (queue, Utils.UtcNow ("yyyyMMdd"), hour);
        }
        #endregion
        
        #region GetMatchPlayerDetails
        /// <summary>
        /// /getmatchplayerdetails[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{match_id}
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns>Returns player information for a live match.</returns>
        public List<Models.MatchPlayer> GetMatchPlayerDetails (int matchId) {
        	return this.CheckRequest <List<Models.MatchPlayer>> ("getmatchplayerdetails", matchId);
        }
        #endregion
        
        #region GetMotd
        /// <summary>
        /// /getmotd[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}
        /// </summary>
        /// <returns>Returns information about the 20 most recent Match-of-the-Days.</returns>
        public System.Collections.Generic.List <Models.MatchDetails> GetMotd () {
        	return this.CheckRequest <System.Collections.Generic.List <Models.MatchDetails>> ("getmotd"); // Ambos retornam 0
        }
        #endregion
        
        #region GetPatchInfo
        /// <summary>
        /// /getpatchinfo[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}
        /// </summary>
        /// <returns>Function returns information about current deployed patch. Currently, this information only includes patch version.</returns>
        public Models.PatchInfo GetPatchInfo () {
        	return this.CheckRequest <Models.PatchInfo> ("getpatchinfo");
        }
        #endregion
        
        #region GetPlayer
        /// <summary>
        /// /getplayer[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{player}
        /// </summary>
        /// <param name="name">The name of the Paladins player you want to get the details of.</param>
        /// <returns>Returns league and other high level data for a particular player.</returns>
        public Models.Player GetPlayer (string name) {
        	return this.CheckRequest <System.Collections.Generic.List<Models.Player>> ("getplayer", name) [0];
        }
        #endregion
        
        #region GetPlayerAchievements
        /// <summary>
        /// /getplayerachievements[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{playerId}
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns select achievement totals (Double kills, Tower Kills, First Bloods, etc) for the specified playerId.</returns>
        public Models.PlayerAchievements GetPlayerAchievements (int id) {
        	return this.CheckRequest <Models.PlayerAchievements> ("getplayerachievements", id);
        }
        #endregion
        
        #region GetPlayerLoadouts
        /// <summary>
        /// /getplayerloadouts[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/playerId}/{languageCode}
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns>Returns deck loadouts per Champion.</returns>
        public System.Collections.Generic.List <Models.PlayerLoadouts> GetPlayerLoadouts (int playerId) { return this.GetPlayerLoadouts (playerId, this.Language); }
        /// <summary>
        /// /getplayerloadouts[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/playerId}/{languageCode}
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="language"></param>
        /// <returns>Returns deck loadouts per Champion.</returns>
        public System.Collections.Generic.List <Models.PlayerLoadouts> GetPlayerLoadouts (int playerId, Enums.eLanguageCode language) {
        	return this.CheckRequest <System.Collections.Generic.List<Models.PlayerLoadouts>> ("getplayerloadouts", playerId, language);
        }
        #endregion
        
        #region GetPlayerStatus
        /// <summary>
        /// /getplayerstatus[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{player}
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns>Returns player status as follows: Offline (0), InLobby (1), ChampionSelection (2), InGame (3), Online (4), NotFound (5)</returns>
        public Models.PlayerStatus GetPlayerStatus (string playerName) {
        	return this.CheckRequest <Models.PlayerStatus> ("getplayerstatus", playerName);
        }
        #endregion
        
        #region GetQueueStats
        /// <summary>
        /// /getqueuestats[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{player}/{queue}
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="queue"></param>
        /// <returns>Returns match summary statistics for a (player, queue) combination grouped by gods played.</returns>
        public List<Models.QueueChampionStat> GetQueueStats (string playerName, Enums.QueueType queue) {
        	return this.CheckRequest <List<Models.QueueChampionStat>> ("getqueuestats", playerName, queue);
        }
        /// <summary>
        /// /getqueuestats[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}/{player}/{queue}
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="queue"></param>
        /// <returns>Returns match summary statistics for a (player, queue) combination grouped by gods played.</returns>
        public List<Models.QueueChampionStat> GetQueueStats (int playerId, Enums.QueueType queue) {
        	return this.CheckRequest <List<Models.QueueChampionStat>> ("getqueuestats", playerId, queue);
        }
        #endregion

        #region GetTopMatches
        /// <summary>
        /// /gettopmatches[ResponseFormat]/{developerId}/{signature}/{session}/{timestamp}
        /// </summary>
        /// <returns>Lists the 50 most watched / most recent recorded matches.</returns>
        public List<Models.TopMatch> GetTopMatches () {
            return this.Deserialize <List<Models.TopMatch>> (this.RequestURL (this.BuildUrlRequest ("gettopmatches")), this.responseFormat);
        }
        #endregion
        
        #endregion
	}
}