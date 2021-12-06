using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyRoomPlayer : NetworkRoomPlayer
{
    [SyncVar]
    public int number = 100;

    void Update() {
        if (!isLocalPlayer) return;

        if (Input.GetMouseButtonDown(0)) {
            CmdTallyMe();
        }
    }

    [Command]
    public void CmdTallyMe() {
        number += 1;
        Debug.Log("clicked");
    }
}
