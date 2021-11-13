using Conquest.Audio;
using Conquest.PersistantManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    private static AudioManager m;

    [SerializeField] private AudioMixer mixer;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioSource musicSource1;

    [SerializeField] private MusicGroup musicGroup;
    [SerializeField] private SfxGroup sfxGroup;
    [SerializeField] private AmbienceGroup ambienceGroup;

    private Dictionary<string, AudioClip> dictionary;

    private void Awake() {

        if(PersistentManager.m.audioManager != this)
            return;

        m = PersistentManager.m.audioManager;

        dictionary = new Dictionary<string, AudioClip>();

        foreach(var item in musicGroup.clips)
            dictionary.Add(item.musicClip.ToString(), item.clip);

        foreach(var item in sfxGroup.clips)
            dictionary.Add(item.sfxClip.ToString(), item.clip);

        foreach(var item in ambienceGroup.clips)
            dictionary.Add(item.sfxClip.ToString(), item.clip);

        Debug.Log($"Audio manager dictionary setup. Total clips: {dictionary.Count}");
        Play2D(Music.IAmJustice);
    }

    private void OnEnable() {

        PersistentManager.onSceneLoaded += delegate {

            FadeSceneVolume(false);
        };
    }

    private void OnDisable() {

        PersistentManager.onSceneLoaded -= delegate {

            FadeSceneVolume(false);
        };
    }

    public void FadeSceneVolume(bool In) {

        //to do
        //crossfade

        if(In) {
        
            mixer.DOSetFloat("sceneVolume", 0.0f, 1.5f);
        
        } else {
        
            mixer.DOSetFloat("sceneVolume", -80.0f, 1.5f);
        }
    }

    public static void Play2D(Sfx sfx) {

        m.source.PlayOneShot(m.GetClip(sfx));
    }

    public static void Play2D(Music music) {

        m.musicSource1.clip = m.GetClip(music);
        m.musicSource1.Play();
    }

    public AudioClip GetClip(Music music) =>     dictionary[music.ToString()];
    
    public AudioClip GetClip(Sfx sfx) => dictionary[sfx.ToString()];
}



