using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using Photon.Pun;
using Photon.Realtime;
using DG.Tweening;

namespace Conquest {

    public class ConnectToServer : MonoBehaviourPunCallbacks {

        public TextMeshProUGUI statusText;
        public TextMeshProUGUI percentageText;
        public CanvasGroup cg;
        public LoginManager loginManager;
        public TextMeshProUGUI versionText;

        private int step;
        private float lerpedStep;

        private bool fullyConnected;

        private void Awake() {

            //versionText.text = DevSettings.GameVersion;
        }

        private void Start() {

            if (PhotonNetwork.IsConnected) {

                if (PhotonNetwork.OfflineMode)
                    PhotonNetwork.OfflineMode = false;
                else
                    return;
            }

            Debug.Log("<color=green>Online mode enabled</color>");

            cg.DOFade(1.0f, 0.5f);

            //PhotonNetwork.GameVersion = DevSettings.GameVersion;
            PhotonNetwork.ConnectUsingSettings();
            statusText.text = "Connecting to server";
        }

        private void Update() {

            if (fullyConnected)
                return;

            switch (PhotonNetwork.NetworkClientState) {

                case ClientState.ConnectingToNameServer:

                    step = 1;
                    break;

                case ClientState.ConnectedToNameServer:

                    step = 2;
                    break;

                case ClientState.Authenticating:

                    step = 3;
                    break;

                case ClientState.ConnectingToMasterServer:

                    step = 4;
                    break;

                case ClientState.ConnectedToMasterServer:

                    step = 5;
                    break;

                case ClientState.JoiningLobby:

                    step = 6;
                    break;

                case ClientState.JoinedLobby:

                    step = 7;
                    break;

                default:
                    break;
            }

            lerpedStep = Mathf.MoveTowards(lerpedStep, step, 15.0f * Time.deltaTime);
            percentageText.text = $"{(int)(((float)lerpedStep / 7) * 100)}%";
        }

        public override void OnConnectedToMaster() {

            statusText.text = "Joining lobby";
            if (PhotonNetwork.IsConnected)
                PhotonNetwork.JoinLobby();
        }

        public override void OnJoinedLobby() {

            statusText.text = "Joined lobby";
            fullyConnected = true;
            loginManager.AllowEnter(true);
            cg.DOFade(0.0f, 0.75f);
        }

        private void OnDestroy() {

            cg.DOKill();
        }
    }
}
