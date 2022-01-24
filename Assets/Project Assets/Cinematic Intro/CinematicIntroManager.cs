using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CinematicIntroManager : MonoBehaviour {

    AsyncOperation op;

    [SerializeField] PlayableDirector director;

    void Start() {

        //placeholder test
        op = SceneManager.LoadSceneAsync("Title Screen");
        op.allowSceneActivation = false;

        StartCoroutine(Test());
    }

    IEnumerator Test() {

        yield return new WaitForSeconds((float)director.duration);
        op.allowSceneActivation = true;
    }
}
