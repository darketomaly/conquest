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

        PhotonNetwork.ConnectUsingSettings();

        textMesh.text = "connecting to server";

        Application.backgroundLoadingPriority = ThreadPriority.BelowNormal; //prevents lag when loading scene
        (loadsceneOp = SceneManager.LoadSceneAsync("Login Screen")).allowSceneActivation = false;
    }

    public override void OnConnectedToMaster() {

        textMesh.text = "joining lobby";
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby() {

        textMesh.text = "loading login screen";
        loadsceneOp.allowSceneActivation = true;
    }
}
