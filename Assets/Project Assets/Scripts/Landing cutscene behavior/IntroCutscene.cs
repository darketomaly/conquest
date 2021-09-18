using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class IntroCutscene : MonoBehaviour {

    [Header("Fx")]
    public VolumeProfile volume;
    private ChromaticAberration chromaticAberration;
    private LiftGammaGain liftGammaGain;

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

    private void Awake() {

        DOTween.Init(); //
    }

    private IEnumerator Start() {

        StartCoroutine(MoveAgent());

        yield return new WaitForSeconds(0.20f);

        //fadeBg.DOFade(0.0f, 2.0f);
        SceneFade.FadeOut(2.5f);

        cam.DOMove(endTransform.position, positionTweenDuration);
        cam.DORotateQuaternion(endTransform.rotation, rotationTweenduration);

        //-----------

        volume.TryGet(out chromaticAberration);
        volume.TryGet(out liftGammaGain);
    }

    public void AnimateFx() {

        DOTween.To(()=> chromaticAberration.intensity.value, x=> chromaticAberration.intensity.value = x, 1.0f, 0.35f);
        DOTween.To(()=> liftGammaGain.lift.value, x=> liftGammaGain.lift.value = x, new Vector4(1, 1, 1, -0.125f), 0.55f);
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

        cam.DOKill();
        chromaticAberration.intensity.value = 0.0f;
        liftGammaGain.lift.value = new Vector4(1, 1, 1, 0.0f);
    }
}
