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
    public struct ActionMapActions
    {
        private @Control m_Wrapper;
        public ActionMapActions(@Control wrapper) { m_Wrapper = wrapper; }
        public InputAction @Zoom => m_Wrapper.m_actionMap_Zoom;
        public InputAction @KeyPressZoom => m_Wrapper.m_actionMap_KeyPressZoom;
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
            }
        }
    }
    public ActionMapActions @actionMap => new ActionMapActions(this);
    public interface IActionMapActions
    {
        void OnZoom(InputAction.CallbackContext context);
        void OnKeyPressZoom(InputAction.CallbackContext context);
    }
}
