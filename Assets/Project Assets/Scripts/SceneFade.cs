using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Events;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class SceneFade : MonoBehaviour {

    private static SceneFade m;

    public Image bg;
    public AudioMixer mixer;

    private Tween fadeOutTween = null;
    private Tween fadeInTween = null;

    private void Awake() {

        if (m != null) Destroy(this.gameObject);
        else m = this;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start() =>
        DontDestroyOnLoad(gameObject);

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) {

        FadeOut();
    }

    public static void FadeIn() {

        m.bg.DOKill();
        m.fadeInTween = m.bg.DOFade(1.0f, 0.7f).OnComplete(() => m.fadeInTween = null);
        //m.mixer.DOSetFloat("bgmVolume", -80.0f, 0.7f);
    }

    public static void FadeOut() {

        if (m.fadeOutTween != null) //on additive scene load this gets called more than once
            return; //

        m.bg.DOKill();
        m.fadeOutTween = m.bg.DOFade(0.0f, 1.0f).OnComplete(() => m.fadeOutTween = null);
        //m.mixer.DOSetFloat("bgmVolume", Player.localPlayerData.audio_settings_bgmVolume, 0.35f);
    }

    public static bool AbleToInteract() {

        if (m.fadeInTween != null || m.bg.color.a == 1.0f)
            return false;
        else
            return true;
    }
}

