using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Similar to network manager HUD but with custom buttons
/// Eventually will be the login and signup manager
/// </summary>
public class NetworkManagerUI : MonoBehaviour {

    public GameObject wrap;

    public void StartHost(bool value) {

        if (value)
            ExtendedNetworkManager.singleton.StartHost();
        else ExtendedNetworkManager.singleton.StopHost();
    }

    public void StartClient(bool value) {

        if (value)
            ExtendedNetworkManager.singleton.StartClient();
        else ExtendedNetworkManager.singleton.StopClient();
    }

    public void StartServer(bool value) {

        if (value)
            ExtendedNetworkManager.singleton.StartServer();
        else ExtendedNetworkManager.singleton.StopServer();
    }
}
