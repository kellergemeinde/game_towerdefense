
using UnityEngine;

// GameSparks
using GameSparks.Api.Requests;
using GameSparks.Core;
using GameSparks.Api.Messages;

public class GS_MatchMaking : GS_Base
{

    private static int Skill = 0;

	private void MatchMaking(bool cancel = false)
    {
        var matchRequest = new MatchmakingRequest().SetMatchShortCode("matchRanked");

        if (cancel)
        {
            matchRequest
                .SetSkill(Skill)
                .SetMatchGroup("group1");
        } else
        {
            matchRequest.SetAction("cancel");
        }
        
        matchRequest.Send((response) => {
            GSData scriptData = response.ScriptData;
        });
    }

    private void MatchDetails(string matchID)
    {
        new MatchDetailsRequest()
            .SetMatchId(matchID)
            .SetRealtimeEnabled(false)
            .Send((response) => {
                GSData scriptData = response.ScriptData;
            });
    }

    private void MatchFound(MatchFoundMessage message)
    {
        
    }

    private void MatchNotFound(MatchNotFoundMessage message)
    {

    }

    private void MatchUpdated(MatchUpdatedMessage message)
    {
        
    }

    private void Start()
    {
        MatchFoundMessage.Listener += MatchFound;
        MatchNotFoundMessage.Listener += MatchNotFound;
        MatchUpdatedMessage.Listener += MatchUpdated;
    }
}
