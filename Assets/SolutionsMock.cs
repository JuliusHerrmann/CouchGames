using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SolutionsMock : MonoBehaviour
{
    public GameObject referenz, refPlayerList;
    void Start()
    {
        StartCoroutine(mock());
    }

    IEnumerator mock(){
        yield return new WaitForSeconds(3);

        List<Player> players = refPlayerList.GetComponent<PlayerList>().allePlayer;
        List<Bewegung> bew = new List<Bewegung>(); 
        bew.Add(new Bewegung(Spielstein.MOVEDIRECTION.top, Bewegung.FARBEN.gelb));
        bew.Add(new Bewegung(Spielstein.MOVEDIRECTION.top, Bewegung.FARBEN.rot));
        bew.Add(new Bewegung(Spielstein.MOVEDIRECTION.left, Bewegung.FARBEN.gelb));
        bew.Add(new Bewegung(Spielstein.MOVEDIRECTION.top, Bewegung.FARBEN.gelb));
        bew.Add(new Bewegung(Spielstein.MOVEDIRECTION.down, Bewegung.FARBEN.gelb));
        bew.Add(new Bewegung(Spielstein.MOVEDIRECTION.top, Bewegung.FARBEN.gelb));
        bew.Add(new Bewegung(Spielstein.MOVEDIRECTION.left, Bewegung.FARBEN.gelb));
        bew.Add(new Bewegung(Spielstein.MOVEDIRECTION.top, Bewegung.FARBEN.gruen));
        bew.Add(new Bewegung(Spielstein.MOVEDIRECTION.top, Bewegung.FARBEN.gelb));
        Solution s1 = new Solution(bew, players[0]);
        referenz.GetComponent<GameController>().solutionSubmitted(s1);
        yield return new WaitForSeconds(3);
        List<Bewegung> bew2 = new List<Bewegung>(); 
        bew2.Add(new Bewegung(Spielstein.MOVEDIRECTION.top, Bewegung.FARBEN.blau));
        bew2.Add(new Bewegung(Spielstein.MOVEDIRECTION.down, Bewegung.FARBEN.blau));
        bew2.Add(new Bewegung(Spielstein.MOVEDIRECTION.top, Bewegung.FARBEN.gelb));
        bew2.Add(new Bewegung(Spielstein.MOVEDIRECTION.left, Bewegung.FARBEN.gelb));
        bew2.Add(new Bewegung(Spielstein.MOVEDIRECTION.top, Bewegung.FARBEN.gelb));
        Solution s2 = new Solution(bew2, players[1]);
        referenz.GetComponent<GameController>().solutionSubmitted(s2);
    }
}
