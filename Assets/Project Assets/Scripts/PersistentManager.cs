using Conquest.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Conquest {

    /// <summary> Holds references accross different scenes to avoid having to create separate singletons. </summary>
    public class PersistentManager : MonoBehaviour {

        #region Variables

        internal static PersistentManager m;

        public GameObject dataManagerPrefab;

        [Header("Elements")]
        [SerializeField] internal SceneFade sceneFade;
        [SerializeField] internal AudioManager audioManager;

        public static Action onSceneLoaded;

        private int lastInvokedOn = -1;

        #endregion

        #region Setup

        private void OnEnable() {
           
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable() {

            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void Awake() {

            if (m != null)
                Destroy(gameObject);
            else {

                onSceneLoaded = null;
                m = this;
                DontDestroyOnLoad(gameObject);
            }

            if (!DataManager.instance)
                Instantiate(dataManagerPrefab);
        }

        #endregion

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) {

            if (m == this && SceneManager.GetActiveScene().buildIndex != m.lastInvokedOn) {

                if (!DataManager.instance)
                    Instantiate(dataManagerPrefab);

                m.lastInvokedOn = SceneManager.GetActiveScene().buildIndex;
                onSceneLoaded?.Invoke();
            }
        }
    }
}
