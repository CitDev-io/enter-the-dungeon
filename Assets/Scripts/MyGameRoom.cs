using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyGameRoom : MonoBehaviour
{
    void Start() {
        NetManager.instance.Chirp();
        // Can i get to a server only method from here?
        // set up context, enter the first phase
        // nudge the actors, they're on!
        
        // this really should be spawned by the server at the beginning
        // because it should be a networked object
        
    }

}
