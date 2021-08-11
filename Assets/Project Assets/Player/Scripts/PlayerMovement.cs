using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour {

    private Control control;
    private PhotonView photonView;

    private void Awake() {

        control = new Control(); //not used yet, does nothing
        photonView = GetComponent<PhotonView>();
    }

    private void OnEnable() =>
        control.Enable();

    private void OnDisable() =>
        control.Disable();
    
    private void Update() {

        if (!photonView.IsMine) return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame) 
            transform.position =
                new Vector3(transform.position.x + 1.0f, transform.position.y, transform.position.z);
    }
}
