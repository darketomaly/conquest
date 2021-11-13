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

        private bool sceneLoadedCalled;

        private void Awake() {

            if(m != null) {

                Destroy(gameObject);
            } else {

                m = this;
            }

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void Start() => DontDestroyOnLoad(gameObject);

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) {

            if(m != this || sceneLoadedCalled)
                return;

            Debug.Log("on scene loaded");
            sceneLoadedCalled = true;
            StartCoroutine(ResetAfterDelay());
            onSceneLoaded?.Invoke();
        }

        private IEnumerator ResetAfterDelay() {

            //just to make sure i dont invoke the action more than once

            yield return new WaitForSeconds(1.0f);
            sceneLoadedCalled = false;
        }
    }
}

