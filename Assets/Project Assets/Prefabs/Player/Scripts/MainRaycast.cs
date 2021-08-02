using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainRaycast : MonoBehaviour {

    private Camera cam;
    private Ray ray;
    private RaycastHit hit;

    private void Start() =>
        cam = FindObjectOfType<Camera>();

    private void Update() { //can use a callback instead of checking every frame
                            //but if in a future we want to implement tooltips behavior they will be called here

        if (Mouse.current.leftButton.wasPressedThisFrame) 
            StartRay();
    }

    private void StartRay() {

        ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit))
            Debug.Log($"clicked {hit.transform.name}");
    }
}

