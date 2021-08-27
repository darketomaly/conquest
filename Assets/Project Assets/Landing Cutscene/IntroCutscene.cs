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

    IEnumerator Start() {

        yield return new WaitForEndOfFrame();

        fadeBg.DOFade(0.0f, 0.75f);

        cam.DOMove(endTransform.position, positionTweenDuration);
        cam.DORotateQuaternion(endTransform.rotation, rotationTweenduration);

        agent.SetDestination(endPosition.position);
    }

    private void OnDestroy() {

        fadeBg.DOKill();
    }
}
