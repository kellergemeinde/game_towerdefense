#pragma warning disable 612,618
#pragma warning disable 0114
#pragma warning disable 0108

using System;
using System.Collections.Generic;
using GameSparks.Core;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!

namespace GameSparks.Api.Requests{
		public class LogEventRequest_findMatch : GSTypedRequest<LogEventRequest_findMatch, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_findMatch() : base("LogEventRequest"){
			request.AddString("eventKey", "findMatch");
		}
	}
	
	public class LogChallengeEventRequest_findMatch : GSTypedRequest<LogChallengeEventRequest_findMatch, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_findMatch() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "findMatch");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_findMatch SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
	}
	
}
	

namespace GameSparks.Api.Messages {


}
