using Conquest.Audio;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Conquest {

    public class Player : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback {

        public PlayerMovement movement;

        public void OnPhotonInstantiate(PhotonMessageInfo info) {

            if (SceneManager.GetActiveScene().buildIndex != 0) //test
                AudioManager.Play2D(Music.ForestOfEmbracing);
        }

        public void LeaveRoom() {

            SceneFade.FadeIn();
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LoadLevel("Title Screen");
        }

        private void Update() {

            //testing
            if (Keyboard.current.spaceKey.wasPressedThisFrame) {

                if (PhotonNetwork.InRoom)
                    LeaveRoom();

            } else if (Keyboard.current.xKey.wasPressedThisFrame)
                AudioManager.Play2D(Sfx.FootstepRock);
        }
    }
}
