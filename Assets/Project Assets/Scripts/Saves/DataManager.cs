using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour {

    public static LocalData localData;

    private static DataManager instance;

    private string savePath;

    void Awake() {

        instance = this;

        savePath = $"{ Application.persistentDataPath}/LocalData.json";
        ReadFile();

        DontDestroyOnLoad(gameObject); //no need for a singleton, in no moment it will return to the original scene
    }

    private void ReadFile() {

        if (File.Exists(savePath)) {

            localData = JsonUtility.FromJson<LocalData>(File.ReadAllText(savePath));
            localData.timesReEnteredTheGame++;

            SceneManager.LoadScene($"Title Screen");

        } else {

            WriteFile();
            SceneManager.LoadScene($"Cinematic Intro Scene");
        }
    }

    private void OnDestroy() =>
        WriteFile();

    private static void WriteFile() =>
        File.WriteAllText(instance.savePath, JsonUtility.ToJson(localData));

    /// <summary>Player preferences, unimportant data</summary>
    public struct LocalData {

        public int timesReEnteredTheGame;
    }

    /// <summary>Data grabbed from the database</summary>
    public struct OnlineData { //keep as optimized as possible

        public int timePlayed;
    }
}


