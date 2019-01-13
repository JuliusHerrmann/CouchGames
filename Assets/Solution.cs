using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Solution
{
    public List<Bewegung> moves = new List<Bewegung>();
    public Player player;
    public int secondsLeftWhenSubmitted = 0;

    public Solution(List<Bewegung> moves, Player player){
        this.moves = moves;
        this.player = player;
    }
}
