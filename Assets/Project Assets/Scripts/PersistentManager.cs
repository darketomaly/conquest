using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Conquest.PersistantManager {

    public class PersistentManager : MonoBehaviour {

        internal static PersistentManager m;

        [Header("Elements")]
        [SerializeField] internal SceneFade sceneFade;
        [SerializeField] internal DevSettings devSettings;
        [SerializeField] internal AudioManager audioManager;

        public static Action onSceneLoaded;

        private int lastInvokedOn = -1;

        private void Awake() {

            if(m != null) {

                Destroy(gameObject);

            } else {

                onSceneLoaded = null;
                m = this;
                SceneManager.sceneLoaded += OnSceneLoaded;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) {

            if(m == this && SceneManager.GetActiveScene().buildIndex != m.lastInvokedOn) {

                Debug.Log($"<color=olive>Persistent manager:</color> Last invoked on {m.lastInvokedOn}, current {SceneManager.GetActiveScene().buildIndex}");
                m.lastInvokedOn = SceneManager.GetActiveScene().buildIndex;
                PersistentManager.onSceneLoaded?.Invoke();
            }
        }
    }
}

