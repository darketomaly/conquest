using Conquest.PersistantManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private static AudioManager m;

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClipGroup[] groups;

    private Dictionary<string, AudioClip> dictionary;

    private void Awake() {

        if(PersistentManager.m.audioManager != this)
            return;

        m = PersistentManager.m.audioManager;

        dictionary = new Dictionary<string, AudioClip>();

        foreach(AudioClipGroup group in groups) {
       
            foreach(var clip in group.clips) {

                if(group.audioType == AudioClipGroup.AudioType.Music)
                    dictionary.Add(clip.musicClip.ToString(), clip.clip);
                else if (group.audioType == AudioClipGroup.AudioType.SoundEffect)
                    dictionary.Add(clip.sfxClip.ToString(), clip.clip);
            }
        }

        Debug.Log($"Audio manager dictionary setup. Total clips: {dictionary.Count}");
    }

    public static void Play2D(SoundEffect sfx) {

        m.source.PlayOneShot(m.GetClip(sfx));
    }

    public static void Play2D(Music music) { }

    public AudioClip GetClip(Music music) =>     dictionary[music.ToString()];
    
    public AudioClip GetClip(SoundEffect sfx) => dictionary[sfx.ToString()];
}



