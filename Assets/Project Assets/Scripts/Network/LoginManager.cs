using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;
using TMPro;

public class LoginManager : MonoBehaviourPunCallbacks {

    public TextMeshProUGUI playerCountText;
    public Button button;

    private void Awake() {

        StartCoroutine(DisplayPlayerCount());
    }

    public void EnterRoom() {

        RoomOptions roomOptions = new RoomOptions();
        //roomOptions.MaxPlayers = 4;
        roomOptions.PublishUserId = true;

        button.interactable = false;
        
        PhotonNetwork.JoinOrCreateRoom("world", roomOptions, TypedLobby.Default);
    }

    IEnumerator DisplayPlayerCount() {

        while (true) {

            playerCountText.text =
                $"Players inside: {PhotonNetwork.CountOfPlayersInRooms}.";

            yield return new WaitForSeconds(5.1f);
        }
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

        PhotonNetwork.LoadLevel("Conquest");    //this has to be on the same frame
                                                //waiting for the scene fade makes current joined players not appear
    }
}