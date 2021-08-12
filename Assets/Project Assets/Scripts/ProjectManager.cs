using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class ProjectManager {

    #region Networking

    /// <summary>
    /// Offline mode should only be used for developers. There is no plan to support offline mode for release builds.
    /// </summary>
    [MenuItem("Conquest/ScriptableObjects/Create Unit")]
    public static void EnableOfflineMode() {

        Debug.Log("Create unit scriptable object here.");
    }

    #endregion

}
