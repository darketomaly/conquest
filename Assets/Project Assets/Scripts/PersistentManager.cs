using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Conquest.PersistantManager {

    /// <summary>
    /// Holds references accross different scenes to avoid having to create separate singletons.
    /// </summary>
    public class PersistentManager : MonoBehaviour {

        internal static PersistentManager m;

        public GameObject dataManagerPrefab;

        [Header("Elements")]
        [SerializeField] internal SceneFade sceneFade;
        [SerializeField] internal DevSettings devSettings;
        [SerializeField] internal AudioManager audioManager;

        public static Action onSceneLoaded;

        private int lastInvokedOn = -1;

        private void Awake() {

            if(m != null)
                Destroy(gameObject);
             else {

                onSceneLoaded = null;
                m = this;
                SceneManager.sceneLoaded += OnSceneLoaded;
                DontDestroyOnLoad(gameObject);
            }

            if (!DataManager.instance)
                Instantiate(dataManagerPrefab).GetComponent<DataManager>().loadSceneOnFileRead = false;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) {

            //prevent executing on landing or the cinematic cutscene
            if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
                return;

            if(m == this && SceneManager.GetActiveScene().buildIndex != m.lastInvokedOn) {

                if (!DataManager.instance)
                    Instantiate(dataManagerPrefab).GetComponent<DataManager>().loadSceneOnFileRead = false;

                Debug.Log($"<color=olive>Persistent manager:</color> Last invoked on {m.lastInvokedOn}, current {SceneManager.GetActiveScene().buildIndex}");
                m.lastInvokedOn = SceneManager.GetActiveScene().buildIndex;
                PersistentManager.onSceneLoaded?.Invoke();
            }
        }
    }
}

