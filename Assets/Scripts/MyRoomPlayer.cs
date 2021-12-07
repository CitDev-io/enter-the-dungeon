using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyRoomPlayer : NetworkRoomPlayer
{
    [SerializeField]
    List<GameObject> teamRoomOnlyGameObjects = new List<GameObject>();
    [SerializeField]
    List<GameObject> localOnlyGameObjects = new List<GameObject>();

    [SyncVar]
    public int number = 100;

    void AdjustPositions() {
        if (isLocalPlayer) return;

        
    }

    void Update() {
        if (!isLocalPlayer) return;

        if (Input.GetMouseButtonDown(0)) {
            CmdTallyMe();
        }
    }

    [Command]
    public void CmdTallyMe() {
        number += 1;
    }

    public override void OnStartLocalPlayer()
    {
        foreach(GameObject o in localOnlyGameObjects) {
            o.SetActive(true);
        }
    }

    public override void OnClientEnterRoom()
    {
        /* this can't stay here */
        foreach(GameObject o in teamRoomOnlyGameObjects) {
            o.SetActive(true);
        }
    }

    public override void OnClientExitRoom()
    {
        /* This can't stay here. */
        foreach(GameObject o in teamRoomOnlyGameObjects) {
            o.SetActive(false);
        }
        foreach(GameObject o in localOnlyGameObjects) {
            o.SetActive(false);
        }
    }

    public void ReadyUp() {
        CmdChangeReadyState(true);
    }
}
