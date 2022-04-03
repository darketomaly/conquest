using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using DG.Tweening;

namespace Conquest {

    public class LoginManager : MonoBehaviourPunCallbacks {

        public Button button;
        public CanvasGroup cg;

        private void Start() {

        }

        public void AllowEnter(bool value) {

            button.interactable = value;
            cg.DOFade(value ? 1.0f : 0.0f, 1.0f);
        }

        public void EnterRoom() {

            Debug.Log($"Attempting to join or create room");
            SceneFade.FadeIn();

            RoomOptions roomOptions = new RoomOptions() {

                PublishUserId = true
            };

            button.interactable = false;

            PhotonNetwork.JoinOrCreateRoom("world", roomOptions, TypedLobby.Default);
        }

        public override void OnCreateRoomFailed(short returnCode, string message) {

            Debug.Log($"Create room failed: {message}");
            button.interactable = true;
        }

        public override void OnJoinRoomFailed(short returnCode, string message) {

            Debug.Log($"Join room failed: {message}");
            button.interactable = true;
        }

        public override void OnJoinedRoom() {

            Debug.Log($"Joined room <color=olive>{PhotonNetwork.CurrentRoom.Name}</color>");
            PhotonNetwork.LoadLevel("Playground");
        }

        private void OnDestroy() {

            cg.DOKill();
        }
    }
}
