using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Player
{
    public int points;
    public Guid UUid;
    public string name;
    // Start is called before the first frame update
    public Player(int points, string name){
        this.points = points;
        this.name = name;
        UUid = Guid.NewGuid();
    }

    public void addPoints(int points){
        this.points += points;
    }
}
