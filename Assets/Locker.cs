using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Locker : MonoBehaviour
{
    [SerializeField]
    MyRoomPlayer RoomPlayer;

    [SerializeField]
    GameObject Avatar;

    [SerializeField]
    TextMeshProUGUI Nameplate;

    [SerializeField]
    TextMeshProUGUI Status;

    void FixedUpdate() {
        if (!RoomPlayer) return;

        Nameplate.text = RoomPlayer.gameObject.name;
        Status.text = RoomPlayer.readyToBegin ? "READY":"";
    }

    public bool isOccupied() {
        return RoomPlayer != null;
    }

    public void Empty(){
        RoomPlayer = null;
    }

    public void Assign(MyRoomPlayer player) {
        RoomPlayer = player;
    }
}
