using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using Photon.Pun;

public class CameraMovement : MonoBehaviour {

    public InputActionReference movementNoMouse;
    public InputActionReference movementWithMouse;

    private CinemachineVirtualCamera virtualCamera;
    private CinemachineFramingTransposer transposer;
    private CinemachineInputProvider inputProvider;

    private PlayerMovement playerMovement;
    private Control control;

    private float requestedToZoom;

    private void Awake() {

        control = new Control();
        control.actionMap.Zoom.performed += x => { Zoom(-x.ReadValue<float>()); };
        control.actionMap.KeyPressZoom.started += x => { requestedToZoom = -x.ReadValue<float>(); };
        control.actionMap.KeyPressZoom.canceled += delegate { requestedToZoom = 0; };

        //mouse middle button, allow mouse camera movement
        control.actionMap.MouseMiddleButton.started += delegate { 
            
            inputProvider.XYAxis = movementWithMouse;
            virtualCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = 125;
            virtualCamera.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = 125;
        };

        control.actionMap.MouseMiddleButton.canceled += delegate {
            inputProvider.XYAxis = movementNoMouse; 
            virtualCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = 250;
            virtualCamera.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = 250;
        };
    }

    private void OnEnable() => control.Enable();

    private void OnDisable() => control.Disable();

    private IEnumerator Start() {

        playerMovement = GameManager.localPlayer.movement;

        CinemachineBrain brain = Camera.main.GetComponent<CinemachineBrain>();

        while(brain.ActiveVirtualCamera == null) //tiny delay
            yield return null;

        virtualCamera = brain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        transposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        virtualCamera.Follow = playerMovement.transform;
        inputProvider = virtualCamera.GetComponent<CinemachineInputProvider>();
    }

    private void Update() {

        if(requestedToZoom != 0) //zoom from key press
            Zoom(requestedToZoom * Time.deltaTime * 15.0f);
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
