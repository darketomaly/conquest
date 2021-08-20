// GENERATED AUTOMATICALLY FROM 'Assets/Project Assets/Input management/Control.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Control : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Control()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Control"",
    ""maps"": [
        {
            ""name"": ""actionMap"",
            ""id"": ""726dcb6f-5813-44e2-9ca0-244db5f09726"",
            ""actions"": [
                {
                    ""name"": ""Zoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""28472803-62a4-4202-8292-dfdd575b8342"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""KeyPressZoom"",
                    ""type"": ""Button"",
                    ""id"": ""f7f1371d-ba29-418f-993f-dedcf97e865d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c714fa1c-ff1a-4ec2-808e-ae8498200b90"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraMovementWMouse"",
                    ""type"": ""PassThrough"",
                    ""id"": ""56c148c2-0f85-4a59-a067-e857bc58d8e5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseMiddleButton"",
                    ""type"": ""Button"",
                    ""id"": ""1bfc19c9-7c40-4efb-b491-987fdab13f08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cf6434d9-d88e-4618-86fc-f0dbe1d37502"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""PageUpDwn"",
                    ""id"": ""e8c3f4db-a302-46bd-b349-32f53fa1bad0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyPressZoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""be627462-f91c-4f02-b044-6644dca15112"",
                    ""path"": ""<Keyboard>/pageDown"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyPressZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""75708de8-ff2f-4050-90e2-86638114689c"",
                    ""path"": ""<Keyboard>/pageUp"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyPressZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e0a7996b-b305-4460-9149-eafe309c2217"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""375118f0-ea11-4004-af7d-4c23a2c2b742"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c58d9319-e8e1-4ae4-8b32-a9dc9a80f637"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0592dedc-7334-4639-84e2-de6acf968bcf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2294362c-eb1d-4414-9a54-2ce8c85072b3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3aac544c-068e-4941-afa4-4805f00ead48"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovementWMouse"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8c61d474-6064-43b7-93cc-ed80c4e6e8e8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovementWMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a4134b79-0135-405e-9df5-ea5a92d2df56"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovementWMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fc768f1d-64de-4388-bd89-ab2027bf3001"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovementWMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""992dc431-5bc0-47c0-9893-ce61a378e8d3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovementWMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c82d96de-95ba-437c-af27-8d2871a6586d"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertY=false)"",
                    ""groups"": """",
                    ""action"": ""CameraMovementWMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7866817c-6772-4df9-99ff-8f38a8411926"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMiddleButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // actionMap
        m_actionMap = asset.FindActionMap("actionMap", throwIfNotFound: true);
        m_actionMap_Zoom = m_actionMap.FindAction("Zoom", throwIfNotFound: true);
        m_actionMap_KeyPressZoom = m_actionMap.FindAction("KeyPressZoom", throwIfNotFound: true);
        m_actionMap_CameraMovement = m_actionMap.FindAction("CameraMovement", throwIfNotFound: true);
        m_actionMap_CameraMovementWMouse = m_actionMap.FindAction("CameraMovementWMouse", throwIfNotFound: true);
        m_actionMap_MouseMiddleButton = m_actionMap.FindAction("MouseMiddleButton", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // actionMap
    private readonly InputActionMap m_actionMap;
    private IActionMapActions m_ActionMapActionsCallbackInterface;
    private readonly InputAction m_actionMap_Zoom;
    private readonly InputAction m_actionMap_KeyPressZoom;
    private readonly InputAction m_actionMap_CameraMovement;
    private readonly InputAction m_actionMap_CameraMovementWMouse;
    private readonly InputAction m_actionMap_MouseMiddleButton;
    public struct ActionMapActions
    {
        private @Control m_Wrapper;
        public ActionMapActions(@Control wrapper) { m_Wrapper = wrapper; }
        public InputAction @Zoom => m_Wrapper.m_actionMap_Zoom;
        public InputAction @KeyPressZoom => m_Wrapper.m_actionMap_KeyPressZoom;
        public InputAction @CameraMovement => m_Wrapper.m_actionMap_CameraMovement;
        public InputAction @CameraMovementWMouse => m_Wrapper.m_actionMap_CameraMovementWMouse;
        public InputAction @MouseMiddleButton => m_Wrapper.m_actionMap_MouseMiddleButton;
        public InputActionMap Get() { return m_Wrapper.m_actionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IActionMapActions instance)
        {
            if (m_Wrapper.m_ActionMapActionsCallbackInterface != null)
            {
                @Zoom.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnZoom;
                @KeyPressZoom.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnKeyPressZoom;
                @KeyPressZoom.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnKeyPressZoom;
                @KeyPressZoom.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnKeyPressZoom;
                @CameraMovement.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnCameraMovement;
                @CameraMovementWMouse.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnCameraMovementWMouse;
                @CameraMovementWMouse.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnCameraMovementWMouse;
                @CameraMovementWMouse.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnCameraMovementWMouse;
                @MouseMiddleButton.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMouseMiddleButton;
                @MouseMiddleButton.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMouseMiddleButton;
                @MouseMiddleButton.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMouseMiddleButton;
            }
            m_Wrapper.m_ActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @KeyPressZoom.started += instance.OnKeyPressZoom;
                @KeyPressZoom.performed += instance.OnKeyPressZoom;
                @KeyPressZoom.canceled += instance.OnKeyPressZoom;
                @CameraMovement.started += instance.OnCameraMovement;
                @CameraMovement.performed += instance.OnCameraMovement;
                @CameraMovement.canceled += instance.OnCameraMovement;
                @CameraMovementWMouse.started += instance.OnCameraMovementWMouse;
                @CameraMovementWMouse.performed += instance.OnCameraMovementWMouse;
                @CameraMovementWMouse.canceled += instance.OnCameraMovementWMouse;
                @MouseMiddleButton.started += instance.OnMouseMiddleButton;
                @MouseMiddleButton.performed += instance.OnMouseMiddleButton;
                @MouseMiddleButton.canceled += instance.OnMouseMiddleButton;
            }
        }
    }
    public ActionMapActions @actionMap => new ActionMapActions(this);
    public interface IActionMapActions
    {
        void OnZoom(InputAction.CallbackContext context);
        void OnKeyPressZoom(InputAction.CallbackContext context);
        void OnCameraMovement(InputAction.CallbackContext context);
        void OnCameraMovementWMouse(InputAction.CallbackContext context);
        void OnMouseMiddleButton(InputAction.CallbackContext context);
    }
}
