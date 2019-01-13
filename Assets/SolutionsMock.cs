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
        bew.Add(new Bewegung("o", 2));
        bew.Add(new Bewegung("o", 3));
        bew.Add(new Bewegung("r", 2));
        bew.Add(new Bewegung("o", 2));
        bew.Add(new Bewegung("l", 2));
        bew.Add(new Bewegung("o", 2));
        bew.Add(new Bewegung("r", 2));
        bew.Add(new Bewegung("u", 2));
        bew.Add(new Bewegung("r", 2));
        Solution s1 = new Solution(bew, players[0]);
        referenz.GetComponent<GameController>().solutionSubmitted(s1);
        yield return new WaitForSeconds(3);
        List<Bewegung> bew2 = new List<Bewegung>(); 
        bew2.Add(new Bewegung("l", 2));
        bew2.Add(new Bewegung("r", 3));
        bew2.Add(new Bewegung("u", 2));
        bew2.Add(new Bewegung("r", 2));
        bew2.Add(new Bewegung("o", 2));
        Solution s2 = new Solution(bew2, players[1]);
        referenz.GetComponent<GameController>().solutionSubmitted(s2);
    }
}
