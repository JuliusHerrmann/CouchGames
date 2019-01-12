using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerList : MonoBehaviour
{
    public List<Player> allePlayer = new List<Player>();
    public int gameId;
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
