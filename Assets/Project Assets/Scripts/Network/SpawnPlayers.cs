using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayers : MonoBehaviourPunCallbacks {

    [SerializeField] private Transform startPosition;

    private static readonly string playerPrefabPath = "Photon Spawns/Player";

    private void Start() {

        if (!PhotonNetwork.IsConnected) { //Only used when developing

            Debug.Log("<color=red>Offline mode enabled.</color>");
            PhotonNetwork.OfflineMode = true;

            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 1;

            PhotonNetwork.JoinOrCreateRoom("world", roomOptions, TypedLobby.Default);
        }

        GameObject spawnedPlayer =
                PhotonNetwork.Instantiate(playerPrefabPath, startPosition.position, Quaternion.identity);
        OnSpawnBehavior(spawnedPlayer.GetComponent<Player>());
    }

    //Only gets called on the local client, used to store references
    private void OnSpawnBehavior(Player spawnedPlayer) {

        GameManager.localPlayer = spawnedPlayer;
    }
}
