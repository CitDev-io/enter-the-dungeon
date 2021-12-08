using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TeamRoomManager : MonoBehaviour
{
    [SerializeField]
    List<Locker> lockers;

    List<NetworkRoomPlayer> GetCrew() {
        return NetManager.instance.roomSlots;
    }

    public void OnTeamChange() {
        AssignTeamToLockers();
    }

    void AssignTeamToLockers() {
        var crew = GetCrew();

        ClearLockers();
        foreach(NetworkRoomPlayer cm in crew) {
            if (cm.isLocalPlayer) {
                lockers[0].Assign((MyRoomPlayer)cm);
            } else {
                Locker l = GetOpenRemoteLocker();
                l.Assign((MyRoomPlayer) cm);
            }
        }
    }

    void ClearLockers() {
        foreach(Locker l in lockers) {
            l.Empty();
        }
    }

    Locker GetOpenRemoteLocker() {
        for (var i=1; i < lockers.Count; i++) {
            if (!lockers[i].isOccupied()) {
                return lockers[i];
            }
        }
        return null;
    }
}
