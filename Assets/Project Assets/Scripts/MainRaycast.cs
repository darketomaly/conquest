using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainRaycast : MonoBehaviour {

    public Camera cam;
    public LayerMask layers;

    public void Update() {

        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue()); //
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layers)) {

            if (Mouse.current.leftButton.wasPressedThisFrame) {

                if(hit.transform.root != GameManager.localPlayer.transform) {

                    Interactable interactable = 
                        TryGetInteractable(hit.transform);

                    if (interactable != null) {

                        GameManager.localPlayer?.movement.MoveTowards(interactable);

                    } else {

                        GameManager.localPlayer?.movement.TryMoveTo(hit.point);
                    }

                }
            }
        }
    }

    private Interactable TryGetInteractable(Transform startingObject) {

        Transform parent = startingObject;
        while (parent != null) {

            if (parent.CompareTag("Interactable")) return parent.GetComponent<Interactable>();
            else parent = parent.transform.parent;
        }

        return null;
    } 
}
