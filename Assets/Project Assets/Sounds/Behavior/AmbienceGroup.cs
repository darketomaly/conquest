using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Conquest.Audio {

    [CreateAssetMenu(fileName = "Ambience clips", menuName = "Conquest/Audio/Ambience clip group")]
    public class AmbienceGroup : ScriptableObject {

        public AmbienceClipReference[] clips;
    }

    [System.Serializable]
    public struct AmbienceClipReference {

        public Sfx sfxClip;
        public AudioClip clip;
    }
}
