using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;

public class FbScript : MonoBehaviour {
    public Text FriendsText;

   


    #region Inviting
   

    #endregion

    public void GetFriendsPlayingThisGame()
    {
        string query = "/me/friends";
        FB.API(query, HttpMethod.GET, result =>
        {
            var dictionary = (Dictionary<string, object>)Facebook.MiniJSON.Json.Deserialize(result.RawResult);
            var friendsList = (List<object>)dictionary["data"];
            FriendsText.text = string.Empty;
            foreach (var dict in friendsList)                    //Invita a tus amigos de FB a jugar
                FriendsText.text += ((Dictionary<string, object>)dict)["name"];
        });
    }
}
