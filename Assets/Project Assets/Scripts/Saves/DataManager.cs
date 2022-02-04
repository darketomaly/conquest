using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor;

public class DataManager : MonoBehaviour {

    public static LocalData localData;

    [SerializeField] private Image splash;

    private static DataManager instance;
    private string savePath;
    private AsyncOperation sceneLoadOp;

    void Start() {

        instance = this;
        StartCoroutine(SplashScreen());
        ReadFile();

        DontDestroyOnLoad(gameObject); //no need for a singleton, in no moment it will return to the original scene
    }

    private IEnumerator SplashScreen() {

        yield return new WaitForSeconds(0.2f);

        splash.DOFade(1.0f, 0.75f);

        yield return new WaitForSeconds(1.25f);

        splash.DOFade(0.0f, 0.75f).OnComplete(()=> sceneLoadOp.allowSceneActivation = true);
    }

    private void ReadFile() {

        savePath = $"{ Application.persistentDataPath}/LocalData.json";

        if (File.Exists(savePath)) {

            localData = JsonUtility.FromJson<LocalData>(File.ReadAllText(savePath));
            localData.timesReEnteredTheGame++;

            Debug.Log($"<color=olive>Preloading title screen</color>");
            sceneLoadOp = SceneManager.LoadSceneAsync("Title Screen");

        } else {

            WriteFile();
            Debug.Log($"<color=olive>Preloading cinematic intro scene</color>");
            sceneLoadOp = SceneManager.LoadSceneAsync("Cinematic Intro Scene");
        }

        sceneLoadOp.allowSceneActivation = false;
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

    #if UNITY_EDITOR
    [MenuItem("Conquest/Delete Save File")]
    private static void DeleteFile() {

        string _savePath = $"{ Application.persistentDataPath}/LocalData.json";
        if (File.Exists(_savePath))
            File.Delete(_savePath);

        Debug.Log($"<color=olive>LocalData deleted</color>");
    }
    #endif
}


