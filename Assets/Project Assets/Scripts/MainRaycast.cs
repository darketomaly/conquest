using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainRaycast : MonoBehaviour {

    public Camera cam;

    public void Update() {

        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit)) {

            if (Mouse.current.leftButton.wasPressedThisFrame) {

                GameManager.localPlayer.movement.MoveTo(hit.point);
            }
        }
    }
}
