using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class CustomSceneManager {

    public static async void LoadScene(string sceneName, bool networked) {

        SceneFade.FadeIn();
        await Task.Delay(System.TimeSpan.FromSeconds(0.4f));

        if (networked) {

            PhotonNetwork.LoadLevel(sceneName);

        } else {

            SceneManager.LoadScene(sceneName);
        }
    }
}
