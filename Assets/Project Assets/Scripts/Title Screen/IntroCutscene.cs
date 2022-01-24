using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class IntroCutscene : MonoBehaviour {

    [Header("Fx")]
    [SerializeField] private VolumeProfile volume;
    private ChromaticAberration chromaticAberration;
    private LiftGammaGain liftGammaGain;

    [Header("Camera")]
    [SerializeField] private Transform vCam;
    [SerializeField] private Transform cameraStartTransform;
    [SerializeField] private Transform cameraEndTransform;
    [SerializeField] private CinemachineCameraOffset offsetComponent;
    private Vector3 offset;

    private void Awake() =>
        DOTween.Init();

    private IEnumerator Start() {

        vCam.position = cameraStartTransform.position;
        vCam.rotation = cameraStartTransform.rotation;

        vCam.DOMove(cameraEndTransform.position, 5.0f);
        vCam.DORotateQuaternion(cameraEndTransform.rotation, 7.0f);

        yield return new WaitForSeconds(0.1f);

        volume.TryGet(out chromaticAberration);
        volume.TryGet(out liftGammaGain);

        chromaticAberration.intensity.value = 1.0f;

        //math is not neccessary
        //still getting that small 'bug' where the lift value is off with the scene fade's alpha

        float a = SceneFade.GetCurrentAlpha();

        float a0 = 1;
        float a1 = 0;
        float b0 = -0.125f;
        float b1 = 0;
        float w = b0 + (b1 - b0) * ((a - a0) / (a1 - a0));

        liftGammaGain.lift.value = new Vector4(1, 1, 1, w);

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

        offsetComponent.m_Offset.x = Mathf.Lerp(offsetComponent.m_Offset.x, offset.x, 0.15f * Time.deltaTime);
        offsetComponent.m_Offset.y = Mathf.Lerp(offsetComponent.m_Offset.y, offset.y, 0.15f * Time.deltaTime);
    }

    private void OnDestroy() {

        vCam.DOKill();

        if(chromaticAberration)
            chromaticAberration.intensity.value = 0.0f;

        if(liftGammaGain)
            liftGammaGain.lift.value = new Vector4(1, 1, 1, 0.0f);
    }
}
