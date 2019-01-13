using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Solution> solutionsForRound = new List<Solution>();
    public GameObject speicher;
    public GameObject timer, figurenController;
    public int seconds = 60;

    public void Start(){
        //speicher = GameObject.Find("PlayerListObject");
    }

    public void solutionSubmitted(Solution s){
        if(solutionsForRound.Count == 0){
            startTimer();
        }
        solutionsForRound.Add(s);
        if(solutionsForRound.Count == speicher.GetComponent<PlayerList>().allePlayer.Count){
            seconds = 1;
        }
    }
    

    public void startNewRound(){
        //Send Id um zu starten
        //playerList.GetComponent<PlayerList>().gameId;
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void startTimer()
    {
        StartCoroutine(start());
    }

    
    IEnumerator start()
    {
        while (seconds > 0)
        {
            timer.GetComponent<TextMeshProUGUI>().text = seconds.ToString();
            seconds--;
            yield return new WaitForSeconds(1);
        }
        // Lösungsvorgang starten wenn der Timer abgelaufen ist.
        figurenController.GetComponent<figurenController>().startMoves();
    }
}
