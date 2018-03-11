using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameSparks
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;

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
            .SetSegments(new GSRequestData().AddString("email", email))
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Player Registered \n User Name: " + response.DisplayName);

                    //DataController.SaveAccountData(email, username, password);
                }
                else
                {
                    Debug.Log("Error Registering Player... \n " + response.Errors.JSON.ToString());
                }
            });
    }

    public bool Login(string username, string password)
    {
        return Authentication(username, password);
    }

    public bool PasswordRecoveryRequest(string email)
    {
        var request = new GSRequestData()
            .AddString("action", "passwordRecoveryRequest")
            .AddString("email", email);

        return Authentication("", "", request);
    }

    public bool PasswordReset(string newPassword, string token)
    {
        var request = new GSRequestData()
            .AddString("action", "resetPassword")
            .AddString("password", newPassword)
            .AddString("token", token);

        return Authentication("", "", request);
    }

    // TESTING
    public void ChangeUserDetails(string displayName, string language, string newPassword, string oldPassword, string userName)
    {
        new ChangeUserDetailsRequest()
        .SetDisplayName(displayName)
        .SetLanguage(language)
        .SetNewPassword(newPassword)
        .SetOldPassword(oldPassword)
        .SetUserName(userName)
        .Send((response) => {
            GSData scriptData = response.ScriptData;
        });
    }

    /// <summary>
    /// Login request for the user.
    /// Can also be used as password recovery or reset.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="action">Set action to "resetPassword" or "passwordRecoveryRequest" for password recovery.</param>
    /// <returns></returns>
    private bool Authentication(string username, string password, GSRequestData action = null)
    {
        Debug.Log("Authorizing Player...");
        bool success = false;
        new AuthenticationRequest()
            .SetUserName(username)
            .SetPassword(password)
            .SetScriptData(action)
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
