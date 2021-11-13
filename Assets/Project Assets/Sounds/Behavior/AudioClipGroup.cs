using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Audio clip group", menuName ="Conquest/Audio clip grouop")]
public class AudioClipGroup : ScriptableObject {

    public AudioType audioType;

    public AudioClipReference[] clips;

    [System.Serializable]
    public struct AudioClipReference {

        [Header("Assign one depending on type. Needs custom editor.")]
        public Music musicClip;
        public SoundEffect sfxClip;

        [Space]
        public AudioClip clip;
    }

    public enum AudioType {

        Music,
        SoundEffect,
        Ambience
    }
}

#if UNITY_EDITOR

#endif

