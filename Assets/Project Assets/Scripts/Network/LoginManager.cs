using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;

public class LoginManager : MonoBehaviourPunCallbacks {

    public Button button;
    private void Start() {

        Debug.Log("<color=green>Online mode enabled.</color>");
    }

    public void EnterRoom() {

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        roomOptions.PublishUserId = true;
        
        PhotonNetwork.JoinOrCreateRoom("world", roomOptions, TypedLobby.Default);
        button.interactable = false;
    }
    
    public override void OnCreateRoomFailed(short returnCode, string message) {

        Debug.Log($"Create room failed: {message}");
        button.interactable = true;
    }
    
    public override void OnJoinRoomFailed(short returnCode, string message) {

        Debug.Log($"Join room failed: {message}");
        button.interactable = true;
    }

    public override void OnJoinedRoom() {

        StartCoroutine(_OnJoinedRoom());
    }

    private IEnumerator _OnJoinedRoom() {

        SceneFade.FadeIn();
        yield return new WaitForSeconds(0.7f);
        PhotonNetwork.LoadLevel("Conquest");
    }
}
