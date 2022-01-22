using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicIntroManager : MonoBehaviour {

    AsyncOperation op;

    void Start() {

        //placeholder test
        op = SceneManager.LoadSceneAsync("Title Screen");
        op.allowSceneActivation = false;

        StartCoroutine(Test());
    }

    IEnumerator Test() {

        yield return new WaitForSeconds(5);
        op.allowSceneActivation = true;
    }
}
