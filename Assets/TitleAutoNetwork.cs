using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TitleAutoNetwork : MonoBehaviour
{
    void Start() {
        #if UNITY_EDITOR
            NetManager.instance.StartHost();
        #elif UNITY_SERVER
            NetManager.instance.StartHost();
        #else
            NetManager.instance.StartClient();
        #endif
    }
}
