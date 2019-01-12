using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class figurenController : MonoBehaviour
{
    public GameObject fRot, fGruen, fBlau, fGelb;
    List<Bewegung> alleBewegungen = new List<Bewegung>();
    string bewegungen;
    // Start is called before the first frame update
    public void Start()
    {
        Bewegung b = new Bewegung("r", 3);
        alleBewegungen.Add(b);
        b = new Bewegung("o", 3);
        alleBewegungen.Add(b);
        b = new Bewegung("l", 3);
        alleBewegungen.Add(b);
         b = new Bewegung("r", 1);
        alleBewegungen.Add(b);
        b = new Bewegung("u", 3);
        alleBewegungen.Add(b);
         b = new Bewegung("r", 3);
        alleBewegungen.Add(b);
    }

    int step = 0;
    void Update(){
        if(step < alleBewegungen.Count){
            if(!fRot.GetComponent<Spielstein>().moving && !fGruen.GetComponent<Spielstein>().moving && !fBlau.GetComponent<Spielstein>().moving && !fGelb.GetComponent<Spielstein>().moving)
            {
                bewegungAusfuehren(alleBewegungen[step]);
                step ++;
            }
        }
    }

    public void bewegungAusfuehren(Bewegung b){
        Spielstein s = b.getFigur().GetComponent<Spielstein>();
        s.move(b.getDirection());
    }
}
