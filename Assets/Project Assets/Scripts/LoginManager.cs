using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LoginManager : MonoBehaviourPunCallbacks {
    
    public void EnterRoom() {

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        roomOptions.PublishUserId = true;
        
        PhotonNetwork.JoinOrCreateRoom("world", roomOptions, TypedLobby.Default);
    }

    public override void OnCreatedRoom() =>
        Debug.Log("Room created");
    
    public override void OnCreateRoomFailed(short returnCode, string message) =>
        Debug.Log($"Create room failed: {message}");
    
    public override void OnJoinRoomFailed(short returnCode, string message) =>
        Debug.Log($"Join room failed: {message}");
    
    public override void OnJoinedRoom() =>
        PhotonNetwork.LoadLevel("Conquest");
}
