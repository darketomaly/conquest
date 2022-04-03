using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Conquest {

    public class SpawnPlayers : MonoBehaviourPunCallbacks {

        [SerializeField] private Transform startPosition;

        private static readonly string playerPrefabPath = "Photon Spawns/Player/Player";

        private void Start() {

            Application.targetFrameRate = -1;
            Debug.Log($"Spawning");

            if (!PhotonNetwork.IsConnected) {

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
}
