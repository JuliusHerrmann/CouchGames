using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Player
{
    public int points = 0;
    public Guid UUid;
    public string name;
    public bool guidVorhanden = false;
    // Start is called before the first frame update
    public Player(string name, bool erstelleGuid, Guid id){
        //this.points = points;
        this.name = name;
        if (erstelleGuid)
        {
            UUid = Guid.NewGuid();
        }
        else
        {
            UUid = id;
        }
    }

    public void addPoints(int points){
        this.points += points;
    }
}
