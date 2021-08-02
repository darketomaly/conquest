using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class ExtendedNetworkManager : NetworkManager {

    /// <summary>
    /// Called on the server when a client is ready.
    /// </summary>
    public static event Action<NetworkConnection> onServerReadied;

    public override void OnServerReady(NetworkConnection conn) {

        base.OnServerReady(conn);
        onServerReadied?.Invoke(conn);
    }
}
