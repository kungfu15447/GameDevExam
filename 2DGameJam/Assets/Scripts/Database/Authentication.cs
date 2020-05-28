using Proyecto26;
using RSG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Authentication : MonoBehaviour
{
    private static string signUpEndPoint = "https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=AIzaSyDThdaoWgpc673Z8opbhcitXsEt9zEAO9s";
    private static string signInEndPoint = "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyDThdaoWgpc673Z8opbhcitXsEt9zEAO9s";
    private static string idToken;
    private static string localId;
    public static IPromise<SignInResponse> SignUp(string email, string password)
    {
        string userData = "{" +
            "\"email\": \"" + email + "\", " +
            "\"password\": \""+ password + "\", " +
            "\"returnSecureToken\": true}";
        return RestClient.Post<SignInResponse>(signUpEndPoint, userData);
    }

    public static IPromise<SignInResponse> Login(string email, string password)
    {
        string userData = "{\"email\": \"" + email + "\", \"password\": \"" + password + "\", \"returnSecureToken\": true}";
        return RestClient.Post<SignInResponse>(signInEndPoint, userData);
    }

    public static string GetLocalId()
    {
        return localId;
    }

    public static string GetIdToken()
    {
        return idToken;
    }

    public static void SetLocalId(string id)
    {
        localId = id;
    }

    public static void SetIdToken(string token)
    {
        idToken = token;
    }
}
