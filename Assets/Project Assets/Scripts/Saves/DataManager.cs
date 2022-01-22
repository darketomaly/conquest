using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour {

    public static LocalData localData;

    private static DataManager instance;

    private string savePath;

    void Awake() {

        savePath = $"{ Application.persistentDataPath}/LocalData.json";
        ReadFile();

        instance = this;
        DontDestroyOnLoad(gameObject); //no need for a singleton, in no moment it will return to the original scene
    }

    private void ReadFile() {

        if (File.Exists(savePath)) {

            localData = JsonUtility.FromJson<LocalData>(File.ReadAllText(savePath));
            localData.timesReEnteredTheGame++;

            SceneManager.LoadScene($"Title Screen");

        } else {

            Debug.LogError($"<color=olive>Load cinematric intro here (to do)</color>");

            //Load cinematic intro scene here     
            WriteFile();
        }
    }

    private void OnDestroy() =>
        WriteFile();

    private static void WriteFile() =>
        File.WriteAllText(instance.savePath, JsonUtility.ToJson(localData));

    public struct LocalData {

        public int timesReEnteredTheGame;
    }

    public struct OnlineData {

        public int timePlayed;
    }
}


