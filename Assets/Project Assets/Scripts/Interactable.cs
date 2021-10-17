using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    [Header("Interactable")]
    [Tooltip("Used to search the closest point in the agent's perspective. Leave blank if overriding destination.")] 
    public Collider m_collider;
    [Tooltip("Does the agent needs to be close to the object to interact with it?")]
    public bool needsToBeReachedToInteract = true;
    [Tooltip("If set, agent moves towards the given point instead.")] 
    public Transform overrideDestination;
    public bool rotateTowardsOnFocus = true;

    public virtual void OnFocus() {

        //Debug.Log($"Focused on {transform.name}.");
    }

    public virtual void OnDefocus() { 
                                      
        //Debug.Log($"Defocused from {transform.name}.");
    }
}


public class NPC : Interactable
{
    public NPC()
    {
        Console.WriteLine("NPC constructor.");
    }

    public static void Main()
    {
        NPC npc = new NPC();

        npc.print();
    }


}