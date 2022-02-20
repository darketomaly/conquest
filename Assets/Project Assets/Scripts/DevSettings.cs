using Conquest.PersistantManager;
using UnityEngine;

public class DevSettings : MonoBehaviour {

    private static DevSettings m;

    [SerializeField] private string gameVersion;

    public static string GameVersion => m.gameVersion; 

    private void Awake() {

        m = PersistentManager.m.devSettings;
    }
}
