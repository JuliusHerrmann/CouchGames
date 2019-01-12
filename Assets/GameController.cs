using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Solution> solutionsForRound = new List<Solution>();
    public GameObject speicher;

    public void Start(){
        //speicher = GameObject.Find("PlayerListObject");
    }

    public void solutionSubmitted(Solution s){
        if(solutionsForRound.Count == 0){
            startTimer();
        }
        solutionsForRound.Add(s);
        if(solutionsForRound.Count == speicher.GetComponent<PlayerList>().allePlayer.Count){
            timer.GetComponent<PlayerController>().seconds = 1;
        }
    }
    public GameObject timer, figurenController;
    // Start is called before the first frame update
    void startTimer()
    {
        timer.GetComponent<PlayerController>().startTimer();
    }

    public void startNewRound(){
        //Send Id um zu starten
        //playerList.GetComponent<PlayerList>().gameId;
    }
    // Update is called once per frame
    void Update()
    {
        if(timer.GetComponent<PlayerController>().timeUp){
            figurenController.GetComponent<figurenController>().startMoves();
            timer.GetComponent<PlayerController>().timeUp = false;
        }
    }
}
