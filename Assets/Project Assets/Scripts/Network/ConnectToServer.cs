using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using Photon.Pun;
using Photon.Realtime;

public class ConnectToServer : MonoBehaviourPunCallbacks {

    public TextMeshProUGUI textMesh;
    public ProgressBar progressBar;
    public TextMeshProUGUI percentageText;

    private AsyncOperation loadsceneOp;

    private void Start() {

        Debug.Log("<color=green>Online mode enabled.</color>");

        SceneFade.FadeOut();
        Application.backgroundLoadingPriority = ThreadPriority.BelowNormal; //prevents lag when loading scene
        (loadsceneOp = SceneManager.LoadSceneAsync("Login Screen")).allowSceneActivation = false;

        PhotonNetwork.ConnectUsingSettings();
        textMesh.text = "connecting to server";
    }

    private void Update() {

        switch (PhotonNetwork.NetworkClientState) {

            case ClientState.ConnectingToNameServer:

                //Debug.Log("1: Connecting to name server");
                progressBar.value = 1;
                break;

            case ClientState.ConnectedToNameServer:

                //Debug.Log("2: Connected to name server"); //
                progressBar.value = 2;
                break;

            case ClientState.Authenticating:

                //Debug.Log("3: Authenticating");
                //progressBar.value = 3;
                break;

            case ClientState.ConnectingToMasterServer:

                //Debug.Log("4: Connecting to master server");
                progressBar.value = 3;
                break;

            case ClientState.JoiningLobby:

                //Debug.Log("5: Joining lobby");
                progressBar.value = 4;
                break;

            case ClientState.JoinedLobby:

                //Debug.Log("6: Joined lobby");
                progressBar.value = 5;
                break;

            default:
                break;
        }

        percentageText.text = progressBar.percentage + "%";
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
