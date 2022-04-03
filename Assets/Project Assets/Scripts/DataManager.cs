using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class DataManager : MonoBehaviour {

    public static LocalData localData;
    public static DataManager instance;

    public string m_GameVersion;

    public AsyncOperation sceneLoadOp;

    private string savePath;

    #region Internal Behavior

    void Start() {

        instance = this;
        ReadFile();
        DontDestroyOnLoad(gameObject); //no need for a singleton
    }

    private void ReadFile() {

        savePath = $"{ Application.persistentDataPath}/LocalData.json";

        if (File.Exists(savePath)) {

            localData = JsonUtility.FromJson<LocalData>(File.ReadAllText(savePath));
            localData.timesReEnteredTheGame++;

            if (SceneManager.GetActiveScene().buildIndex == 0) { //if we are on landing

                Debug.Log($"<color=olive>Preloading title screen</color>");
                sceneLoadOp = SceneManager.LoadSceneAsync("Title Screen");
            }

        } else {

            WriteFile();

            if (SceneManager.GetActiveScene().buildIndex == 0) { //if we are on landing

                Debug.Log($"<color=olive>Preloading cinematic intro scene</color>");
                sceneLoadOp = SceneManager.LoadSceneAsync("Cinematic Intro Scene");
            }
        }

        Debug.Log($"<color=olive>Local data file read</color>");

        if (SceneManager.GetActiveScene().buildIndex == 0) //if we are on landing
            sceneLoadOp.allowSceneActivation = false;
    }

    private static void WriteFile() =>
        File.WriteAllText(instance.savePath, JsonUtility.ToJson(localData));

    #if UNITY_EDITOR
    [MenuItem("Conquest/Delete Save File")]
    private static void DeleteFile() {

        string _savePath = $"{ Application.persistentDataPath}/LocalData.json";
        if (File.Exists(_savePath))
            File.Delete(_savePath);

        Debug.Log($"<color=olive>LocalData deleted</color>");
    }
    #endif

    #endregion

    /// <summary>Player preferences, unimportant data</summary>
    public struct LocalData { //

        public int timesReEnteredTheGame;
    }

    /// <summary>Data grabbed from the database</summary>
    public struct OnlineData { //keep as optimized as possible

        public int timePlayed;
    }
}