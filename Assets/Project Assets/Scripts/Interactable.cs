using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    [Header("Interactable")]
    public Collider m_collider;
    public bool needsToBeReachedToInteract;

    public virtual void OnFocus() {

        Debug.Log($"Focused on {transform.name}.");
    }

    public virtual void OnDefocus() { 
                                      

        Debug.Log($"Defocused from {transform.name}.");
    }
}
