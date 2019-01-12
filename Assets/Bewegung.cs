using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Bewegung
{
    public enum FARBEN {rot, gruen, gelb, blau};
    Spielstein.MOVEDIRECTION direction;
    int farbe;
    GameObject figur;

    public Bewegung(string s, int farbe){
        if(s.Equals("o")){
            direction= Spielstein.MOVEDIRECTION.top;
        }
        else if(s.Equals("u")){
            direction= Spielstein.MOVEDIRECTION.down;
        }
        else if(s.Equals("l")){
            direction= Spielstein.MOVEDIRECTION.left;
        }
        else if(s.Equals("r")){
            direction= Spielstein.MOVEDIRECTION.right;
        }

        if(farbe == 0){
            figur = GameObject.Find("Rot");
        } else if(farbe == 1){
            figur = GameObject.Find("Gruen");
        }else if(farbe == 2){
            figur = GameObject.Find("Gelb");
        }else if(farbe == 3){
            figur = GameObject.Find("Blau");
        }
    }

    public GameObject getFigur(){
        return figur;
    }
    public Spielstein.MOVEDIRECTION getDirection(){
        return direction;
    }
}
