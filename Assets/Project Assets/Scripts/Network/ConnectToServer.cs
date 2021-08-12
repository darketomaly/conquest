using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using Photon.Pun;

public class ConnectToServer : MonoBehaviourPunCallbacks {

    public TextMeshProUGUI textMesh;

    private AsyncOperation loadsceneOp;

    private void Start() {

        Debug.Log("<color=green>Online mode enabled.</color>");

        SceneFade.FadeOut();
        Application.backgroundLoadingPriority = ThreadPriority.BelowNormal; //prevents lag when loading scene
        (loadsceneOp = SceneManager.LoadSceneAsync("Login Screen")).allowSceneActivation = false;

        PhotonNetwork.ConnectUsingSettings();
        textMesh.text = "connecting to server";
    }

    public override void OnConnectedToMaster() {

        textMesh.text = "joining lobby";
        if(PhotonNetwork.IsConnected)
            PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby() {

        StartCoroutine(_OnJoinedLobby());
    }

    private IEnumerator _OnJoinedLobby() {

        textMesh.text = "loading login screen";
        SceneFade.FadeIn();
        yield return new WaitForSeconds(0.7f);
        loadsceneOp.allowSceneActivation = true;
    }
}
