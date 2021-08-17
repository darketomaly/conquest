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

    public void EnterRoom() {

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        roomOptions.PublishUserId = true;

        button.interactable = false;

        PhotonNetwork.JoinOrCreateRoom("world", roomOptions, TypedLobby.Default);
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

        CustomSceneManager.LoadScene("Conquest", true);
    }
}
