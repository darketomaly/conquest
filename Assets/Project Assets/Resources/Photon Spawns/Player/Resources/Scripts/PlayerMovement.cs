using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using UnityEngine.AI;
using System;

public class PlayerMovement : MonoBehaviour {

    public Action whileMovementWasDisabled;

    [SerializeField] private ParticleSystem destinationParticle;
    private PhotonView photonView;
    private NavMeshAgent agent;

    private Interactable focus;
    private Coroutine movingTowardsInteractable;
    public bool movementDisabled;

    [SerializeField] private Animator animator;
    private float velocity;

    private void Awake() {

        photonView = GetComponent<PhotonView>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {

        animator.SetFloat("velocity", agent.velocity.magnitude);
    }

    #region Movement

    public void TryMoveTo(Vector3 desiredPosition, Interactable interactable = null) {

        NavMeshPath path = new NavMeshPath();
        Vector3 particlePosition;

        if (!movementDisabled) {

            MoveTo(desiredPosition);
            particlePosition = agent.destination;

        } else {

            //invoked once the agent can move
            whileMovementWasDisabled = delegate {

                if (interactable != null)
                    MoveTowards(interactable, false);
                else MoveTo(desiredPosition);

                whileMovementWasDisabled = null;
            };

            agent.CalculatePath(desiredPosition, path);
            if (path.corners.Length > 0)
                particlePosition = path.corners[path.corners.Length - 1]; //destination if agent could move
            else particlePosition = agent.transform.position;
            //Debug.DrawLine(agent.transform.position, path.corners[path.corners.Length - 1], Color.green, 1.0f);
        }

        ParticleSystem.MainModule module = destinationParticle.main;

        if (interactable != null)
            module.startColor = Color.red;
        else
            module.startColor = Color.white;

        Instantiate(destinationParticle, particlePosition, transform.rotation * Quaternion.Euler(-90.0f, 0.0f, 0.0f));
    }

    public void MoveTo(Vector3 desiredPosition) {

        if (focus) {

            focus.OnDefocus();
            focus = null;
        }

        if (movingTowardsInteractable != null) StopCoroutine(movingTowardsInteractable);

        agent.SetDestination(desiredPosition);
    }

    public void MoveTowards(Interactable interactable, bool executeTryMoveTo = true) {

        movingTowardsInteractable =
            StartCoroutine(_MoveTowards(interactable, executeTryMoveTo));
    }

    private Vector3 interactableDesiredDestination(Interactable interactable) {

        if (interactable.overrideDestination)
            return interactable.overrideDestination.position;
        else 
            return interactable.m_collider.ClosestPointOnBounds(transform.position);
    }

    private IEnumerator _MoveTowards(Interactable interactable, bool executeTryMoveTo = true) {

        if(executeTryMoveTo)
            TryMoveTo(interactableDesiredDestination(interactable), interactable);
        if (movementDisabled) yield break;

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

                StartCoroutine(RotateTowards(interactableDesiredDestination(interactable)));
                yield break;
            }

            yield return new WaitForSeconds(0.05f);
        }

    }

    #endregion

    private float turn;

    //placeholder test
    private IEnumerator RotateTowards(Vector3 lookAt) {

        yield return null;

        Vector3 dir = lookAt - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dir);

        Debug.Log(rotation.eulerAngles.magnitude);
    }
}
