using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameSparks
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

public class GameSparksManager : MonoBehaviour
{

    private static GameSparksManager instance = null;

    public void Register(string username, string email, string password)
    {
        Debug.Log("Registering Player...");
        new RegistrationRequest()
            .SetDisplayName(username)
            .SetUserName(username)
            .SetPassword(password)
            .SetSegments(new GameSparks.Core.GSRequestData().AddString("Email", email))
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Player Registered \n User Name: " + response.DisplayName);

                    //OCDataController.SaveAccountData(email, username, password);
                }
                else
                {
                    Debug.Log("Error Registering Player... \n " + response.Errors.JSON.ToString());
                }
            });
    }

    public bool Login(string username, string password)
    {
        Debug.Log("Authorizing Player...");
        bool success = false;
        new AuthenticationRequest()
            .SetUserName(username)
            .SetPassword(password)
            .Send((response =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Player Authenticated... \n User Name: " + response.DisplayName);
                    success = true;
                }
                else
                {
                    Debug.Log("Error Authenticating Player... \n " + response.Errors.JSON.ToString());
                }
            }));

        return success;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
