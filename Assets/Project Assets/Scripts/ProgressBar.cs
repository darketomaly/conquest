using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ProgressBar : MonoBehaviour {

    public float maximum = 1;
    [SerializeField] private float _value;
    [SerializeField] private Image fill;
    [HideInInspector] public int percentage;

    private Tween fillTween;
    private Tween percentageTween;

    public float value {

        get { return _value; }
        set {

            if (value == _value) return; //no change

            if (value > maximum) 
                _value = maximum;
             else 
                _value = value;

            //fill.fillAmount = _value / maximum;
            //percentage = (int)((_value / maximum) * 100.0f);

            DOTween.To(()=> fill.fillAmount, x=> fill.fillAmount = x, _value / maximum, 0.25f);
            DOTween.To(()=> percentage, x=> percentage = x, (int)((_value / maximum) * 100.0f), 0.25f);
        }
    }

    private void OnDestroy() {

        fillTween.Kill();
        percentageTween.Kill();
    }
}
