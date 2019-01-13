using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Bewegung
{
    public enum FARBEN {rot, gruen, gelb, blau, nichts};
    Spielstein.MOVEDIRECTION direction;
    FARBEN farbe;
    GameObject figur;

    public Bewegung(Spielstein.MOVEDIRECTION d, FARBEN c){
        direction = d;
        farbe = c;
    }

    public GameObject getFigur(){
        return figur;
    }
    public Spielstein.MOVEDIRECTION getDirection(){
        return direction;
    }
}
