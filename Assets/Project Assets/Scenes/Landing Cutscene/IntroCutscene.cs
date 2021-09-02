using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.InputSystem;

public class IntroCutscene : MonoBehaviour {

    [Header("UI")]
    public Image fadeBg;

    [Header("Camera")]
    public Transform cam;
    public CinemachineCameraOffset offsetComponent;
    public Transform endTransform;
    public float positionTweenDuration;
    public float rotationTweenduration;
    private Vector3 offset;

    [Header("Npc")]
    public NavMeshAgent agent;
    public Transform endPosition;
    public Animator animator;

    private IEnumerator Start() {

        StartCoroutine(MoveAgent());

        yield return new WaitForSeconds(0.20f);

        //fadeBg.DOFade(0.0f, 2.0f);
        SceneFade.FadeOut(2.5f);

        cam.DOMove(endTransform.position, positionTweenDuration);
        cam.DORotateQuaternion(endTransform.rotation, rotationTweenduration);
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

    private void Update() {

        offset = Vector3.Lerp(offset, Mouse.current.delta.ReadValue(), 0.125f * Time.deltaTime);
        offset = Vector3.ClampMagnitude(offset, 0.25f);

        offsetComponent.m_Offset.x = Mathf.Lerp(offsetComponent.m_Offset.x, offset.x, 1.0f * Time.deltaTime);
        offsetComponent.m_Offset.y = Mathf.Lerp(offsetComponent.m_Offset.y, offset.y, 1.0f * Time.deltaTime);
    }

    private void OnDestroy() {

        fadeBg.DOKill();
        cam.DOKill();
    }
}
