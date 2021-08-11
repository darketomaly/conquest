using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour {

    public string prefabName;
    public Transform startPos;

    private void Start() =>
        PhotonNetwork.Instantiate("Photon Spawns/Player", startPos.position, Quaternion.identity);
}
