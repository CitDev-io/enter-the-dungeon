using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyRoomPlayer : NetworkRoomPlayer
{
    public List<GameObject> localOnlyGameObjects = new List<GameObject>();

    public override void OnStartLocalPlayer()
    {
        showUI();
    }

    void showUI() {
        if (isLocalPlayer) {
            foreach(GameObject o in localOnlyGameObjects) {
                o.SetActive(true);
            }
        }
    }

    void hideUI() {
            foreach(GameObject o in localOnlyGameObjects) {
                o.SetActive(false);
            }
    }

    public override void OnClientEnterRoom()
    {
       showUI();
    }

    public override void OnClientExitRoom()
    {
        hideUI();
    }

    public void ToggleReady() {
        CmdChangeReadyState(!readyToBegin);
    }
}
