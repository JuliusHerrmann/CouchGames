using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Solution
{
    public List<Bewegung> moves = new List<Bewegung>();
    public Guid playerId;
    public Solution(List<Bewegung> moves, Guid playerId){
        this.moves = moves;
        this.playerId = playerId;
    }
}
