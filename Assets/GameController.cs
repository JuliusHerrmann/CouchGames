﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private const int MAX_SECONDS_TIMER = 60;

    public List<Solution> solutionsForRound = new List<Solution>();
    public GameObject speicher;
    public GameObject timer, figurenController;
    public int seconds = MAX_SECONDS_TIMER;

    private bool solvingSolutions = false;
    private int solutionNumber = 1;
    public void Start()
    {
        //speicher = GameObject.Find("PlayerListObject");
    }

    /// <summary>
    /// Wird aufgerufen, wenn ein player eine solution abgeschickt hat.
    /// </summary>
    /// <param name="solution"></param>
    public void solutionSubmitted(Solution solution)
    {
        if(solutionsForRound.Count == 0){
            startTimer();
        }
        solutionsForRound.Add(solution);
        if(solutionsForRound.Count == speicher.GetComponent<PlayerList>().allePlayer.Count){
            seconds = 1;
        }
    }
    

    public void startNewRound()
    {
        //Send Id um zu starten
        //playerList.GetComponent<PlayerList>().gameId;
        seconds = MAX_SECONDS_TIMER;
    }

    // Update is called once per frame
    void Update()
    {
        if (solvingSolutions)
        {
            figurenController figController = figurenController.GetComponent<figurenController>();
            if (!figController.solutionInProgress && solutionNumber <= solutionsForRound.Count)
            {
                Solution solution = solutionsForRound[solutionNumber - 1];
                bool isLastSolutionOfRound = solutionNumber == solutionsForRound.Count;
                solutionNumber++;
                figController.setSolution(solution);
                figController.startMoves(isLastSolutionOfRound);
            }
            // überprüfen, ob die letzte solution der Runde fertig durchlaufen wurde
            else if (!figController.solutionInProgress && solutionNumber > solutionsForRound.Count)
            {
                solvingSolutions = false;

                // Solutions bewerten und sortieren
                evaluateSolutions();

                // punkte der runde zu den einzelnen Spielern hinzufügen
                //TODO

                // nächste Runde starten
                startNewRound();
            }
            
        }
        
    }

    public void startTimer()
    {
        StartCoroutine(start());
    }

    private void startSolutionSolving()
    {
        solvingSolutions = true;
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
        startSolutionSolving();
    }

    /// <summary>
    /// bewertet alle solutions und sortiert sie danach, ob sie korrekt waren und welche solution
    /// </summary>
    private void evaluateSolutions()
    {
        //TODO
    }
}
