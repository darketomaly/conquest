using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GraphicRaycasterManager : MonoBehaviour {

    /// <summary>
    /// Returns the hovered graphic element.
    /// </summary>
    public static Action<Transform> onMouseOver;
    public static Action onNothingFound;

    private GraphicRaycaster raycaster;
    private PointerEventData pointerEventData;
    private EventSystem eventSystem;

    private void Start() {

        raycaster = FindObjectOfType<GraphicRaycaster>();
        eventSystem = FindObjectOfType<EventSystem>();
        pointerEventData = new PointerEventData(eventSystem);

        if (!raycaster){

            Debug.Log($"<color=red>Graphic raycaster not found in scene. Disabling {name}</color>"); //
            enabled = false;
        }
    }

    private void Update() {

        pointerEventData = new PointerEventData(EventSystem.current);

        pointerEventData.position = Mouse.current.position.ReadValue();

        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(pointerEventData, results);

        if (results.Count > 0)
            onMouseOver?.Invoke(results[0].gameObject.transform);
        else 
            onNothingFound?.Invoke();
    }

    private void OnDestroy() {

        onMouseOver = null;
        onNothingFound = null;
    }

}
