using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour {

    public string prefabName;
    public Transform startPos;

    private static readonly string playerPrefabPath = "Photon Spawns/Player";

    private void Start() {

        if (PhotonNetwork.IsConnected) {

            GameObject spawnedPlayer =
                PhotonNetwork.Instantiate(playerPrefabPath, startPos.position, Quaternion.identity);
            OnSpawnBehavior(spawnedPlayer.GetComponent<Player>());

        } else { //Used to test the game wihout having to connect from Landing scene

            Debug.Log($"<color=red>Offline mode.</color>");
            GameObject spawnedPlayer = Instantiate(Resources.Load<GameObject>(playerPrefabPath));
            OnSpawnBehavior(spawnedPlayer.GetComponent<Player>());

        }
    }

    //Only gets called on the local client, used to store references
    private void OnSpawnBehavior(Player spawnedPlayer) {

        GameManager.localPlayer = spawnedPlayer;
    }
}
