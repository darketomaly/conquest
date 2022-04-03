using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Conquest.Audio;

namespace Conquest {

    public class SceneFade : MonoBehaviour {

        private static SceneFade m;

        public Image bg;

        private Tween fadeOutTween = null;
        private Tween fadeInTween = null;

        private void Awake() {

            if (PersistentManager.m.sceneFade != this)
                return;

            m = PersistentManager.m.sceneFade;
            FadeOut(3.0f);

            PersistentManager.m.audioManager.FadeInMasterVolume();
        }

        private void OnEnable() => PersistentManager.onSceneLoaded += delegate { FadeOut(); };

        private void OnDisable() => PersistentManager.onSceneLoaded -= delegate { FadeOut(); };

        public static void FadeIn() {

            if (m.fadeInTween != null)
                return;

            PersistentManager.m.audioManager.FadeSceneVolume(false);

            m.bg.DOKill();
            m.fadeInTween = m.bg.DOFade(1.0f, 0.35f).OnComplete(() => m.fadeInTween = null);
        }

        public static void FadeOut(float fadeDuration = 2.0f) {

            if (m.fadeOutTween != null)
                return;

            PersistentManager.m.audioManager.FadeSceneVolume(true);

            if (SceneManager.GetActiveScene().name == "Title Screen")
                AudioManager.Play2D(Music.IAmJustice);

            if (m.fadeInTween != null) {

                m.fadeInTween.OnComplete(delegate {

                    m.bg.DOKill();
                    m.fadeInTween = null;

                    m.fadeOutTween =
                    m.bg.DOFade(0.0f, fadeDuration).OnComplete(() => m.fadeOutTween = null).
                    OnKill(() => m.fadeOutTween = null);
                });
            } else {

                m.bg.DOKill();
                m.fadeOutTween =
                    m.bg.DOFade(0.0f, fadeDuration).OnComplete(() => m.fadeOutTween = null).
                    OnKill(() => m.fadeOutTween = null);
            }
        }

        public static float GetCurrentAlpha() {

            return m.bg.color.a;
        }
    }
}

