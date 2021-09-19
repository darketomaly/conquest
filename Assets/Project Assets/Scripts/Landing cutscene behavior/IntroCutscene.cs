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
    public CinemachineCameraOffset offsetComponent;
    private Vector3 offset;

    private void Awake() =>
        DOTween.Init();

    private IEnumerator Start() {

        yield return new WaitForSeconds(0.1f);

        volume.TryGet(out chromaticAberration);
        volume.TryGet(out liftGammaGain);

        chromaticAberration.intensity.value = 1.0f;
        liftGammaGain.lift.value = new Vector4(1, 1, 1, -0.125f);

        SceneFade.FadeOut(2.0f);
        AnimateFx(true);
        Application.targetFrameRate = 60;
    }

    public void AnimateFx(bool fadeOut) { //also called on click

        if (!fadeOut) {

            DOTween.To(() => chromaticAberration.intensity.value, x => chromaticAberration.intensity.value = x, 1.0f, 0.35f);
            DOTween.To(() => liftGammaGain.lift.value, x => liftGammaGain.lift.value = x, new Vector4(1, 1, 1, -0.125f), 0.35f);

        } else {

            DOTween.To(() => chromaticAberration.intensity.value, x => chromaticAberration.intensity.value = x, 0.0f, 1.15f);
            DOTween.To(() => liftGammaGain.lift.value, x => liftGammaGain.lift.value = x, new Vector4(1, 1, 1, 0.0f), 0.35f); //
        }
    }

    private void Update() {

        offset = Vector3.Lerp(offset, Mouse.current.delta.ReadValue(), 0.125f * Time.deltaTime);
        offset = Vector3.ClampMagnitude(offset, 0.25f);

        offsetComponent.m_Offset.x = Mathf.Lerp(offsetComponent.m_Offset.x, offset.x, 0.5f * Time.deltaTime);
        offsetComponent.m_Offset.y = Mathf.Lerp(offsetComponent.m_Offset.y, offset.y, 0.5f * Time.deltaTime);
    }

    private void OnDestroy() {

        chromaticAberration.intensity.value = 0.0f;
        liftGammaGain.lift.value = new Vector4(1, 1, 1, 0.0f);
    }
}
