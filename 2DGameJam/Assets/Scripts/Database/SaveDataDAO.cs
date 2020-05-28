using Proyecto26;
using RSG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataDAO : MonoBehaviour
{
    private static string firestoreURL = "https://firestore.googleapis.com/v1/projects/game-dev-exam-9991f/databases/(default)/documents/savedata";

    public static IPromise<SaveData>GetSaveDataByUser(string userId)
    {
        return RestClient.Get<SaveData>(firestoreURL + "/" + userId);
    }

    public static IPromise<SaveData>PatchSaveDataForUser(string userId)
    {
        float playerHP = GlobalControl.instance.playerHP;
        int playerPoints = GlobalControl.instance.playerPoints;
        int levelIndex = GlobalControl.instance.currentLevel;
        string player = PlayerPrefs.GetString("Character");
        string docMask = "?updateMask.fieldPaths=playerHP&updateMask.fieldPaths=playerPoints&updateMask.fieldPaths=character&updateMask.fieldPaths=currentLevel";
        string patchURL = firestoreURL + "/" + userId + docMask;

        SaveData newSave = new SaveData();
        SaveData.Field fields = new SaveData.Field();
        SaveData.Field.PlayerHP hp = new SaveData.Field.PlayerHP();
        SaveData.Field.PlayerPoints points = new SaveData.Field.PlayerPoints();
        SaveData.Field.Character character = new SaveData.Field.Character();
        SaveData.Field.CurrentLevel currentLevel = new SaveData.Field.CurrentLevel();

        hp.integerValue = playerHP;
        points.integerValue = playerPoints;
        character.stringValue = player;
        currentLevel.integerValue = levelIndex;
        fields.playerHP = hp;
        fields.playerPoints = points;
        fields.character = character;
        fields.currentLevel = currentLevel;
        newSave.fields = fields;

        return RestClient.Request<SaveData>(new RequestHelper
        {
            Uri = patchURL,
            Method = "PATCH",
            Body = newSave,
            ContentType = "application/json",
            Retries = 2,
            RetrySecondsDelay = 2
        }) ;
    }

    public static IPromise<ResponseHelper> DeleteSaveDataOnUser(string userId)
    {
        return RestClient.Delete(firestoreURL + "/" + userId);
    }
}
