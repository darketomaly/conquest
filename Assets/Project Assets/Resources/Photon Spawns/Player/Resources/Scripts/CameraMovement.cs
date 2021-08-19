using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CameraMovement : MonoBehaviour {

    private CinemachineVirtualCamera virtualCamera;
    private CinemachineFramingTransposer transposer;
    private CinemachinePOV pov;
    private PlayerMovement playerMovement;
    private Control control;

    private float requestedToZoom;

    private void Awake() {

        control = new Control();
        control.actionMap.Zoom.performed += x => { Zoom(-x.ReadValue<float>()); };
        control.actionMap.KeyPressZoom.started += x => { requestedToZoom = -x.ReadValue<float>(); };
        control.actionMap.KeyPressZoom.canceled += delegate { requestedToZoom = 0; };
    }

    private void OnEnable() => control.Enable();

    private void OnDisable() => control.Disable();

    private void Start() {

        playerMovement = GameManager.localPlayer.movement;
        virtualCamera = 
            Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        transposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        pov = virtualCamera.GetCinemachineComponent<CinemachinePOV>();
        virtualCamera.Follow = playerMovement.transform;
    }

    private void Update() {

        if (requestedToZoom != 0) //zoom from key press
            Zoom(requestedToZoom * Time.deltaTime * 15.0f);

        if (Keyboard.current.spaceKey.isPressed) {

            pov.m_HorizontalAxis.Value += 25.0f * Time.deltaTime;
        }
    }

    private void Zoom(float amount) {

        //if (amount == 0) return;
        amount = Mathf.Clamp(amount, -1, 1);

        if (amount > 0) {

            if(transposer.m_CameraDistance < 10)
                transposer.m_CameraDistance += amount;

        } else if (amount < 0) {

            if(transposer.m_CameraDistance > 4)
                transposer.m_CameraDistance += amount;
        }
    }
}
