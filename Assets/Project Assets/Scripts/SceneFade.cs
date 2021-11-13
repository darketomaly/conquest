using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Conquest.PersistantManager;

public class SceneFade : MonoBehaviour {

    private static SceneFade m;

    public Image bg;

    private Tween fadeOutTween = null;
    private Tween fadeInTween = null;

    private void Awake() {

        if(PersistentManager.m.sceneFade != this)
            return;

        m = PersistentManager.m.sceneFade;
        FadeOut(3.0f);
        PersistentManager.m.audioManager.FadeSceneVolume(true);
    } 

    private void OnEnable() => PersistentManager.onSceneLoaded += delegate { FadeOut(); };

    private void OnDisable() => PersistentManager.onSceneLoaded -= delegate { FadeOut(); };
    
    public static void FadeIn() {

        if (m.fadeInTween != null) return;
        
        m.bg.DOKill();
        m.fadeInTween = m.bg.DOFade(1.0f, 0.35f).OnComplete(() => m.fadeInTween = null);
    }

    public static void FadeOut(float fadeDuration = 2.0f) {

        if(m.fadeInTween != null) {
        
            m.fadeInTween.OnComplete(delegate {
        
                m.bg.DOKill();
                m.fadeInTween = null;
                m.fadeInTween.Kill();
        
                m.fadeOutTween = 
                m.bg.DOFade(0.0f, fadeDuration).OnComplete(() => m.fadeOutTween = null).
                OnKill(()=> m.fadeOutTween = null);
            });
        } else {
        
            m.bg.DOKill();
            m.fadeOutTween = 
                m.bg.DOFade(0.0f, fadeDuration).OnComplete(() => m.fadeOutTween = null).
                OnKill(() => m.fadeOutTween = null);
        }
    }
}

