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

    public void MoveTo(Vector3 desiredPosition) {

        if (focus) {

            focus.OnDefocus();
            focus = null;
        }

        agent.SetDestination(desiredPosition);

        //To do: Movement point decal/particle here
        Instantiate(destinationParticle, desiredPosition, Quaternion.identity);
    }

    public void MoveTowards(Interactable interactable) {

        StartCoroutine(_MoveTowards(interactable));
    }

    private IEnumerator _MoveTowards(Interactable interactable) {

        MoveTo(interactable.m_collider.ClosestPointOnBounds(transform.position));

        while (true) {

            //look for closest point as you move in new directions
            agent.SetDestination(interactable.m_collider.ClosestPointOnBounds(transform.position));

            yield return null; //skip a frame until agent starts moving

            if (agent.remainingDistance < 0.35f) {

                if(interactable.needsToBeReachedToInteract &&
                    Vector3.Distance(transform.position, interactable.m_collider.ClosestPointOnBounds(transform.position)) > 1.25) {
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
