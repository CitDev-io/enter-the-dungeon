using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyRoomPlayer : NetworkRoomPlayer
{
    [SyncVar]
    public int number = 100;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            number += 1;
            Debug.Log("clicked");
        }
    }
}
