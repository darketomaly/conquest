using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSpawnPoint : MonoBehaviour {

    private void Awake() => ExtendedNetworkManager.onServerReadied += SpawnPlayer;

    private void OnDrawGizmos() {

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.3f);
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
    }

    private void SpawnPlayer(NetworkConnection conn) {

        GameObject playerInstance = 
            Instantiate(ExtendedNetworkManager.singleton.playerPrefab, transform.position, transform.rotation);

        NetworkServer.Spawn(playerInstance, conn);
    }
}
