using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Conquest.Audio {

    [CreateAssetMenu(fileName = "Sfx clips", menuName = "Conquest/Audio/Sfx clip group")]
    public class SfxClips : ScriptableObject {

        public SfxClipReference[] clips;

        [System.Serializable]
        public struct SfxClipReference {

            public Sfx sfxClip;
            public AudioClip clip;
        }
    }
}