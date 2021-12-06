using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Conquest.PersistantManager;

public class LoginManager : MonoBehaviourPunCallbacks {

    public Button button;
    public CanvasGroup cg;

    private void Start() {

        cg.DOFade(1.0f, 0.25f);
    }

    public void EnterRoom() {

        Debug.Log($"Attempting to join or create room");
        SceneFade.FadeIn();

        RoomOptions roomOptions = new RoomOptions();
        //roomOptions.MaxPlayers = 4;
        roomOptions.PublishUserId = true;
        button.interactable = false;
        
        PhotonNetwork.JoinOrCreateRoom("world1", roomOptions, TypedLobby.Default);
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

        Debug.Log($"Joined room <color=olive>{PhotonNetwork.CurrentRoom.Name}</color>");
        PhotonNetwork.LoadLevel("Playground"); 
    }

    private void OnDestroy() {

        cg.DOKill();
    }
}
