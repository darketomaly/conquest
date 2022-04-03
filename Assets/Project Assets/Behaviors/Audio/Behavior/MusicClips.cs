using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Conquest.Audio {

    [CreateAssetMenu(fileName = "Music clips", menuName = "Conquest/Audio/Music clip group")]
    public class MusicClips : ScriptableObject {

        public MusicClipReference[] clips;

        [System.Serializable]
        public struct MusicClipReference {

            public Music musicClip;
            public AudioClip clip;
        }
    }
}