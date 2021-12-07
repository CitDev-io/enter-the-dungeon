using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TeamRoomManager : MonoBehaviour
{
    List<NetworkRoomPlayer> GetCrew() {
        return NetManager.instance.roomSlots;
    }

    public void OnTeamChange() {
        var crew = GetCrew();
        foreach(NetworkRoomPlayer cm in crew) {
            AssignLocker((MyRoomPlayer) cm);
        }
    }

    void AssignLocker(MyRoomPlayer roomPlayer) {
        Debug.Log("Find a locker for this fella with "+ roomPlayer.number);
    }
}
