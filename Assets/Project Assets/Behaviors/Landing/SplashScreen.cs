using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour {

    [SerializeField] private Image splash;
    [SerializeField] private AudioSource logoMusic;

    private void Start() {

        Application.backgroundLoadingPriority = ThreadPriority.Low;
        StartCoroutine(DoSplashScreen());
    }

    private IEnumerator DoSplashScreen() {

        yield return new WaitForSeconds(0.05f);

        logoMusic.Play();
        splash.DOFade(1.0f, 0.75f);

        yield return new WaitForSecondsRealtime(5);

        logoMusic.DOFade(0.0f, 1.25f);

        splash.DOFade(0.0f, 1.3f).OnComplete(delegate {

            if (DataManager.instance && DataManager.instance.sceneLoadOp != null)
                DataManager.instance.sceneLoadOp.allowSceneActivation = true;
        });
    }
}
