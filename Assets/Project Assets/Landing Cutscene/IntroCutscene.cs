using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using DG.Tweening;

public class IntroCutscene : MonoBehaviour {

    [Header("UI")]
    public Image fadeBg;

    [Header("Camera")]
    public Transform cam;
    public Transform endTransform;
    public float positionTweenDuration;
    public float rotationTweenduration;

    [Header("Npc")]
    public NavMeshAgent agent;
    public Transform endPosition;
    public Animator animator;

    IEnumerator Start() {

        yield return new WaitForSeconds(0.25f);

        fadeBg.DOFade(0.0f, 1.25f);

        cam.DOMove(endTransform.position, positionTweenDuration);
        cam.DORotateQuaternion(endTransform.rotation, rotationTweenduration);

        StartCoroutine(MoveAgent());
    }

    private IEnumerator MoveAgent() {

        agent.SetDestination(endPosition.position);

        yield return new WaitForSeconds(0.05f); //skip a frame until agent starts moving

        while (true) {

            if (agent.remainingDistance < 0.15f) {

                animator.SetFloat("velocity", 0.0f);
                yield break;
            }

            animator.SetFloat("velocity", agent.velocity.magnitude);
            yield return null;
        }
    }

    private void OnDestroy() {

        fadeBg.DOKill();
        cam.DOKill();
    }
}
