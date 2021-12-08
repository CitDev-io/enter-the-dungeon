using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetManager : NetworkRoomManager
{
    public static NetManager instance { get; protected set; }
    public GameObject GameRoomManagerPrefab;
    public override void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            throw new System.Exception("An instance of this singleton already exists.");
        }
        else
        {
            instance = (NetManager)this;
        }
        base.Awake();
    }

    public void Chirp() {
        Debug.Log("You are looking at the RoomManager, ref.");
    }

    /// <summary>
    /// Called just after GamePlayer object is instantiated and just before it replaces RoomPlayer object.
    /// This is the ideal point to pass any data like player name, credentials, tokens, colors, etc.
    /// into the GamePlayer object as it is about to enter the Online scene.
    /// </summary>
    /// <param name="roomPlayer"></param>
    /// <param name="gamePlayer"></param>
    /// <returns>true unless some code in here decides it needs to abort the replacement</returns>
    public override bool OnRoomServerSceneLoadedForPlayer(NetworkConnection conn, GameObject roomPlayer, GameObject gamePlayer)
    {
        // Transferring knowledge about myself that i would want from the lobby (prefs)
        // Don't rely on vulnerable data here. That's why we have a Game Room server-state.

        return true;
    }

    public override void OnRoomClientEnter() {
        GameObject.FindObjectOfType<TeamRoomManager>()?.GetComponent<TeamRoomManager>()?.OnTeamChange();
    }

    public override void OnRoomClientExit() {
        GameObject.FindObjectOfType<TeamRoomManager>()?.GetComponent<TeamRoomManager>()?.OnTeamChange();
    }

    // SERVER ONLY
    public override void OnRoomServerSceneChanged(string sceneName) {
        Debug.Log(sceneName);
        if (sceneName == "Assets/Scenes/GameRoom.unity") {
            GameObject manager = Instantiate(GameRoomManagerPrefab);
            // pass off whatever the manager will need to proceed in isolation until the match concludes

            NetworkServer.Spawn(manager);
        }
    }
}
