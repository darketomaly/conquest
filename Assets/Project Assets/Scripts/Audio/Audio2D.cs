using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio2D : MonoBehaviour {

    private static Audio2D m;

    [SerializeField] private AudioSource source;
    private AudioClip[] audioClips;
    private Dictionary<string, int> dTest = new Dictionary<string, int>();

    private void Awake() {

        m = this;
        m.audioClips = Resources.LoadAll<AudioClip>("Audio");

        for (int i = 0; i < m.audioClips.Length; i++)
            dTest.Add(m.audioClips[i].name, i);
    }

    /// <summary>
    /// Reference a clip from Clips. Example: Clips.UI.UIHover
    /// </summary>
    public static void PlayClip(object clip) =>
        m.source.PlayOneShot(m.audioClips[m.dTest[clip.ToString()]]);
}

