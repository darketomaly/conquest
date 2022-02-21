using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicIntroManager : MonoBehaviour {

    AsyncOperation op;

    void Start() {

        op = SceneManager.LoadSceneAsync("Title Screen");
        op.allowSceneActivation = false;
    }

    public void ActivateTitleScreen(){

        op.allowSceneActivation = true;
    }

    public void PrintMessage(bool value) {

        Debug.Log($"<color=olive>Printing {value}</color>");
    }
}
