using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class dltme : MonoBehaviour
{
    public void Click() {
        Debug.Log(NetworkServer.active);
    }
}
