using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour {

    private Control control;
    private PhotonView photonView;

    private void Awake() {

        photonView = GetComponent<PhotonView>();
    }

    public void MoveTo(Vector3 desiredPosition) {

        //if (PhotonNetwork.IsConnected)
        //    if (!photonView.IsMine) return;

        transform.position = desiredPosition;
    }
}
