using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private ParticleSystem destinationParticle;
    private PhotonView photonView;
    private NavMeshAgent agent;

    private Interactable focus;

    private void Awake() {

        photonView = GetComponent<PhotonView>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveTo(Vector3 desiredPosition, bool colorDestinationParticle = false) {

        if (focus) {

            focus.OnDefocus();
            focus = null;
        }

        agent.SetDestination(desiredPosition);


        ParticleSystem.MainModule module = destinationParticle.main;
        if (colorDestinationParticle) {

            module.startColor = Color.red;
        } else {

            module.startColor = Color.white;
        }

        Instantiate(destinationParticle, agent.destination, transform.rotation * Quaternion.Euler(-90.0f, 0.0f, 0.0f)); //
    }

    public void MoveTowards(Interactable interactable) {

        StartCoroutine(_MoveTowards(interactable));
    }

    private Vector3 interactableDesiredDestination(Interactable interactable) {

        if (interactable.overrideDestination)
            return interactable.overrideDestination.position;
        else 
            return interactable.m_collider.ClosestPointOnBounds(transform.position);
    }

    private IEnumerator _MoveTowards(Interactable interactable) {

        MoveTo(interactableDesiredDestination(interactable), true);

        while (true) {

            agent.SetDestination(interactableDesiredDestination(interactable));

            yield return null; //skip a frame until agent starts moving

            if (agent.remainingDistance < 0.35f) {

                if(interactable.needsToBeReachedToInteract &&
                    Vector3.Distance(transform.position, interactableDesiredDestination(interactable)) > 1.25) {
                    //note: distance check needs to have a little offset since agent hasn't stopped moving (0.35f remaining distance)
                    Debug.Log($"<color=red>{interactable.transform.name}</color> unreachable.");

                } else {

                    focus = interactable;
                    interactable.OnFocus();
                }

                yield break;
            }

            yield return new WaitForSeconds(0.05f);
        }
    }
}
