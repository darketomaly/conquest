using System;
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

        private void Awake() {

            if(m != null)
                Destroy(gameObject);
             else
                m = this;

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void Start() => DontDestroyOnLoad(gameObject);

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) =>  onSceneLoaded?.Invoke();
    }
}

