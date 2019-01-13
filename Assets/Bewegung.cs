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
        switch (farbe)
        {
            case FARBEN.blau:
                figur = GameObject.Find("Blau");
                break;
            case FARBEN.rot:
                figur = GameObject.Find("Rot");
                break;
            case FARBEN.gelb:
                figur = GameObject.Find("Gelb");
                break;
            case FARBEN.gruen:
                figur = GameObject.Find("Gruen");
                break;
        }
    }

    public GameObject getFigur(){
        return figur;
    }
    public Spielstein.MOVEDIRECTION getDirection(){
        return direction;
    }
}
