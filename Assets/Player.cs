using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int points;
    public string name;
    // Start is called before the first frame update
    public Player(int points, string name){
        this.points = points;
        this.name = name;
    }

    public void addPoints(int points){
        this.points += points;
    }
}
